using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    #region CompanyType枚举
    //public enum CompanyType
    //{
    //    /// <summary>
    //    /// 供应商
    //    /// </summary>
    //    Supplier,
    //    /// <summary>
    //    /// 客户
    //    /// </summary>
    //    Customer,
    //}
    #endregion
    public class Company:Base.BaseModel 
    {
        public CompanyType  CompanyType { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1}",this.Code,this.Name);
        }
    }
}
