using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  IBillsTypeDAO
    {
        /// <summary>
        /// 往BillsType表中插入一条数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        void InsertBillsType(BillsType type,IDbConnection conn);
        /// <summary>
        /// 往BillsType表中插入一条数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertBillsType(BillsType type,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新BillsType表中的已有的一条数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        void UpdateBillsType(BillsType type,IDbConnection conn);
        /// <summary>
        /// 更新BillsType表中的已有的一条数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateBillsType(BillsType type,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除BillsType表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteBillsType(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID删除BillsType表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteBillsType(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 获取BillsType表中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<BillsType> SelectAllBillsType(IDbConnection conn);
        /// <summary>
        /// 根据ID查找对应的BillsType
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        BillsType SelectBillsType(int id,IDbConnection conn);
        /// <summary>
        /// 根据条件进行模糊检索
        /// </summary>
        /// <param name="codeCond"></param>
        /// <param name="nameCond"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<BillsType> SearchBillsType(string nameCond,IDbConnection conn); 
    }
}
