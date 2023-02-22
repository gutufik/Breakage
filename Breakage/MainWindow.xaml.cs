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

namespace Breakage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frmMain.NavigationService.Navigate(new Pages.ClientsListPage());
            frmMain.Navigated += FrmMain_Navigated;
        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {
            btnGoBack.Visibility = frmMain.NavigationService.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.GoBack();       
        }
    }
}
