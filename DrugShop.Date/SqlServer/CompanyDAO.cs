using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal  class CompanyDAO:ICompanyDAO 
    {

        public void InsertCompany(Company company, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_Company(CompanyCode,CompanyName,CompanyType_ID,Actived,Remark) 
            values(@CompanyCode,@CompanyName,@CompanyType_ID,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType_ID", company.CompanyType.ID));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertCompany(Company company, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_Company(CompanyCode,CompanyName,CompanyType_ID,Actived,Remark) 
            values(@CompanyCode,@CompanyName,@CompanyType_ID,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType_ID", company.CompanyType.ID));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateCompany(Company company, IDbConnection conn)
        {
            string sql = @"
            Update MD_Company set 
                CompanyCode=@CompanyCode,CompanyName=@CompanyName,CompanyType_ID=@CompanyType_ID, Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType_ID", company.CompanyType.ID));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            paramList.Add(new SqlParameter("@ID", company.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateCompany(Company company, IDbConnection  conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_Company set 
                CompanyCode=@CompanyCode,CompanyName=@CompanyName,CompanyType_ID=@CompanyType_ID, Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType_ID", company.CompanyType.ID));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            paramList.Add(new SqlParameter("@ID", company.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteCompany(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_Company where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteCompany(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_Company where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Company> SelectAllCompanies(IDbConnection conn)
        {
            string sql = @"select 
            Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
            Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark
            from MD_Company as Mc 
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID";
            return SelectCompanies(sql,new List<SqlParameter>(),(SqlConnection)conn);
        }
        public Company SelectCompany(int id, IDbConnection conn)
        {
            string sql = @"select 
            Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
            Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark
            from MD_Company as Mc 
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Company company = null;
            while (reader.Read())
            {
                company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    company.Remark = reader.GetString(4);
                }
                company.CompanyType = new CompanyType();
                company.CompanyType.ID = reader.GetInt32(5);
                company.CompanyType.Code = reader.GetString(6);
                company.CompanyType.Name = reader.GetString(7);
                company.CompanyType.Actived = reader.GetBoolean(8);
                if (!reader.IsDBNull(9))
                {
                    company.CompanyType.Remark = reader.GetString(9);
                }
            }
            reader.Close();
            return company;
        }

        public List<Company> SelectCompanies(CompanyType companyType, IDbConnection conn)
        {
            string sql = @"select 
            Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
            Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark
            from MD_Company as Mc 
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID
            where Mct.ID=@Mct.ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Mct.ID", companyType.ID));
            return SelectCompanies(sql, paramList, (SqlConnection)conn);
        }

        public List<Company> SearchCompanies(string codeCond, string nameCond, IDbConnection conn)
        {
            string sql = @"select 
            Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
            Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark
            from MD_Company as Mc 
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID
            where CompanyCode like @CompanyCode
            or CompanyName like @CompanyName";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", string.Format("%{0}%", codeCond)));
            paramList.Add(new SqlParameter("@CompanyName", string.Format("%{0}%", nameCond)));
            return SelectCompanies(sql, paramList, (SqlConnection)conn);
        }
        private List<Company> SelectCompanies(string sql,List<SqlParameter> paramList,SqlConnection conn)
        {
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Company> companyList = new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    company.Remark = reader.GetString(4);
                }
                company.CompanyType = new CompanyType();
                company.CompanyType.ID = reader.GetInt32(5);
                company.CompanyType.Code = reader.GetString(6);
                company.CompanyType.Name = reader.GetString(7);
                company.CompanyType.Actived = reader.GetBoolean(8);
                if (!reader.IsDBNull(9))
                {
                    company.CompanyType.Remark = reader.GetString(9);
                }
                companyList.Add(company);
            }
            reader.Close();
            return companyList;
        }
    }
}
