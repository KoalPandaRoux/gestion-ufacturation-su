using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using gestion_ufacturation.BLL;
using gestion_ufacturation.SHARED;
using MahApps.Metro.Controls;


namespace gestion_ufacturation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ClientService clientService = new ClientService();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            client_list.ItemsSource = clientService.GetClients();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients c = new Clients();
            c.nom = Nom.Text;
            c.prenom = Prenom.Text;
            c.numero_telephone = Numero.Text;
            c.adresse = Adresse.Text;
            clientService.Ajouter(c);
        }
    }
}
