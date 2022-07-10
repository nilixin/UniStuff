﻿using System;
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
    /// Interaction logic for ShopsView.xaml
    /// </summary>
    public partial class ShopsView : UserControl
    {
        public ShopsView()
        {
            InitializeComponent();

            string? message;
            Db db = new(Constants.CONN_STRING, out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            var shopsTable = db.RetrieveAll("select * from shops_all_rus");
            dgShops.ItemsSource = shopsTable.DefaultView;
        }
    }
}
