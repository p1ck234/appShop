using appShop.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace appShop
{
    /// <summary>
    /// Interaction logic for TableTovarPage.xaml
    /// </summary>
    public partial class TableTovarPage : Page
    {
        public TableTovarPage()
        {
            InitializeComponent();
            MainWindow.bd.ProductSales.Load();
            dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderBy(x => x.id);
        }
        ProductSale selectEntites = new ProductSale();
        private void sortDate_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderByDescending(x => x.date);
        }

        private void sortQuntity_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderBy(x => x.count);
        }

        private void sortId_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderBy(x => x.id_product);
        }

        private void sortIdProduct_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderBy(x => x.id);
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            selectEntites = (ProductSale)dtgTovarTable.SelectedItem;
            if (selectEntites != null)
            {
                try
                {
                    tbId.Text = selectEntites.id.ToString();
                    tbDateSale.Text = selectEntites.date.ToString();
                    tbIdProd.Text = selectEntites.id_product.ToString();
                    tbQunt.Text = selectEntites.count.ToString();
                    spRed.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MainWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            selectEntites = (ProductSale)dtgTovarTable.SelectedItem;
            if (selectEntites != null)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        MainWindow.bd.ProductSales.Remove(selectEntites);
                        MainWindow.bd.SaveChanges();
                        dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderBy(x => x.id);
                        MainWindow.Inf("Элемент удален");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MainWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void tbId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbDateSale_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9/:/\/]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbIdProd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbQunt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.ProductSales.Load();
            ProductSale currentProduct = new ProductSale();
            if (tbId.Text != "" && tbDateSale.Text != "" && tbIdProd.Text != "" && tbQunt.Text != "")
            {
                try
                {
                    currentProduct.id = int.Parse(tbId.Text);
                    currentProduct.date = DateTime.Parse(tbDateSale.Text);
                    currentProduct.id_product = int.Parse(tbIdProd.Text);
                    currentProduct.count = int.Parse(tbQunt.Text);
                    MainWindow.bd.ProductSales.Remove(selectEntites);
                    MainWindow.bd.ProductSales.Add(currentProduct);
                    MainWindow.bd.SaveChanges();
                    MainWindow.Inf("Данный сохранены");
                    spRed.Visibility = Visibility.Hidden;
                    dtgTovarTable.ItemsSource = MainWindow.bd.ProductSales.Local.OrderBy(x => x.id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
