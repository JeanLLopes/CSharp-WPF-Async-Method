﻿#pragma checksum "..\..\Programa_AssincronoCancelaProgresso.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "331F69EB13C3313FB6E3391B89D1D7E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace ProjetoAsync.Windows.WPF {
    
    
    /// <summary>
    /// Programa_AssincronoCancelaProgresso
    /// </summary>
    public partial class Programa_AssincronoCancelaProgresso : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Programa_AssincronoCancelaProgresso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxValor;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Programa_AssincronoCancelaProgresso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonResultado;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Programa_AssincronoCancelaProgresso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelResultado;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Programa_AssincronoCancelaProgresso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxResultado;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Programa_AssincronoCancelaProgresso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancelar;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Programa_AssincronoCancelaProgresso.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBarResultado;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjetoAsync.Windows.WPF;component/programa_assincronocancelaprogresso.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Programa_AssincronoCancelaProgresso.xaml"
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
            this.TextBoxValor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ButtonResultado = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\Programa_AssincronoCancelaProgresso.xaml"
            this.ButtonResultado.Click += new System.Windows.RoutedEventHandler(this.ButtonResultado_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LabelResultado = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.ListBoxResultado = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.ButtonCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Programa_AssincronoCancelaProgresso.xaml"
            this.ButtonCancelar.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ProgressBarResultado = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
