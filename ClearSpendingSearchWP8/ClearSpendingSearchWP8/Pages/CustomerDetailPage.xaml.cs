using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClearSpendingSearchWP8.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Threading.Tasks;

namespace ClearSpendingSearchWP8.Pages
{
    public partial class CustomerDetailPage : PhoneApplicationPage
    {
        public CustomerDetailPage()
        {
            InitializeComponent();
        }

        List<GeoCoordinate> MyCoordinates = new List<GeoCoordinate>();
        
        Geoposition MyGeoPosition = null;

        private async Task<bool> GetCoordinates()
        {
            // Get the phone's current location.
            Geolocator MyGeolocator = new Geolocator();
            MyGeolocator.DesiredAccuracyInMeters = 5;
            
            try
            {
                MyGeoPosition = await MyGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));
                MyCoordinates.Add(new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude));
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Location is disabled in phone settings or capabilities are not checked.");
            }
            catch (Exception ex)
            {
                // Something else happened while acquiring the location.
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        RouteQuery MyQuery = null;
        GeocodeQuery Mygeocodequery = null;

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainStatic.Loading = true;
            await ViewModelLocator.MainStatic.SearchItem.CurrentCustomerItem.LoadFullCustomerData();
            ViewModelLocator.MainStatic.Loading = false;

            await GetCoordinates();
            Mygeocodequery = new GeocodeQuery();
            Mygeocodequery.SearchTerm = ViewModelLocator.MainStatic.SearchItem.CurrentCustomerItem.Details.PostalAddress;
            //Mygeocodequery.GeoCoordinate = new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude);
            Mygeocodequery.GeoCoordinate = new GeoCoordinate(0, 0);

            Mygeocodequery.QueryCompleted += Mygeocodequery_QueryCompleted;
            Mygeocodequery.QueryAsync();
        }

        void Mygeocodequery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            if (e.Error == null)
            {
                try
                {
                    MyQuery = new RouteQuery();
                    MyCoordinates.Add(e.Result[0].GeoCoordinate);
                    MyQuery.Waypoints = MyCoordinates;
                    MyQuery.QueryCompleted += MyQuery_QueryCompleted;
                    MyQuery.QueryAsync();
                    Mygeocodequery.Dispose();
                }
                catch { } 
            }
        }

        void MyQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {
            if (e.Error == null)
            {
                try
                {
                    Route MyRoute = e.Result;
                    MapRoute MyMapRoute = new MapRoute(MyRoute);
                    MyMap.AddRoute(MyMapRoute);
                    MyQuery.Dispose();
                }
                catch
                {
                }
                
            }
        }
    }
}