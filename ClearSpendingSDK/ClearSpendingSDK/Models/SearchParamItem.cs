using System;
using GalaSoft.MvvmLight;

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
                    //break;
                case SearchType.Suppliers:
                    return Supplier.ToString();
                    //break;
                case SearchType.Customers:
                    return Customer.ToString();
                    //break;
                default:
                    return Contract.ToString();
                    //break;
            }
            //return Contract.ToString();
        }
    }

    public class SearchParamCustomerItem : ViewModelBase
    {
        public override string ToString()
        {
            string outString = "?";
            if (!String.IsNullOrEmpty(Namesearch))
            {
                outString = outString + "namesearch=" + Namesearch + "&";
            }
            if (!String.IsNullOrEmpty(Spzregnum))
            {
                outString = outString + "spzregnum=" + Spzregnum + "&";
            }
            if (!String.IsNullOrEmpty(Inn))
            {
                outString = outString + "inn=" + Inn + "&";
            }
            if (!String.IsNullOrEmpty(Kpp))
            {
                outString = outString + "kpp=" + Kpp + "&";
            }
            if (!String.IsNullOrEmpty(Okpo))
            {
                outString = outString + "okpo=" + Okpo + "&";
            }
            if (!String.IsNullOrEmpty(Okved))
            {
                outString = outString + "okved=" + Okved + "&";
            }
            if (!String.IsNullOrEmpty(Name))
            {
                outString = outString + "name=" + Name + "&";
            }
            if (!String.IsNullOrEmpty(Ogrn))
            {
                outString = outString + "ogrn=" + Ogrn + "&";
            }
            if (!String.IsNullOrEmpty(Okogu))
            {
                outString = outString + "okogu=" + Okogu + "&";
            }
            if (!String.IsNullOrEmpty(Okato))
            {
                outString = outString + "okato=" + Okato + "&";
            }
            if (!String.IsNullOrEmpty(Subordination))
            {
                outString = outString + "subordination=" + Subordination + "&";
            }
            if (!String.IsNullOrEmpty(Orgtype))
            {
                outString = outString + "orgtype=" + Orgtype + "&";
            }
            if (!String.IsNullOrEmpty(Regioncode))
            {
                outString = outString + "regioncode=" + Regioncode + "&";
            }
            if (!String.IsNullOrEmpty(Kladregion))
            {
                outString = outString + "kladregion=" + Kladregion + "&";
            }
            outString = outString + "page=" + Page + "&";
            outString = outString + "perpage=" + Perpage + "&";
            outString = outString.Trim('&');
            return outString;
        }

        /// <summary>
        /// Текст для поиска по названию
        /// Example: больница
        /// </summary>
        public string Namesearch { get; set; }
        /// <summary>
        /// Уникальный идентификатор заказчика (из СПЗ — сводного перечня заказчиков)
        /// Example: 03133001560
        /// </summary>
        public string Spzregnum { get; set; }
        /// <summary>
        /// ИНН заказчика
        /// Example: 1811003621
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// КПП заказчика
        /// Example: 183801001
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// ОКПО заказчика
        /// Example: 54469414
        /// </summary>
        public string Okpo { get; set; }
        /// <summary>
        /// ОКВЭД заказчика
        /// Example: 80.21.2
        /// </summary>
        public string Okved { get; set; }
        /// <summary>
        /// Полное и точное назавание заказчика
        /// Example: Муниципальное бюджетное общеобразовательное учреждение "Арзамасцевская средняя общеобразовательная школа"
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ОГРН заказчика
        /// Example: 1021800860487
        /// </summary>
        public string Ogrn { get; set; }
        /// <summary>
        /// Код ОКОГУ заказчика
        /// Example: 4210007
        /// </summary>
        public string Okogu { get; set; }
        /// <summary>
        /// ОКАТО заказчика
        /// Example: 94222811000
        /// </summary>
        public string Okato { get; set; }
        /// <summary>
        /// Код уровня заказчика: федеральный, субъекта федерации, местное самоуправление
        /// Example: 3
        /// </summary>
        public string Subordination { get; set; }
        /// <summary>
        /// Код организационной форма, типа организации
        /// Example: 3
        /// </summary>
        public string Orgtype { get; set; }
        /// <summary>
        /// Код региона
        /// Example: 18
        /// </summary>
        public string Regioncode { get; set; }
        /// <summary>
        /// Код региона по КЛАДР
        /// Example: 18000000000
        /// </summary>
        public string Kladregion { get; set; }

        private int _page = 1;
        /// <summary>
        /// Номер страницы выборки
        /// Example: 1
        /// </summary>
	    public int Page
	    {
		    get { return _page;}
                set
                {
                    _page = value;
                }
	    }

        private int _perpage;
        /// <summary>
        /// Число элементов выводимых за раз
        /// Example: 50
        /// </summary>
	    public int Perpage
	    {
		    get { return _perpage;}
		    set { _perpage = value;}
	    }
    }

    public class SearchParamSupplierItem : ViewModelBase
    {
        public SearchParamSupplierItem()
        {
        }
        /// <summary>
        /// Текст для поиска по названию
        /// Example: сервис
        /// </summary>
        public string Namesearch { get; set; }
        /// <summary>
        /// ИНН поставщика
        /// Example: 2320143971
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// КПП поставщика
        /// Example: 231901001
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// Код региона
        /// Example: 23
        /// </summary>
        public string Regioncode { get; set; }
        /// <summary>
        /// Организационаая форма поставщика
        /// Example: OOO
        /// </summary>
        public string Orgform { get; set; }
        /// <summary>
        /// Наличие поставщика в реестре недобросовестных поставщиков
        /// Example: false
        /// </summary>
        public bool? Inblacklist { get; set; }

        private int _page = 1;
        /// <summary>
        /// Номер страницы выборки
        /// Example: 1
        /// </summary>
	    public int Page
	    {
            get
            {
                return _page;
            }
                set
                {
                    _page = value;
                }
	    }

        private int _perpage = 50;
        /// <summary>
        /// Число элементов выводимых за раз
        /// Example: 50
        /// </summary>
	    public int Perpage
	    {
		    get { return _perpage;}
		    set { _perpage = value;}
	    }

        public override string ToString()
        {
            string outString = "?";
            if (!String.IsNullOrEmpty(Namesearch))
            {
                outString = outString + "namesearch=" + Namesearch + "&";
            }
            if (!String.IsNullOrEmpty(Inn))
            {
                outString = outString + "inn=" + Inn + "&";
            }
            if (!String.IsNullOrEmpty(Kpp))
            {
                outString = outString + "kpp=" + Kpp + "&";
            }
            if (!String.IsNullOrEmpty(Regioncode))
            {
                outString = outString + "regioncode=" + Regioncode + "&";
            }
            if (!String.IsNullOrEmpty(Orgform))
            {
                outString = outString + "orgform=" + Orgform + "&";
            }
            if (Inblacklist!=null)
            {
                outString = outString + "inblacklist=" + Inblacklist.ToString() + "&";
            }
            outString = outString + "page=" + Page + "&";
            outString = outString + "perpage=" + Perpage + "&";
            outString = outString.Trim('&');
            return outString;
        }
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

        private string _customerregion;
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public string Customerregion
        {
            get { return _customerregion; }
            set { _customerregion = value; }
        }

        /*private List<string> _regionItems = new List<string>();
        /// <summary>
        /// Список регионов
        /// </summary>
        public List<string> RegionItems
        {
            get { return _regionItems; }
            set
            {
                _regionItems = value;
                RaisePropertyChanged("RegionItems");
            }
        }*/


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
            if (!String.IsNullOrEmpty(Productsearch))
            {
                outString = outString + "productsearch=" + Productsearch + "&";
            }
            if (!String.IsNullOrEmpty(Regnum))
            {
                outString = outString + "regnum=" + Regnum + "&";
            }
            if (!String.IsNullOrEmpty(Customerinn))
            {
                outString = outString + "customerinn=" + Customerinn + "&";
            }
            if (!String.IsNullOrEmpty(Customerkpp))
            {
                outString = outString + "customerkpp=" + Customerkpp + "&";
            }
            if (!String.IsNullOrEmpty(Supplierkpp))
            {
                outString = outString + "supplierkpp=" + Supplierkpp + "&";
            }
            if (!String.IsNullOrEmpty(Customerregion))
            {
                outString = outString + "customerregion=" + Customerregion + "&";
            }
            if ((DaterangeStart.Date != DateTime.Now.Date) || 
                (DaterangeEnd.Date != DateTime.Now.Date))
            {
                outString = outString + "daterange=" + DaterangeStart.ToString("dd.MM.yy") +
                    "-" + DaterangeEnd.ToString("dd.MM.yy") + "&";
            }
            outString = outString + "page=" + Page + "&";
            outString = outString + "perpage=" + Perpage + "&";
            outString = outString.Trim('&');
            return outString;
        }
    }
}
