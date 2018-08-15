using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  IStorehouseDAO
    {
        /// <summary>
        /// 往Storehouse表中插入一条数据
        /// </summary>
        /// <param name="house"></param>
        /// <param name="conn"></param>
        void InsertStorehouse(Storehouse house,IDbConnection conn);
        /// <summary>
        /// 往Storehouse表中插入一条数据
        /// </summary>
        /// <param name="house"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertStorehouse(Storehouse house,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新Storehouse中一条已有的数据
        /// </summary>
        /// <param name="house"></param>
        /// <param name="conn"></param>
        void UpdateStorehouse(Storehouse house,IDbConnection conn);
        /// <summary>
        /// 更新Storehouse中一条已有的数据
        /// </summary>
        /// <param name="house"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateStorehouse(Storehouse house,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除Storehouse中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteStorehouse(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID删除Storehouse中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteStorehouse(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 获取Storehouse中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Storehouse> SelectAllStorehouse(IDbConnection conn);
        /// <summary>
        /// 根据ID查找对应的StroeHouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Storehouse SelectStorehouse(int id,IDbConnection conn);
        /// <summary>
        /// 根据条件进行模糊检索
        /// </summary>
        /// <param name="codeCond"></param>
        /// <param name="nameCond"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Storehouse> SearchStorehouse(string codecond, string namecond, IDbConnection conn);
    }
}
