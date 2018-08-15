using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class BillsDAO : IBillsDAO
    {

        public void InsertBill(Bills bill, IDbConnection conn)
        {
            string sql = @"insert into 
            MD_Bills(BillsCode,StoreHouse_ID,BillsType_ID,Maker,MakerDate,CreateDate,Actived,IsCancleOut,IsRedBill,Company_ID,Remark )
            values(@BillsCode,@StoreHouse_ID,@BillsType_ID,@Maker,@MakerDate,@CreateDate,@Actived,@IsCancleOut,@IsRedBill,@Company_ID,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@BillsCode", bill.Code));
            paramList.Add(new SqlParameter("@StoreHouse_ID", bill.Storehouse.ID));
            paramList.Add(new SqlParameter("@BillsType_ID", bill.BillsType.ID));
            paramList.Add(new SqlParameter("@Maker", bill.Maker));
            paramList.Add(new SqlParameter("@MakerDate", bill.MakeDate));
            paramList.Add(new SqlParameter("@CreateDate", bill.CreateDate));
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancleOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@Company_ID", bill.Company.ID));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
            Object idObj = DataAccessUtil.ExecuteScalar("SELECT @@IDENTITY", new List<SqlParameter>(), (SqlConnection)conn);
            int newID = int.Parse(idObj.ToString());
            foreach (BillsItem item in bill.Items)
            {
                sql = @"insert into 
            MD_BillsItem(Bills_ID,Drugs_ID,UnitPrice,Count,Money,Remark )
            values(@Bills_ID,@Drugs_ID,@UnitPrice,@Count,@Money,@Remark)";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@Bills_ID", newID));
                paramList.Add(new SqlParameter("@Drugs_ID", item.Drugs.ID));
                paramList.Add(new SqlParameter("@UnitPrice", item.UnitPrice));
                paramList.Add(new SqlParameter("@Count", item.Count));
                paramList.Add(new SqlParameter("@Money", item.Money));
                paramList.Add(new SqlParameter("@Remark", item.Remark));
                DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
            }
            bill.ID = newID;
        }

        public void InsertBill(Bills bill, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"insert into 
            MD_Bills(BillsCode,StoreHouse_ID,BillsType_ID,Maker,MakerDate,CreateDate,Actived,IsCancleOut,IsRedBill,Company_ID,Remark )
            values(@BillsCode,@Storehouse_ID,@BillsType_ID,@Maker,@MakerDate,@CreateDate,@Actived,@IsCancleOut,@IsRedBill,@Company_ID,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@BillsCode", bill.Code));
            paramList.Add(new SqlParameter("@Storehouse_ID", bill.Storehouse.ID));
            paramList.Add(new SqlParameter("@BillsType_ID", bill.BillsType.ID));
            paramList.Add(new SqlParameter("@Maker", bill.Maker));
            paramList.Add(new SqlParameter("@MakerDate", bill.MakeDate));
            paramList.Add(new SqlParameter("@CreateDate", bill.CreateDate));
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancleOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@Company_ID", bill.Company.ID));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
            Object idObj = DataAccessUtil.ExecuteScalar("SELECT @@IDENTITY", new List<SqlParameter>(), (SqlTransaction)trans);
            int newID = int.Parse(idObj.ToString());
            foreach (BillsItem item in bill.Items)
            {
                sql = @"insert into 
            MD_BillsItem(Bills_ID,Drugs_ID,UnitPrice,Count,Money,Remark )
            values(@Bills_ID,@Drugs_ID,@UnitPrice,@Count,@Money,@Remark)";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@Bills_ID", newID));
                paramList.Add(new SqlParameter("@Drugs_ID", item.Drugs.ID));
                paramList.Add(new SqlParameter("@UnitPrice", item.UnitPrice));
                paramList.Add(new SqlParameter("@Count", item.Count));
                paramList.Add(new SqlParameter("@Money", item.Money));
                paramList.Add(new SqlParameter("@Remark", item.Remark));
                DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
            }
            bill.ID = newID;
        }

        public void UpdateBill(Bills bill, IDbConnection conn)
        {
            string sql = @"Update MD_Bills 
            set BillsCode=@BillsCode,Storehouse_ID=@Storehouse_ID,Actived=@Actived,IsCancleOut=@IsCancleOut,IsRedBill=@IsRedBill,Remark=@Remark
            where ID=@ID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@BillsCode", bill.Code));
            paramList.Add(new SqlParameter("Storehouse_ID", bill.Storehouse.ID));
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancleOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            paramList.Add(new SqlParameter("@ID", bill.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateBill(Bills bill, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Update MD_Bills 
            set BillsCode=@BillsCode,Storehouse_ID=@Storehouse_ID,Actived=@Actived,IsCancleOut=@IsCancleOut,IsRedBill=@IsRedBill,Remark=@Remark
            where ID=@ID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@BillsCode", bill.Code));
            paramList.Add(new SqlParameter("Storehouse_ID", bill.Storehouse.ID));
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancleOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            paramList.Add(new SqlParameter("@ID", bill.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteBill(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_Bills  where ID=@ID ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteBill(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_Bills  where ID=@ID ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public Bills SelectBill(int id, IDbConnection conn)
        {
            string sql = @"
            select
               Mb.ID,Mb.BillsCode,Mb.Maker,Mb.MakerDate,Mb.CreateDate,Mb.Actived,Mb.IsCancleOut,Mb.IsRedBill,Mb.Remark,
               Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
               Mbt.ID,Mbt.Name,Mbt.IsOut,Mbt.Actived,Mbt.Remark,
               Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
               Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark 
            from MD_Bills as Mb 
            inner join MD_Storehouse as Msh on Mb.StoreHouse_ID=Msh.ID 
            inner join MD_BillsType as Mbt on Mb.BillsType_ID=Mbt.ID 
            inner join MD_Company as Mc on Mb.Company_ID=Mc.ID
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID 
            where Mb.ID=@ID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Bills bill = null;
            while (reader.Read())
            {
                bill = new Bills();
                BillModelHelper(reader, bill);
            }
            reader.Close();
            if (bill != null)
            {
                sql = @"
            Select Mbi.ID,Mbi.Count,Mbi.UnitPrice,Mbi.Money,Mbi.Remark,
                Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
                Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
                Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_BillsItem as Mbi
            inner join MD_Drugs as Md on Mbi.Drugs_ID=Md.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            where Mbi.Bills_ID=@ID ";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@ID", id));
                reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
                while (reader.Read())
                {
                    BillsItem item = new BillsItem();
                    BillItemModelHelper(reader, item);
                    bill.Items.Add(item);
                }
            }
            reader.Close();
            return bill;
        }

        private void BillItemModelHelper(SqlDataReader reader, BillsItem item)
        {
            item.ID = reader.GetInt32(0);
            item.Count = reader.GetInt32(1);
            item.UnitPrice = reader.GetDecimal(2);
            item.Money = reader.GetDecimal(3);
            if (!reader.IsDBNull(4))
            {
                item.Remark = reader.GetString(4);
            }
            item.Drugs = new Drugs();
            item.Drugs.ID = reader.GetInt32(5);
            item.Drugs.Code = reader.GetString(6);
            item.Drugs.Name = reader.GetString(7);
            item.Drugs.UnitPrice = reader.GetDecimal(8);
            item.Drugs.Standard = reader.GetString(9);
            item.Drugs.Unit = reader.GetString(10);
            item.Drugs.Actived = reader.GetBoolean(11);
            if (!reader.IsDBNull(12))
            {
                item.Drugs.Remark = reader.GetString(12);
            }
            item.Drugs.From = new DrugFrom();
            item.Drugs.From.ID = reader.GetInt32(13);
            item.Drugs.From.Code = reader.GetString(14);
            item.Drugs.From.Name = reader.GetString(15);
            item.Drugs.From.Actived = reader.GetBoolean(16);
            if (!reader.IsDBNull(17))
            {
                item.Drugs.From.Remark = reader.GetString(17);
            }
            item.Drugs.Category = new DrugCategory();
            item.Drugs.Category.ID = reader.GetInt32(18);
            item.Drugs.Category.Code = reader.GetString(19);
            item.Drugs.Category.Name = reader.GetString(20);
            item.Drugs.Category.Actived = reader.GetBoolean(21);
            if (!reader.IsDBNull(22))
            {
                item.Drugs.Category.Remark = reader.GetString(22);
            }

        }

        private void BillModelHelper(SqlDataReader reader, Bills bill)
        {
            bill.ID = reader.GetInt32(0);
            bill.Code = reader.GetString(1);
            bill.Maker = reader.GetString(2);
            bill.MakeDate = reader.GetDateTime(3);
            bill.CreateDate = reader.GetDateTime(4);
            bill.Actived = reader.GetBoolean(5);
            bill.IsCancelOut = reader.GetBoolean(6);
            bill.IsRedBill = reader.GetBoolean(7);
            if (!reader.IsDBNull(8))
            {
                bill.Remark = reader.GetString(8);
            }
            bill.Storehouse = new Storehouse();
            bill.Storehouse.ID = reader.GetInt32(9);
            bill.Storehouse.Code = reader.GetString(10);
            bill.Storehouse.Name = reader.GetString(11);
            bill.Storehouse.Actived = reader.GetBoolean(12);
            if (!reader.IsDBNull(13))
            {
                bill.Storehouse.Remark = reader.GetString(13);
            }
            bill.BillsType = new BillsType();
            bill.BillsType.ID = reader.GetInt32(14);
            bill.BillsType.Name = reader.GetString(15);
            bill.BillsType.IsOut = reader.GetBoolean(16);
            bill.BillsType.Actived = reader.GetBoolean(17);
            if (!reader.IsDBNull(18))
            {
                bill.BillsType.Remark = reader.GetString(18);
            }
            bill.Company = new Company();
            bill.Company.ID = reader.GetInt32(19);
            bill.Company.Code = reader.GetString(20);
            bill.Company.Name = reader.GetString(21);
            bill.Company.Actived = reader.GetBoolean(22);
            if (!reader.IsDBNull(23))
            {
                bill.Company.Remark = reader.GetString(23);
            }
            bill.Company.CompanyType = new CompanyType();
            bill.Company.CompanyType.ID = reader.GetInt32(24);
            bill.Company.CompanyType.Code = reader.GetString(25);
            bill.Company.CompanyType.Name = reader.GetString(26);
            bill.Company.CompanyType.Actived = reader.GetBoolean(27);
            if (!reader.IsDBNull(28))
            {
                bill.Company.CompanyType.Remark = reader.GetString(28);
            }
        }

        public List<Bills> SelectBills(DateTime fromDate, DateTime toDate, IDbConnection conn)
        {
            string sql = @"
            select
               Mb.ID,Mb.BillsCode,Mb.Maker,Mb.MakerDate,Mb.CreateDate,Mb.Actived,Mb.IsCancleOut,Mb.IsRedBill,Mb.Remark,
               Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
               Mbt.ID,Mbt.Name,Mbt.IsOut,Mbt.Actived,Mbt.Remark,
               Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
               Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark 
            from MD_Bills as Mb 
            inner join MD_Storehouse as Msh on Mb.Storehouse_ID=Msh.ID 
            inner join MD_BillsType as Mbt on Mb.BillsType_ID=Mbt.ID 
            inner join MD_Company as Mc on Mb.Company_ID=Mc.ID
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID 
            where Mb.MakerDate between @fromDate and @toDate
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@fromDate", fromDate));
            paramList.Add(new SqlParameter("@toDate", toDate));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Bills> list = new List<Bills>();
            while (reader.Read())
            {
                Bills bill = new Bills();
                BillModelHelper(reader, bill);
                list.Add(bill);
            }
            reader.Close();
            foreach (Bills b in list)
            {
                sql = @"
                    Select Mbi.ID,Mbi.Count,Mbi.UnitPrice,Mbi.Money,Mbi.Remark,
                       Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
                       Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
                       Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
                    from MD_BillsItem as Mbi
                    inner join MD_Drugs as Md on Mbi.Drugs_ID=Md.ID 
                    inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID
                    inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
                    where Mbi.Bills_ID=@ID ";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@ID", b.ID));
                reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
                while (reader.Read())
                {
                    BillsItem item = new BillsItem();
                    BillItemModelHelper(reader, item);
                    b.Items.Add(item);
                }
                reader.Close();
            }
            return list;
        }

        public List<Bills> SearchBills(SearchBillsTemplate temp, IDbConnection conn)
        {
            string sql = @"
            select
               Mb.ID,Mb.BillsCode,Mb.Maker,Mb.MakerDate,Mb.CreateDate,Mb.Actived,Mb.IsCancleOut,Mb.IsRedBill,Mb.Remark,
               Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
               Mbt.ID,Mbt.Name,Mbt.IsOut,Mbt.Actived,Mbt.Remark,
               Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.Actived,Mc.Remark,
               Mct.ID,Mct.CompanyTypeCode,Mct.CompanyTypeName,Mct.Actived,Mct.Remark 
            from MD_Bills as Mb 
            inner join MD_Storehouse as Msh on Mb.Storehouse_ID=Msh.ID 
            inner join MD_BillsType as Mbt on Mb.BillsType_ID=Mbt.ID 
            inner join MD_Company as Mc on Mb.Company_ID=Mc.ID
            inner join MD_CompanyType as Mct on Mc.CompanyType_ID=Mct.ID 
            where Mb.MakerDate between @FromDate and @ToDate
            and (Mc.CompanyCode like @CompanyCond or Mc.CompanyName like @CompanyCond)
            and (Mb.Maker like @Maker)
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FromDate", temp.FromDate));
            paramList.Add(new SqlParameter("@ToDate", temp.ToDate));
            paramList.Add(new SqlParameter("@CompanyCond", string.Format("%{0}%", temp.CompanyCond == null ? "" : temp.CompanyCond)));
            paramList.Add(new SqlParameter("@Maker", string.Format("%{0}%", temp.BillMaker == null ? "" : temp.BillMaker)));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Bills> list = new List<Bills>();
            while (reader.Read())
            {
                Bills bill = new Bills();
                BillModelHelper(reader, bill);
                list.Add(bill);

            }
            reader.Close();
            foreach (Bills b in list)
            {
                sql = @"
                    Select Mbi.ID,Mbi.Count,Mbi.UnitPrice,Mbi.Money,Mbi.Remark,
                       Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
                       Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
                       Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
                    from MD_BillsItem as Mbi
                    inner join MD_Drugs as Md on Mbi.Drugs_ID=Md.ID 
                    inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID
                    inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
                    where Mbi.Bills_ID=@ID ";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@ID", b.ID));
                reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
                while (reader.Read())
                {
                    BillsItem item = new BillsItem();
                    BillItemModelHelper(reader, item);
                    b.Items.Add(item);
                }
                reader.Close();
            }
            return list;
        }
       
    }
}
