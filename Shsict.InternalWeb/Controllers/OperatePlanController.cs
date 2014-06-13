﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class OperatePlanController : Controller
    {
          [Authorize(Roles = "CQ")]
        public ActionResult Index()
        {
            return RedirectToAction("DayShift");

        }

           [Authorize(Roles = "CQ")]
        public ActionResult DayShift(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.ToString("yyyy-MM-dd");

            var _OperatePlan = Cache.OperatePlanList.FindAll(t => t.SHIFT.Trim().Equals("日") && t.SHIFT_DATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_OperatePlan.Count == 0)
            {
                OperatePlan operatePlan = new OperatePlan();
                operatePlan.TEAMNAME = noData;
                operatePlan.MyDate = id;
                _OperatePlan.Add(operatePlan);

            }
            return View(_OperatePlan.ToList());
        }

           [Authorize(Roles = "CQ")]
        public ActionResult NightShift(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.ToString("yyyy-MM-dd");

            var _OperatePlan = Cache.OperatePlanList.FindAll(t => t.SHIFT.Trim().Equals("夜") && t.SHIFT_DATE.Equals(DateTime.Parse(id)));
            string noData = "暂无数据";
            if (_OperatePlan.Count == 0)
            {
                OperatePlan operatePlan = new OperatePlan();
                operatePlan.TEAMNAME = noData;
                operatePlan.MyDate = id;
                _OperatePlan.Add(operatePlan);

            }

            return View(_OperatePlan.ToList());
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

                OperatePlanList = OperatePlan.GetOperatePlans();

            }

            public static List<OperatePlan> OperatePlanList;

        }
    }

}