using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class BillsTypeDAO : IBillsTypeDAO
    {
        public void InsertBillsType(BillsType type, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_BillsType(Code,Name,IsOut,Actived,Remark) 
            values(@Code,@Name,@IsOut,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", type.Code));
            paramList.Add(new SqlParameter("@Name", type.Name));
            paramList.Add(new SqlParameter("@IsOut", type.IsOut));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertBillsType(BillsType type, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_BillsType(Code,Name,IsOut,Actived,Remark) 
            values(@Code,@Name,@IsOut,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", type.Code));
            paramList.Add(new SqlParameter("@Name", type.Name));
            paramList.Add(new SqlParameter("@IsOut", type.IsOut));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateBillsType(BillsType type, IDbConnection conn)
        {
            string sql = @"
            Update MD_BillsType set 
                Code=@Code,Name=@Name,IsOut=@IsOut,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", type.Code));
            paramList.Add(new SqlParameter("@Name", type.Name));
            paramList.Add(new SqlParameter("@IsOut", type.IsOut));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            paramList.Add(new SqlParameter("@ID", type.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateBillsType(BillsType type, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_BillsType set 
                Code=@Code,Name=@Name,IsOut=@IsOut,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", type.Code));
            paramList.Add(new SqlParameter("@Name", type.Name));
            paramList.Add(new SqlParameter("@IsOut", type.IsOut));
            paramList.Add(new SqlParameter("@Actived", type.Actived));
            paramList.Add(new SqlParameter("@Remark", type.Remark));
            paramList.Add(new SqlParameter("@ID", type.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteBillsType(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_BillsType where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteBillsType(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_BillsType where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<BillsType> SelectAllBillsType(IDbConnection conn)
        {
            string sql = @"select ID,Code,Name,IsOut,Actived,Remark from MD_BillsType";
            return SelectBillsType(sql, new List<SqlParameter>(), (SqlConnection)conn);
        }
        public BillsType SelectBillsType(int id, IDbConnection conn)
        {
            string sql = @"
            select ID,Code,Name,IsOut,Actived,Remark
            from MD_BillsType where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            BillsType type = null;
            while (reader.Read())
            {
                type = new BillsType();
                type.ID = reader.GetInt32(0);
                type.Code = reader.GetString(1);
                type.Name = reader.GetString(2);
                type.IsOut = reader.GetBoolean(3);
                type.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    type.Remark = reader.GetString(5);
                }
            }
            reader.Close();
            return type;
        }

        public List<BillsType> SearchBillsType(string nameCond, IDbConnection conn)
        {
            string sql = @"
            select ID,Code,Name,IsOut,Actived,Remark 
            from MD_BillsType
            where Name like @Name
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", string.Format("%{0}%", nameCond)));
            return SelectBillsType(sql, paramList, (SqlConnection)conn);
        }

        private List<BillsType> SelectBillsType(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<BillsType> list = new List<BillsType>();
            while (reader.Read())
            {
                BillsType type = new BillsType();
                type.ID = reader.GetInt32(0);
                type.Code = reader.GetString(1);
                type.Name = reader.GetString(2);
                type.IsOut = reader.GetBoolean(3);
                type.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    type.Remark = reader.GetString(5);
                }
                list.Add(type);
            }
            reader.Close();
            return list;
        }
    }
}
