using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSpendingSDK.Models
{
    public class ProductsItems
    {
        public ProductsItems()
        {
            Product = new List<ProductItem>();
        }
        public List<ProductItem> Product { get; set; }
    }

    public class ProductItem: ViewModelBase
    {
        private string _name;
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ShortName
        {
            private set { }
            get
            {
                string outString = Name;
                string[] query = outString.Split(' ').Take(10).ToArray();
                if (query.Count() < 10)
                {
                    outString = Name;
                }
                else
                {
                    outString = String.Join(" ", query)+"...";
                }
                return outString;
            }
        }

        private Dictionary<string, string> _okei;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> OKEI
        {
            get { return _okei; }
            set { _okei = value; }
        }

        private Dictionary<string, string> _OKDP;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> OKDP
        {
            get { return _OKDP; }
            set { _OKDP = value; }
        }

        private double _price;
        //Цена товара
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _sid;
        /// <summary>
        /// 
        /// </summary>
        public string Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private string _text;
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _sum;
        /// <summary>
        /// 
        /// </summary>
        public string Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }

        private string _quantity;
        /// <summary>
        /// Количество товаров
        /// </summary>
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
                        
        
    }
}
