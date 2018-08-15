using System;
using System.Collections.Generic;
using System.Text;
using DrugShop.Model;

namespace DrugShop.Core
{
    public class CacheService
    {
        /// <summary>
        /// 保存所有的公司信息
        /// </summary>
        private static List<Company> _AllCompanies = null;
        /// <summary>
        /// 保存所有的公司类别信息
        /// </summary>
        private static List<CompanyType> _AllCompanyTypes = null;
        /// <summary>
        /// 保存所有的药品信息
        /// </summary>
        private static List<Drugs> _AllDrugs = null;
        /// <summary>
        /// 保存所有的药品类别信息
        /// </summary>
        private static List<DrugCategory> _AllDrugCategory = null;
        /// <summary>
        /// 保存所有的药品产地信息
        /// </summary>
        private static List<DrugFrom> _AllDrugFrom = null;
        /// <summary>
        /// 保存所有的库房信息
        /// </summary>
        private static List<Storehouse> _AllStorehouse = null;
        /// <summary>
        /// 保存所有的票据类型信息
        /// </summary>
        private static List<BillsType> _AllBillsType = null;

        /// <summary>
        /// 获取缓存中的所有关联单位（客户/供应商/同盟店）
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllCompanies()
        {
            if (_AllCompanies==null)
            {
                _AllCompanies = new ModelService().GetAllCompanies();
            }
            return _AllCompanies;
        }
        /// <summary>
        /// 获取指定品种的缓存信息
        /// </summary>
        /// <param name="companyType"></param>
        /// <returns></returns>
        public List<Company> GetAllCompanyByType(CompanyType companyType)
        {
            List<Company> all = GetAllCompanies();
            List<Company> resultList = new List<Company>();
            foreach (Company company in all)
            {
                if (company.CompanyType==companyType)
                {
                    resultList.Add(company);
                }
            }
            return resultList;
        }
        /// <summary>
        /// 获取缓存中的所有关联单位类型（客户/供应商/同盟店）
        /// </summary>
        /// <returns></returns>
        public List<CompanyType> GetAllCompanyTypes()
        {
            if (_AllCompanyTypes == null )
            {
                _AllCompanyTypes = new ModelService().GetAllCompanyTypes();
            }
            return _AllCompanyTypes;
        }
        /// <summary>
        /// 获取缓存中的所有药品
        /// </summary>
        /// <returns></returns>
        public List<Drugs> GetAllDrugs()
        {
            if (_AllDrugs==null)
            {
                _AllDrugs = new ModelService().GetAllDrugs();
            }
            return _AllDrugs;
        }
        /// <summary>
        /// 获取缓存中的所有药品种类
        /// </summary>
        /// <returns></returns>
        public List<DrugCategory> GetAllDrugsCategory()
        {
            if (_AllDrugCategory==null )
            {
                _AllDrugCategory = new ModelService().GetAllDrugCategory();
            }
            return _AllDrugCategory;
        }
        /// <summary>
        /// 获取缓存中的所有药品产地
        /// </summary>
        /// <returns></returns>
        public List<DrugFrom> GetAllDrugsFrom()
        {
            if (_AllDrugFrom==null)
            {
                _AllDrugFrom = new ModelService().GetAllDrugFrom();
            }
            return _AllDrugFrom;
        }
        /// <summary>
        /// 获取缓存中的所有库房信息
        /// </summary>
        /// <returns></returns>
        public List<Storehouse> GetAllStorehouse()
        {
            if (_AllStorehouse==null)
            {
                _AllStorehouse = new ModelService().GetAllStorehouse();
            }
            return _AllStorehouse;
        }
        public List<BillsType> GetAllBillsType()
        {
            if (_AllBillsType==null)
            {
                _AllBillsType = new ModelService().GetAllBillsTypes();
            }
            return _AllBillsType;
        }
        public BillsType GetBillsType(string billsTypeName)
        {
            if (_AllBillsType==null )
            {
                _AllBillsType = GetAllBillsType();
            }
            BillsType billsType = null;
            foreach (BillsType item in _AllBillsType)
            {
                if (item.Name==billsTypeName)
                {
                    billsType = item;
                }
            }
            if (billsType==null)
            {
                throw new ApplicationException("不存在的票据类型");
            }
            return billsType;
        }
    }
}
