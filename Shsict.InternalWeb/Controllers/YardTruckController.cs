using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class YardTruckController : Controller
    {
        //
        // GET: /YardTruck/
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("TimeDesc");
        
        }

            [Authorize(Roles = "ZYL")]
        public ActionResult TimeAsc()
        {
            return View(Cache.YardTruckList.OrderBy(x => x.OUTWAITTM).ToList());
        
        }
            [Authorize(Roles = "ZYL")]
            public ActionResult TimeDesc()
            {
                return View(Cache.YardTruckList.OrderByDescending(x => x.OUTWAITTM).ToList());

            }
            [Authorize(Roles = "ZYL")]
            public ActionResult TruckAsc()
            {
                return View(Cache.YardTruckList.OrderBy(x => x.OUTTRKNUM).ToList());

            }
        
          [Authorize(Roles = "ZYL")]
            public ActionResult TruckDesc()
            {
                return View(Cache.YardTruckList.OrderByDescending(x => x.OUTTRKNUM).ToList());

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

                YardTruckList = YardTruck.GetYardTrucks();

            }

            public static List<YardTruck> YardTruckList;

        }
    }
}
