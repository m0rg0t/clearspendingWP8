
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace ClearSpendingSearchWP8.Pages.SampleData
{
    public class CountriesInfoProvider : IGenericListFieldInfoProvider
    {
        public System.Collections.IEnumerable ItemsSource
        {
            get { return new List<string>() { "Country 1", "Country 2", "Country 3", "Country 4", "Country 5" }; }
        }

        public IGenericListValueConverter ValueConverter
        {
            get { return null; }
        }
    }
}
