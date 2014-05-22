using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class TwinLiftController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Import");
        }

        public ActionResult Import(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.ToString("yyyy-MM-dd");

            var _twinLift = Cache.TwinLiftList.FindAll(t => t.IEFG.ToUpper().Equals("I"));

            string noData = "暂无数据";

            if (_twinLift.Count == 0)
            {
                TwinLift twinLift = new TwinLift();

                twinLift.VESSELNAME = noData;
                twinLift.REPORTDATE = DateTime.Parse(id);
                twinLift.MyDate = id;

                _twinLift.Add(twinLift);
            }
            return View(_twinLift.ToList());
        }

        public ActionResult Export(string id)
        {
            var _twinLift = Cache.TwinLiftList.FindAll(t => t.IEFG.ToUpper().Equals("E"));

            string noData = "暂无数据";

            if (_twinLift.Count == 0)
            {
                TwinLift twinLift = new TwinLift();

                twinLift.VESSELNAME = noData;
                twinLift.REPORTDATE = DateTime.Parse(id);
                twinLift.MyDate = id;

                _twinLift.Add(twinLift);
            }
            return View(_twinLift.ToList());
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

                TwinLiftList = TwinLift.GetTwinLifts();

            }

            public static List<TwinLift> TwinLiftList;

        }

    }
}
