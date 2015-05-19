﻿//Copyright (c) 2012 Microsoft Corporation.  All rights reserved. 
//    Use of this sample source code is subject to the terms of the Microsoft license  
//    agreement under which you licensed this sample source code and is provided AS-IS. 
//    If you did not accept the terms of the license agreement, you are not authorized  
//    to use this sample source code.  For the terms of the license, please see the  
//    license agreement between you and Microsoft. 
 
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Bing.Speech;
using Windows.Media.SpeechSynthesis;
using Windows.Media.Capture;
using Windows.Graphics.Display;
using Bing.Translator;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO; 
using System.Diagnostics;
namespace VoiceTranslatorAppCS
{
    public sealed partial class MainPage : Page
    {
        private SpeechRecognizer[] recognizers = new SpeechRecognizer[4];
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;

        }
        SpeechRecognizer SR;
        MediaCaptureInitializationSettings _captureInitSettings;
        List<Windows.Devices.Enumeration.DeviceInformation> _deviceList;
        Windows.Media.Capture.MediaCapture _mediaCapture;
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            /* Before running this app, you must obtain ClientID and ClientSecret values
             * for the Speech and Translator controls from the Windows Azure Data Marketplace.
             * Speech: https://datamarket.azure.com/dataset/bing/speechcontrol
             * Translator: https://datamarket.azure.com/dataset/bing/microsofttranslator
             * For more information, see http://msdn.microsoft.com/en-us/library/dn434606.aspx
             * and http://msdn.microsoft.com/en-us/library/dn261775.aspx */

            // Initialize the SpeechRecognizer.
            var speechCreds = new SpeechAuthorizationParameters();
            //speechCreds.ClientId = "YOUR SPEECH CLIENT ID HERE";
            //speechCreds.ClientSecret = "YOUR SPEECH CLIENT SECRET HERE";

            speechCreds.ClientId = "Speech-Control-Test-AppId";
            speechCreds.ClientSecret = "0QKTzXhzygSMQHHLFvlyIQb9vZ/IR5gWWiTcrFv5Vkc=";
            
            SR = new SpeechRecognizer("en-US", speechCreds);
            recognizers[0] = new SpeechRecognizer("en-US", speechCreds);
            recognizers[1] = new SpeechRecognizer("es-ES", speechCreds);
            recognizers[2] = new SpeechRecognizer("de-DE", speechCreds);
            recognizers[3] = new SpeechRecognizer("fr-FR", speechCreds);
            // Bind it to the UX control.
            SpeechControl.SpeechRecognizer = SR;
            SpeechControlEN.SpeechRecognizer = recognizers[0];
            SpeechControlES.SpeechRecognizer = recognizers[1];
            SpeechControlDE.SpeechRecognizer = recognizers[2];
            SpeechControlFR.SpeechRecognizer = recognizers[3];

            // Supply credentials for the Translator Control.
            //Trans.ClientId = "YOUR TRANSLATOR CLIENT ID HERE";
            //Trans.ClientSecret = "YOUR TRANSLATOR CLIENT SECRET HERE";

            Trans.ClientId = "LeithTranslatorTestApp0987";
            Trans.ClientSecret = "6ZRjAVL9a6EttX+FcqDOazD11DEeGwmZSWfpbt4No/M=";
            
