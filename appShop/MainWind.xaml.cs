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
using System.Windows.Shapes;

namespace appShop
{
    /// <summary>
    /// Interaction logic for MainWind.xaml
    /// </summary>
    public partial class MainWind : Window
    {
        public MainWind()
        {
            InitializeComponent();
            if (Manager.Admin == true)
            {
                tbRole.Text = "Вы вошли как менеджер";
            }
            else
            {
                tbRole.Text = "Вы вошли как клиент";
            }
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new MainPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
