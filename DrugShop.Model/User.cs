using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class User:Base.BaseModel 
    {
        public string  Password { get; set; }
        public bool IsAdmin { get; set; }
        public override string ToString()
        {
            return string.Format("{0}({1})",this.Code,this.Name);
        }
    }
}
