using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class PadTruckOperationCycleController : Controller
    {
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("SortByTruck");
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByTruck(string id = "25")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id, out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i);
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25);

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.TRUCKNO).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByCompTruck(string id = "25")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id, out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i);
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25);

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.COMPLETETRUCKNUM).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByAvgTruck(string id = "25")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id, out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i);
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25);

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.AVEPERIOD).ToList());
        }


    }
}
