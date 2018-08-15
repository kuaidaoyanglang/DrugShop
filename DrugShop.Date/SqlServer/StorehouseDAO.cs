using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class StorehouseDAO : IStorehouseDAO
    {
        public void InsertStorehouse(Storehouse house, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_Storehouse(StorehouseCode,StorehouseName,Actived,Remark) 
            values(@StorehouseCode,@StorehouseName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", house.Code));
            paramList.Add(new SqlParameter("@StorehouseName", house.Name));
            paramList.Add(new SqlParameter("@Actived", house.Actived));
            paramList.Add(new SqlParameter("@Remark", house.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertStorehouse(Storehouse house, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_Storehouse(StorehouseCode,StorehouseName,Actived,Remark) 
            values(@StorehouseCode,@StorehouseName,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", house.Code));
            paramList.Add(new SqlParameter("@StorehouseName", house.Name));
            paramList.Add(new SqlParameter("@Actived", house.Actived));
            paramList.Add(new SqlParameter("@Remark", house.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateStorehouse(Storehouse house, IDbConnection conn)
        {
            string sql = @"
            Update MD_Storehouse set 
                StorehouseCode=@StorehouseCode,StorehouseName=@StorehouseName, Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", house.Code));
            paramList.Add(new SqlParameter("@StorehouseName", house.Name));
            paramList.Add(new SqlParameter("@Actived", house.Actived));
            paramList.Add(new SqlParameter("@Remark", house.Remark));
            paramList.Add(new SqlParameter("@ID", house.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateStorehouse(Storehouse house, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_Storehouse set 
                StorehouseCode=@StorehouseCode,StorehouseName=@StorehouseName, Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", house.Code));
            paramList.Add(new SqlParameter("@StorehouseName", house.Name));
            paramList.Add(new SqlParameter("@Actived", house.Actived));
            paramList.Add(new SqlParameter("@Remark", house.Remark));
            paramList.Add(new SqlParameter("@ID", house.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteStorehouse(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_Storehouse where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteStorehouse(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_Storehouse where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Storehouse> SelectAllStorehouse(IDbConnection conn)
        {
            string sql = @"
            select ID,StorehouseCode,StorehouseName,Actived,Remark
            from MD_Storehouse";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Storehouse> houseList = new List<Storehouse>();
            while (reader.Read())
            {
                Storehouse house = new Storehouse();
                house.ID = reader.GetInt32(0);
                house.Code = reader.GetString(1);
                house.Name = reader.GetString(2);
                house.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    house.Remark = reader.GetString(4);
                }
                houseList.Add(house);
            }
            reader.Close();
            return houseList;
        }

        public Storehouse SelectStorehouse(int id, IDbConnection conn)
        {
            string sql = @"
            select ID,StorehouseCode,StorehouseName,Actived,Remark 
            from MD_Storehouse where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Storehouse house = null;
            while (reader.Read())
            {
                house = new Storehouse();
                house.ID = reader.GetInt32(0);
                house.Code = reader.GetString(1);
                house.Name = reader.GetString(2);
                house.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    house.Remark = reader.GetString(4);
                }
            }
            reader.Close();
            return house;
        }

        public List<Storehouse> SearchStorehouse(string codeCond, string nameCond, IDbConnection conn)
        {
            string sql = @"select ID,StorehouseCode,StorehouseName,Actived,Remark 
             from MD_Storehouse
             where StorehouseCode like @StorehouseCode
             or StorehouseName like @StorehouseName";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", string.Format("%{0}%", codeCond)));
            paramList.Add(new SqlParameter("@StorehouseName", string.Format("%{0}%", nameCond)));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Storehouse> houseList = new List<Storehouse>();
            while (reader.Read())
            {
                Storehouse house = new Storehouse();
                house.ID = reader.GetInt32(0);
                house.Code = reader.GetString(1);
                house.Name = reader.GetString(2);
                house.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    house.Remark = reader.GetString(4);
                }
                houseList.Add(house);
            }
            reader.Close();
            return houseList;
        }
    }
}
