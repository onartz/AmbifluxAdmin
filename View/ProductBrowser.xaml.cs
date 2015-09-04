using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AmbifluxAdmin.Model;
using System.Collections;

namespace AmbifluxAdmin.View
{
    /// <summary>
    /// Logique d'interaction pour ProductBrowser.xaml
    /// </summary>
    public partial class ProductBrowser : Page
    {
        private ItemType currentView;
        private string statusMessage = null;

        public ProductBrowser()
        {
            InitializeComponent();
            displayAllProducts();
        }

        

        private void OnUpdate(bool commitUpdate)
        {
            if (!commitUpdate)
            {
                statusMessage += "Update canceled";
            }

            switch (currentView)
            {
                //case ItemType.Equipment:
                //    displayAllEquipements();
                //    break;

                case ItemType.ProductCategory:
                    displayAllProductCategories();
                    break;

                case ItemType.Product:
                    displayAllProducts();
                    break;


                default:                  
                   displayAllProducts();
                    break;
            }

        }

        #region Product
        /// <summary>
        /// Selection des products a afficher
        /// </summary>
        private void displayAllProducts()
        {
             var products = from p in new DataClassesDataContext().Product
                            where p is Product
                       select p as Product;
            displayProducts(products);
            ProductButton.IsEnabled = false;
        }

        /// <summary>
        /// Affichage de la liste des Products
        /// </summary>
        /// <param name="products"></param>
        private void displayProducts(IEnumerable<Product> products)
        {
            currentView = ItemType.Product;
            displayList(from product in products orderby product.ProductNumber select product);
        }
        #endregion

        #region ProductCategory

        /// <summary>
        /// Selection des categories a afficher
        /// </summary>
        private void displayAllProductCategories()
        {
            var categories = from category in new DataClassesDataContext().ProductCategory
                             where category is ProductCategory
                             select category as ProductCategory;
            displayProductCategories(categories);
            ProductCategoryButton.IsEnabled = false;
        }

        /// <summary>
        /// Affichage de la liste des ProductCategoryCategories
        /// </summary>
        /// <param name="categories"></param>
        private void displayProductCategories(IEnumerable<ProductCategory> categories)
        {
            currentView = ItemType.ProductCategory;
            displayList(from category in categories orderby category.Name select category);
        }
        #endregion


        /// <summary>
        /// Affichage générique de liste
        /// </summary>
        /// <param name="dataToList"></param>
        private void displayList(IEnumerable dataToList)
        {
            ResetDisplay();
            Listing.DataContext = dataToList;
        }

        

        private void ResetDisplay()
        {
            //viewingBooksForAttribute = null;
            ProductButton.IsEnabled = true;
            ProductCategoryButton.IsEnabled = true;
           

            if (statusMessage == null)
            {
                if (currentView == ItemType.ProductCategory) { statusMessage = "Displaying Categories"; }
                if (currentView == ItemType.Product) { statusMessage = "Displaying Products"; }
               
            }

            StatusText.Content = statusMessage;
            statusMessage = null;
        }

        #region Evenements venant de l'IHM


        private void DisplayAllProducts(object sender, RoutedEventArgs e)
        {
            displayAllProducts();
        }

        /// <summary>
        /// Evt click sur Edit data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditData(object sender, RoutedEventArgs e)
        {
            var data = (sender as Button).CommandParameter as IDBItem;
            if (data == null) { return; }

            EditResourceDetailsDialog.ShowDialog(ModalDialogParent,currentView,data,OnUpdate);          
        }

        private void AddData(object sender, RoutedEventArgs e)
        {
            EditResourceDetailsDialog.ShowDialog(ModalDialogParent, currentView, null, OnUpdate);   
        }

        private void DisplayAllProductCategories(object sender, RoutedEventArgs e)
        {
            displayAllProductCategories();
        }


      
        #endregion

        public static RoutedCommand DeleteDataCommand = new RoutedCommand();

        private void CanDeleteData(object sender, CanExecuteRoutedEventArgs args)
        {
            var data = args.Parameter as IDBItem;
            if (data == null) { return; }

            args.CanExecute = data.CanDelete();
            args.ContinueRouting = false;
            args.Handled = true;
        }

        private void DeleteData(object sender, ExecutedRoutedEventArgs args)
        {
            var data = args.Parameter as IDBItem;
            if (data == null) { return; }

            DB.DeleteItem(data);
            OnUpdate(true);
        }



        public static RoutedCommand DeleteSoftDataCommand = new RoutedCommand();

        private void CanDeleteSoftData(object sender, CanExecuteRoutedEventArgs args)
        {
            var data = args.Parameter as IDBItem;
            if (data == null) { return; }

            args.CanExecute = data.CanDeleteSoft();
            args.ContinueRouting = false;
            args.Handled = true;
        }

        private void DeleteSoftData(object sender, ExecutedRoutedEventArgs args)
        {
            var data = args.Parameter as IDBItem;
            if (data == null) { return; }

            DB.DeleteSoftItem(data);
            OnUpdate(true);
        }

    



       

     
    }
}
