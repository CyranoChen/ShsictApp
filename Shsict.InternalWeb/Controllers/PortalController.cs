using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Shsict.InternalWeb.Controllers
{
    public class PortalController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var id = this.HttpContext.Request.RequestContext.HttpContext.User.Identity as FormsIdentity;

            if (id != null && id.IsAuthenticated)
            {
                string[] roles = id.Ticket.UserData.Split(',');

                return View(roles);
            }

            return View();
        }

    }
}
