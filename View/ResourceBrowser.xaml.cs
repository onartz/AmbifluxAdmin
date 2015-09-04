using System;
using System.Collections.Generic;
using System.Collections;
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
    /// Logique d'interaction pour ResourceBrowser.xaml
    /// </summary>
    public partial class ResourceBrowser : Page
    {
        private ItemType currentView;
        private string statusMessage = null;
        public ResourceBrowser()
        {
            InitializeComponent();
            displayAllEmployees();
        }

        #region Employees
        private void DisplayAllEmployees(object sender, RoutedEventArgs e)
        {
            displayAllEmployees();
        }

        private void displayAllEmployees()
        {
            var employees = from e in new DataClassesDataContext().Resource
                            where e is Employee & e.ResourceStatus.Value != "Deleted"
                       select e as Employee;
            displayEmployees(employees);
            
            

            EmployeeButton.IsEnabled = false;
        }

        private void displayEmployees(IEnumerable<Employee> employees)
        {
            
            currentView = ItemType.Employee;
            //displayList(from employee in employees orderby employee.Contact.FirstName ascending select employee);
            displayList(from employee in employees select employee);
        }


      
        #endregion

   

        #region Workstations
        private void DisplayAllWorkstations(object sender, RoutedEventArgs e)
        {
            displayAllWorkstations();
        }

        private void displayAllWorkstations()
        {
            var workstations = from w in new DataClassesDataContext().Resource
                               where w.ResourceStatus.Value != "Deleted" & w is Workstation
                             select w as Workstation;
            displayWorkstations(workstations);

            WorkstationButton.IsEnabled = false;
        }

        private void displayWorkstations(IEnumerable<Workstation> workstations)
        {
            currentView = ItemType.Workstation;
            displayList(from w in workstations orderby w.Name select w);
        }

        #endregion


        #region Location
        private void DisplayAllLocations(object sender, RoutedEventArgs e)
        {
            displayAllLocations();
        }

        private void displayAllLocations()
        {
            var locations = from e in new DataClassesDataContext().Location
                            where e.LocationStatus.Value != "Deleted"
                             select e;
            displayLocations(locations);

            LocationButton.IsEnabled = false;
        }

        private void displayLocations(IEnumerable<Location> locations)
        {
            currentView = ItemType.Location;
            displayList(from location in locations orderby location.Name select location);
        }

        #endregion

        #region Container
        private void DisplayAllContainers(object sender, RoutedEventArgs e)
        {
            displayAllContainers();
        }

        private void displayAllContainers()
        {
            var containers = from e in new DataClassesDataContext().Container
                            //where e.Status == "Active"
                            select e;
            displayContainers(containers);

            ContainerButton.IsEnabled = false;
        }

        private void displayContainers(IEnumerable<Container> containers)
        {
            currentView = ItemType.Container;
            displayList(from container in containers orderby container.Numero select container);
        }

        #endregion

        private void ResetDisplay()
        {
            //viewingBooksForAttribute = null;
            EmployeeButton.IsEnabled = true;
            //EquipmentButton.IsEnabled = true;
            LocationButton.IsEnabled = true;
            ContainerButton.IsEnabled = true;
            WorkstationButton.IsEnabled = true;

            if (statusMessage == null)
            {
                if (currentView == ItemType.Employee) { statusMessage = "Liste des personnels AIPL"; }
                //if (currentView == ItemType.Equipment) { statusMessage = "Liste de équipements"; }
                if (currentView == ItemType.Workstation) { statusMessage = "Liste des machines"; }
                if (currentView == ItemType.Location) { statusMessage = "Liste des emplacements"; }
                if (currentView == ItemType.Container) { statusMessage = "Liste des containers"; }
            }

            StatusText.Content = statusMessage;
            statusMessage = null;
        }


        private void displayList(IEnumerable dataToList)
        {
            ResetDisplay();
            Listing.DataContext = dataToList;
        }
        
        
        private void EditData(object sender, RoutedEventArgs e)
        {
            var data = (sender as Button).CommandParameter as IDBItem;
            //var data = (sender as Button).CommandParameter;
            if (data == null) { return; }

            EditResourceDetailsDialog.ShowDialog(ModalDialogParent,currentView,data,OnUpdate);          
        }

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

                case ItemType.Location:
                    displayAllLocations();
                    break;

                case ItemType.Container:
                    displayAllContainers();
                    break;

                case ItemType.Workstation:
                    displayAllWorkstations();
                    break;

                case ItemType.Employee:
                default:
                    //if( viewingBooksForAttribute != null ) {
                    //    // refresh this item from the datacontext
                    //    viewingBooksForAttribute = Catalog.GetExistingItem( viewingBooksForAttribute ) as IBookCollection;
                    //}

                    //if( viewingBooksForAttribute != null ) {
                    //    DisplayBooks( viewingBooksForAttribute.Books );
                    //} else {
                    displayAllEmployees();
                    //}
                    break;
            }

        }

      

        private void AddData(object sender, RoutedEventArgs e)
        {
            EditResourceDetailsDialog.ShowDialog(ModalDialogParent, currentView, null, OnUpdate);
        }

        private void LoadBooksForAttribute(object sender, RoutedEventArgs e)
        {

        }

       


    }
}
