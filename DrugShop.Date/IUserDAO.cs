using System;
using System.Collections.Generic;
using System.Text;
using DrugShop.Model;
using System.Data;

namespace DrugShop.Date
{
    public interface  IUserDAO
    {
        /// <summary>
        /// 往User表中插入一个数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        void InsertUser(User user,IDbConnection conn);
        /// <summary>
        /// 往User表中插入一个数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertUser(User user,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 在User表中更新一条已有数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        void UpdateUser(User user,IDbConnection conn);
        /// <summary>
        /// 在User表中更新一条已有数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateUser(User user,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID在User表中删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteUser(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID在User表中删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteUser(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 获取User表中所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<User> SelectAllUser(IDbConnection conn);
        /// <summary>
        /// 根据Code和password查找用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        User SelectUser(string userCode,string password,IDbConnection conn);
        
        /// <summary>
        /// 给一个用户添加一个权限
        /// </summary>
        /// <param name="RewourceID"></param>
        /// <param name="UserID"></param>
        /// <param name="trans"></param>
        void AddResourceIntoUser(int RewourceID,int UserID,IDbConnection conn);
        /// <summary>
        /// 给一个用户添加一个权限
        /// </summary>
        /// <param name="ResourceID"></param>
        /// <param name="UserID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void AddResourceIntoUser(int ResourceID,int UserID,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 移除一个用户的所有权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="trans"></param>
        void RemoveResourceIntoUser(int UserID, IDbTransaction trans);
        /// <summary>
        /// 移除一个用户的所有权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void RemoveResourceFromUser(int UserID, IDbConnection conn, IDbTransaction trans);

    }
}
