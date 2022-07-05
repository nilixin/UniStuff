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
            DBLogic dBLogic = new("Host=localhost;Username=postgres;Password=postgres;Database=bakers_ledger_experimental", out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            // settlements
            var settlementsTable = dBLogic.RetrieveAll("select * from settlements_all_rus");
            dgSettlements.DataContext = settlementsTable.DefaultView;
            dgSettlements.SelectedIndex = 0;

            // grades
            var gradesTable = dBLogic.RetrieveAll("select * from grades_all_rus");
            dgGrades.DataContext = gradesTable.DefaultView;
            dgGrades.SelectedIndex = 0;

            // legals
            var legalsTable = dBLogic.RetrieveAll("select * from legals_all_rus");
            dgLegals.DataContext = legalsTable.DefaultView;
            dgLegals.SelectedIndex = 0;

            // owners
            var ownersTable = dBLogic.RetrieveAll("select * from owners_all_rus");
            dgOwners.DataContext = ownersTable.DefaultView;
            dgOwners.SelectedIndex = 0;

            // districts
            var districtsTable = dBLogic.RetrieveAll("select * from districts_all_rus");
            dgDistricts.DataContext = districtsTable.DefaultView;
            dgDistricts.SelectedIndex = 0;

            // shops
            var shopsTable = dBLogic.RetrieveAll("select * from shops_all_rus");
            dgShops.DataContext = shopsTable.DefaultView;
            dgShops.SelectedIndex = 0;

            // companies
            // trademarks
            // deliveries
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
            UIMethods.ToggleVisibility(svDeliveries, btnDeliveries);
        }

        private void btnShops_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svShops, btnShops);
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svProducts, btnProducts);
        }

        private void btnTrademarks_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svTrademarks, btnTrademarks);
        }

        private void btnOwners_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svOwners, btnOwners);
        }

        private void btnDistricts_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svDistricts, btnDistricts);
        }

        private void btnSettlements_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svSettlements, btnSettlements);
        }

        private void btnGrades_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svGrades, btnGrades);
        }

        private void btnLegals_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svLegals, btnLegals);
        }

        private void btnQueries_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(svQueries, btnQueries);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
