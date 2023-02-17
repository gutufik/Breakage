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
using Microsoft.Win32;

namespace Breakage.Pages
{
    /// <summary>
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public Client Client { get; set; }
        public List<Gender> Genders { get; set; }
        public ClientPage(Client client)
        {
            InitializeComponent();
            Client = client;
            Genders = DataAccess.GetGenders();
            DataContext = this;
        }

        private void btnChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().Value == true)
            {
                Client.Photo = File.ReadAllBytes(openFileDialog.FileName);
                ClientImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteClient(Client);
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveClient(Client);
            NavigationService.GoBack();
        }
    }
}
