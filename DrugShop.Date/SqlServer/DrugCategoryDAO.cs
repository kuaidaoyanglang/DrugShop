using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal  class DrugCategoryDAO:IDrugCategoryDAO 
    {

        public void InsertDrugCategory(DrugCategory category, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_DrugCategory(DrugCategoryCode,DrugCategoryName,Actived,Remark) 
            values(@DrugCategoryCode,@DrugCategoryName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCategoryCode", category.Code));
            paramList.Add(new SqlParameter("@DrugCategoryName", category.Name));
            paramList.Add(new SqlParameter("@Actived", category.Actived));
            paramList.Add(new SqlParameter("@Remark",category.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertDrugCategory(DrugCategory category, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_DrugCategory(DrugCategoryCode,DrugCategoryName,Actived,Remark) 
            values(@DrugCategoryCode,@DrugCategoryName,@Actived,@Remark)  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCategoryCode", category.Code));
            paramList.Add(new SqlParameter("@DrugCategoryName", category.Name));
            paramList.Add(new SqlParameter("@Actived", category.Actived));
            paramList.Add(new SqlParameter("@Remark", category.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateDrugCategory(DrugCategory category, IDbConnection conn)
        {
            string sql = @"
            Update MD_DrugCategory set 
                DrugCategoryCode=@DrugCategoryCode,DrugCategoryName=@DrugCategoryName,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCategoryCode", category.Code));
            paramList.Add(new SqlParameter("@DrugCategoryName", category.Name));
            paramList.Add(new SqlParameter("@Actived", category.Actived));
            paramList.Add(new SqlParameter("@Remark", category.Remark));
            paramList.Add(new SqlParameter("@ID", category.ID));
            paramList.Add(new SqlParameter("@Remark",category.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateDrugCategory(DrugCategory category, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_DrugCategory set 
                DrugCategoryCode=@DrugCategoryCode,DrugCategoryName=@DrugCategoryName,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCategoryCode", category.Code));
            paramList.Add(new SqlParameter("@DrugCategoryName", category.Name));
            paramList.Add(new SqlParameter("@Actived", category.Actived));
            paramList.Add(new SqlParameter("@Remark", category.Remark));
            paramList.Add(new SqlParameter("@ID", category.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteDrugCategory(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_DrugCategory where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteDrugCategory(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_DrugCategory where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<DrugCategory> SelectAllDrugCategory(IDbConnection conn)
        {
            string sql = @"select ID,DrugCategoryCode,DrugCategoryName,Actived,Remark from MD_DrugCategory";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<DrugCategory> categoryList = new List<DrugCategory>();
            while (reader.Read())
            {
                DrugCategory category = new DrugCategory();
                category.ID = reader.GetInt32(0);
                category.Code = reader.GetString(1);
                category.Name = reader.GetString(2);
                category.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    category.Remark = reader.GetString(4);
                }
                categoryList.Add(category);
            }
            reader.Close();
            return categoryList;
        }
        public DrugCategory SelectDrugCategory(int id, IDbConnection conn)
        {
            string sql = @"
            select ID,DrugCategoryCode,DrugCategoryName,Actived,Remark
            from MD_DrugCategory where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            DrugCategory category = null;
            while (reader.Read())
            {
                category = new DrugCategory();
                category.ID = reader.GetInt32(0);
                category.Code = reader.GetString(1);
                category.Name = reader.GetString(2);
                category.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    category.Remark = reader.GetString(4);
                }
            }
            reader.Close();
            return category;
        }


        public List<DrugCategory> SearchDrugCategory(string searchCond, IDbConnection conn)
        {
            string sql = @"select 
            ID,DrugCategoryCode,DrugCategoryName,Actived,Remark 
            from MD_DrugCategory
            where DrugCategoryCode like @DrugCategoryCode 
            or DrugCategoryName like @DrugCategoryName
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCategoryCode", string.Format("%{0}%", searchCond)));
            paramList.Add(new SqlParameter("@DrugCategoryName", string.Format("%{0}%", searchCond)));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<DrugCategory> categoryList = new List<DrugCategory>();
            while (reader.Read())
            {
                DrugCategory category = new DrugCategory();
                category.ID = reader.GetInt32(0);
                category.Code = reader.GetString(1);
                category.Name = reader.GetString(2);
                category.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    category.Remark = reader.GetString(4);
                }
                categoryList.Add(category);
            }
            reader.Close();
            return categoryList;
        }
    }
}
