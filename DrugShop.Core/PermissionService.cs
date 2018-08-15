using System;
using System.Collections.Generic;
using System.Text;
using DrugShop.Model;
using System.Data;
using DrugShop.Date;

namespace DrugShop.Core
{
    public  class PermissionService
    {
        public List<Resource> GetAllResources()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IResourceDAO dao = DAOFactory.Instance.CreateResourceDAO();
                return dao.SelectAllResource(conn);
            }
        }
        private static User _CurrentUser = null;
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="code">登录ID</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public User Login(string code,string password)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                User user = dao.SelectUser(code,password,conn);
                if (user==null)
                {
                    throw new ApplicationException("用户名或密码不正确，登录失败");
                }
                if (!user.Actived)
                {
                    throw new ApplicationException("用户已经注销，不能登录");
                }
                _CurrentUser = user;
                return user;
            }
        }
        public bool IsUserAccess(string resourceName)
        {
            User user = GetCurrentUser();
            List<Resource> list = GetUserResource(user);
            List<string> resourceNameList = new List<string>();
            foreach (Resource r in list)
            {
                resourceNameList.Add(r.Name);
            }

            return resourceNameList.Contains(resourceName);

        }
        /// <summary>
        /// 获取当前登录用户
        /// 如果没有登录用户，则抛出异常
        /// </summary>
        /// <returns></returns>
        public static User GetCurrentUser()
        {
            if (_CurrentUser==null)
            {
                throw new ApplicationException("用户还没登录，请先登录");
            }
            return _CurrentUser;
        }
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="user">需要获取权限用户</param>
        /// <returns></returns>
        public List<Resource> GetUserResource(User user)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IResourceDAO dao = DAOFactory.Instance.CreateResourceDAO();
                return dao.SelectResource(user.ID,conn);
            }
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">创建的用户信息</param>
        /// <param name="maker">创建人</param>
        public void CreateUser(User user,string maker)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                dao.InsertUser(user,conn);
            }
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">修改的用户</param>
        /// <param name="maker">修改人</param>
        public void ModifyUser(User user, string maker)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                dao.UpdateUser(user,conn);
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">删除的用户</param>
        /// <param name="maker">操作人</param>
        public void DeleteUser(User user, string maker)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                    dao.DeleteUser(user.ID, conn,trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 初始化所有资源列表
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public void InitResources(List<Resource> res)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IResourceDAO dao = DAOFactory.Instance.CreateResourceDAO();
                    foreach (Resource  r in res)
                    {
                        dao.InsertResource(r,conn,trans);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="res">资源（权限）</param>
        public void SetUserResources(User user,List<Resource > res)
        {
            using (IDbConnection conn=DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                    dao.RemoveResourceFromUser(user.ID,conn,trans);
                    foreach (Resource r in res)
                    {
                        dao.AddResourceIntoUser(r.ID,user.ID,conn,trans);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                return dao.SelectAllUser(conn);
            }
        }
    }
}
