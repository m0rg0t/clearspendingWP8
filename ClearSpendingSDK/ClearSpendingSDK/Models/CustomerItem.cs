using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSpendingSDK.Models
{
    public class CustomerItem: ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ContractsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ContractsSum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SearchRank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
    }
}
