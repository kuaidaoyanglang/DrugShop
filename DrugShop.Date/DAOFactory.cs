using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

namespace DrugShop.Date
{
    public class DAOFactory
    {
        private enum DatabaseType
        {
            SqlServer,
            MySql,
            Oracole,
            DB2,
            Postgre,
            SQLite
        }
        private DatabaseType _DbType;
        private string _ProviderName;
        private string _ConnectionString;
        private DAOFactory()
        {
            try
            {
                string connKey = "Dbconn";
                _ProviderName = ConfigurationManager.ConnectionStrings[connKey].ProviderName;
                _ConnectionString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;
                if (_ProviderName == "System.Data.SqlClient")
                {
                    _DbType = DatabaseType.SqlServer;
                }
                else if (_ProviderName == "System.Data.Oracole")
                {
                    _DbType = DatabaseType.Oracole;
                }
                else if (_ProviderName == "System.Data.MySql")
                {
                    _DbType = DatabaseType.MySql;
                }
                else if (_ProviderName == "System.Data.DB2")
                {
                    _DbType = DatabaseType.DB2;
                }
                else if (_ProviderName == "System.Data.Postgre")
                {
                    _DbType = DatabaseType.Postgre;
                }
                else if (_ProviderName == "System.Data.SQLite")
                {
                    _DbType = DatabaseType.SQLite;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("读取数据库配置文件错误，获取数据库文件失败。");
            }
            

        }
        private static DAOFactory _Instance=null;
        public static DAOFactory Instance
        {
            get {
                if (_Instance==null)
                {
                    _Instance = new DAOFactory();
                }
                return _Instance;
            }
        }
        public IEventLogDAO CreateEventLogDAO()
        {
            IEventLogDAO dao = null;
            if (_DbType==DatabaseType.SqlServer )
            {
                dao = new SqlServer.EventLogDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.EventLogDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.EventLogDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.EventLogDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.EventLogDAO();
            }
            return dao;
        }
        public IBillsDAO CreateBillsDAO()
        {
            IBillsDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.BillsDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.BillsDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.BillsDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.BillsDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.BillsDAO();
            }
            return dao;
        }
        public IBillsTypeDAO CreateBillsTypeDAO()
        {
            IBillsTypeDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.BillsTypeDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.BillsTypeDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.BillsTypeDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.BillsTypeDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.BillsTypeDAO();
            }
            return dao;
        }
        public ICompanyDAO CreateCompanyDAO()
        {
            ICompanyDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.CompanyDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.CompanyDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.CompanyDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.CompanyDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.CompanyDAO();
            }
            return dao;
        }
        public ICompanyTypeDAO CreateCompanyTypeDAO()
        {
            ICompanyTypeDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.CompanyTypeDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.CompanyTypeDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.CompanyTypeDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.CompanyTypeDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.CompanyTypeDAO();
            }
            return dao;
        }
        public IDrugCategoryDAO CreateDrugCategoryDAO()
        {
            IDrugCategoryDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.DrugCategoryDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.DrugCategoryDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.DrugCategoryDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.DrugCategoryDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.DrugCategoryDAO();
            }
            return dao;
        }
        public IDrugFromDAO CreateDrugFromDAO()
        {
            IDrugFromDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.DrugFromDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.DrugFromDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.DrugFromDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.DrugFromDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.DrugFromDAO();
            }
            return dao;
        }
        public IDrugsDAO CreateDrugsDAO()
        {
            IDrugsDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.DrugsDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.DrugsDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.DrugsDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.DrugsDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.DrugsDAO();
            }
            return dao;
        }
        public IResourceDAO CreateResourceDAO()
        {
            IResourceDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.ResourceDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.ResourceDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.ResourceDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.ResourceDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.ResourceDAO();
            }
            return dao;
        }
        public IStockDAO CreateStockDAO()
        {
            IStockDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.StockDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.StockDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.StockDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.StockDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.StockDAO();
            }
            return dao;
        }
        public IStorehouseDAO CreateStorehouseDAO()
        {
            IStorehouseDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.StorehouseDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.StorehouseDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.StorehouseDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.StorehouseDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.StorehouseDAO();
            }
            return dao;
        }
        public IUserDAO CreateUserDAO()
        {
            IUserDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.UserDAO();
            }
            else if (_DbType == DatabaseType.MySql)
            {
                dao = new SqlServer.UserDAO();
            }
            else if (_DbType == DatabaseType.Oracole)
            {
                dao = new SqlServer.UserDAO();
            }
            else if (_DbType == DatabaseType.DB2)
            {
                dao = new SqlServer.UserDAO();
            }
            else if (_DbType == DatabaseType.Postgre)
            {
                dao = new SqlServer.UserDAO();
            }
            return dao;
        }
        public IDbConnection OpenConnection()
        {
            IDbConnection conn = System.Data.Common.DbProviderFactories.GetFactory(_ProviderName).CreateConnection();
            conn.ConnectionString = _ConnectionString;
            conn.Open();
            return conn;
        }
    }
}
