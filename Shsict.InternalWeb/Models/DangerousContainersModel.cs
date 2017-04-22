using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 危险品消防措施
    /// </summary>
    public class DangerousContainers
    {
        public DangerousContainers() { }

        public DangerousContainers(DataRow dr)
        {
            InitDangerousContainers(dr);
        }

        private void InitDangerousContainers(DataRow dr)
        {
            if (dr != null)
            {
   
                CNTRNO = dr["CNTRNO"].ToString();

                YLOCATION = dr["YLOCATION"].ToString();

                UNNO = dr["UNNO"].ToString();

                DNGGCD = dr["DNGGCD"].ToString();

                CSIZE = dr["CSIZE"].ToString();

                CTYPE = dr["CTYPE"].ToString();

                STS = dr["STS"].ToString();

                STGFG = dr["STGFG"].ToString();

                CSTTO = dr["CSTTO"].ToString();

                STGDAYS = dr["STGDAYS"].ToString();

                WS = dr["WS"].ToString();

                SS = dr["SS"].ToString();
            }
            else
            {
                throw new Exception("Unable to init DangerousContainers.");
            }
        }

        #region members and propertis

        public string CNTRNO { get; set; }

        public string YLOCATION { get; set; }

        public string UNNO { get; set; }

        public string DNGGCD { get; set; }

        public string CSIZE { get; set; }

        public string CTYPE { get; set; }

        public string STS { get; set; }

        public string STGFG { get; set; }

        public string CSTTO { get; set; }

        public string STGDAYS { get; set; }

        public string WS { get; set; }

        public string SS { get; set; }

        public string SEARCHKEY { get; set; }
        #endregion


        public static List<DangerousContainers> GetDangerousByCntrno(String Cntrno)
        {

            DataTable dt = Shsict.DataAccess.DangerousContainers.GetDangerousByCntrno(Cntrno);
            List<DangerousContainers> list = new List<DangerousContainers>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DangerousContainers(dr));
                }
            }

            return list;
        }

        public static List<DangerousContainers> GetDangerous()
        {

            DataTable dt = Shsict.DataAccess.DangerousContainers.GetDangerous();
            List<DangerousContainers> list = new List<DangerousContainers>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DangerousContainers(dr));
                }
            }

            return list;
        }

    }

}