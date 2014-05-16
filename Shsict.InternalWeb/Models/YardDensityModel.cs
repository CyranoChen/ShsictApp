using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 堆场利用率
    /// </summary>
    public class YardDensity
    {
        public YardDensity() { }

        public YardDensity(DataRow dr)
        {
            InitYardDensity(dr);
        }

        private void InitYardDensity(DataRow dr)
        {
            if (dr != null)
            {
                YD_ID = DateTime.Parse(dr["YD_ID"].ToString());
                YD_CNTR_STATUS = dr["YD_CNTR_STATUS"].ToString();
                YD_SAC_SUM = dr["YD_SAC_SUM"].ToString();
                YD_YARD_SLOT_SUM = dr["YD_YARD_SLOT_SUM"].ToString();
                YD_YARD_SLOT_TOTAL = dr["YD_YARD_SLOT_TOTAL"].ToString();
                YD_PCT = double.Parse(dr["round(YD_PCT,5)"].ToString());
                YD_DES = dr["round(YD_DES,5)"].ToString();

                MyDate = YD_ID.ToString("yyyy-MM-dd");
                MyYD_PCT=YD_PCT.ToString("0.##%");
            }
            else
            {
                throw new Exception("Unable to init YardDensity.");
            }
        }

        #region members and propertis
        public DateTime YD_ID { get; set; }

        public string YD_CNTR_STATUS { get; set; }

        public string YD_SAC_SUM { get; set; }

        public string YD_YARD_SLOT_SUM { get; set; }

        public string YD_YARD_SLOT_TOTAL { get; set; }

        public double YD_PCT { get; set; }

        public string YD_DES { get; set; }

        public string MyDate { get; set; }

        public string MyYD_PCT { get; set; }
        
        #endregion

        public static List<YardDensity> GetYardDensitys()
        {
            DataTable dt = Shsict.DataAccess.YardDensity.GetYardDensitys();
            List<YardDensity> list = new List<YardDensity>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new YardDensity(dr));
                }
            }

            return list;
        }
    }

}