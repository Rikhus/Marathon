﻿#pragma checksum "..\..\WinLogin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "12310ED0FFE1E5931B15BE032FE2E9A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Marathon;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Marathon {
    
    
    /// <summary>
    /// WinLogin
    /// </summary>
    public partial class WinLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSelRunner;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSelCoordinator;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSelAdmin;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Marathon;component/winlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinLogin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnSelRunner = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\WinLogin.xaml"
            this.BtnSelRunner.Click += new System.Windows.RoutedEventHandler(this.BtnSelRunner_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnSelCoordinator = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\WinLogin.xaml"
            this.BtnSelCoordinator.Click += new System.Windows.RoutedEventHandler(this.BtnSelCoordinator_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnSelAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\WinLogin.xaml"
            this.BtnSelAdmin.Click += new System.Windows.RoutedEventHandler(this.BtnSelAdmin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

