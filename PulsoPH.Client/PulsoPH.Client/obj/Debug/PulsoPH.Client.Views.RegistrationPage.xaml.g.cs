//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PulsoPH.Client.Views {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class RegistrationPage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::PulsoPH.Client.UserControls.CustomEntry fullName;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::PulsoPH.Client.UserControls.CustomEntry entryAddress;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::PulsoPH.Client.UserControls.CustomButton BtnRegister;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Grid gridIndicator;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Syncfusion.SfBusyIndicator.XForms.SfBusyIndicator busyindicator;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(RegistrationPage));
            fullName = this.FindByName<global::PulsoPH.Client.UserControls.CustomEntry>("fullName");
            entryAddress = this.FindByName<global::PulsoPH.Client.UserControls.CustomEntry>("entryAddress");
            BtnRegister = this.FindByName<global::PulsoPH.Client.UserControls.CustomButton>("BtnRegister");
            gridIndicator = this.FindByName<global::Xamarin.Forms.Grid>("gridIndicator");
            busyindicator = this.FindByName<global::Syncfusion.SfBusyIndicator.XForms.SfBusyIndicator>("busyindicator");
        }
    }
}