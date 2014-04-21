using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ClearSpendingSDK.Models
{
    public class BudgetLevelItem: ViewModelBase
    {
        private string _budgetLevelName;
        /// <summary>
        /// 
        /// </summary>
	    public string BudgetLevelName
	    {
		    get { return _budgetLevelName;}
		    set { _budgetLevelName = value;}
	    }

        private string _id;
        /// <summary>
        /// 
        /// </summary>
	    public string Id
	    {
		    get { return _id;}
		    set { _id = value;}
	    }
	
        private string _budgetLevelCode;
        /// <summary>
        /// 
        /// </summary>
	    public string BudgetLevelCode
	    {
		    get { return _budgetLevelCode;}
		    set { _budgetLevelCode = value;}
	    }
    }
}
