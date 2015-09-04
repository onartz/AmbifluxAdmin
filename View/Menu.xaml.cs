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

namespace AmbifluxAdmin
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
       
        public Menu()

        {
            InitializeComponent();
            displayMenu();
        }

        /// <summary>
        /// Affichage en fonction du role de l'utilsiateur
        /// </summary>
        private void displayMenu()
        {
            var employee = (from e in new DataClassesDataContext().Resource
                           where e is Employee & (e as Employee).Login==Environment.UserName
                           select e as Employee).SingleOrDefault();
            if (employee != null)
            {
                if (employee.IsAdministrator)
                    Admin.Visibility = Visibility.Visible;
            }         
        }
    }
}
