using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public  interface  IResourceDAO
    {
        /// <summary>
        /// 往Resource表中插入一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        void InsertResource(Resource res,IDbConnection conn);
        /// <summary>
        /// 往Resource表中插入一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertResource(Resource res,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 修改Resource表中的一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        void UpdateResource(Resource res,IDbConnection conn);
        /// <summary>
        /// 修改Resource表中的一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateResource(Resource res,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 删除Resource表中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteResource(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 删除Resource表中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteResource(int id,IDbConnection conn);
        /// <summary>
        /// 获取所有Resource信息
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Resource> SelectAllResource(IDbConnection conn);
        /// <summary>
        /// 获取指定用户所能访问的资源列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Resource> SelectResource(int userId, IDbConnection conn);
       
    }
}
