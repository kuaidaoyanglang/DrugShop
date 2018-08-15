using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model.Base
{
    public abstract class BaseModel
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual bool Actived { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        public virtual string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType() && !obj.GetType().IsSubclassOf(this.GetType()))
            {
                return false;
            }
            BaseModel that = (BaseModel)obj;
            return this.ID == that.ID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
