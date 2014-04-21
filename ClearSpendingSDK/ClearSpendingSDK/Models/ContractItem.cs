using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSpendingSDK.Models
{
    public class ContractItem
    {
        private string _id;
        /// <summary>
        /// Идентификатор контракта
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _price;
        /// <summary>
        /// Цена контракта
        /// </summary>
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _regNum;
        /// <summary>
        /// 
        /// </summary>
        public string RegNum
        {
            get { return _regNum; }
            set { _regNum = value; }
        }

        private DateTime _signDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime SignDate
        {
            get { return _signDate; }
            set { _signDate = value; }
        }

        private string _searchRank;
        /// <summary>
        /// 
        /// </summary>
        public string SearchRank
        {
            get { return _searchRank; }
            set { _searchRank = value; }
        }

        private CustomerItem _customer;
        /// <summary>
        /// Заказчик контракта
        /// </summary>
        public CustomerItem Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        /// <summary>
        /// Продукты товара
        /// </summary>
        public ProductsItems Products { get; set; }
        
        public string ProductTitle
        {
            get {
                string outString = "";
                try
                {
                    var item = Products.Product.FirstOrDefault();
                    
                    if (item != null)
                    {
                        outString = item.Name;
                    }
                    ;
                }
                catch
                {
                }
                return outString; 
            }
            private set { }
        }

        public string ShortProductTitle
        {
            get
            {
                string outString = ProductTitle;
                string[] query = outString.Split(' ').Take(10).ToArray();
                if (query.Count() < 10)
                {
                    outString = ProductTitle;
                }
                else
                {
                    outString = String.Join(" ", query) + "...";
                }
                return outString;
            }
            private set
            {
            }
        }
        

        public SuppliersItems Suppliers { get; set; }

    }

}
