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
    /// Logique d'interaction pour ResourceDetails.xaml
    /// </summary>
    public partial class ResourceDetails : UserControl
    {
        private IDBItem dataItem;
        internal DataClassesDataContext database { get; private set; }
        private readonly CollectionViewSource LocationList;
        private readonly CollectionViewSource ContainerStatusList;
        private readonly CollectionViewSource LocationStatusList;
        private readonly CollectionViewSource LocationTypeList;
        private readonly CollectionViewSource ResourceStatusList;
        private readonly CollectionViewSource ProductStatusList;
        private readonly CollectionViewSource ProductCategoryList;

        private Action<bool> completeAction = null;
        private UIElement parentDetails;

        public ResourceDetails()
        {
            InitializeComponent();

            LocationList = (CollectionViewSource)FindResource("LocationList");
            LocationTypeList = (CollectionViewSource)FindResource("LocationTypeList");
            LocationStatusList = (CollectionViewSource)FindResource("LocationStatusList");

            ContainerStatusList = (CollectionViewSource)FindResource("ContainerStatusList");
            
            ResourceStatusList = (CollectionViewSource)FindResource("ResourceStatusList");

            ProductStatusList = (CollectionViewSource)FindResource("ProductStatusList");
            ProductCategoryList = (CollectionViewSource)FindResource("ProductCategoryList");

            Visibility = Visibility.Hidden;
        }

     
        public void ShowDialog( UIElement parent, ItemType type, IDBItem dataToEdit, Action<bool> completed ) {

            database= new DataClassesDataContext();
            parentDetails = parent;
            completeAction = completed;

            SetupData(type, dataToEdit );
            parentDetails.IsEnabled = false;
            Visibility = Visibility.Visible;
        }


        private void SetupData(ItemType type, IDBItem dataToEdit)
        {
            if (dataToEdit == null)
            {   
                dataItem = DB.AddNewItem(database,type);
            }
            else
            {
                dataItem = DB.GetExistingItem(database, dataToEdit);
            }
            LoadAssociatedLists();
            BindDataToEditForm();
            
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
            if (dataItem is Workstation)
            {
                ResourceStatusList.Source = from s in database.ResourceStatus select s; 
                LocationList.Source=from l in database.Location where l.LocationStatus.Value!="Deleted" select l;
            }
            if (dataItem is SRMA)
            {
                ResourceStatusList.Source = from s in database.ResourceStatus select s;
            }
            if (dataItem is Container)
            {
                ContainerStatusList.Source = from c in database.ContainerStatus select c;
            }
            if (dataItem is Location)
            {
                LocationStatusList.Source = from c in database.LocationStatus select c;
                LocationTypeList.Source = from c in database.LocationType select c;
            }
            if (dataItem is Product)
            {
                ProductStatusList.Source = from p in database.ProductStatus select p;
                ProductCategoryList.Source = from p in database.ProductCategory select p;
            }
            if (dataItem is ProductCategory)
            {
                LocationList.Source = from l in database.Location where l.LocationStatus.Value != "Deleted" select l;
            }



            //if (dataItem is IBookCollection)
            //{
            //    AddBooksControl.Display(this, (IBookCollection)dataItem);
            //    AddAuthorsControl.Hide();
            //}
            //else
            //{
            //    AddAuthorsControl.Display(this, (Book)dataItem);
            //    AddBooksControl.Hide();
            //}
        }


        private void SaveDetails(object sender, RoutedEventArgs e)
        {
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
