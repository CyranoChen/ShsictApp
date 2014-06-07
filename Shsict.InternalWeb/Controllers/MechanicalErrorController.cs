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
          [Authorize(Roles = "JX")]
        public ActionResult Index(string id)
        {
            List<MechanicalError> _MechanicalError;

            if (id != null)
            {
                _MechanicalError = Cache.MechanicalErrorList.FindAll(t => t.MECHANICALNO.ToUpper().Contains(id.ToUpper()));

            }
            else
            {
                _MechanicalError = Cache.MechanicalErrorList;
            }

            string noData = "暂无数据";

            if (_MechanicalError == null || _MechanicalError.Count == 0)
            {
                MechanicalError mechanicalError = new MechanicalError();

                mechanicalError.MECHANICALNO = noData;

                _MechanicalError.Add(mechanicalError);
            }


            _MechanicalError[0].SEARCHKEY = id;
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
