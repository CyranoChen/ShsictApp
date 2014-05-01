using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;



using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class ThreeShiftController : Controller
    {
        //
        // GET: /ThreeShift/
        //private ShsictConext db = new ShsictConext();
        //[HttpPost]
        public ActionResult Index(string _date = "2013/9/19")
        {
            //IList<ThreeShift> _threeShift = db.ThreeShift.ToList();
            //var _threeShift = db.ThreeShift.ToList();
            //var _threeShifts = (from p in db.ThreeShift where p.SHIFTDATE == DateTime.Parse("2013/9/19") select p);


            var _threeShifts = Cache.ThreeShiftList.FindAll(t => t.SHIFTDATE.Equals(DateTime.Parse(_date)));
            ////if (_threeShift == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(_threeShifts);
            return View(_threeShifts.ToList());
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

                ThreeShiftList = ThreeShift.GetContainerMains();
                //TruckList_Active = TruckList.FindAll(delegate(OTruck t) { return true; });
            }

            public static ThreeShift Load(string SID)
            {
                return ThreeShiftList.Find(delegate(ThreeShift t) { return t.SID.Equals(SID); });
                //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
            }

            public static List<ThreeShift> ThreeShiftList;
            //public static List<OTruck> TruckList_Active;
        }

    }
}
