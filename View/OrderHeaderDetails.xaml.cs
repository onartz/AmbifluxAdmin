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
    public partial class OrderHeaderDetails : UserControl
    {
        private IDBItem dataItem;
        internal DataClassesDataContext database { get; private set; }
        private Location deliveryLocation;
        private Customer currentCustomer;
        private readonly CollectionViewSource ProductCategoryList;

        private Action<bool> completeAction = null;
        private UIElement parentDetails;

        public OrderHeaderDetails()
        {
            InitializeComponent();           
            ProductCategoryList = (CollectionViewSource)FindResource("ProductCategoryList");           
            Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Affiche le controle
        /// </summary>
        /// <param name="parent">Celui qui appelle</param>
        /// <param name="type">Type d objet a afficher</param>
        /// <param name="dataToEdit">Objet a afficher</param>
        /// <param name="completed"></param>
        public void ShowDialog(UIElement parent, ItemType type, IDBItem dataToEdit, Action<bool> completed)
        {
            database = new DataClassesDataContext();
            currentCustomer = DB.GetCustomerByName(database, Environment.UserName);
            deliveryLocation = DB.GetWorkstationByName(database, Environment.MachineName).Location;
           
            parentDetails = parent;
            completeAction = completed;
            SetupData(type, dataToEdit);
            parentDetails.IsEnabled = false;
            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Prepare le données et les affiche
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dataToEdit"></param>
        private void SetupData(ItemType type, IDBItem dataToEdit)
        {
            if (dataToEdit == null)
            {
                dataItem = DB.AddNewItem(database, type);
                if (dataItem is DemandeExpress)
                {
                    (dataItem as DemandeExpress).Customer = currentCustomer;
                    (dataItem as DemandeExpress).Location = deliveryLocation;
                }
                if (dataItem is Echange)
                {
                    (dataItem as Echange).Customer = currentCustomer;
                    (dataItem as Echange).Location = deliveryLocation;
                }
            }
            else
            {
                dataItem = DB.GetExistingItem(database, dataToEdit);
            }

            BindDataToEditForm();
            LoadAssociatedLists();
        }


        /// <summary>
        /// Bind les donnees avec les champs du formulaire
        /// </summary>
        private void BindDataToEditForm()
        {
            Binding binding = new Binding();
            binding.Source = dataItem;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            EditForm.SetBinding(DataContextProperty, binding);
        }

        /// <summary>
        /// Charge les objets associés
        /// </summary>
        private void LoadAssociatedLists()
        {
            if (dataItem is DemandeExpress)
            {
                ProductCategoryList.Source = from s in database.ProductCategory select s;

            }
            if (dataItem is Echange)
            {
    
            }

        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDetails(object sender, RoutedEventArgs e)
        {
            WorkOrder w;
            WorkOrderRouting worDeplacement1;
            WorkOrderRouting worDeplacement2;
            WorkOrderRouting worChargement;
            WorkOrderRouting worDechargement;
            Contact c;
    
            if (dataItem is DemandeExpress)
            {
                //si le customer n existe pas encore dans la base, on le crée
                if (currentCustomer==null)
                {
                    currentCustomer = DB.AddNewItem(database, ItemType.Customer) as Customer;
                    currentCustomer.CustomerType='I';
                    currentCustomer.UserName=Environment.UserName;

                    (dataItem as DemandeExpress).Customer = currentCustomer;

                    //On crée le Contact associé
                    Contact customerContact=DB.AddNewItem(database,ItemType.Contact) as Contact;

                    try
                    {
                        c = new Contact("LDAP://DC=ad,DC=univ-lorraine,DC=fr", "aip-adread", "Gzero01!", currentCustomer.UserName);
                        customerContact.FirstName = c.FirstName;
                        customerContact.LastName = c.LastName;
                        customerContact.EmailAddress = c.EmailAddress;
                        currentCustomer.Contact = customerContact;         
                    }
                    catch (Exception ex)
                    { return; }            
                }

                
                //Création d'un Workorder de déplacement
                w = DB.AddNewItem(database, ItemType.WorkOrder) as WorkOrder;
                //Emplacement de Destination
                //w.Location = (dataItem as DemandeExpress).Location;
                //Emplacement Source
                //w.Location1 = (dataItem as DemandeExpress).ProductCategory.Location;
                w.OrderHeader = (dataItem as OrderHeader);
                w.Type = "LIV";
                w.WorkOrderStatusID = 1;


                //Création d'un WorkOrderRouting pour le déplacement vers le poste de chargment
                worDeplacement1 = DB.AddNewItem(database, ItemType.WorkOrderRouting) as WorkOrderRouting;
                worDeplacement1.WorkOrder=w;
                worDeplacement1.OperationSequence = 10;
                worDeplacement1.Location = (dataItem as DemandeExpress).ProductCategory.Location;
                worDeplacement1.Type = 'T';
                worDeplacement1.WorkOrderRoutingStatusId = 1;
                

                //Création d'un WorkOrderRouting pour le chargement
                worChargement = DB.AddNewItem(database, ItemType.WorkOrderRouting) as WorkOrderRouting;
                worChargement.WorkOrder = w;
                worChargement.OperationSequence = 20;
                worChargement.Location = (dataItem as DemandeExpress).ProductCategory.Location;
                worChargement.Type = 'C';
                worChargement.WorkOrderRoutingStatusId = 1;

                //Création d'un WorkOrderRouting pour le déplacement vers le poste de livraison
                worDeplacement2 = DB.AddNewItem(database, ItemType.WorkOrderRouting) as WorkOrderRouting;
                worDeplacement2.WorkOrder = w;
                worDeplacement2.OperationSequence = 30;
                worDeplacement2.Location = (dataItem as DemandeExpress).Location;
                worDeplacement2.Type = 'T';
                worDeplacement2.WorkOrderRoutingStatusId = 1;

                //Création d'un WorkOrderRouting pour la livraison
                worDechargement = DB.AddNewItem(database, ItemType.WorkOrderRouting) as WorkOrderRouting;
                worDechargement.WorkOrder = w;
                worDechargement.OperationSequence = 40;
                worDechargement.Location = (dataItem as DemandeExpress).Location;
                worDechargement.Type = 'L';
                worDechargement.WorkOrderRoutingStatusId = 1;


            }
            database.SubmitChanges();
            CloseDialog(true);
        }

        /// <summary>
        /// Annule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelUpdate(object sender, RoutedEventArgs e)
        {

            //BookCatalog.CancelChanges();
            CloseDialog(false);
        }

        /// <summary>
        /// Ferme et retour au form appelabnt
        /// </summary>
        /// <param name="result"></param>
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
