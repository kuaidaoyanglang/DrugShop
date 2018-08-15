using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class SearchBillsTemplate
    {
        public DateTime  FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CompanyCond { get; set; }
        public string  Custom { get; set; }
        public bool? Actived { get; set; }
        public string  DrugsName { get; set; }
        public string DrugsFrom { get; set; }
        public string  DrugsCategory { get; set; }
        public string  BillMaker { get; set; }
    }
}
