using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  IDrugCategoryDAO
    {
        /// <summary>
        /// 往DrugCategory中插入一条信息
        /// </summary>
        /// <param name="category"></param>
        /// <param name="conn"></param>
        void InsertDrugCategory(DrugCategory category,IDbConnection conn);
        /// <summary>
        /// 往DrugCategory表中插入一条信息
        /// </summary>
        /// <param name="category"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertDrugCategory(DrugCategory category,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新一条DrugCategory信息
        /// </summary>
        /// <param name="category"></param>
        /// <param name="conn"></param>
        void UpdateDrugCategory(DrugCategory category,IDbConnection conn);
        /// <summary>
        /// 更新一条DrugCategory信息
        /// </summary>
        /// <param name="category"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateDrugCategory(DrugCategory category,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除一条DrugCategory信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteDrugCategory(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID删除一条DrugCategory信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteDrugCategory(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 获取所有的DrugCategory信息
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<DrugCategory> SelectAllDrugCategory(IDbConnection conn);
        /// <summary>
        /// 根据ID检索DrugCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DrugCategory SelectDrugCategory(int id, IDbConnection conn);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <returns></returns>
        List<DrugCategory> SearchDrugCategory(string searchCond,IDbConnection conn);
    }
}
