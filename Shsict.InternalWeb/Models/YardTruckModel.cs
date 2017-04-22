using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 外集卡超时
    /// </summary>
    public class YardTruck
    {
        public YardTruck() { }

        public YardTruck(DataRow dr)
        {
            InitYardTruck(dr);
        }

        private void InitYardTruck(DataRow dr)
        {
            if (dr != null)
            {

                YARDNO = dr["YARDNO"].ToString();

                INTRKNUM = dr["INTRKNUM"].ToString();

                INWAITTM = dr["INWAITTM"].ToString();

                OUTTRKNUM =  double.Parse(dr["OUTTRKNUM"].ToString());

                OUTWAITTM = double.Parse(dr["OUTWAITTM"].ToString());

                RTGNO = dr["RTGNO"].ToString();


            }
            else
            {
                throw new Exception("Unable to init YardTruck.");
            }
        }

        #region members and propertis

        public string YARDNO { get; set; }

        public string INTRKNUM { get; set; }

        public string INWAITTM { get; set; }

        public double OUTTRKNUM { get; set; }

        public double OUTWAITTM { get; set; }

        public string RTGNO { get; set; }

        #endregion

        public static List<YardTruck> GetYardTrucks()
        {
            DataTable dt = Shsict.DataAccess.YardTruck.GetYardTrucks();
            List<YardTruck> list = new List<YardTruck>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new YardTruck(dr));
                }
            }

            return list;
        }

    }

}