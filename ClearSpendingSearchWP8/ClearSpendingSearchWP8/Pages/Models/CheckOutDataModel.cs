
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;
using ClearSpendingSearchWP8.Pages.SampleData;

namespace ClearSpendingSearchWP8.Pages.Models
{
    public class CheckOutDataModel
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string CardNumber
        {
            get;
            set;
        }

        public DateTime? ExpirationDate
        {
            get;
            set;
        }

        public string SecurityCode
        {
            get;
            set;
        }

        [GenericListEditor(typeof(CountriesInfoProvider))]
        public string Country
        {
            get;
            set;
        }

        public string StreetAddress
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Region
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }
    }
}
