using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugShop.Model;

namespace DrugShop.Date.SqlServer
{
    internal class EventLogDAO : IEventLogDAO
    {

        public void InsertEventLog(EventLog eventLog, IDbConnection conn)
        {
            string sql = @"insert into 
            MD_EventLog(Maker,MakeDate,ClientPC,Message,Remark) 
            values(@Maker,@MakeDate,@ClientPC,@Message,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Maker", eventLog.Maker));
            paramList.Add(new SqlParameter("@MakeDate", eventLog.MakeDate));
            paramList.Add(new SqlParameter("@ClientPC", eventLog.ClientPC));
            paramList.Add(new SqlParameter("@Message", eventLog.Message));
            paramList.Add(new SqlParameter("@Remark", eventLog.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteEventLog(int id, IDbConnection conn)
        {
            string sql = @"Delete MD_EventLog Where ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteEventLog(DateTime deadLine, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"Delete MD_EventLog Where CreatDate<@deadLine";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@deadLine", deadLine));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public List<EventLog> SelectEventLog(DateTime fromDate, DateTime toDate, IDbConnection conn)
        {
            string sql = @"
            Select ID,Maker,MakeDate,ClientPC,Message,Remark 
            from MD_EventLog
            where MakeDate between @fromDate to @toDate";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@fromDate", fromDate));
            paramList.Add(new SqlParameter("@toDate", toDate));
            return SelectEventLogs(sql, paramList, (SqlConnection)conn);

        }

        public List<EventLog> SelectAllEventLog(IDbConnection conn)
        {
            string sql = @"
            Select ID,Maker,MakeDate,ClientPC,Message,Remark 
            from MD_EventLog";
            return SelectEventLogs(sql, new List<SqlParameter>(), (SqlConnection)conn);
        }

        private List<EventLog> SelectEventLogs(string sql, List<SqlParameter> paramList,SqlConnection conn)
        {
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<EventLog> list = new List<EventLog>();
            while (reader.Read())
            {
                EventLog log = new EventLog();
                log.ID = reader.GetInt32(0);
                log.Maker = reader.GetString(1);
                log.MakeDate = reader.GetDateTime(2);
                log.ClientPC = reader.GetString(3);
                if (!reader.IsDBNull(4))
                {
                    log.Message = reader.GetString(4);
                }
                if (!reader.IsDBNull(5))
                {
                    log.Remark = reader.GetString(5);
                }
                list.Add(log);
            }
            reader.Close();
            return list;
        }
    }
}
