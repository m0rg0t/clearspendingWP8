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
        public string Kpp { get; set; }

        public string regNum { get; set; }

        public string fullName { get; set; }

        public string inn { get; set; }
    }
}
