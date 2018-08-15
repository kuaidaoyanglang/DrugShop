using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class BillsType:Base.BaseModel 
    {
        /// <summary>
        /// 是否为出库操作
        /// </summary>
        public bool  IsOut { get; set; }
    }
}
