using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class Stock:Base.BaseModel 
    {
        public override string  Code 
        { 
            get{
                throw new NotSupportedException("该属性不被支持");
            } 
            set{
                throw new NotSupportedException("该属性不被支持");
            } 
        }
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
        public Drugs  Drug { get; set; }
        public Storehouse  Storehouse { get; set; }
        public int Count { get; set; }

    }
}
