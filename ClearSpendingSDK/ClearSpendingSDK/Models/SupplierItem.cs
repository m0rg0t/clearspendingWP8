using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSpendingSDK.Models
{
    public class SuppliersItems
    {
        public SupplierItem Supplier { get; set; }
    }

    public class SupplierItem: ViewModelBase
    {
        public string Kpp { get; set; }

        public string FactualAddress { get; set; }

        public string OrganizationName { get; set; }

        public Dictionary<string, string> ContactInfo { get; set; }

        public string OrganizationForm { get; set; }

        public Dictionary<string, string> Country { get; set; }

        public string Inn { get; set; }

        public string ParticipantType { get; set; }

        public string ContactPhone { get; set; }

        public string PostAddress { get; set; }

        public string ContactFax { get; set; }
    }
}
