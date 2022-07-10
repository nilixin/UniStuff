using BakersLedger.ViewModels;
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

namespace BakersLedger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string? message;
            Db db = new(Constants.CONN_STRING, out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnDeliveries_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new DeliveriesViewModel();
            else
                DataContext = null;
        }

        private void btnShops_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new ShopsViewModel();
            else
                DataContext = null;
        }

        private void btnTrademarks_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new TrademarksViewModel();
            else
                DataContext = null;
        }

        private void btnCompanies_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new CompaniesViewModel();
            else
                DataContext = null;
        }

        private void btnOwners_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new OwnersViewModel();
            else
                DataContext = null;
        }

        private void btnDistricts_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new DistrictsViewModel();
            else
                DataContext = null;
        }

        private void btnSettlements_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new SettlementsViewModel();
            else
                DataContext = null;
        }

        private void btnGrades_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new GradesViewModel();
            else
                DataContext = null;
        }

        private void btnLegals_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                DataContext = new LegalsViewModel();
            else
                DataContext = null;
        }

        private void btnQueries_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
