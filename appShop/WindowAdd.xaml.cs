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
using System.Windows.Shapes;

namespace appShop
{
    /// <summary>
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
            List<string> actual = new List<string>();
            actual.Add("Актуально");
            actual.Add("Неактуально");
            cmbActual.ItemsSource = actual;
            cmbActual.SelectedIndex = 0;
            tbName.Text = TovarPage.selectEntites.Title;
            tbPrice.Text = TovarPage.selectEntites.Cost.ToString();
            tbDescript.Text = TovarPage.selectEntites.Description;
            List<string> cat = new List<string>() { "Футболки", "Толстовки", "Брюки", "Перчатки", "Головные уборы" };
            cmbCat.ItemsSource = cat;
            if (TovarPage.selectEntites.Category == "Футболки")
            {
                cmbCat.SelectedIndex = 0;
            }
            else if (TovarPage.selectEntites.Category == "Толстовки")
            {
                cmbCat.SelectedIndex = 1;
            }
            else if (TovarPage.selectEntites.Category == "Брюки")
            {
                cmbCat.SelectedIndex = 2;
            }
            else if (TovarPage.selectEntites.Category == "Перчатки")
            {
                cmbCat.SelectedIndex = 3;
            }
            else if (TovarPage.selectEntites.Category == "Головные уборы")
            {
                cmbCat.SelectedIndex = 4;
            }
        }

        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[а-яА-Я\,\.0-9a-zA-Z]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbDescript_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[а-яА-Я\,\.0-9a-zA-Z]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bd.Products.Load();
            Product currentProduct = new Product();
            currentProduct.ID = TovarPage.selectEntites.ID;
            currentProduct.Title = tbName.Text;
            currentProduct.Cost = decimal.Parse(tbPrice.Text);
            currentProduct.Description = tbDescript.Text;
            currentProduct.MainImagePath = TovarPage.selectEntites.MainImagePath;
            if (cmbCat.SelectedIndex == 0)
            {
                currentProduct.Category = "Футболки";
            }
            else if (cmbCat.SelectedIndex == 1)
            {
                currentProduct.Category = "Толстовки";
            }
            else if (cmbCat.SelectedIndex == 2)
            {
                currentProduct.Category = "Брюки";
            }
            else if (cmbCat.SelectedIndex == 3)
            {
                currentProduct.Category = "Перчатки";
            }
            else if (cmbCat.SelectedIndex == 4)
            {
                currentProduct.Category = "Головные уборы";
            }
            if (cmbActual.SelectedIndex == 0)
            {
                currentProduct.isActive = true;
            }
            else
            {
                currentProduct.isActive = false;
            }
            try
            {
                MainWindow.bd.Products.Add(currentProduct);
                MainWindow.bd.SaveChanges();
                MainWindow.Inf("Информация сохранена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
