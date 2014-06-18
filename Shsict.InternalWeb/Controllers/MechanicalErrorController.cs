using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;
using System.Web.Security;
namespace Shsict.InternalWeb.Controllers
{
    public class MechanicalErrorController : Controller
    {
        [Authorize(Roles = "JX")]
        public ActionResult Index(string id)
        {
            List<MechanicalError> _MechanicalError;

            string user = this.HttpContext.Request.RequestContext.HttpContext.User.Identity.Name;

            if (!string.IsNullOrEmpty(id))
            {
                _MechanicalError = Cache.MechanicalErrorList.FindAll(t => t.MECHANICALNO.ToUpper().Contains(id.ToUpper()) && t.JobNo.Equals(user)).OrderByDescending(t => t.ERRORTIME).ToList();

            }
            else
            {
                _MechanicalError = Cache.MechanicalErrorList.FindAll(t => t.JobNo.Equals(user)).OrderByDescending(t => t.ERRORTIME).ToList();

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

        public void Update(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    MechanicalError.UpdateMechanicalError(id.Trim());

                    MechanicalErrorController.Cache.RefreshCache();

                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
            }
            catch
            {
                Response.Write("error");
            }
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
