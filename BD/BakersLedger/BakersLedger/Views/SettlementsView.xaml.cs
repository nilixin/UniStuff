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

namespace BakersLedger.Views
{
    /// <summary>
    /// Interaction logic for SettlementsView.xaml
    /// </summary>
    public partial class SettlementsView : UserControl
    {
        public SettlementsView()
        {
            InitializeComponent();

            string? message;
            Db db = new("Host=localhost;Username=postgres;Password=postgres;Database=bakers_ledger_experimental", out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            var settlementsTable = db.RetrieveAll("select * from settlements_all_rus");
            dgSettlements.ItemsSource = settlementsTable.DefaultView;

        }
    }
}
