﻿

#pragma checksum "C:\Users\Matt\Downloads\Speech Rec\C#\VoiceTranslatorAppCS\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "86BBF1C77D916AA8459A3DAEA2FA4E1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VoiceTranslatorAppCS
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Speech.Xaml.SpeechRecognizerUx SpeechControl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Speech.Xaml.SpeechRecognizerUx SpeechControlEN; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Speech.Xaml.SpeechRecognizerUx SpeechControlES; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Speech.Xaml.SpeechRecognizerUx SpeechControlDE; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Speech.Xaml.SpeechRecognizerUx SpeechControlFR; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.CaptureElement capturePreview; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton SpeakButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox VoiceList; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.CheckBox ShowAlternatesBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock AlternatesText; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox AlternatesList; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock ErrorBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Translator.TranslatorControl Trans; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.MediaElement TTS; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox FromList; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TranslatedText; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///MainPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            SpeechControl = (global::Bing.Speech.Xaml.SpeechRecognizerUx)this.FindName("SpeechControl");
            SpeechControlEN = (global::Bing.Speech.Xaml.SpeechRecognizerUx)this.FindName("SpeechControlEN");
            SpeechControlES = (global::Bing.Speech.Xaml.SpeechRecognizerUx)this.FindName("SpeechControlES");
            SpeechControlDE = (global::Bing.Speech.Xaml.SpeechRecognizerUx)this.FindName("SpeechControlDE");
            SpeechControlFR = (global::Bing.Speech.Xaml.SpeechRecognizerUx)this.FindName("SpeechControlFR");
            capturePreview = (global::Windows.UI.Xaml.Controls.CaptureElement)this.FindName("capturePreview");
            SpeakButton = (global::Windows.UI.Xaml.Controls.AppBarButton)this.FindName("SpeakButton");
            VoiceList = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("VoiceList");
            ShowAlternatesBox = (global::Windows.UI.Xaml.Controls.CheckBox)this.FindName("ShowAlternatesBox");
            AlternatesText = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("AlternatesText");
            AlternatesList = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("AlternatesList");
            ErrorBox = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("ErrorBox");
            Trans = (global::Bing.Translator.TranslatorControl)this.FindName("Trans");
            TTS = (global::Windows.UI.Xaml.Controls.MediaElement)this.FindName("TTS");
            FromList = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("FromList");
            TranslatedText = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TranslatedText");
        }
    }
}



