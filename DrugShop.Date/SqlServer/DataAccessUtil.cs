using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DrugShop.Date.SqlServer
{
    internal class DataAccessUtil
    {
        /// <summary>
        /// 返回上次操作的第一行、第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, List<SqlParameter> paramList, SqlConnection  conn)
        {
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteScalar();
        }
        /// <summary>
        /// 返回上次操作的第一行、第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlCommand cmd = trans.Connection.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteScalar();
        }
        #region 执行非查询式数据库操作
        
        /// <summary>
        /// 执行传入连接的非查询SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <param name="conn"></param>
        public static void ExecuteNonQuery(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            ExecuteNonQuery(sql, paramList, CommandType.Text,conn);
        }
       
        /// <summary>
        /// 执行传入连接的非查询SQL语句或存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <param name="type"></param>
        /// <param name="conn"></param>
        public static void ExecuteNonQuery(string sql, List<SqlParameter> paramList, CommandType type, SqlConnection conn)
        {
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 支持事物的非查询式SQL或存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <param name="trans"></param>
        public static void ExecuteNonQuery(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            ExecuteNonQuery(sql, paramList, CommandType.Text, trans);
        }
        
        /// <summary>
        /// 支持事物的非查询式SQL或存储过程
        /// </summary>
        /// <param name="sqlProcedure"></param>
        /// <param name="paramList"></param>
        /// <param name="type"></param>
        /// <param name="trans"></param>
        public static void ExecuteNonQuery(string sqlProcedure, List<SqlParameter> paramList, CommandType type, SqlTransaction trans)
        {
            SqlCommand cmd = trans.Connection.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sqlProcedure;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.CommandType = type;
            cmd.ExecuteNonQuery();
        }
        
        public static void ExecuteNonQuery(string sqlProcedure, List<SqlParameter> paramList, CommandType type, SqlConnection conn,SqlTransaction trans)
        {
            SqlCommand cmd = trans.Connection.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sqlProcedure;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.CommandType = type;
            cmd.ExecuteNonQuery();
        }
        #endregion
        #region 执行查询式数据库操作
        /// <summary>
        ///执行查询式SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            return ExecuteReader(sql, paramList, CommandType.Text,conn);
        }
        /// <summary>
        /// 执行查询式SQL语句或者存储过程
        /// </summary>
        /// <param name="sqlOrProcedure"></param>
        /// <param name="paramList"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sqlOrProcedure, List<SqlParameter> paramList, CommandType type,SqlConnection conn)
        {
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlOrProcedure;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.CommandType = type;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteReader();
        }
        public static DataSet ExecuteDataSet(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            return ExecuteDataSet(sql, paramList, CommandType.Text,conn);
        }
        public static DataSet ExecuteDataSet(string sqlOrProcedure, List<SqlParameter> paramList, CommandType type,SqlConnection conn)
        {
            if (conn.State!=ConnectionState.Open )
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlOrProcedure;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.CommandType = type;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public static DataTable ExecuteDataTable(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            return ExecuteDataTable(sql, paramList, CommandType.Text,conn);
        }
        public static DataTable ExecuteDataTable(string sqlOrProcedure, List<SqlParameter> paramList, CommandType type,SqlConnection conn)
        {
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlOrProcedure;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.CommandType = type;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        #endregion
    }
}
