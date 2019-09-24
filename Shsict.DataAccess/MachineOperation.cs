using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.OracleClient;

namespace Shsict.DataAccess
{
    public static class MachineOperation
    {
        //public static DataTable GetMachineUnit()
        //{
        //    string shift = GetShiftDate(DateTime.Now);
        //    string sql = @"select MACHNO,MACHTYPE,UNIT,round((sysdate-lastoptime)*24*60,0) LASTOPTM,LASTLOC from SSICT_APP_MACHINEOPERATION where opdate='" + shift + "'";

        //    DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql);

        //    if (ds.Tables[0].Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return ds.Tables[0];
        //    }
        //}

        public static DataTable GetMachineUnitByDate(string opDate)
        {
            string sql = @"select MACHNO,MACHTYPE,UNIT,round((sysdate-lastoptime)*24*60,0) LASTOPTM,LASTLOC from  SSICT_APP_MACHINEOPERATION  where opdate=:opDate";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("opDate", opDate);

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

        //public static DataTable GetMachineOperationSummary()
        //{
        //    string shift = GetShiftDate(DateTime.Now);
        //    string sql = @"select max(unit) MAXUNIT,min(unit) MINUNIT,floor(avg(unit)) AVGUNIT,count(*) DUTYMACH,MACHTYPE SMACHTYPE from SSICT_APP_MACHINEOPERATION where opdate='" + shift + "' group by MACHTYPE";

        //    DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql);

        //    if (ds.Tables[0].Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return ds.Tables[0];
        //    }
        //}

        public static DataTable GetMachineOperationSummaryByDate(string opDate)
        {
            string sql = @"select max(unit) MAXUNIT,min(unit) MINUNIT,floor(avg(unit)) AVGUNIT,count(*) DUTYMACH,MACHTYPE SMACHTYPE from SSICT_APP_MACHINEOPERATION where opdate= :opDate group by MACHTYPE";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("opDate", opDate);

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
