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
    /// Logique d'interaction pour RequestBrowser.xaml
    /// </summary>
    public partial class RequestBrowser : Page
    {
        private ItemType currentView;
        private string statusMessage = null;

        public RequestBrowser()
        {
            InitializeComponent();
            displayAllDemandeExpress();
            
        }

        private void EditData(object sender, RoutedEventArgs e)
        {
            var data = (sender as Button).CommandParameter as IDBItem;
            //var data = (sender as Button).CommandParameter;
            if (data == null) { return; }

            EditRequestDetailsDialog.ShowDialog(ModalDialogParent, currentView, data, OnUpdate);    
        }

        private void DisplayAllDemandeExpress(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayAllEchange(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayAllCommandes(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayAllEvacuations(object sender, RoutedEventArgs e)
        {

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

                case ItemType.DemandeExpress:
                    displayAllDemandeExpress();
                    break;

         
                default:
                  
                    displayAllDemandeExpress();
                  
                    break;
            }

        }

        private void displayAllDemandeExpress()
        {
            var demandes = from d in new DataClassesDataContext().OrderHeader
                            where d is DemandeExpress & d.OrderStatus.Value != "Closed"
                            select d as DemandeExpress;
            displayDemandeExpress(demandes);

            DemandeExpressButton.IsEnabled = false;
        }

        private void displayDemandeExpress(IEnumerable<DemandeExpress> demandes)
        {
            currentView = ItemType.DemandeExpress;
            displayList(from demande in demandes select demande);
        }

   
        private void ResetDisplay()
        {
            //viewingBooksForAttribute = null;
            DemandeExpressButton.IsEnabled = true;
            //EquipmentButton.IsEnabled = true;
            //LocationButton.IsEnabled = true;
            //ContainerButton.IsEnabled = true;
            //WorkstationButton.IsEnabled = true;

            if (statusMessage == null)
            {
                if (currentView == ItemType.DemandeExpress) { statusMessage = "Liste des demandes express"; }
                ////if (currentView == ItemType.Equipment) { statusMessage = "Liste de équipements"; }
                //if (currentView == ItemType.Workstation) { statusMessage = "Liste des machines"; }
                //if (currentView == ItemType.Location) { statusMessage = "Liste des emplacements"; }
                //if (currentView == ItemType.Container) { statusMessage = "Liste des containers"; }
            }

            StatusText.Content = statusMessage;
            statusMessage = null;
        }


        private void displayList(IEnumerable dataToList)
        {
            ResetDisplay();
            Listing.DataContext = dataToList;
        }
        





        private void AddData(object sender, RoutedEventArgs e)
        {
            EditRequestDetailsDialog.ShowDialog(ModalDialogParent, currentView, null, OnUpdate);
        }
    }
}
