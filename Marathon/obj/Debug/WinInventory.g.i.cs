﻿#pragma checksum "..\..\WinInventory.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93044AD72630137E24BCFDE93A314142293A5CC6"
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
    /// WinInventory
    /// </summary>
    public partial class WinInventory : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 98 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTime;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogout;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblRunnersCount;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TypesCount;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListComposition;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReport;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\WinInventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnArrival;
        
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
            System.Uri resourceLocater = new System.Uri("/Marathon;component/wininventory.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinInventory.xaml"
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
            
            #line 98 "..\..\WinInventory.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LblTime = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.BtnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\WinInventory.xaml"
            this.BtnLogout.Click += new System.Windows.RoutedEventHandler(this.BtnLogout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LblRunnersCount = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TypesCount = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.ListComposition = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.BtnReport = ((System.Windows.Controls.Button)(target));
            
            #line 204 "..\..\WinInventory.xaml"
            this.BtnReport.Click += new System.Windows.RoutedEventHandler(this.BtnReport_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnArrival = ((System.Windows.Controls.Button)(target));
            
            #line 205 "..\..\WinInventory.xaml"
            this.BtnArrival.Click += new System.Windows.RoutedEventHandler(this.BtnArrival_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

