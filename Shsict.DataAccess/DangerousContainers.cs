using  System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    public class DangerousContainers
    {
        /// <summary>
        /// 危险品消防查询
        /// </summary>
        public static DataTable GetDangerousByCntrno(string STRcntrno)
        {
            string sql = @"SELECT CNTRNO,YLOCATION,UNNO,DNGGCD,CSIZE,CTYPE,STS,STGFG,CSTTO,STGDAYS,ssict_get_fireprotection_F(unno,'UN') SS,ssict_get_fireprotection_F(dnggcd,'DNG') WS 
                        FROM SSICT_DANGEROUS_CONTAINERS WHERE CNTRNO like :STRcntrno";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("CNTRNO", STRcntrno);

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

        public static DataTable GetDangerous()
        {
            string sql = @"SELECT CNTRNO,YLOCATION,UNNO,DNGGCD,CSIZE,CTYPE,STS,STGFG,CSTTO,STGDAYS,ssict_get_fireprotection_F(unno,'UN') SS,ssict_get_fireprotection_F(dnggcd,'DNG') WS
                        FROM SSICT_DANGEROUS_CONTAINERS ";

      

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
