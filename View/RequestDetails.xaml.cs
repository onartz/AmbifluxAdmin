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

namespace AmbifluxAdmin.View
{
    /// <summary>
    /// Logique d'interaction pour RequestDetails.xaml
    /// </summary>
    public partial class RequestDetails : UserControl
    {
        private IDBItem dataItem;
        internal DataClassesDataContext database { get; private set; }
        private readonly CollectionViewSource LocationList;
        private readonly CollectionViewSource ProductCategoryList;

        private Action<bool> completeAction = null;
        private UIElement parentDetails;

        public RequestDetails()
        {
            InitializeComponent();
            LocationList = (CollectionViewSource)FindResource("LocationList");
            ProductCategoryList = (CollectionViewSource)FindResource("ProductCategoryList");

            Visibility = Visibility.Hidden;
        }
        public void ShowDialog(UIElement parent, ItemType type, IDBItem dataToEdit, Action<bool> completed)
        {

            database = new DataClassesDataContext();
            parentDetails = parent;
            completeAction = completed;

            SetupData(type, dataToEdit);
            parentDetails.IsEnabled = false;
            Visibility = Visibility.Visible;
        }


        private void SetupData(ItemType type, IDBItem dataToEdit)
        {
            if (dataToEdit == null)
            {
                dataItem = DB.AddNewItem(database, type);
            }
            else
            {
                dataItem = DB.GetExistingItem(database, dataToEdit);
            }

            BindDataToEditForm();
            LoadAssociatedLists();
        }

        private void BindDataToEditForm()
        {
            Binding binding = new Binding();
            binding.Source = dataItem;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            EditForm.SetBinding(DataContextProperty, binding);
        }

        private void LoadAssociatedLists()
        {
            if (dataItem is DemandeExpress)
            {
                //ProductCategoryList.Source = from s in database.ProductCategory select s;
                ProductCategoryList.Source = from l in database.ProductCategory select l;
            }

        }


        private void SaveDetails(object sender, RoutedEventArgs e)
        {
            if (dataItem is DemandeExpress)
            {
                (dataItem as DemandeExpress).DeliveryLocationID =(int)(dataItem as DemandeExpress).ProductCategory.DefaultLocationID;
            }
            database.SubmitChanges();
            CloseDialog(true);
        }

        private void CancelUpdate(object sender, RoutedEventArgs e)
        {

            //BookCatalog.CancelChanges();
            CloseDialog(false);
        }

        private void CloseDialog(bool result)
        {
            EditForm.ClearValue(DataContextProperty);
            database = null;

            Visibility = Visibility.Hidden;
            parentDetails.IsEnabled = true;

            if (completeAction != null)
            {
                completeAction.Invoke(result);
            }
        }
    }
}
