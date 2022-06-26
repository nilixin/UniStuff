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
            if (spDeliveries.Visibility == Visibility.Hidden && !AnyStackPanelVisible)
            {
                spDeliveries.Visibility = Visibility.Visible;
                AnyStackPanelVisible = true;
                btnDeliveries.Background = (Brush)Application.Current.Resources["DarkBase"];
            }
            else
            {
                spDeliveries.Visibility = Visibility.Hidden;
                AnyStackPanelVisible = false;
                btnDeliveries.Background = (Brush)Application.Current.Resources["LightBase"];
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
