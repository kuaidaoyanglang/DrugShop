using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class StockDAO:IStockDAO 
    {

        public void InsertStock(Stock stock, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_Stock(Storehouse_ID,Drugs_ID,Count) 
            values(@Storehouse_ID,@Drugs_ID,@Count) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Storehouse_ID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@Drugs_ID", stock.Drug.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertStock(Stock stock, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_Stock(Storehouse_ID,Drugs_ID,Count) 
            values(@Storehouse_ID,@Drugs_ID,@Count) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Storehouse_ID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@Drugs_ID", stock.Drug.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateStock(Stock stock, IDbConnection conn)
        {
            string sql = @"
            Update MD_Stock set 
                Storehouse_ID=@Storehouse_ID,Drugs_ID=@Drugs_ID,Count=@Count
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Storehouse_ID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@Drugs_ID", stock.Drug.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            paramList.Add(new SqlParameter("@ID", stock.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateStock(Stock stock, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_Stock set 
                Storehouse_ID=@Storehouse_ID,Drugs_ID=@Drugs_ID,Count=@Count
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Storehouse_ID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@Drugs_ID", stock.Drug.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            paramList.Add(new SqlParameter("@ID", stock.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteStock(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_Stock where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteStock(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_Stock where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Stock> SelectAllStocks(IDbConnection conn)
        {
            string sql = @"Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            ";
            return SelectStocks(sql,new List<SqlParameter>(),(SqlConnection)conn);
        }
        public Stock SelectStock(int id, IDbConnection conn)
        {
            string sql = @"Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where Ms.ID=@Ms.ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Ms.ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Stock stock = null;
            while (reader.Read())
            {
                stock = this.ModelHelper(reader);
            }
            reader.Close();
            return stock;
        }

        public List<Stock> SelectStockByStorehouseID(int storehouseID, IDbConnection conn)
        {
            string sql = @"Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where Msh.ID=@Msh.ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Msh.ID", storehouseID));
            return SelectStocks(sql, paramList, (SqlConnection)conn);
        }

        public List<Stock> SelectStockByDrugsID(int drugsID, IDbConnection conn)
        {
            string sql = @"Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where Md.ID=@Md.ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Md.ID", drugsID));
            return SelectStocks(sql, paramList, (SqlConnection)conn);
        }

        public List<Stock> SelectStockByCategoryID(int categoryID, IDbConnection conn)
        {
            string sql = @"
            Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            where Mdc.ID=@Mdc.ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Mdc.ID", categoryID));
            return SelectStocks(sql, paramList, (SqlConnection)conn);
        }

        private List<Stock> SelectStocks(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Stock> stockList = new List<Stock>();
            while (reader.Read())
            {
                Stock stock = this.ModelHelper(reader);
                stockList.Add(stock);
            }
            reader.Close();
            return stockList;
        }

        private Stock ModelHelper(SqlDataReader reader)
        {
            Stock stock = new Stock();
            stock.ID = reader.GetInt32(0);
            stock.Count = reader.GetInt32(1);
            stock.Storehouse = new Storehouse();
            stock.Storehouse.ID = reader.GetInt32(2);
            stock.Storehouse.Code = reader.GetString(3);
            stock.Storehouse.Name = reader.GetString(4);
            stock.Storehouse.Actived = reader.GetBoolean(5);
            if (!reader.IsDBNull(6))
            {
                stock.Storehouse.Remark = reader.GetString(6);
            }
            stock.Drug = new Drugs();
            stock.Drug.ID = reader.GetInt32(7);
            stock.Drug.Code = reader.GetString(8);
            stock.Drug.Name = reader.GetString(9);
            stock.Drug.UnitPrice = reader.GetDecimal(10);
            stock.Drug.Standard = reader.GetString(11);
            stock.Drug.Unit = reader.GetString(12);
            stock.Drug.Actived = reader.GetBoolean(13);
            if (!reader.IsDBNull(14))
            {
                stock.Drug.Remark = reader.GetString(14);
            }
            stock.Drug.From = new DrugFrom();
            stock.Drug.From.ID = reader.GetInt32(15);
            stock.Drug.From.Code = reader.GetString(16);
            stock.Drug.From.Name = reader.GetString(17);
            stock.Drug.From.Actived = reader.GetBoolean(18);
            if (!reader.IsDBNull(19))
            {
                stock.Drug.From.Remark = reader.GetString(19);
            }
            stock.Drug.Category = new DrugCategory();
            stock.Drug.Category.ID = reader.GetInt32(20);
            stock.Drug.Category.Code = reader.GetString(21);
            stock.Drug.Category.Name = reader.GetString(22);
            stock.Drug.Category.Actived = reader.GetBoolean(23);
            if (!reader.IsDBNull(22))
            {
                stock.Drug.Category.Remark = reader.GetString(24);
            }
            return stock;
        }
        public Stock SelectStockByDrugsAndStorehouse(int drugsID, int storehouseID, IDbConnection conn,IDbTransaction trans)
        {
            string sql = @"
            Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            WHERE Ms.Drugs_ID=@DrugsID AND Ms.Storehouse_ID=@StorehouseID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugsID", drugsID));
            paramList.Add(new SqlParameter("@StorehouseID", storehouseID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList,(SqlTransaction)trans);
            List<Stock> list = this.SelectStocks(sql, paramList, reader);
            if (list.Count == 0)
            {
                return null;
            }
            return list[0];
        }
        private List<Stock> SelectStocks(string sql, List<SqlParameter> paramList, SqlDataReader reader)
        {
            List<Stock> list = new List<Stock>();
            while (reader.Read())
            {
                Stock stock = this.ModelHelper(reader);
                list.Add(stock);
            }
            reader.Close();
            return list;
        }



        public Stock SelectStockByDrugsAndStorehouse(int drugsID, int storehouseID, IDbConnection conn)
        {
            string sql = @"
            Select Ms.ID,Ms.Count, 
            Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
            Md.ID,Md.DrugCode,Md.DrugName,Md.UnitPrice,Md.Standard,Md.Unit,Md.Actived,Md.Remark,
            Mdf.ID,Mdf.DrugFromCode,Mdf.DrugFromName,Mdf.Actived,Mdf.Remark,
            Mdc.ID,Mdc.DrugCategoryCode,Mdc.DrugCategoryName,Mdc.Actived,Mdc.Remark
            from MD_Stock as Ms 
            inner join MD_Storehouse as Msh on Ms.StoreHouse_ID=Msh.ID 
            inner join MD_Drugs as Md on Ms.Drugs_ID=Md.ID  
            inner join MD_DrugFrom as Mdf on Md.DrugFrom_ID=Mdf.ID 
            inner join MD_DrugCategory as Mdc on Md.DrugCategory_ID=Mdc.ID 
            WHERE Ms.Drugs_ID=@DrugsID AND Ms.Storehouse_ID=@StorehouseID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DrugsID", drugsID));
            paramList.Add(new SqlParameter("@StorehouseID", storehouseID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Stock> list = this.SelectStocks(sql, paramList, reader);
            if (list.Count == 0)
            {
                return null;
            }
            return list[0];
        }
    }
}
