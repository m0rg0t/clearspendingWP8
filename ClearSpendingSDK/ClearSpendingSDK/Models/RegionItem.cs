using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ClearSpendingSDK.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionItem: ViewModelBase
    {
        public int SubjectCode { get; set; }
        public string Name { get; set; }
        public string CodeOKATO { get; set; }
        public string CodeKLADR { get; set; }
        public string CodeISO3166 { get; set; }
        public string Id { get; set; }
    }
}
