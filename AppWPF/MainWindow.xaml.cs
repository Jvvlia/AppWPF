using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AppCode;

namespace AppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Customers cust;
        public MainWindow()
        {
            string fname = "customers.xml";
            cust = Customers.DeserializeXml(fname);
            InitializeComponent();
            if(cust!=null )
            {
                LstCustomers.ItemsSource = new ObservableCollection<Customer>(cust.CustomersList);
                
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(cust!= null && LstCustomers.SelectedIndex >-1)
            {
                Customer c = LstCustomers.SelectedItem as Customer;
                if(c!=null)
                {
                    cust.RemoveCustomer(c);
                    LstCustomers.ItemsSource = new ObservableCollection<Customer>(cust.CustomersList);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            TxtEdit.Text = LstCustomers.SelectedItem.ToString();
            if (cust!=null)
            {
                Customer c = LstCustomers.SelectedItem as Customer;
                Customer clone = c.Clone() as Customer;
                Edit edit = new(c);
                bool? result = edit.ShowDialog();
                if(result==true)
                {
                    c.Name = clone.Name;
                    c.Address = clone.Address;
                    c.CreationDate = clone.CreationDate;
                    c.VATID= clone.VATID;
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cust!=null)
            {
                Customer c = new Customer();
                Edit edit = new Edit(c);
                bool? result = edit.ShowDialog();
                if(result == true) 
                { 
                    cust.AddCustomer(c);
                    LstCustomers.ItemsSource = new ObservableCollection<Customer>(cust.CustomersList);
                }
            }
        }
    }
}
