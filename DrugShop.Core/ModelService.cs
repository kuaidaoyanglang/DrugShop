using System;
using System.Collections.Generic;
using System.Text;
using DrugShop.Model;
using System.Data;
using DrugShop.Date;

namespace DrugShop.Core
{
    public  class ModelService
    {
        #region  关联单位
        /// <summary>
        /// 增加一个关联单位（客户/供货商）
        /// </summary>
        /// <param name="company">创建的单位</param>
        /// <param name="creator">创建人</param>
        public void CreateCompany(Company company,string creator)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                dao.InsertCompany(company,conn);
            }
        }
        /// <summary>
        /// 保存一个修改的关联单位（客户/供货商）
        /// </summary>
        /// <param name="company">修改的关联单位</param>
        /// <param name="Modifier">修改人</param>
        public void SaveCompany(Company company,string Modifier)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                dao.UpdateCompany(company,conn);
            }
        }
        /// <summary>
        /// 删除一个关联单位（客户/供货商）
        /// </summary>
        /// <param name="company">客户/供货商</param>
        /// <param name="deleter">删除人</param>
        public void DeleteCompany(Company company, string deleter)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                dao.DeleteCompany(company.ID,conn);
            }
        }
        /// <summary>
        /// 获取所有单位（客户/供货商）
        /// </summary>
        /// <returns>所有单位（客户/供货商）</returns>
        public List<Company> GetAllCompanies()
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                return dao.SelectAllCompanies(conn);
            }
        }
        /// <summary>
        /// 根据ID获取关联单位（客户/供应商）
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Company RetrieveCompany(int id)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                return dao.SelectCompany(id,conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<Company> SearchCompanies(string searchCond)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                return dao.SearchCompanies(searchCond,searchCond,conn);
            }
        }
        #endregion
        #region 关联单位类别
        /// <summary>
        /// 新增一条关联单位类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="creator"></param>
        public void CreateCompanyType(CompanyType type,string creator)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyTypeDAO dao = DAOFactory.Instance.CreateCompanyTypeDAO();
                dao.InsertCompanyType(type,conn);
            }
        }
        /// <summary>
        /// 保存修改过的关联单位类型信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Modifier"></param>
        public void SaveCompanyType(CompanyType type,string Modifier)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyTypeDAO dao = DAOFactory.Instance.CreateCompanyTypeDAO();
                dao.UpdateCompanyType(type,conn);
            }
        }
        /// <summary>
        /// 删除一条关联单位类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleter"></param>
        public void DeleteCompanyType(int id,string deleter)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyTypeDAO dao = DAOFactory.Instance.CreateCompanyTypeDAO();
                dao.DeleteCompanyType(id,conn);
            }
        }
        /// <summary>
        /// 获取所有关联单位类型信息
        /// </summary>
        /// <returns></returns>
        public List<CompanyType> GetAllCompanyTypes()
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyTypeDAO dao = DAOFactory.Instance.CreateCompanyTypeDAO();
                return dao.SelectAllCompanyType(conn);
            }
        }
        /// <summary>
        /// 根据ID查找一个关联单位类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyType GetCompanyType(int id)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                ICompanyTypeDAO dao = DAOFactory.Instance.CreateCompanyTypeDAO();
                return dao.SelectCompanyType(id,conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<CompanyType> SearchCompanyType(string searchCond)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyTypeDAO dao = DAOFactory.Instance.CreateCompanyTypeDAO();
                return dao.SearchCompanyType(searchCond, searchCond, conn);
            }
        }
        #endregion
        #region 药品
        /// <summary>
        /// 增加一个药品信息
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="creator"></param>
        public void CreateDrug(Drugs drug,string creator)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                dao.InsertDrug(drug,conn);
            }
        }
        /// <summary>
        /// 保存修改过的药品信息
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="Modifier"></param>
        public void SaveDrug(Drugs drug,string Modifier)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                dao.UpdateDrug(drug ,conn );
            }
        }
        /// <summary>
        /// 删除一个药品信息
        /// </summary>
        /// <param name="drug"></param>
        /// <param name="Deleter"></param>
        public void DeleteDrug(Drugs drug, string Deleter)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                dao.DeleteDrug(drug.ID,conn);
            }
        }
        /// <summary>
        /// 获取所有药品信息
        /// </summary>
        /// <returns></returns>
        public List<Drugs> GetAllDrugs()
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                return dao.SelectAllDrugs(conn);
            }
        }
        /// <summary>
        /// 根据ID查找一个药品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Drugs RetrieveDrug(int id)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                return dao.SelectDrug(id,conn);
            }
        }
        /// <summary>
        /// 获取指定编码的药品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Drugs GetDrugsByCode(string code)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                return dao.SelectDrug(code,conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<Drugs> SearchDrugs(string searchCond)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDrugsDAO dao = DAOFactory.Instance.CreateDrugsDAO();
                SearchDrugsTemplate template = new SearchDrugsTemplate();
                template.Code = searchCond;
                template.Name = searchCond;
                template.From = searchCond;
                template.Category = searchCond;
                return dao.SearchDrugs(template, conn);
            }
        }
        #endregion
        #region 药品种类
        /// <summary>
        /// 增加一个药品种类
        /// </summary>
        /// <param name="category"></param>
        /// <param name="creator"></param>
        public void CreateDrugCategory(DrugCategory category,string creator)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugCategoryDAO dao = DAOFactory.Instance.CreateDrugCategoryDAO();
                dao.InsertDrugCategory(category,conn);
            }
        }
        /// <summary>
        /// 保存修改的药品种类
        /// </summary>
        /// <param name="category"></param>
        /// <param name="modifier"></param>
        public void SaveDrugCategory(DrugCategory category, string modifier)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugCategoryDAO dao = DAOFactory.Instance.CreateDrugCategoryDAO();
                dao.UpdateDrugCategory(category,conn);
            }
        }
        /// <summary>
        /// 删除一条药品种类
        /// </summary>
        /// <param name="category"></param>
        /// <param name="deleter"></param>
        public void DeleteDrugCategory(DrugCategory category, string deleter)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugCategoryDAO dao = DAOFactory.Instance.CreateDrugCategoryDAO();
                dao.DeleteDrugCategory(category.ID,conn);
            }
        }
        /// <summary>
        /// 获取所有药品种类
        /// </summary>
        /// <returns></returns>
        public List<DrugCategory> GetAllDrugCategory()
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugCategoryDAO dao = DAOFactory.Instance.CreateDrugCategoryDAO();
                return dao.SelectAllDrugCategory(conn);
            }
        }
        /// <summary>
        /// 根据ID查找相应的药品种类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DrugCategory RetrieveDrugCategory(int id)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugCategoryDAO dao = DAOFactory.Instance.CreateDrugCategoryDAO();
                return dao.SelectDrugCategory(id,conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<DrugCategory> SearchDrugCategory(string searchCond)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDrugCategoryDAO dao = DAOFactory.Instance.CreateDrugCategoryDAO();
                return dao.SearchDrugCategory(searchCond, conn);
            }
        }
        #endregion
        #region 产地
        /// <summary>
        /// 增加一个药品产地
        /// </summary>
        /// <param name="from"></param>
        /// <param name="creator"></param>
        public void CreateDrugFrom(DrugFrom from, string creator)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugFromDAO dao = DAOFactory.Instance.CreateDrugFromDAO();
                dao.InsertDrugFrom(from,conn);
            }
        }
        /// <summary>
        /// 保存修改的药品产地
        /// </summary>
        /// <param name="from"></param>
        /// <param name="modifier"></param>
        public void SaveDrugFrom(DrugFrom from, string modifier)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugFromDAO dao = DAOFactory.Instance.CreateDrugFromDAO();
                dao.UpdateDrugFrom(from,conn);
            }
        }
        /// <summary>
        /// 删除一条药品产地
        /// </summary>
        /// <param name="from"></param>
        /// <param name="deleter"></param>
        public void DeleteDrugFrom(DrugFrom from, string deleter)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugFromDAO dao = DAOFactory.Instance.CreateDrugFromDAO();
                dao.DeleteDrugFrom(from.ID,conn);
            }
        }
        /// <summary>
        /// 查出所有的药品产地
        /// </summary>
        /// <returns></returns>
        public List<DrugFrom> GetAllDrugFrom()
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugFromDAO dao = DAOFactory.Instance.CreateDrugFromDAO();
                return dao.SelectAllDrugFrom(conn);
            }
        }
        
        /// <summary>
        /// 根据ID查找药品产地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DrugFrom RetrieveDrugsFrom(int id)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDrugFromDAO dao = DAOFactory.Instance.CreateDrugFromDAO();
                return dao.SelectDrugFrom(id,conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<DrugFrom> SearchDrugFrom(string searchCond)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDrugFromDAO dao = DAOFactory.Instance.CreateDrugFromDAO();
                return dao.SearchDrugFrom(searchCond, conn);
            }
        }
        #endregion
        #region 仓库
        /// <summary>
        /// 增加一个药品仓库
        /// </summary>
        /// <param name="storeHouse"></param>
        /// <param name="creator"></param>
        public void CreateStorehouse(Storehouse storeHouse, string creator)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                dao.InsertStorehouse(storeHouse, conn);
            }
        }
        /// <summary>
        /// 保存修改过的药品仓库
        /// </summary>
        /// <param name="Storehouse"></param>
        /// <param name="modifier"></param>
        public void SaveStorehouse(Storehouse storehouse, string modifier)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                dao.UpdateStorehouse(storehouse,conn);
            }
        }
        /// <summary>
        /// 删除一条药品仓库
        /// </summary>
        /// <param name="Storehouse"></param>
        /// <param name="deleter"></param>
        public void DeleteStorehouse(Storehouse storehouse, string deleter)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                dao.DeleteStorehouse(storehouse.ID,conn);
            }
        }
        /// <summary>
        /// 列出所有的药品仓库
        /// </summary>
        /// <returns></returns>
        public List<Storehouse> GetAllStorehouse()
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                return dao.SelectAllStorehouse(conn);
            };
        }
        /// <summary>
        /// 根据ID查找药品仓库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Storehouse RetrieveStorehouse(int id)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                return dao.SelectStorehouse(id,conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<Storehouse> SearchStorehouse(string searchCond)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                return dao.SearchStorehouse(searchCond,searchCond, conn);
            }
        }
        #endregion
        #region 票据类型
        /// <summary>
        /// 新增一条票据类别
        /// </summary>
        /// <param name="type"></param>
        /// <param name="creator"></param>
        public void CreateBillsType(BillsType type, string creator)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsTypeDAO dao = DAOFactory.Instance.CreateBillsTypeDAO();
                dao.InsertBillsType(type, conn);
            }
        }
        /// <summary>
        /// 保存修改过的票据类型信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Modifier"></param>
        public void SaveBillsType(BillsType type, string Modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsTypeDAO dao = DAOFactory.Instance.CreateBillsTypeDAO();
                dao.UpdateBillsType(type, conn);
            }
        }
        /// <summary>
        /// 删除一条票据类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleter"></param>
        public void DeleteBillsType(BillsType billsType, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsTypeDAO dao = DAOFactory.Instance.CreateBillsTypeDAO();
                dao.DeleteBillsType(billsType.ID, conn);
            }
        }
        /// <summary>
        /// 获取所有票据类型信息
        /// </summary>
        /// <returns></returns>
        public List<BillsType> GetAllBillsTypes()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsTypeDAO dao = DAOFactory.Instance.CreateBillsTypeDAO();
                return dao.SelectAllBillsType(conn);
            }
        }
        /// <summary>
        /// 根据ID查找一个票据类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BillsType GetBillsType(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsTypeDAO dao = DAOFactory.Instance.CreateBillsTypeDAO();
                return dao.SelectBillsType(id, conn);
            }
        }
        /// <summary>
        /// 根据条件进行模糊搜索
        /// </summary>
        /// <param name="searchCond">搜索条件</param>
        /// <returns></returns>
        public List<BillsType> SearchBillsType(string searchCond)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsTypeDAO dao = DAOFactory.Instance.CreateBillsTypeDAO();
                return dao.SearchBillsType(searchCond, conn);
            }
        }
        #endregion
    }
}
