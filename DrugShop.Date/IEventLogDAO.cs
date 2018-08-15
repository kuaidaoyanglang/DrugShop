using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public  interface IEventLogDAO
    {
        /// <summary>
        /// 往EventLog中插入一条数据
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertEventLog(EventLog eventLog,IDbConnection conn);
       
        /// <summary>
        /// 根据ID删除EventLog中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteEventLog(int id,IDbConnection conn);
        
        /// <summary>
        /// 删除设定时间前的EventLog
        /// </summary>
        /// <param name="deadDate"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteEventLog(DateTime deadDate,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 检索一段时间内的EventLog中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<EventLog> SelectEventLog(DateTime fromDate,DateTime toDate,IDbConnection conn);
        /// <summary>
        /// 检索所有EventLog数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<EventLog> SelectAllEventLog(IDbConnection conn);
    }
}
