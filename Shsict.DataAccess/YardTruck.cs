using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;


namespace Shsict.DataAccess
{
    /// <summary>
    /// 外集卡超时
    /// </summary>
    public class YardTruck
    {
        public static DataTable GetYardTrucks()
        {
            string sql = @"SELECT YARDNO ,INTRKNUM ,INWAITTM ,OUTTRKNUM ,OUTWAITTM ,RTGNO   
                            FROM  SSICT_APP_YARDTRUCK ORDER BY OUTWAITTM DESC ";

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