using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Reflection;

namespace ClearSpendingSDK.Models
{
    public class SearchParamItem
    {
        public SearchParamItem()
        {
            Contract = new SearchParamContractItem();
            Supplier = new SearchParamSupplierItem();
            Customer = new SearchParamCustomerItem();
        }

        public enum SearchType
        {
            Contracts,
            Suppliers,
            Customers
        }

        public SearchType CurrentType = SearchType.Contracts;

        public SearchParamContractItem Contract { get; set; }
        public SearchParamSupplierItem Supplier { get; set; }
        public SearchParamCustomerItem Customer { get; set; }

        public override string ToString()
        {
            switch (CurrentType) {
                case SearchType.Contracts:
                    return Contract.ToString();
                    break;
                case SearchType.Suppliers:
                    return Supplier.ToString();
                    break;
                case SearchType.Customers:
                    return Customer.ToString();
                    break;
                default:
                    return Contract.ToString();
                    break;
            }
            return Contract.ToString();
        }
    }

    public class SearchParamCustomerItem : ViewModelBase
    {

    }

    public class SearchParamSupplierItem : ViewModelBase
    {

    }

    public class SearchParamContractItem: ViewModelBase
    {
        /// <summary>
        /// Текст для поиска по предмету контракта
        /// </summary>
        public string Productsearch { get; set; }
        /// <summary>
        /// Номер реестровой записи контракта
        /// </summary>
        public string Regnum { get; set; }
        /// <summary>
        /// ИНН заказчика
        /// </summary>
        public string Customerinn { get; set; }
        /// <summary>
        /// КПП заказчика
        /// </summary>
        public string Customerkpp { get; set; }
        /// <summary>
        /// КПП поставщика
        /// </summary>
        public string Supplierkpp { get; set; }
        

        private int _page = 1;
        /// <summary>
        /// Страница
        /// </summary>
        public int Page
        {
            get { return _page; }
            set { _page = value; }
        }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        private int _perpage = 10;
        public int Perpage
        {
            get { return _perpage; }
            set { _perpage = value; }
        }

        private DateTime _daterangeStart = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DaterangeStart
        {
            get { return _daterangeStart; }
            set { _daterangeStart = value; }
        }

        private DateTime _daterangeEnd = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DaterangeEnd
        {
            get { return _daterangeEnd; }
            set { _daterangeEnd = value; }
        }
        
        

        public override string ToString()
        {
            string outString = "?";
            if (Productsearch != null)
            {
                outString = outString + "productsearch=" + Productsearch + "&";
            };
            outString = outString + "page=" + Page + "&";
            outString = outString + "perpage=" + Perpage + "&";
            outString = outString.Trim('&');
            return outString;
        }
    }
}
