using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class UserDAO : IUserDAO
    {
        public void InsertUser(User user, IDbConnection conn)
        {
            string sql = @"
            Insert into MD_User(UserCode,UserName,Password,IsAdmin,Actived,Remark) 
            values(@UserCode,@UserName,@Password,@IsAdmin,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@IsAdmin",user.IsAdmin));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertUser(User user, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Insert into MD_User(UserCode,UserName,Password,IsAdmin,Actived,Remark) 
            values(@UserCode,@UserName,@Password,@IsAdmin,@Actived,@Remark) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateUser(User user, IDbConnection conn)
        {
            string sql = @"
            Update MD_User set 
                UserCode=@UserCode,UserName=@UserName,Password=@Password,IsAdmin=@IsAdmin,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@IsAdmin",user.IsAdmin));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            paramList.Add(new SqlParameter("@ID", user.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateUser(User user, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            Update MD_User set 
                UserCode=@UserCode,UserName=@UserName,Password=@Password,IsAdmin=@IsAdmin,Actived=@Actived,Remark=@Remark
            where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            paramList.Add(new SqlParameter("@ID", user.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteUser(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_User_Resource where User_ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);

            sql = @"Delete MD_User where ID=@ID";
            paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteUser(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_User_Resource where User_ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);

            sql = @"Delete MD_User where ID=@ID";
            paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<User> SelectAllUser(IDbConnection conn)
        {
            string sql = @"select ID,UserCode,UserName,Password,IsAdmin,Actived,Remark from MD_User";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<User> userList = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.ID = reader.GetInt32(0);
                user.Code = reader.GetString(1);
                user.Name = reader.GetString(2);
                user.Password = reader.GetString(3);
                user.IsAdmin = reader.GetBoolean(4);
                user.Actived = reader.GetBoolean(5);
                if (!reader.IsDBNull(6))
                {
                    user.Remark = reader.GetString(6);
                }
                userList.Add(user);
            }
            reader.Close();
            return userList;
        }
        public User SelectUser(string userCode, string password, IDbConnection conn)
        {
            string sql = @"select ID,UserCode,UserName,Password,IsAdmin,Actived,Remark from MD_User where UserCode=@UserCode and Password=@Password";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", userCode));
            paramList.Add(new SqlParameter("@Password", password));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<User> list = new List<User>();
            User user = null;
            while (reader.Read())
            {
                user = new User();
                user.ID = reader.GetInt32(0);
                user.Code = reader.GetString(1);
                user.Name = reader.GetString(2);
                user.Password = reader.GetString(3);
                user.IsAdmin = reader.GetBoolean(4);
                user.Actived = reader.GetBoolean(5);
                if (!reader.IsDBNull(6))
                {
                    user.Remark = reader.GetString(6);
                }
                list.Add(user);
            }
            if (list.Count==0)
            {
                return null;
            }
            if (list.Count > 1)
            {
                throw new ApplicationException("用户不为一。");
            }
            reader.Close();
            return user;
        }

        public void AddResourceIntoUser(int ResourceID, int UserID, IDbConnection conn)
        {
            string sql = @"insert into MD_User_Resource(User_ID,Resource_ID) values(@User_ID,@Resource_ID)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Resource_ID", ResourceID));
            paramList.Add(new SqlParameter("@User_ID", UserID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void AddResourceIntoUser(int ResourceID, int UserID, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"insert into MD_User_Resource(User_ID,Resource_ID) values(@User_ID,@Resource_ID)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Resource_ID", ResourceID));
            paramList.Add(new SqlParameter("@User_ID", UserID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }


        public void RemoveResourceIntoUser(int UserID, IDbTransaction trans)
        {
            string sql = @"delete MD_User_Resource where User_ID=@User_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@User_ID", UserID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void RemoveResourceFromUser(int UserID, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"delete MD_User_Resource where User_ID=@User_ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@User_ID", UserID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }
    }
}
