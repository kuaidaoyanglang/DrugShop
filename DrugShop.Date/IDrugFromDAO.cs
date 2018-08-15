using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
     public interface  IDrugFromDAO
    {
         /// <summary>
         /// 往DrugFrom中新增一条信息
         /// </summary>
         /// <param name="category"></param>
         /// <param name="conn"></param>
         void InsertDrugFrom(DrugFrom from,IDbConnection conn);
         /// <summary>
         /// 往DrugFrom中新增一条信息
         /// </summary>
         /// <param name="category"></param>
         /// <param name="conn"></param>
         /// <param name="trans"></param>
         void InsertDrugFrom(DrugFrom from,IDbConnection conn,IDbTransaction trans);
         /// <summary>
         /// 更新DrugFrom中的一条信息
         /// </summary>
         /// <param name="category"></param>
         /// <param name="conn"></param>
         void UpdateDrugFrom(DrugFrom from,IDbConnection conn);
         /// <summary>
         /// 更新DrugFrom中的一条信息
         /// </summary>
         /// <param name="category"></param>
         /// <param name="conn"></param>
         /// <param name="trans"></param>
         void UpdateDrugFrom(DrugFrom from,IDbConnection conn,IDbTransaction trans);
         /// <summary>
         /// 根据ID删除DrugFrom中的一条信息
         /// </summary>
         /// <param name="id"></param>
         /// <param name="conn"></param>
         void DeleteDrugFrom(int id,IDbConnection conn);
         /// <summary>
         /// 根据ID删除DrugFrom中的一条信息
         /// </summary>
         /// <param name="id"></param>
         /// <param name="conn"></param>
         /// <param name="trans"></param>
         void DeleteDrugFrom(int id,IDbConnection conn,IDbTransaction trans);
         /// <summary>
         /// 获取DrugFrom中的所有信息
         /// </summary>
         /// <param name="conn"></param>
         /// <returns></returns>
         List<DrugFrom> SelectAllDrugFrom(IDbConnection conn);
         /// <summary>
         /// 根据ID检索DrugFrom
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
         DrugFrom SelectDrugFrom(int id,IDbConnection conn);
         List<DrugFrom> SearchDrugFrom(string searchCond,IDbConnection conn);
    }
}
