using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal  class DrugsDAO:IDrugsDAO 
    {

        public void InsertDrug(Drugs drug, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_Drugs(DrugCode,DrugName,UnitPrice,Standard,Unit,DrugFrom_ID,DrugCategory_ID,Actived,Remark) 
            values(@DrugsCode,@DrugsName,@UnitPrice,@Standard,@Unit,@DrugFrom_ID,@DrugCategory_ID,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugsCode", drug.Code));
            paramList.Add(new SqlParameter("@DrugsName", drug.Name));
            paramList.Add(new SqlParameter("@UnitPrice",drug.UnitPrice));
            paramList.Add(new SqlParameter("@Standard", drug.Standard));
            paramList.Add(new SqlParameter("@Unit", drug.Unit));
            paramList.Add(new SqlParameter("@DrugFrom_ID", drug.From.ID));
            paramList.Add(new SqlParameter("@DrugCategory_ID", drug.Category.ID));
            paramList.Add(new SqlParameter("@Actived", drug.Actived));
            paramList.Add(new SqlParameter("@Remark", drug.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertDrug(Drugs drug, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_Drugs(DrugCode,DrugName,UnitPrice,Standard,Unit,DrugFrom_ID,DrugCategory_ID,Actived,Remark) 
            values(@DrugsCode,@DrugsName,@UnitPrice,@Standard,@Unit,@DrugFrom_ID,@DrugCategory_ID,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugsCode", drug.Code));
            paramList.Add(new SqlParameter("@DrugsName", drug.Name));
            paramList.Add(new SqlParameter("@UnitPrice", drug.UnitPrice));
            paramList.Add(new SqlParameter("@Standard", drug.Standard));
            paramList.Add(new SqlParameter("@Unit", drug.Unit));
            paramList.Add(new SqlParameter("@DrugFrom_ID", drug.From.ID));
            paramList.Add(new SqlParameter("@DrugCategory_ID", drug.Category.ID));
            paramList.Add(new SqlParameter("@Actived", drug.Actived));
            paramList.Add(new SqlParameter("@Remark", drug.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
        }

        public void UpdateDrug(Drugs drug, IDbConnection conn)
        {
            string sql = @"
            Update MD_Drugs set 
                DrugCode=@DrugCode,DrugName=@DrugName,UnitPrice=@UnitPrice,Standard=@Standard,Unit=@Unit,DrugFrom_ID=@DrugFrom_ID,DrugCategory_ID=@DrugCategory_ID, Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCode", drug.Code));
            paramList.Add(new SqlParameter("@DrugName", drug.Name));
            paramList.Add(new SqlParameter("@UnitPrice", drug.UnitPrice));
            paramList.Add(new SqlParameter("@Standard", drug.Standard));
            paramList.Add(new SqlParameter("@Unit", drug.Actived));
            paramList.Add(new SqlParameter("@DrugFrom_ID", drug.From.ID));
            paramList.Add(new SqlParameter("@DrugCategory_ID", drug.Category.ID));
            paramList.Add(new SqlParameter("@Actived", drug.Actived));
            paramList.Add(new SqlParameter("@Remark", drug.Remark));
            paramList.Add(new SqlParameter("@ID", drug.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateDrug(Drugs drug, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_Drugs set 
                DrugCode=@DrugCode,DrugName=@DrugName,UnitPrice=@UnitPrice,Standard=@Standard,Unit=@Unit,DrugFrom_ID=@DrugFrom_ID,DrugCategory_ID=@DrugCategory_ID,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCode", drug.Code));
            paramList.Add(new SqlParameter("@DrugName", drug.Name));
            paramList.Add(new SqlParameter("@UnitPrice", drug.UnitPrice));
            paramList.Add(new SqlParameter("@Standard", drug.Standard));
            paramList.Add(new SqlParameter("@Unit", drug.Actived));
            paramList.Add(new SqlParameter("@DrugFrom_ID", drug.From.ID));
            paramList.Add(new SqlParameter("@DrugCategory_ID", drug.Category.ID));
            paramList.Add(new SqlParameter("@Actived", drug.Actived));
            paramList.Add(new SqlParameter("@Remark", drug.Remark));
            paramList.Add(new SqlParameter("@ID", drug.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteDrug(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_Drugs where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteDrug(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_Drugs where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Drugs> SelectAllDrugs(IDbConnection conn)
        {
            string sql = @"
            Select 
               Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
               Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
               Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Drugs as Md 
            inner join  MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            ";
            return SelectDrugs(sql, new List<SqlParameter>(), (SqlConnection)conn);
        }
        public Drugs SelectDrug(int id, IDbConnection conn)
        {
            string sql = @"
            Select 
               Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
               Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
               Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Drugs as Md 
            inner join  MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Drugs drug = null;
            while (reader.Read())
            {
                drug = this.ModelHelper(reader);
            }
            reader.Close();
            return drug;
        }
        public Drugs SelectDrug(string code, IDbConnection conn)
        {
            string sql = @"
            Select 
               Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
               Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
               Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Drugs as Md 
            inner join  MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where DrugCode=@DrugCode";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCode", code));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Drugs drug = null;
            while (reader.Read())
            {
                drug = this.ModelHelper(reader);
            }
            reader.Close();
            return drug;
        }
        public List<Drugs> SearchDrugs(SearchDrugsTemplate drug, IDbConnection conn)
        {
            string sql = @"
            Select 
               Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
               Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
               Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Drugs as Md 
            inner join  MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where Md.DrugCode like @DrugCode
            or Md.DrugName like @DrugName
            or Md.DrugFromName like @DrugFromName
            or Md.DrugCategory like @DrugCategory";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugCode", string.Format("%{0}%", drug.Code)));
            paramList.Add(new SqlParameter("@DrugName", string.Format("%{0}%", drug.Name)));
            paramList.Add(new SqlParameter("@DrugFromName", string.Format("%{0}%", drug.From)));
            paramList.Add(new SqlParameter("@DrugCategory", string.Format("%{0}%", drug.Category)));
            return SelectDrugs(sql, paramList, (SqlConnection)conn);
        }

        public List<Drugs> SelectDrugsByDrugFrom(DrugFrom from, IDbConnection conn)
        {
            string sql = @"
            Select 
               Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
               Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
               Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Drugs as Md 
            inner join  MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where Mdf.ID=@Mdf.ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Mdf.ID", from.ID));
            return SelectDrugs(sql, paramList, (SqlConnection)conn);
        }

        
        private List<Drugs> SelectDrugs(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Drugs> drugList = new List<Drugs>();
            while (reader.Read())
            {
                Drugs drug = this.ModelHelper(reader);
                drugList.Add(drug);
            }
            reader.Close();
            return drugList;
        }
        private Drugs ModelHelper(SqlDataReader reader)
        {
            Drugs drug = new Drugs();
            drug.ID = reader.GetInt32(0);
            drug.Code = reader.GetString(1);
            drug.Name = reader.GetString(2);
            drug.UnitPrice = reader.GetDecimal(3);
            drug.Standard = reader.GetString(4);
            drug.Unit = reader.GetString(5);
            drug.Actived = reader.GetBoolean(6);
            if (!reader.IsDBNull(7))
            {
                drug.Remark = reader.GetString(7);
            }
            drug.From = new DrugFrom();
            drug.From.ID = reader.GetInt32(8);
            drug.From.Code = reader.GetString(9);
            drug.From.Name = reader.GetString(10);
            drug.From.Actived = reader.GetBoolean(11);
            if (!reader.IsDBNull(12))
            {
                drug.From.Remark = reader.GetString(12);
            }
            drug.Category = new DrugCategory();
            drug.Category.ID = reader.GetInt32(13);
            drug.Category.Code = reader.GetString(14);
            drug.Category.Name = reader.GetString(15);
            drug.Category.Actived = reader.GetBoolean(16);
            if (!reader.IsDBNull(17))
            {
                drug.Category.Remark = reader.GetString(17);
            }
            return drug;
        }
    }
}
