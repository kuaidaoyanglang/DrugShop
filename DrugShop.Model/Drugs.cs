using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class Drugs:Base.BaseModel 
    {
        /// <summary>
        /// 产地
        /// </summary>
        public DrugFrom  From { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public DrugCategory  Category { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string  Standard { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
    }
}
