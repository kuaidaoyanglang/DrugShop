using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  IStockDAO
    {
        /// <summary>
        /// 往Stock表中插入一条数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        void InsertStock(Stock stock,IDbConnection conn);
        /// <summary>
        /// 往Stock表中插入一条数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertStock(Stock stock,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新Stock表中一条已有的数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        void UpdateStock(Stock stock,IDbConnection conn);
        /// <summary>
        /// 更新Stock表中一条已有的数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateStock(Stock stock,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除Stock表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteStock(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID删除Stock表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteStock(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 获取Stock表中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Stock> SelectAllStocks(IDbConnection conn);
        /// <summary>
        /// 根据ID检索对应的Stock
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Stock SelectStock(int id,IDbConnection conn);
       
        /// <summary>
        /// 根据StorehouseID检索对应的Stork
        /// </summary>
        /// <param name="storehouseID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Stock> SelectStockByStorehouseID(int storehouseID,IDbConnection conn);
        /// <summary>
        /// 根据DrugsID检索对应的Stork
        /// </summary>
        /// <param name="drugsID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Stock> SelectStockByDrugsID(int drugsID,IDbConnection conn);
        /// <summary>
        /// 根据DrugID和StorehouseID查找仓库
        /// </summary>
        /// <param name="drugsID"></param>
        /// <param name="storehouseID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Stock SelectStockByDrugsAndStorehouse(int drugsID,int storehouseID, IDbConnection conn);
        /// <summary>
        /// 根据DrugID和StorehouseID查找仓库
        /// </summary>
        /// <param name="drugsID"></param>
        /// <param name="storehouseID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Stock SelectStockByDrugsAndStorehouse(int drugsID, int storehouseID, IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据CategoryID检索对应的Stock
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Stock> SelectStockByCategoryID(int categoryID,IDbConnection conn);

    }
}
