using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shsict.InternalWeb.Controllers
{
    public class PadYardTruckController : Controller
    {
        //
        // GET: /PadYardTruck/
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("TimeDesc");

        }

        [Authorize(Roles = "ZYL")]
        public ActionResult TimeAsc()
        {
            return View(YardTruckController.Cache.YardTruckList.OrderBy(x => x.OUTWAITTM).ToList());

        }
        [Authorize(Roles = "ZYL")]
        public ActionResult TimeDesc()
        {
            return View(YardTruckController.Cache.YardTruckList.OrderByDescending(x => x.OUTWAITTM).ToList());

        }
        [Authorize(Roles = "ZYL")]
        public ActionResult TruckAsc()
        {
            return View(YardTruckController.Cache.YardTruckList.OrderBy(x => x.OUTTRKNUM).ToList());

        }

        [Authorize(Roles = "ZYL")]
        public ActionResult TruckDesc()
        {
            return View(YardTruckController.Cache.YardTruckList.OrderByDescending(x => x.OUTTRKNUM).ToList());

        }
    }
}
