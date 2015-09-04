﻿#pragma checksum "..\..\..\..\View\ProductBrowser.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A084D1DF320245CD2089F09836E8BCA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.586
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// ProductBrowser
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ProductBrowser : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 108 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ModalDialogParent;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProductButton;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProductCategoryButton;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBarItem StatusText;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Listing;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\View\ProductBrowser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AmbifluxAdmin.View.ResourceDetails EditResourceDetailsDialog;
        
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
            System.Uri resourceLocater = new System.Uri("/AmbifluxClient;component/view/productbrowser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ProductBrowser.xaml"
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
            case 1:
            
            #line 13 "..\..\..\..\View\ProductBrowser.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanDeleteData);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\View\ProductBrowser.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteData);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\..\View\ProductBrowser.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanDeleteSoftData);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\View\ProductBrowser.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteSoftData);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ModalDialogParent = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.ProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\..\View\ProductBrowser.xaml"
            this.ProductButton.Click += new System.Windows.RoutedEventHandler(this.DisplayAllProducts);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ProductCategoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\..\View\ProductBrowser.xaml"
            this.ProductCategoryButton.Click += new System.Windows.RoutedEventHandler(this.DisplayAllProductCategories);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 122 "..\..\..\..\View\ProductBrowser.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddData);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StatusText = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 9:
            this.Listing = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.EditResourceDetailsDialog = ((AmbifluxAdmin.View.ResourceDetails)(target));
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
            case 3:
            
            #line 41 "..\..\..\..\View\ProductBrowser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditData);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
