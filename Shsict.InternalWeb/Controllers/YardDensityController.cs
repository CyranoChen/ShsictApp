using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;
namespace Shsict.InternalWeb.Controllers
{
    public class YardDensityController : Controller
    {
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                id = DateTime.Now.ToString("yyyy-MM-dd");

            }

            var _YardDensity = Cache.YardDensityList.FindAll(t => t.YD_ID.Date.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_YardDensity.Count == 0)
            {
                YardDensity yardDensity = new YardDensity();

                yardDensity.YD_CNTR_STATUS = noData;
                yardDensity.YD_ID = DateTime.Parse(id);
                yardDensity.MyDate = id;

                _YardDensity.Add(yardDensity);
            }

            return View(_YardDensity.ToList());
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

                YardDensityList = YardDensity.GetYardDensitys();

            }

            public static List<YardDensity> YardDensityList;

        }

    }
}
