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
using System.Windows.Shapes;
using SPWally.DataLayer;

namespace SPWally.FunctionalPages
{
    /// <summary>
    /// Interaction logic for ExistingCustomer.xaml
    /// </summary>
    public partial class ExistingCustomer : Page
    {
        private ViewModelValueOriented vmvo;
        public ExistingCustomer()
        {
            InitializeComponent();
            Loaded += ExistingCustomer_Loaded;
        }

        private void ExistingCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            vmvo = new ViewModelValueOriented();
            DataContext = vmvo;
        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            var dbMani = new DatabaseManipulation();
            int custID;

            if (-1 != (custID = dbMani.FindCustomer()))
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
                MessageBox.Show("Could Not Find Specific Customer.", "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Refund_Click(object sender, RoutedEventArgs e)
        {
            var dbMani = new DatabaseManipulation();
            int custID;

            if (-1 != (custID = dbMani.FindCustomer()))
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
                    frame.Navigate(new RefundOrder());
                }
                //Code Courtesy of Shmuel Zang in codeprojects.com https://www.codeproject.com/Questions/281551/frame-navigation-in-WPF
            }
            else
            {
                MessageBox.Show("Could Not Find Specific Customer.", "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
