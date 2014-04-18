using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Shsict.Entity
{
    /// <summary>
    /// 更新日志
    /// </summary>
    public class LogEvent
    {
        public LogEvent() { }

        public LogEvent(DataRow dr)
        {
            InitLogEvent(dr);
        }

        private void InitLogEvent(DataRow dr)
        {
            if (dr != null)
            {
                LOGID = dr["LOGID"].ToString();
                EventType = (LogType)Enum.Parse(typeof(LogType), dr["EventType"].ToString());
                Message = dr["Message"].ToString();
                ErrorStackTrace = dr["ErrorStackTrace"].ToString();
                    EventDate = DateTime.Parse(dr["EventDate"].ToString());
               
               
            }
            else
            {
                throw new Exception("Unable to init LogEvent.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.LogEvent.GetLogEventByID(LOGID);

            if (dr != null)
            {
                InitLogEvent(dr);
            }
        }

        public void Insert()
        {
            Shsict.DataAccess.LogEvent.InsertLogEvent(LOGID, EventType.ToString(), Message, ErrorStackTrace, (DateTime)EventDate);

        }

        public void Update()
        {
            Shsict.DataAccess.LogEvent.UpdateLogEvent(LOGID, EventType.ToString(), Message, ErrorStackTrace, (DateTime)EventDate);

        }

        public void Delete()
        {
            Shsict.DataAccess.LogEvent.DeleteLogEvent(LOGID);

        }

        public static List<LogEvent> GetLogEvents()
        {
            DataTable dt = Shsict.DataAccess.LogEvent.GetLogEvents();
            List<LogEvent> list = new List<LogEvent>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LogEvent(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// 插入LOG表
        /// </summary>
        /// <param name="let">LOG类型</param>
        /// <param name="message">LOG信息</param>
        /// <param name="errorStackTrace">异常堆栈</param>
        public static void Logging(LogType let, string message, string errorStackTrace)
        {
            LogEvent l = new LogEvent();
            l.EventType = let;
            l.EventDate = DateTime.Now.ToLocalTime();
            l.Message = message;
            l.ErrorStackTrace = errorStackTrace;
            l.Insert();
        }

        /// <summary>
        /// 记录执行成功消息
        /// </summary>
        /// <param name="msgSuccess"></param>
        public static void logSuccess(string msgSuccess)
        {
            Logging(LogType.Success, msgSuccess, string.Empty);
        }
        public static void logErro(Exception exp)
        {
            Logging(LogType.Error, exp.Message, exp.StackTrace);
        }
        public static void logErroMsg(string msgErro)
        {
            Logging(LogType.Error, msgErro, string.Empty);
        }

        #region members and propertis
        public string LOGID { get; set; }
        public LogType EventType { get; set; }
        public string Message { get; set; }
        public string ErrorStackTrace { get; set; }
        public DateTime EventDate { get; set; }
        #endregion
        public enum LogType
        {
            Success,
            Error
        }
    }
}



