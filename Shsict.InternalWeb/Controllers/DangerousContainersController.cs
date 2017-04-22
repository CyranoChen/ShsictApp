using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class DangerousContainersController : Controller
    {
        [Authorize(Roles = "CQ")]
        public ActionResult Index(string id)
        {
            List<DangerousContainers> _DangerousContainers = new List<DangerousContainers>();
            if (string.IsNullOrEmpty(id))
            {

                DangerousContainers dngDangerousContainers = new DangerousContainers();

                dngDangerousContainers.CNTRNO = "暂无数据";
                //dngDangerousContainers.CNTRNO = id;

                
                _DangerousContainers.Add(dngDangerousContainers);
            }
            else
            {

                _DangerousContainers = Cache.DangerousContainersList.FindAll(t => t.CNTRNO.Contains(id.ToUpper()));
                string noData = "暂无数据";

                if (_DangerousContainers.Count == 0)
                {
                    DangerousContainers dngDangerousContainers = new DangerousContainers();

                    dngDangerousContainers.CNTRNO = noData;
                    //dngDangerousContainers.CNTRNO = id;


                    _DangerousContainers.Add(dngDangerousContainers);
                }

                _DangerousContainers[0].SEARCHKEY = id;
            }


            return View(_DangerousContainers.ToList());


        }

        //public ActionResult Index(string id)
        //{
        //    List<DangerousContainers> _DangerousContainers;

        //    if (string.IsNullOrEmpty(id))
        //    {
        //        DangerousContainers dngDangerousContainers = new DangerousContainers();
        //        dngDangerousContainers.CNTRNO = "请输入箱号";

        //        id = "";
        //        _DangerousContainers.Add(dngDangerousContainers);
        //    }
        //    else
        //    {

        //        _DangerousContainers = Cache.DangerousContainersList.FindAll(t => t.CNTRNO.Contains(id.ToUpper()));
        //        string noData = "暂无数据";

        //        if (_DangerousContainers.Count == 0)
        //        {
        //            DangerousContainers dngDangerousContainers = new DangerousContainers();

        //            dngDangerousContainers.CNTRNO = noData;
        //            dngDangerousContainers.CNTRNO = id;


        //            _DangerousContainers.Add(dngDangerousContainers);
        //        }

        //        _DangerousContainers[0].SEARCHKEY = id;

        //    }

        //    return View(_DangerousContainers.ToList());


        //}


        //public ActionResult Index(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        id = "";

        //    List<DangerousContainers> _DangerousContainers = Cache.DangerousContainersList.FindAll(t => t.CNTRNO.Contains(id.ToUpper()));

        //    string noData = "暂无数据";

        //    if (_DangerousContainers.Count == 0)
        //    {
        //        DangerousContainers dangerouscontainers = new DangerousContainers();

        //        dangerouscontainers.CNTRNO = noData;
        //        dangerouscontainers.CNTRNO = id;


        //        _DangerousContainers.Add(dangerouscontainers);
        //    }

        //    _DangerousContainers[0].SEARCHKEY = id;
        //    return View(_DangerousContainers.ToList());
        //}


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
                

                DangerousContainersList = DangerousContainers.GetDangerous();

            }

            public static List<DangerousContainers> DangerousContainersList;

        }

    }
}
