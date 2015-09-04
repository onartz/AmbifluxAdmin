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
using System.Collections.ObjectModel;

namespace AmbifluxAdmin.View
{
    /// <summary>
    /// Logique d'interaction pour OrderHeaderBrowser.xaml
    /// </summary>
    public partial class OrderHeaderBrowser : Page
    {
        private ItemType currentView;
        private string statusMessage = null;

        private readonly CollectionViewSource listeDe;

        private Customer currentCustomer= DB.GetCustomerByName(Environment.UserName);
        

        public OrderHeaderBrowser()
        {
            InitializeComponent();
            displayDemandesExpressByCustomer();
        }

        private void DisplayDemandesExpressByUser(object sender, RoutedEventArgs e)
        {
           
            displayDemandesExpressByCustomer();

        }

        /// <summary>
        /// Affiche le formulaire pour editer/modifier un objet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditData(object sender, RoutedEventArgs e)
        {
            var data = (sender as Button).CommandParameter as IDBItem;
            if (data == null) { return; }
            ViewOrderDetailsDialog.ShowDialog(ModalDialogParent, currentView, data, OnUpdate);
            
        }
        /// <summary>
        /// Affiche le formulaire vierger permettant d'ajouter un nouvel objet dans la base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddData(object sender, RoutedEventArgs e)
        {
            ViewOrderDetailsDialog.ShowDialog(ModalDialogParent, currentView, null, OnUpdate);
            
        }

     

       
        private void OnUpdate(bool commitUpdate)
        {
            if (currentCustomer == null)
                currentCustomer = DB.GetCustomerByName(Environment.UserName);

            if (!commitUpdate)
            {
                statusMessage += "Update canceled";
            }

            switch (currentView)
            {
               
                case ItemType.DemandeExpress:
                    displayDemandesExpressByCustomer();
                    break;
                case ItemType.Echange:
                    currentCustomer = DB.GetCustomerByName(Environment.UserName);
                    DisplayEchangesByUser();
                    break;

                default:
                  displayDemandesExpressByCustomer();
                    break;
            }

        }

        private void DisplayEchangesByUser()
        {
            var demandes = from d in new DataClassesDataContext().OrderHeader
                           where d is Echange & d.OrderStatus.Value != "Closed" & d.Customer == currentCustomer
                           select d as Echange;
            displayEchanges(demandes);
            MyEchangeButton.IsEnabled = false;
            MyDemandeExpressButton.IsEnabled = true;
        }

        /// <summary>
        /// Affiche les demandes du customer connecte s'il a déjà passé commande
        /// </summary>
        private void displayDemandesExpressByCustomer()
        {
        
            var demandes = from d in new DataClassesDataContext().OrderHeader
                           where d is DemandeExpress & d.OrderStatus.Value != "Closed" & d.OrderStatus.Value != "Canceled" & d.Customer == currentCustomer
                           select d as DemandeExpress;
            displayDemandeExpress(demandes);

            MyDemandeExpressButton.IsEnabled = false;
            MyEchangeButton.IsEnabled = true;
        }

        private void DisplayEchangesByUser(object sender, RoutedEventArgs e)
        {

            DisplayEchangesByUser();
        }


        //test
        private ObservableCollection<DemandeExpress> GetDemandesExpress()
        {
            var liste = new ObservableCollection<DemandeExpress>();
            foreach (var de in (from d in new DataClassesDataContext().OrderHeader
                                where d is DemandeExpress & d.OrderStatus.Value != "Closed" & d.Customer == currentCustomer
                                select d as DemandeExpress))
            {

                liste.Add(de);
                
            }
            return liste;
        }



        private void displayEchanges(IEnumerable<Echange> demandes)
        {
            currentView = ItemType.Echange;
            displayList(from demande in demandes select demande);
        }

        /// <summary>
        /// Affiche une liste de demandes express
        /// </summary>
        /// <param name="demandes"></param>
        private void displayDemandeExpress(IEnumerable<DemandeExpress> demandes)
        {
            currentView = ItemType.DemandeExpress;
            displayList(from demande in demandes select demande);
            //displayList(demandes);
        }

        /// <summary>
        /// Affiche une liste d'objets
        /// </summary>
        /// <param name="dataToList"></param>
        private void displayList(IEnumerable dataToList)
        {
            ResetDisplay();
            Listing.DataContext = dataToList;
        }


        /// <summary>
        /// Réinitialise l"affichage
        /// </summary>
        private void ResetDisplay()
        {
            //viewingBooksForAttribute = null;
            MyDemandeExpressButton.IsEnabled = true;
            //EquipmentButton.IsEnabled = true;
            //LocationButton.IsEnabled = true;
            //ContainerButton.IsEnabled = true;
            //WorkstationButton.IsEnabled = true;

            if (statusMessage == null)
            {
                if (currentView == ItemType.DemandeExpress) { statusMessage = "Liste des demandes express"; }
                if (currentView == ItemType.Echange) { statusMessage = "Liste des échanges"; }
                ////if (currentView == ItemType.Equipment) { statusMessage = "Liste de équipements"; }
                //if (currentView == ItemType.Workstation) { statusMessage = "Liste des machines"; }
                //if (currentView == ItemType.Location) { statusMessage = "Liste des emplacements"; }
                //if (currentView == ItemType.Container) { statusMessage = "Liste des containers"; }
            }

            StatusText.Content = statusMessage;
            statusMessage = null;
        }


       

   
    }
}
