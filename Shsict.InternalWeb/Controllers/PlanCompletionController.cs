using Shsict.DataAccess;
using Shsict.InternalWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shsict.InternalWeb.Controllers
{
    public class PlanCompletionReturnModel
    {
        public string arr { get; set; }
        public PlanCompletionModel model { get; set; }
        public string MyTime { get; set; }
        public DateTime dateData { get; set; }
        public int max { get; set; }
    }
    //作业进度跟踪

    public class PlanCompletionController : Controller
    {

        [Authorize(Roles = "ZY")]
        public ActionResult Index(string id = null)
        {
            var model = new PlanCompletionReturnModel();


            DateTime shiftDate;
            if (id == null)
                shiftDate = DateTime.Now;
            else
            {
                try
                {
                    shiftDate = DateTime.Parse(id);
                }
                catch
                {
                    shiftDate = DateTime.Now;
                }
            }

            var mydata = Cache.MyDataList.FindAll(t => t.SHIFT_DATE.Date.Equals(shiftDate.Date));
            #region debug
            //var mydata = new List<ThroughputRatioModel>();
            //ThroughputRatioModel model11 = new ThroughputRatioModel();
            //model11.SHIFT_HOUR = "12";
            //model11.AMOUNT = 1370;
            //ThroughputRatioModel model1 = new ThroughputRatioModel();
            //model1.SHIFT_HOUR = "02";
            //model1.AMOUNT = 370;
            //ThroughputRatioModel model2 = new ThroughputRatioModel();
            //model2.SHIFT_HOUR = "16";
            //model2.AMOUNT = 970;
            //ThroughputRatioModel model3 = new ThroughputRatioModel();
            //model3.SHIFT_HOUR = "05";
            //model3.AMOUNT = 1356;
            //ThroughputRatioModel model4 = new ThroughputRatioModel();
            //model4.SHIFT_HOUR = "09";
            //model4.AMOUNT = 47;
            //ThroughputRatioModel model5 = new ThroughputRatioModel();
            //model5.SHIFT_HOUR = "07";
            //model5.AMOUNT = 1370;
            //ThroughputRatioModel model6 = new ThroughputRatioModel();
            //model6.SHIFT_HOUR = "23";
            //model6.AMOUNT = 977;
            //mydata.Add(model11);
            //mydata.Add(model1);
            //mydata.Add(model2);
            //mydata.Add(model3);
            //mydata.Add(model5);
            //mydata.Add(model4);
            //mydata.Add(model6);
            #endregion
            var arr = new double[24];
            int max = 0;
            if (mydata != null &&　mydata.Count > 0)
            {
                max = (int)mydata[0].AMOUNT;
                for (int i = 0; i < mydata.Count; i++)
                {
                    var sort = int.Parse(mydata[i].SHIFT_HOUR);
                    arr[sort] = mydata[i].AMOUNT;
                    if (mydata[i].AMOUNT > max)
                        max = (int)mydata[i].AMOUNT;
                }
            }
            model.arr = string.Join(",", arr);

            var mylist = Cache.MyFiveValues.Find(t => t.SHIFT_DATE.Date.Equals(shiftDate.Date));


            #region debug
            //var mylist = new PlanCompletionModel();
            //mylist.AMOUNT = 26000.10001;
            //mylist.PLANAMOUT = 18490.50005;
            //mylist.TIMESCHEDULE = "76.71%";
            //mylist.PlanCompletionRATE = "44.10%";
            #endregion
            if (mylist != null)
            {
                //判断时间是否是今天
                if (!shiftDate.Date.Equals(System.DateTime.Now.Date))
                {
                    //不是今天
                    mylist.TIMESCHEDULE = "100%";
                }

                var size = mylist.TIMESCHEDULE.Substring(0, mylist.TIMESCHEDULE.LastIndexOf("%"));
                if (double.Parse(size) > 100)
                {//超过100%
                    mylist.TIMESCHEDULE = "100%";
                }
            }
            model.model = mylist ?? new PlanCompletionModel() { PlanCompletionRATE = "0%", TIMESCHEDULE = "0%" };
            model.MyTime = shiftDate.ToString("yyyy-MM-dd");
            model.dateData = shiftDate;
            model.max = (int)(max * (1.4));
            return View(model);



        }


        public static class Cache
        {
            static Cache()
            {
                InitCache();
            }

            public static void RefreshCache()
            {
                InitCache();
            }

            private static void InitCache()
            {

                MyDataList = ThroughputRatioModel.GetMyData();
                MyFiveValues = PlanCompletionModel.GetFiveValues();

            }

            public static List<ThroughputRatioModel> MyDataList;
            public static List<PlanCompletionModel> MyFiveValues;

        }

    }

}