            PopulateLanguages();
            EnumerateCameras();
            
        }

        #region WebcamCode
        private async void EnumerateCameras()
        {
            var devices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(
                Windows.Devices.Enumeration.DeviceClass.VideoCapture);
            _deviceList = new List<Windows.Devices.Enumeration.DeviceInformation>();

            // Add the devices to deviceList
            if (devices.Count > 0)
            {

                for (var i = 0; i < devices.Count; i++)
                {
                    _deviceList.Add(devices[i]);
                }

                InitCaptureSettings();
                InitMediaCapture();

            }
        }


        private void InitCaptureSettings()
        {
            _captureInitSettings = null;
            _captureInitSettings = new Windows.Media.Capture.MediaCaptureInitializationSettings();
            _captureInitSettings.AudioDeviceId = "";
            _captureInitSettings.VideoDeviceId = "";
            _captureInitSettings.StreamingCaptureMode = Windows.Media.Capture.StreamingCaptureMode.Video;
            _captureInitSettings.PhotoCaptureSource = Windows.Media.Capture.PhotoCaptureSource.VideoPreview;

            if (_deviceList.Count > 0)
                _captureInitSettings.VideoDeviceId = _deviceList[0].Id;
        }

        // Create and initialze the MediaCapture object.
        public async void InitMediaCapture()
        {
            _mediaCapture = null;
            _mediaCapture = new Windows.Media.Capture.MediaCapture();

            // Set the MediaCapture to a variable in MainPage.xaml.cs to handle suspension.

            await _mediaCapture.InitializeAsync(_captureInitSettings);
            capturePreview.Source = _mediaCapture;
            await _mediaCapture.StartPreviewAsync();
        }

        #endregion

        private async void PopulateLanguages()
        {
            // Get the lists of available languages for the Translator control. 
            GetLanguagesResult transLangs = await Trans.TranslatorApi.GetLanguagesAsync();
            // Handle any failed service calls. 
            if (transLangs.Languages.Count < 1)
            {
                ErrorBox.Text = "Failed to retrieve languages. Restart and try again.";
                return;
            }
            
            // Get the available voices.
            var allVoices = SpeechSynthesizer.AllVoices;
            string[] voices = new string[allVoices.Count];
            string[] languages = new string[allVoices.Count];
            for (int i = 0; i < allVoices.Count; i++)
            {
                foreach (var transLang in transLangs.Languages)
                {
                    // Verify each voice is supported by Translator before including it in the list.
                    if (transLang.Substring(0, 2).ToLower() == allVoices[i].Language.Substring(0, 2).ToLower())
                    {
                        languages[i] = transLang.Substring(0, 2).ToLower();
                        voices[i] = allVoices[i].Description;
                    }
                }
            }
            List<string> languagesPruned = languages.ToList();
            languagesPruned = languagesPruned.Distinct().ToList();
            VoiceList.ItemsSource = voices;
            VoiceList.SelectedItem = voices[0];
            FromList.ItemsSource = languagesPruned;
            FromList.SelectedItem = languagesPruned[0];
        }

        private async void SpeakButton_Click(object sender, RoutedEventArgs e)
        {
            this.ErrorBox.Text = "";
            try
            {
                SpeechRecognitionResult result = null;
                switch (FromList.SelectedItem.ToString())
                {
                    case "en":
                        result = await recognizers[0].RecognizeSpeechToTextAsync();
                        break;
                    case "es":
                        result = await recognizers[1].RecognizeSpeechToTextAsync();
                        break;
                    case "de":
                        result = await recognizers[2].RecognizeSpeechToTextAsync();
                        break;
                    case "fr":
                        result = await recognizers[3].RecognizeSpeechToTextAsync();
                        break;
                    default:
                        break;

                }
                //var result = await recognizers[FromList.SelectedIndex].RecognizeSpeechToTextAsync();
                //var result = await SR.RecognizeSpeechToTextAsync();
                var speechIn = result.Text;

                if (result.Text == null)
                {
                    speechIn = "I'm sorry, I didn't understand you.";
                }

                if (this.ShowAlternatesBox.IsChecked == true)
                {
                    var maxAlternates = 5;
                    ShowAlternates(result.GetAlternates(maxAlternates));
                }
                else
                {
                    TranslateAndSay(speechIn);
                }
            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }

        private async void TranslateAndSay(string speechIn)
        {
            // Catch empty results.
            if (speechIn == null) speechIn = "I'm sorry, I didn't understand you.";

            // Get the selected voice.
            var synth = new SpeechSynthesizer();
            var selectedVoice = VoiceList.SelectedItem.ToString();
            var voices = SpeechSynthesizer.AllVoices;
            foreach (var v in voices)
            {
                if (v.Description == selectedVoice)
                {
                    synth.Voice = v;
                    break;
                }
            }
            
            // Specify language only, in case an installed culture is not supported by Translator.
            var synthLang = synth.Voice.Language.Substring(0, 2);

            // Get the text translation.
            Trans.LanguageFrom = FromList.SelectedItem.ToString();
            var result = await Trans.TranslatorApi.TranslateAsync(Trans.LanguageFrom, synthLang, null, speechIn);

            TranslatedText.Text = result.TextTranslated;
            // Speak the translated text.
            //var stream = await synth.SynthesizeTextToStreamAsync(result.TextTranslated);
            //TTS.SetSource(stream, stream.ContentType);
        }

        private void ShowAlternates(IReadOnlyList<SpeechRecognitionResult> alternates)
        {
            switch (alternates.Count)
            {
                case 0:
                    TranslateAndSay("I'm sorry, I didn't understand you.");
                    break;
                case 1:
                    TranslateAndSay(alternates[0].Text);
                    break;
                default:
                    // Write the values to a string[] array.
                    string[] s = new string[alternates.Count];
                    for (int i = 0; i < alternates.Count; i++)
                    {
                        s[i] = alternates[i].Text;
                    }

                    // Populate the ComboBox.
                    this.AlternatesList.ItemsSource = s;
                    this.AlternatesList.PlaceholderText = s[0];
                    this.AlternatesText.Visibility = Visibility.Visible;
                    this.AlternatesList.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AlternatesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AlternatesText.Visibility = Visibility.Collapsed;
            this.AlternatesList.Visibility = Visibility.Collapsed;
            TranslateAndSay(AlternatesList.SelectedItem.ToString());
        }
    }
}
