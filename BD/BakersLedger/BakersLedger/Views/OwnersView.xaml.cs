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
    /// Interaction logic for OwnersView.xaml
    /// </summary>
    public partial class OwnersView : UserControl
    {
        public OwnersView()
        {
            InitializeComponent();

            string? message;
            Db db = new(Constants.CONN_STRING, out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            var ownersTable = db.RetrieveAll("select * from owners_all_rus");
            dgOwners.ItemsSource = ownersTable.DefaultView;
        }
    }
}
