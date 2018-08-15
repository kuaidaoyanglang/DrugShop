using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal  class CompanyTypeDAO:ICompanyTypeDAO 
    {
        public void InsertCompanyType(CompanyType type, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_CompanyType(CompanyTypeCode,CompanyTypeName,Actived,Remark) 
            values(@CompanyTypeCode,@CompanyTypeName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyTypeCode", type.Code));
            paramList.Add(new SqlParameter("@CompanyTypeName", type.Name));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertCompanyType(CompanyType type, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_CompanyType(CompanyTypeCode,CompanyTypeName,Actived,Remark) 
            values(@CompanyTypeCode,@CompanyTypeName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyTypeCode", type.Code));
            paramList.Add(new SqlParameter("@CompanyTypeName", type.Name));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateCompanyType(CompanyType type, IDbConnection conn)
        {
            string sql = @"
            Update MD_CompanyType set 
                CompanyTypeCode=@CompanyTypeCode,CompanyTypeName=@CompanyTypeName,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyTypeCode", type.Code));
            paramList.Add(new SqlParameter("@CompanyTypeName", type.Name));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            paramList.Add(new SqlParameter("@ID", type.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateCompanyType(CompanyType type, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_CompanyType set 
                CompanyTypeCode=@CompanyTypeCode,CompanyTypeName=@CompanyTypeName,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyTypeCode", type.Code));
            paramList.Add(new SqlParameter("@CompanyTypeName", type.Name));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            paramList.Add(new SqlParameter("@ID", type.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteCompanyType(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_CompanyType where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteCompanyType(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_CompanyType where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<CompanyType> SelectAllCompanyType(IDbConnection conn)
        {
            string sql = @"select ID,CompanyTypeCode,CompanyTypeName,Actived,Remark from MD_CompanyType";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<CompanyType> typeList = new List<CompanyType>();
            while (reader.Read())
            {
                CompanyType type = new CompanyType();
                type.ID = reader.GetInt32(0);
                type.Code = reader.GetString(1);
                type.Name = reader.GetString(2);
                type.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    type.Remark = reader.GetString(4);
                }
                typeList.Add(type);
            }
            reader.Close();
            return typeList;
        }

        public CompanyType SelectCompanyType(int id, IDbConnection conn)
        {
            string sql = @"
            select ID,CompanyTypeCode,CompanyTypeName,Actived,Remark
            from MD_CompanyType where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            CompanyType type = null;
            while (reader.Read())
            {
                type = new CompanyType();
                type.ID = reader.GetInt32(0);
                type.Code = reader.GetString(1);
                type.Name = reader.GetString(2);
                type.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(5))
                {
                    type.Remark = reader.GetString(5);
                }
            }
            reader.Close();
            return type;
        }

        public List<CompanyType> SearchCompanyType(string codeCond, string nameCond, IDbConnection conn)
        {
            string sql = @"select ID,CompanyTypeCode,CompanyTypeName,Actived,Remark 
             from MD_CompanyType
             where CompanyTypeCode like @CompanyTypeCode
             or CompanyTypeName like @CompanyTypeName";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyTypeCode", string.Format("%{0}%", codeCond)));
            paramList.Add(new SqlParameter("@CompanyTypeName", string.Format("%{0}%", nameCond)));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<CompanyType> typeList = new List<CompanyType>();
            while (reader.Read())
            {
                CompanyType type = new CompanyType();
                type.ID = reader.GetInt32(0);
                type.Code = reader.GetString(1);
                type.Name = reader.GetString(2);
                type.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(5))
                {
                    type.Remark = reader.GetString(5);
                }
                typeList.Add(type);
            }
            reader.Close();
            return typeList;
        }
    }
}
