using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class BillsItem:Base.BaseModel 
    {
        /// <summary>
        /// 药品
        /// </summary>
        public Drugs Drugs { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 实际销售价格
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 实际总价
        /// </summary>
        public decimal Money { get; set; }
    }
}
