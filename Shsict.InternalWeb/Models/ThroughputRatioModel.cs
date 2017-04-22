using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shsict.InternalWeb.Models
{
    public class ThroughputRatioModel
    {
        public ThroughputRatioModel() { }

        public ThroughputRatioModel(DataRow dr)
        {
            InitThroughputRatio(dr);
        }

        private void InitThroughputRatio(DataRow dr)
        {
            if (dr != null)
            {

                SHIFT_DATE = DateTime.Parse(dr["SHIFT_DATE"].ToString());
                SHIFT_HOUR = dr["SHIFT_HOUR"].ToString();
                REAL_HOUR = int.Parse(dr["REAL_HOUR"].ToString());
                AMOUNT = double.Parse(dr["AMOUNT"].ToString());
            }


            //MyLASTALLDAY_COMPLETERATE = double.Parse(LASTALLDAY_COMPLETERATE).ToString("0.##%");

            else
            {
                throw new Exception("Unable to init ThroughputRatio.");
            }
        }

        #region members and propertis

        public DateTime SHIFT_DATE { get; set; }

        public string SHIFT_HOUR { get; set; }

        public int REAL_HOUR { get; set; }

        public double AMOUNT { get; set; }
 
        #endregion
 

        public static List<ThroughputRatioModel> GetMyDataByTime(DateTime Date)
        {

            DataTable dt = Shsict.DataAccess.ThroughputRatio.GetMyDataByTime(Date);
            List<ThroughputRatioModel> list = new List<ThroughputRatioModel>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ThroughputRatioModel(dr));
                }
            }

            return list;
        }

        public static List<ThroughputRatioModel> GetMyData()
        {
            DataTable dt = Shsict.DataAccess.ThroughputRatio.GetMyData();
            List<ThroughputRatioModel> list = new List<ThroughputRatioModel>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ThroughputRatioModel(dr));
                }
            }

            return list;
        }


    }

}
 