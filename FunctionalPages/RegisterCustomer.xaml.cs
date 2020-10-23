﻿// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
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
using SPWally.FunctionalPages;
using SPWally.DataLayer;

namespace SPWally.FunctionalPages
{
    /// <summary>
    /// Interaction logic for RegisterCustomer.xaml
    /// </summary>
    public partial class RegisterCustomer : Page
    {
        private ViewModelValueOriented vmvo;
        public RegisterCustomer()
        {
            InitializeComponent();
            Loaded += RegisterCustomer_Loaded;
        }

        private void RegisterCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            vmvo = new ViewModelValueOriented();
            DataContext = vmvo;
        }

        private void ConfirmCust_Click(object sender, RoutedEventArgs e)
        {
            DatabaseManipulation dataMani = new DatabaseManipulation();
            int custID;

            if ((custID = dataMani.FindCustomer()) == -1)
            {
                if ((custID = dataMani.AddCustomer()) != -1)
                {
                    vmvo.CurrentCustomer.CustomerID = custID;
                    vmvo.CurrentCustomer.FirstName = vmvo.FirstName;
                    vmvo.CurrentCustomer.LastName = vmvo.LastName;
                    vmvo.CurrentCustomer.Phone = vmvo.Phone;

                    // Find the frame.
                    Frame frame = null;
                    DependencyObject parent = VisualTreeHelper.GetParent(this);

                    // Cycles through to MainWindow frame
                    while (parent != null && frame == null)
                    {
                        frame = parent as Frame;
                        parent = VisualTreeHelper.GetParent(parent);
                    }

                    // Change the page of the frame.
                    if (frame != null)
                    {
                        frame.Navigate(new PurchaseOrder());
                    }
                    //Code Courtesy of Shmuel Zang in codeprojects.com https://www.codeproject.com/Questions/281551/frame-navigation-in-WPF
                }
                else
                {
                    MessageBox.Show("Error: Could Not Add Customer To Database", "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Customer Already Exists", "Alert!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
