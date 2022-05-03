using appShop.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace appShop
{
    /// <summary>
    /// Interaction logic for BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        public BuyWindow()
        {
            InitializeComponent();
            tbBuy.Text += "\"" + TovarPage.selectEntites.Title + "\"" + "?";
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            cmbCount.ItemsSource = a;
            cmbCount.SelectedIndex = 0;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            ProductSale currentBuy = new ProductSale();
            try
            {
                currentBuy.id = MainWindow.bd.ProductSales.Local.Count + 1;
                currentBuy.id_product = TovarPage.selectEntites.ID;
                currentBuy.price = TovarPage.selectEntites.Cost;
                currentBuy.date = DateTime.Now;
                currentBuy.count = (int)cmbCount.SelectedItem; 
                MainWindow.bd.ProductSales.Add(currentBuy);
                MainWindow.bd.SaveChanges();
                MainWindow.Inf("Данные сохранены!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
