using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class Storehouse:Base.BaseModel 
    {
        public override string ToString()
        {
            return String.Format("{0} {1}",this.Code,this.Name);
        }
    }
}
