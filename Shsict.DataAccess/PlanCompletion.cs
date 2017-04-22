using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    public class PlanCompletion
    {
        public static DataTable GetFiveValues()
        {
            string sql = @"select * from ssict_app_plancompletion_vw";

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

        public static DataTable GetFiveValuesByTime(DateTime reportDate)
        {
            string sql = @"select * from ssict_app_plancompletion_vm where shift_date=todate(:reportDate,'yyyy-mm-dd')";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("reportDate", reportDate);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

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
 