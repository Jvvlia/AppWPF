using AppCode;
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
using System.Windows.Shapes;

namespace AppWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Customer customer;
        public Edit()
        {
            InitializeComponent();
        }

        public Edit(Customer c) :this()
        {
            this.customer = c;
            TxtName.Text = c.Name;
            TxtAddress.Text = c.Address;
            TxtVat.Text = c.VATID;
            TxtDate.Text = $"{c.CreationDate:dd/MM/yyyy}";
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool? res = false;
            if(!string.IsNullOrEmpty(TxtName.Text) && !string.IsNullOrEmpty(TxtAddress.Text) &&
                !string.IsNullOrEmpty(TxtDate.Text) && !string.IsNullOrEmpty(TxtVat.Text))
            {
                customer.Name = TxtName.Text;
                customer.Address = TxtAddress.Text;
                customer.VATID = TxtVat.Text;
                if (DateTime.TryParseExact(TxtDate.Text, new string[] { "dd-MM-yyyy", "dd/MM/yyyy" },
                   null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    customer.CreationDate = date;
                }
                res = true;
            }
            DialogResult = res;
        }
    }
}
