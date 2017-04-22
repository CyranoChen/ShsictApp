using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shsict.InternalWeb.Models
{
    public class PlanCompletionModel
    {
        public PlanCompletionModel() { }

        public PlanCompletionModel(DataRow dr)
        {
            InitPlanCompletionModel(dr);
        }

        private void InitPlanCompletionModel(DataRow dr)
        {
            if (dr != null)
            {

                SHIFT_DATE = DateTime.Parse(dr["SHIFT_DATE"].ToString());
                PlanCompletionRATE = dr["PlanCompletionRATE"].ToString();
                TIMESCHEDULE = dr["TIMESCHEDULE"].ToString();
                AMOUNT = double.Parse(dr["AMOUNT"].ToString());
                PLANAMOUT = double.Parse(dr["PLANAMOUT"].ToString());
            }


            //MyLASTALLDAY_COMPLETERATE = double.Parse(LASTALLDAY_COMPLETERATE).ToString("0.##%");

            else
            {
                throw new Exception("Unable to init PlanCompletion.");
            }
        }

        #region members and propertis

        public DateTime SHIFT_DATE { get; set; }

        public string PlanCompletionRATE { get; set; }

        public string TIMESCHEDULE { get; set; }

        public double AMOUNT { get; set; }
        public double PLANAMOUT { get; set; }

        #endregion


        public static List<PlanCompletionModel> GetFiveValuesByTime(DateTime Date)
        {

            DataTable dt = Shsict.DataAccess.PlanCompletion.GetFiveValuesByTime(Date);
            List<PlanCompletionModel> list = new List<PlanCompletionModel>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PlanCompletionModel(dr));
                }
            }

            return list;
        }

        public static List<PlanCompletionModel> GetFiveValues()
        {
            DataTable dt = Shsict.DataAccess.PlanCompletion.GetFiveValues();
            List<PlanCompletionModel> list = new List<PlanCompletionModel>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PlanCompletionModel(dr));
                }
            }

            return list;
        }
    }
}