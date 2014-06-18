using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 未完成维修的机械及故障时间
    /// </summary>
    public class SendMessage
    {
        public static DataRow GetSendMessageByID(string sID)
        {
            string sql = @"SELECT  ID, JobNo, SENDMESSAGE, SENDTIME, ERRORTIME, ISSEND, MECHANICALNO 
                            FROM SSICT_SENDMSG_VW WHERE (ID = :tID)";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("SID", sID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetSendMessages()
        {
            string sql = @"SELECT  ID, JobNo, SENDMESSAGE, SENDTIME, ERRORTIME, ISSEND, MECHANICALNO 
                            FROM SSICT_SENDMSG_VW  Order By ISSEND desc";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetFaultMessages()
        {
            string sql = @"SELECT ID ,EMPID ,SHIFTGROUP ,MACNO ,MSGCONTENT ,BEGINTIME ,ENDTIME ,DELAY ,
                           FAULTID ,FG ,SEND ,UPDATEREASON ,UPDATETIME ,SMSSENDTIME ,SMSSENDFLAG  
                            FROM SM_FAULT_MSGREMIND ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static void UpdateSendMessages(string sID)
        {
            string sql = @"DECLARE RS VARCHAR2(20);BEGIN RS:=SSICT_MSGFLAGUPDATE_F(:sID); END;";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("sID", Int64.Parse(sID));

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetInternalTableConnection(), sql, para);
        }

    }
}

