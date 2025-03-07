﻿using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Alloy_Calc.MVVM.ViewModel;
using Alloy_Calc.Services;

namespace Alloy_Calc.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _mousePos;
        public MainWindow()
        {
            InitializeComponent();
            VersionLabel.Content = App.Version;
        }

        private void ToggleLeftMenu_Click(object sender, RoutedEventArgs e)
        {
            if (((ToggleButton)sender).IsChecked == false) 
            {
                Grid.SetColumnSpan(LeftMenu, 1);
            }
            else
            {
                Grid.SetColumnSpan(LeftMenu, 2);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // Get window mouse position
            var mousePos = e.GetPosition(this);
            _mousePos = mousePos;
            CloseLeftMenu(mousePos);
        }

        /// <summary>
        /// Hides LeftMenu panel and updates ToggleButton.IsChecked property
        /// </summary>
        private void HideLeftMenu()
        {
            LeftMenuToggleButton.IsChecked = false;
            Grid.SetColumnSpan(LeftMenu, 1);
        }

        private void CloseLeftMenu(Point mousePos)
        {
            if (mousePos.X > Width * 0.4)
            {
                HideLeftMenu();
            }
        }

        private void OnUserControllMouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            HideLeftMenu();
        }

        public void OnNavigationPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            HideLeftMenu();
        }
    }
}