﻿#pragma checksum "..\..\..\..\View\OrderHeaderBrowser.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "57294D84DF927D4D237EA30D7C4BB06D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.2012
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using AmbifluxAdmin;
using AmbifluxAdmin.Model;
using AmbifluxAdmin.View;
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


namespace AmbifluxAdmin.View {
    
    
    /// <summary>
    /// OrderHeaderBrowser
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class OrderHeaderBrowser : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 105 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ModalDialogParent;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MyDemandeExpressButton;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MyEchangeButton;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBarItem StatusText;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Listing;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\View\OrderHeaderBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AmbifluxAdmin.View.OrderHeaderDetails ViewOrderDetailsDialog;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AmbifluxClient;component/view/orderheaderbrowser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\OrderHeaderBrowser.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            this.ModalDialogParent = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.MyDemandeExpressButton = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\..\View\OrderHeaderBrowser.xaml"
            this.MyDemandeExpressButton.Click += new System.Windows.RoutedEventHandler(this.DisplayDemandesExpressByUser);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MyEchangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\..\View\OrderHeaderBrowser.xaml"
            this.MyEchangeButton.Click += new System.Windows.RoutedEventHandler(this.DisplayEchangesByUser);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\..\View\OrderHeaderBrowser.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddData);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StatusText = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 7:
            this.Listing = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.ViewOrderDetailsDialog = ((AmbifluxAdmin.View.OrderHeaderDetails)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 39 "..\..\..\..\View\OrderHeaderBrowser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditData);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

