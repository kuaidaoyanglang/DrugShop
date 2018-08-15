using System;
using System.Collections.Generic;
using System.Text;
using DrugShop.Date;
using DrugShop.Model;

namespace DrugShop.Core
{
    public class LogServices
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            LogServices.WriteLog(message,"错误！！");
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            LogServices.WriteLog(message, "操作！！");
        }
        /// <summary>
        /// 记录DEBUG日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            LogServices.WriteLog(message, "DEBUG");
        }
        private static void WriteLog(string message,string remark)
        {
            EventLog log = new EventLog();
            log.ClientPC = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[0].ToString();
            log.Message = message;
            log.MakeDate = DateTime.Now;
            log.Remark = remark;
            try
            {
                log.Maker = PermissionService.GetCurrentUser().ToString();
            }
            catch (Exception)
            {

            }
            IEventLogDAO dao = DAOFactory.Instance.CreateEventLogDAO();
            dao.InsertEventLog(log, DAOFactory.Instance.OpenConnection());
        }
    }
}
