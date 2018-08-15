using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class Bills:Base.BaseModel 
    {
        /// <summary>
        /// 从BaseModel继承而来，在该类中不支持
        /// </summary>
        public override string Name
        {
            get
            {
                throw new NotSupportedException("该属性不被支持");
            }
            set
            {
                throw new NotSupportedException("该属性不被支持");
            }
        }
        private List<BillsItem>  _Items=new List<BillsItem>(); 
        public List<BillsItem> Items 
        { 
            get 
            {
                return _Items;
            } 
        }
        public Storehouse  Storehouse { get; set; }
        public BillsType  BillsType { get; set; }
        public int Count { get; set; }
        public DateTime  MakeDate { get; set; }
        public DateTime  CreateDate { get; set; }
        public string  Maker { get; set; }
        public Company  Company { get; set; }
        /// <summary>
        /// 是否被冲销
        /// </summary>
        public bool IsCancelOut { get; set; }
        /// <summary>
        /// 是否为红票
        /// </summary>
        public bool IsRedBill { get; set; }
        /// <summary>
        /// 票据总金额
        /// </summary>
        public decimal  TotalMoney
        {
            get 
            {
                decimal result = 0;
                foreach (BillsItem item in _Items)
                {
                    result += item.Money;
                }
                return result;
            }
        }
    }
}
