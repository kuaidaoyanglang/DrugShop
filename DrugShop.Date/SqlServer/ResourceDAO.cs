using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class ResourceDAO:IResourceDAO 
    {
        public void InsertResource(Resource res, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_Resource(ResourceCode,ResourceName) 
            values(@ResourceCode,@ResourceName) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertResource(Resource res, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_Resource(ResourceCode,ResourceName) 
            values(@ResourceCode,@ResourceName) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
        }

        public void UpdateResource(Resource res, IDbConnection conn)
        {
            string sql = @"
            Update MD_Resource set 
                ResourceCode=@ResourceCode,ResourceName=@ResourceName
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));       
            paramList.Add(new SqlParameter("@ID", res.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateResource(Resource res, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_Resource set 
                ResourceCode=@ResourceCode,ResourceName=@ResourceName
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            paramList.Add(new SqlParameter("@ID", res.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
        }

        public void DeleteResource(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_User_Resource where Resource_ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);

            sql = @"Delete MD_Resource where ID=@ID";
            paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteResource(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_Resource where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);

            sql = @"Delete MD_Resource where ID=@ID";
            paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }
        

        public List<Resource> SelectAllResource(IDbConnection conn)
        {
            string sql = @"select ID,ResourceCode,ResourceName from MD_Resource";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Resource> resList = new List<Resource>();
            while (reader.Read())
            {
                Resource res = new Resource();
                res.ID = reader.GetInt32(0);
                res.Code = reader.GetString(1);
                res.Name = reader.GetString(2);
                resList.Add(res);
            }
            reader.Close();
            return resList;
        }

        public List<Resource> SelectResource(int userId, IDbConnection conn)
        {
            string sql = @"
            select Mr.ID,ResourceCode,ResourceName 
            from MD_Resource as Mr inner join MD_User_Resource as Mur on Mr.ID=Mur.Resource_ID 
            where  Mur.User_ID=@User_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@User_ID", userId));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Resource> resList = new List<Resource>();
            while (reader.Read())
            {
                Resource res = new Resource();
                res.ID = reader.GetInt32(0);
                res.Code = reader.GetString(1);
                res.Name = reader.GetString(2);
                resList.Add(res);
            }
            reader.Close();
            return resList;
        }
    }
}
