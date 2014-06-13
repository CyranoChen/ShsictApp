using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;
namespace Shsict.InternalWeb.Controllers
{
    public class PadMechanicalErrorController : Controller
    {
        [Authorize(Roles = "JX")]
        public ActionResult Index(string id)
        {
            List<MechanicalError> _MechanicalError;
            string user = this.HttpContext.Request.RequestContext.HttpContext.User.Identity.Name;

            if (id != null)
            {
                _MechanicalError = MechanicalErrorController.Cache.MechanicalErrorList.FindAll(t => t.MECHANICALNO.ToUpper().Contains(id.ToUpper()) && t.JobNo.Equals(user)).OrderByDescending(t => t.ERRORTIME).ToList();

            }
            else
            {
                _MechanicalError = MechanicalErrorController.Cache.MechanicalErrorList.FindAll(t => t.JobNo.Equals(user)).OrderByDescending(t => t.ERRORTIME).ToList();

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

    }
}
