﻿#pragma checksum "..\..\WinSelectRoleDebug.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FEA080C15F102D3D77E90B9927E9FDE3F1162768"
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
    /// WinSelectRoleDebug
    /// </summary>
    public partial class WinSelectRoleDebug : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\WinSelectRoleDebug.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRunner;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\WinSelectRoleDebug.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAsCoord;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\WinSelectRoleDebug.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAsAdmin;
        
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
            System.Uri resourceLocater = new System.Uri("/Marathon;component/winselectroledebug.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinSelectRoleDebug.xaml"
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
            this.BtnRunner = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\WinSelectRoleDebug.xaml"
            this.BtnRunner.Click += new System.Windows.RoutedEventHandler(this.BtnRunner_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnAsCoord = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\WinSelectRoleDebug.xaml"
            this.BtnAsCoord.Click += new System.Windows.RoutedEventHandler(this.BtnAsCoord_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnAsAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\WinSelectRoleDebug.xaml"
            this.BtnAsAdmin.Click += new System.Windows.RoutedEventHandler(this.BtnAsAdmin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

