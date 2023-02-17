using System;
using System.IO;
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
using Breakage.Data;

namespace Breakage.Pages
{
    /// <summary>
    /// Interaction logic for ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        public List<Client> Clients { get; set; }
        public ClientsListPage()
        {
            InitializeComponent();
            Clients = DataAccess.GetClients();

            DataAccess.RefreshList += DataAccess_RefreshList;
            DataContext = this;
        }

        private void DataAccess_RefreshList()
        {
            Clients = DataAccess.GetClients();
            lvClients.ItemsSource = Clients;
            lvClients.Items.Refresh();
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = (Client)lvClients.SelectedItem;
            if (client != null)
                NavigationService.Navigate(new ClientPage(client));
        }
    }
}
