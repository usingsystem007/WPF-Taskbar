﻿#pragma checksum "..\..\ExampleTaskbarNotifier.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83CE89FAD12992E3EC56F439FF5A1C324EF46AAFF678A71785FB43F0C9098B67"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPFTaskbarNotifier;


namespace WPFTaskbarNotifierExample {
    
    
    /// <summary>
    /// ExampleTaskbarNotifier
    /// </summary>
    public partial class ExampleTaskbarNotifier : WPFTaskbarNotifier.TaskbarNotifier, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\ExampleTaskbarNotifier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPFTaskbarNotifierExample.ExampleTaskbarNotifier ThisControl;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\ExampleTaskbarNotifier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ItemsList;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\ExampleTaskbarNotifier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFTaskbarNotifierExample;component/exampletaskbarnotifier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ExampleTaskbarNotifier.xaml"
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
            this.ThisControl = ((WPFTaskbarNotifierExample.ExampleTaskbarNotifier)(target));
            return;
            case 2:
            
            #line 57 "..\..\ExampleTaskbarNotifier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HideButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ItemsList = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 4:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\ExampleTaskbarNotifier.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Show_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
