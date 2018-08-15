using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  IBillsDAO
    {
        /// <summary>
        /// 往Bill表中插入一条数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        void InsertBill(Bills bill,IDbConnection conn);
        /// <summary>
        /// 往Bill表中插入一条数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertBill(Bills bill,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新Bill表中的一条已有数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        void UpdateBill(Bills bill,IDbConnection conn);
        /// <summary>
        /// 更新Bill表中的一条已有数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateBill(Bills bill,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 删除Bill表中的一条信息
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        void DeleteBill(int id,IDbConnection conn);
        /// <summary>
        /// 删除Bill表中的一条信息
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteBill(int id,IDbConnection conn,IDbTransaction trans);
        
        /// <summary>
        /// 根据ID查找Bill中的信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Bills SelectBill(int id,IDbConnection conn);
        
        /// <summary>
        ///检索指定时间段内的Bill
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Bills> SelectBills(DateTime fromDate,DateTime toDate,IDbConnection conn);
        /// <summary>
        /// 根据指定CompanyID检索指定时间段内的Bills
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="conpanyID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        
        /// <summary>
        /// 根据条件进行模糊查询
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Bills> SearchBills(SearchBillsTemplate temp,IDbConnection conn);

    }
}
