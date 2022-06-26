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
        bool AnyStackPanelVisible = false;

        public MainWindow()
        {
            InitializeComponent();
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
            UIMethods.ToggleVisibility(spDeliveries, btnDeliveries);
        }

        private void btnShops_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spShops, btnShops);
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spProducts, btnProducts);
        }

        private void btnTrademarks_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spTrademarks, btnTrademarks);
        }

        private void btnOwners_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spOwners, btnOwners);
        }

        private void btnDistricts_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spDistricts, btnDistricts);
        }

        private void btnSettlements_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spSettlements, btnSettlements);
        }

        private void btnGrades_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spGrades, btnGrades);
        }

        private void btnLegalentities_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spLegalentities, btnLegalentities);
        }

        private void btnQueries_Click(object sender, RoutedEventArgs e)
        {
            UIMethods.ToggleVisibility(spQueries, btnQueries);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
