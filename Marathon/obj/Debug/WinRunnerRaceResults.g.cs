﻿#pragma checksum "..\..\WinRunnerRaceResults.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0929D6B7713EC90C77D3EB50DB03C5AB7E769EA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
    /// WinRunnerRaceResults
    /// </summary>
    public partial class WinRunnerRaceResults : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 102 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTime;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogout;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblGender;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblAge;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAllResults;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\WinRunnerRaceResults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListResults;
        
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
            System.Uri resourceLocater = new System.Uri("/Marathon;component/winrunnerraceresults.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinRunnerRaceResults.xaml"
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
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\WinRunnerRaceResults.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LblTime = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.BtnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\WinRunnerRaceResults.xaml"
            this.BtnLogout.Click += new System.Windows.RoutedEventHandler(this.BtnLogout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LblGender = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.LblAge = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.BtnAllResults = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\WinRunnerRaceResults.xaml"
            this.BtnAllResults.Click += new System.Windows.RoutedEventHandler(this.BtnAllResults_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ListResults = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

