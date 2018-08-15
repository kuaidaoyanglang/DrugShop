using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;

namespace DrugShop.Date
{
    public interface  ICompanyDAO
    {
        /// <summary>
        /// 插入一条Company信息
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        void InsertCompany(Company company,IDbConnection conn);
        /// <summary>
        /// 插入一条Company信息
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertCompany(Company company,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 更新一条已有的Company信息
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        void UpdateCompany(Company company, IDbConnection conn);
        /// <summary>
        /// 更新一条已有的Company信息
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateCompany(Company company,IDbConnection conn,IDbTransaction trans);
        /// <summary>
        /// 根据ID删除一条Company信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteCompany(int id, IDbConnection conn);
        /// <summary>
        /// 根据ID删除一条Company信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteCompany(int id, IDbConnection conn, IDbTransaction trans);
        /// <summary>
        /// 根据ID进行查询对应的Company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Company SelectCompany(int id,IDbConnection conn);
        /// <summary>
        /// 获取所Company中的所有数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Company> SelectAllCompanies(IDbConnection conn);
        /// <summary>
        /// 根据给定ConpanyType查询满足条件的数据
        /// </summary>
        /// <param name="companyTtpe"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Company> SelectCompanies(CompanyType companyTtpe,IDbConnection conn);
        /// <summary>
        /// 根据条件进行模糊检索
        /// </summary>
        /// <param name="codeCond"></param>
        /// <param name="nameCond"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Company> SearchCompanies(string codeCond,string nameCond,IDbConnection conn);
    }
}
