using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;
namespace Shsict.InternalWeb.Controllers
{
    public class MechanicalErrorController : Controller
    {
        //
        // GET: /MechanicalError/

        public ActionResult Index()
        {
            var _MechanicalError = Cache.MechanicalErrorList;
            string noData = "暂无数据";

            if (_MechanicalError == null)
            {
                MechanicalError mechanicalError = new MechanicalError();

                mechanicalError.JobNo = noData;
               
                _MechanicalError.Add(mechanicalError);                        
            }
            return View(_MechanicalError.ToList());
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

                MechanicalErrorList = MechanicalError.GetMechanicalErrors();

            }

            public static List<MechanicalError> MechanicalErrorList;

        }
    }
}
