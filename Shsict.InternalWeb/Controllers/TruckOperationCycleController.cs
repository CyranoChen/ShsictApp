using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class TruckOperationCycleController : Controller
    {
        //
        // GET: /TruckOperationCycle/

        public ActionResult Index(string id = "25")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id, out  i))
            {
                _TruckOperationCycles = Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i);
            }
            else
            {
                _TruckOperationCycles = Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25);

            }

            if (_TruckOperationCycles == null)
            {
                string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = noData;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.ToList());
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

                TruckOperationCycleList = TruckOperationCycle.GetTruckOperationCycles();

            }

            public static List<TruckOperationCycle> TruckOperationCycleList;

        }

    }
}
