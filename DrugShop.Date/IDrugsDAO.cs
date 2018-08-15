using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  IDrugsDAO
    {
        /// <summary>
        /// 往Drugs表中插入一条数据
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="conn"></param>
        void InsertDrug(Drugs drug,IDbConnection conn);
        /// <summary>
        /// 往Drugs表中插入一条数据
        /// </summary>
        /// <param name="durg"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertDrug(Drugs durg,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新Drugs表中的一条已有数据
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="conn"></param>
        void UpdateDrug(Drugs drug,IDbConnection conn);
        /// <summary>
        /// 更新Drugs表中的一条已有数据
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateDrug(Drugs drug,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除Drugs表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteDrug(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID删除Drugs表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteDrug(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 获取Drugs表中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Drugs> SelectAllDrugs(IDbConnection conn);
        /// <summary>
        /// 根据ID查找对应的药品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Drugs SelectDrug(int id,IDbConnection conn);
        /// <summary>
        /// 根据code查找对应的药品
        /// </summary>
        /// <param name="code"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Drugs SelectDrug(string code,IDbConnection conn);
        /// <summary>
        /// 根据条件进行模糊检索
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Drugs> SearchDrugs(SearchDrugsTemplate drug,IDbConnection conn);

    }
}
