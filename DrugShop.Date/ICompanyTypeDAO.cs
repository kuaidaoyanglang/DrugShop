using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface ICompanyTypeDAO
    {
        /// <summary>
        /// 往CompanyType表中新增一条数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        void InsertCompanyType(CompanyType type,IDbConnection conn);
        /// <summary>
        /// 往CompanyType表中新增一条数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertCompanyType(CompanyType type,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新CompanyType表中一条已有的数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        void UpdateCompanyType(CompanyType type,IDbConnection conn);
        /// <summary>
        /// 更新CompanyType表中一条已有的数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateCompanyType(CompanyType type,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除CompanyType表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteCompanyType(int id,IDbConnection conn);
        /// <summary>
        /// 根据ID删除CompanyType表中的一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteCompanyType(int id,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 检索CompanyType表中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<CompanyType> SelectAllCompanyType(IDbConnection conn);
        /// <summary>
        /// 根据ID检索对应的CompanyType
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        CompanyType SelectCompanyType(int id,IDbConnection conn);
        
        /// <summary>
        /// 根据条件进行模糊检索
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<CompanyType> SearchCompanyType(string code,string name,IDbConnection conn);
    }
}
