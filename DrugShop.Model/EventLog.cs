using System;
using System.Collections.Generic;
using System.Text;

namespace DrugShop.Model
{
    public class EventLog 
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Maker { get; set; }
        /// <summary>
        /// 用户操作时间
        /// </summary>
        public DateTime  MakeDate { get; set; }
        /// <summary>
        /// 操作IP地址
        /// </summary>
        public string ClientPC { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string  Remark { get; set; }
    }
}
