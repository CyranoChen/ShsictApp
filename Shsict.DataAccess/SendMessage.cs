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
                            FROM SSICT_SENDMSG_VW ";

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

    
        
    }
}

