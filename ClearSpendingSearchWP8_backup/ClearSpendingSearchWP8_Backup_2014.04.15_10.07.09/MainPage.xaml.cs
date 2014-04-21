using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClearSpendingSearchWP8.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClearSpendingSearchWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainStatic.TestLoad();
        }

        private void AboutTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void SuppliersTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SuppliesPage.xaml", UriKind.Relative));
        }

        private void ContractsTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ContractsPage.xaml", UriKind.Relative));
        }

        private void SearchTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SearchPage.xaml", UriKind.Relative));
        }

        private void CustomersTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/CustomersPage.xaml", UriKind.Relative));
        }

        private void StatisticsTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/StatisticsPage.xaml", UriKind.Relative));
        }
    }
}