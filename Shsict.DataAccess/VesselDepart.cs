using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    public class VesselDepart
    {
//        public static DataRow GetThreeShiftByID(string sID)
//        {
//            string sql = @"SELECT  SHIFTDATE, SHIFT, SHIFTPLAN, SHIFTACTUAL, SHIFTCOMPLETERATE 
//                            FROM SSICT_APP_THREESHIFT_VW WHERE (ID = :tID)";

//            OracleParameter[] para = new OracleParameter[1];
//            para[0] = new OracleParameter("SID", sID);

//            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

//            if (ds.Tables[0].Rows.Count == 0)
//            {
//                return null;
//            }
//            else
//            {
//                return ds.Tables[0].Rows[0];
//            }
//        }

        public static DataTable GetVesselDeparts()
        {
            string sql = @"SELECT REPORT_DATE ,VSL_CNNAME  ,VBT_PDPTDT ,VBT_ADPTDT ,VBT_STATUS ,ISLATER ,WKLATER   
                            FROM  SSICT_DAILYREPORT_DEPART_VW";

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

//        public static DataTable GetThreeShiftByDate(DateTime shiftDate)
//        {
//            string sql = @"SELECT  SHIFTDATE, SHIFT, SHIFTPLAN, SHIFTACTUAL, SHIFTCOMPLETERATE 
//                            FROM  SSICT_APP_THREESHIFT_VW  WHERE SHIFTDATE=to_date(:shiftDate,'yyyy-mm-dd')";

//            OracleParameter[] para = new OracleParameter[1];
//            para[0] = new OracleParameter("shiftDate", shiftDate);

//            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

//            if (ds.Tables[0].Rows.Count == 0)
//            {
//                return null;
//            }
//            else
//            {
//                return ds.Tables[0];
//            }
//        }

    }
}
