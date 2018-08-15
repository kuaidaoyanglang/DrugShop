using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal  class DrugFromDAO:IDrugFromDAO 
    {
        public void InsertDrugFrom(DrugFrom from, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_DrugFrom(DrugFromCode,DrugFromName,Actived,Remark) 
            values(@DrugFromCode,@DrugFromName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugFromCode", from.Code));
            paramList.Add(new SqlParameter("@DrugFromName", from.Name));
            paramList.Add(new SqlParameter("@Actived", from.Actived));
            paramList.Add(new SqlParameter("@Remark", from.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertDrugFrom(DrugFrom from, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_DrugFrom(DrugFromCode,DrugFromName,Actived,Remark) 
            values(@DrugFromCode,@DrugFromName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugFromCode", from.Code));
            paramList.Add(new SqlParameter("@DrugFromName", from.Name));
            paramList.Add(new SqlParameter("@Actived", from.Actived));
            paramList.Add(new SqlParameter("@Remark", from.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
        }

        public void UpdateDrugFrom(DrugFrom from, IDbConnection conn)
        {
            string sql = @"
            Update MD_DrugFrom set 
                DrugFromCode=@DrugFromCode,DrugFromName=@DrugFromName,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugFromCode", from.Code));
            paramList.Add(new SqlParameter("@DrugFromName", from.Name));
            paramList.Add(new SqlParameter("@Actived", from.Actived));
            paramList.Add(new SqlParameter("@Remark", from.Remark));
            paramList.Add(new SqlParameter("@ID", from.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateDrugFrom(DrugFrom from, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_DrugFrom set 
                DrugFromCode=@DrugFromCode,DrugFromName=@DrugFromName,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugFromCode", from.Code));
            paramList.Add(new SqlParameter("@DrugFromName", from.Name));
            paramList.Add(new SqlParameter("@Actived", from.Actived));
            paramList.Add(new SqlParameter("@Remark", from.Remark));
            paramList.Add(new SqlParameter("@ID", from.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
        }

        public void DeleteDrugFrom(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_DrugFrom where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteDrugFrom(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_DrugFrom where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<DrugFrom> SelectAllDrugFrom(IDbConnection conn)
        {
            string sql = @"select ID,DrugFromCode,DrugFromName,Actived,Remark from MD_DrugFrom";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<DrugFrom> fromList = new List<DrugFrom>();
            while (reader.Read())
            {
                DrugFrom from = new DrugFrom();
                from.ID = reader.GetInt32(0);
                from.Code = reader.GetString(1);
                from.Name = reader.GetString(2);
                from.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    from.Remark = reader.GetString(4);
                }
                fromList.Add(from);
            }
            reader.Close();
            return fromList;
        }
        public DrugFrom SelectDrugFrom(int id,IDbConnection conn)
        {
            string sql = @"
            select ID,DrugFromCode,DrugFromName,Actived,Remark
            from MD_DrugFrom where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            DrugFrom from = null;
            while (reader.Read())
            {
                from = new DrugFrom();
                from.ID = reader.GetInt32(0);
                from.Code = reader.GetString(1);
                from.Name = reader.GetString(2);
                from.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    from.Remark = reader.GetString(4);
                }
            }
            reader.Close();
            return from;
        }


        public List<DrugFrom> SearchDrugFrom(string searchCond, IDbConnection conn)
        {
            string sql = @"select 
            ID,DrugFromCode,DrugFromName,Actived,Remark
            from MD_DrugFrom
            Where DrugFromCode=@DrugFromCode
            or DrugFromName=@DrugFromName
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugFromCode", searchCond));
            paramList.Add(new SqlParameter("@DrugFromName", searchCond));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<DrugFrom> fromList = new List<DrugFrom>();
            while (reader.Read())
            {
                DrugFrom from = new DrugFrom();
                from.ID = reader.GetInt32(0);
                from.Code = reader.GetString(1);
                from.Name = reader.GetString(2);
                from.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    from.Remark = reader.GetString(4);
                }
                fromList.Add(from);
            }
            reader.Close();
            return fromList;
        }
    }
}
