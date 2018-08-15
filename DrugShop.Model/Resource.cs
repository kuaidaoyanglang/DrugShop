using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class Resource:Base.BaseModel 
    {
        public Resource()
        { }
        public Resource(string name)
        {
            this.Code = name;
            this.Name = name;
        }
    }
}
