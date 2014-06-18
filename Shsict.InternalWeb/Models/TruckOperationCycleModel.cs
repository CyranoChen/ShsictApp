using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 单车运行周期
    /// </summary>
    public class TruckOperationCycle
    {
        public TruckOperationCycle() { }

        public TruckOperationCycle(DataRow dr)
        {
            InitTruckOperationCycle(dr);
        }

        private void InitTruckOperationCycle(DataRow dr)
        {
            if (dr != null)
            {  
                TRUCKNO = dr["TRUCKNO"].ToString();
                COMPLETETRUCKNUM = Int32.Parse(dr["COMPLETETRUCKNUM"].ToString());
                AVEPERIOD =double.Parse( dr["AVEPERIOD"].ToString());
                CURRENTINSTRUCTION = dr["CURRENTINSTRUCTION"].ToString();
             
            }
            else
            {
                throw new Exception("Unable to init TruckOperationCycle.");
            }
        }

        #region members and propertis
        public string TRUCKNO { get; set; }

        public int COMPLETETRUCKNUM { get; set; }

        public double AVEPERIOD { get; set; }

        public string CURRENTINSTRUCTION { get; set; }

        public int Sort { get; set; }
      
        #endregion

        public static List<TruckOperationCycle> GetTruckOperationCycles()
        {
            DataTable dt = Shsict.DataAccess.TruckStatus.GetTruckStatus();
            List<TruckOperationCycle> list = new List<TruckOperationCycle>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TruckOperationCycle(dr));
                }
            }

            return list;
        }
    }

}