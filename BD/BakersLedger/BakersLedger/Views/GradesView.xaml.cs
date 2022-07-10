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
    /// Interaction logic for GradesView.xaml
    /// </summary>
    public partial class GradesView : UserControl
    {
        public GradesView()
        {
            InitializeComponent();

            string? message;
            Db db = new(Constants.CONN_STRING, out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            var gradesTable = db.RetrieveAll("select * from grades_all_rus");
            dgGrades.ItemsSource = gradesTable.DefaultView;
        }
    }
}
