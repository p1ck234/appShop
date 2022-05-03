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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace appShop
{
    /// <summary>
    /// Interaction logic for TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        public TovarPage()
        {
            InitializeComponent();
            MainWindow.bd.Products.Load();
            lvTovar.ItemsSource = MainWindow.bd.Products.Local;
            CheckActual.IsChecked = true;

            if (Manager.Admin == true)
            {
                btnBuy.Visibility = Visibility.Hidden;
                btnRed.Visibility = Visibility.Visible;
                btnDel.Visibility = Visibility.Visible;
                btnRel.Visibility = Visibility.Visible;
                btnAdd.Visibility = Visibility.Visible;
            }
            else
            {
                btnBuy.Visibility = Visibility.Visible;
                btnRed.Visibility = Visibility.Hidden;
                btnDel.Visibility = Visibility.Hidden;
                btnRel.Visibility = Visibility.Hidden;
                btnAdd.Visibility = Visibility.Hidden;
            }
        }
        public static Product selectEntites = new Product();
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.bd.Products.Load();
            lvTovar.ItemsSource = MainWindow.bd.Products.Local.Where(x => x.Title.ToLower().Contains(tbSearch.Text.ToLower()));
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckActual.IsChecked.Value)
            {
                MainWindow.bd.Products.Load();
                lvTovar.ItemsSource = MainWindow.bd.Products.Local.Where(x => x.isActive);
            }
        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.Products.Load();
            lvTovar.ItemsSource = MainWindow.bd.Products.Local;
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            selectEntites = (Product)lvTovar.SelectedItem;
            if (selectEntites != null)
            {
                BuyWindow bw = new BuyWindow();
                bw.Show();
            }
            else
            {
                MainWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd a = new WindowAdd();
            a.Show();
        }

        private void btnRel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.Products.Load();
            lvTovar.ItemsSource = MainWindow.bd.Products.Local;
            MainWindow.Inf("Информация обновлена");
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            selectEntites = (Product)lvTovar.SelectedItem;
            if (selectEntites != null)
            {
                RedWindow a = new RedWindow();
                a.Show();
            }
            else
            {
                MainWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.Products.Load();
            if (selectEntites != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    selectEntites = (Product)lvTovar.SelectedItem;
                    try
                    {
                        MainWindow.bd.Products.Remove(selectEntites);
                        MainWindow.bd.SaveChanges();
                        lvTovar.ItemsSource = MainWindow.bd.Products.Local.OrderBy(x => x.ID);
                        MainWindow.Inf("Элемент удален");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MainWindow.Exp("Вы ничего не выбрали!");
            }
        }
    }
}
