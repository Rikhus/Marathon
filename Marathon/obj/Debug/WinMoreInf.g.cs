﻿#pragma checksum "..\..\WinMoreInf.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "562E2EBABF872ACC82C335F667DB093ADE7D53E4"
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
    /// WinMoreInf
    /// </summary>
    public partial class WinMoreInf : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMarathon;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrevRes;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBMI;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnHowLongMar;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCharityInf;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBMR;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\WinMoreInf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTime;
        
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
            System.Uri resourceLocater = new System.Uri("/Marathon;component/winmoreinf.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinMoreInf.xaml"
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
            
            #line 36 "..\..\WinMoreInf.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnMarathon = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\WinMoreInf.xaml"
            this.BtnMarathon.Click += new System.Windows.RoutedEventHandler(this.BtnMarathon_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnPrevRes = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\WinMoreInf.xaml"
            this.BtnPrevRes.Click += new System.Windows.RoutedEventHandler(this.BtnPrevRes_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnBMI = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.BtnHowLongMar = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.BtnCharityInf = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.BtnBMR = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.LblTime = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

