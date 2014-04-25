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

        //public string FactualAddress { get; set; }

        public string OrganizationName { get; set; }

        public Dictionary<string, string> ContactInfo { get; set; }

        public string OrganizationForm { get; set; }

        public Dictionary<string, string> Country { get; set; }

        public string Inn { get; set; }

        public string ParticipantType { get; set; }

        private string _factualAddress;
        /// <summary>
        /// 
        /// </summary>
        public string FactualAddress
        {
            get
            {
                if (String.IsNullOrEmpty(_factualAddress))
                {
                    _factualAddress = "не указан";
                }
                return _factualAddress;
            }
            set
            {
                _factualAddress = value;
                RaisePropertyChanged("FactualAddress");
            }
        }

        private string _postAddress;
        /// <summary>
        /// 
        /// </summary>
        public string PostAddress
        {
            get
            {
                if (String.IsNullOrEmpty(_postAddress))
                {
                    _postAddress = "не указан";
                }
                return _postAddress;
            }
            set
            {
                _postAddress = value;
                RaisePropertyChanged("PostAddress");
            }
        }

        private string _contactFax;
        /// <summary>
        /// 
        /// </summary>
        public string ContactFax
        {
            get
            {
                if (String.IsNullOrEmpty(_contactFax))
                {
                    _contactFax = "не указан";
                }
                return _contactFax;
            }
            set
            {
                _contactFax = value;
                RaisePropertyChanged("ContactFax");
            }
        }
        

        private string _contactPhone = "";
        /// <summary>
        /// 
        /// </summary>
        public string ContactPhone
        {
            get
            {
                if (String.IsNullOrEmpty(_contactPhone))
                {
                    _contactPhone = "не указан";
                }
                return _contactPhone;
            }
            set
            {
                _contactPhone = value;
                RaisePropertyChanged("ContactPhone");
            }
        }
        
    }
}
