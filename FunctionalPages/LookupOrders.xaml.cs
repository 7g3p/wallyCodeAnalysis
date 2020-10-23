﻿// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SPWally.DataLayer;

namespace SPWally.FunctionalPages
{
    /// <summary>
    /// Interaction logic for LookupOrders.xaml
    /// </summary>
    public partial class LookupOrders : Page
    {
        private ViewModelValueOriented vmvo;
        public LookupOrders()
        {
            InitializeComponent();
            Loaded += LookupOrders_Loaded;
        }

        private void LookupOrders_Loaded(object sender, RoutedEventArgs e)
        {
            vmvo = new ViewModelValueOriented();
            DataContext = vmvo;
        }

        private void Refund_Click(object sender, RoutedEventArgs e)
        {

            if (vmvo.Order.Status == "PAID")
            {
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
                MessageBox.Show("You Cannot Refund a Refunded Order", "Alert!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            DatabaseManipulation dataMani = new DatabaseManipulation();

            if(!dataMani.LoadOrder())
            { 
                MessageBox.Show("Could Not Find the Specified Order.", "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
