using System;
using System.Linq;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class MachineOperationController : Controller
    {
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("Crane");
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult Crane(string date, string shift)
        {
            var opdate = GetOpDateStr(date, shift);
            opdate = !string.IsNullOrEmpty(opdate) ? opdate : GetOpDateStr();

            var model = new MachineOperationDto
            {
                UnitList = MachineOperationUnit.GetMachineOperationUnit(opdate)
                    .FindAll(t => t.MACHTYPE.Equals("桥吊"))
                    .OrderBy(t => t.MACHNO).ToList(),

                Summary = MachineOperationSummary.GetMachineOperationSummary(opdate)
                    .FindAll(t => t.SMACHTYPE.Equals("桥吊")).FirstOrDefault(),

                OpDate = new[]
                {
                    date ?? DateTime.Today.ToString("yyyy-MM-dd"),
                    shift ?? GetShiftStr()
                }
            };

            return View(model);
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult RTG(string date, string shift)
        {
            var opdate = GetOpDateStr(date, shift);
            opdate = !string.IsNullOrEmpty(opdate) ? opdate : GetOpDateStr();

            var model = new MachineOperationDto
            {
                UnitList = MachineOperationUnit.GetMachineOperationUnit(opdate)
                    .FindAll(t => t.MACHTYPE.Equals("轮胎吊"))
                    .OrderBy(t => t.MACHNO).ToList(),

                Summary = MachineOperationSummary.GetMachineOperationSummary(opdate)
                    .FindAll(t => t.SMACHTYPE.Equals("轮胎吊")).FirstOrDefault(),

                OpDate = new[]
                {
                    date ?? DateTime.Today.ToString("yyyy-MM-dd"),
                    shift ?? GetShiftStr()
                }
            };

            return View(model);
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult Forklift(string date, string shift)
        {
            var opdate = GetOpDateStr(date, shift);
            opdate = !string.IsNullOrEmpty(opdate) ? opdate : GetOpDateStr();

            var model = new MachineOperationDto
            {
                UnitList = MachineOperationUnit.GetMachineOperationUnit(opdate)
                    .FindAll(t => t.MACHTYPE.Equals("正面吊/空铲"))
                    .OrderBy(t => t.MACHNO).ToList(),

                Summary = MachineOperationSummary.GetMachineOperationSummary(opdate)
                    .FindAll(t => t.SMACHTYPE.Equals("正面吊/空铲")).FirstOrDefault(),

                OpDate = new[]
                {
                    date ?? DateTime.Today.ToString("yyyy-MM-dd"),
                    shift ?? GetShiftStr()
                }
            };

            return View(model);
        }

        private string GetOpDateStr(string date, string shift)
        {
            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(shift))
            {
                DateTime opDate;
                if (DateTime.TryParse(date, out opDate))
                {
                    if (shift.Equals("daytime", StringComparison.OrdinalIgnoreCase))
                    {
                        return $"{opDate.ToString("yyyy-MM-dd")}|2";
                    }

                    if (shift.Equals("night", StringComparison.OrdinalIgnoreCase))
                    {
                        return $"{opDate.AddDays(+1).ToString("yyyy-MM-dd")}|1";
                    }
                }
            }

            return string.Empty;
        }

        private static string GetOpDateStr()
        {
            var now = DateTime.Now;

            if (now.Hour > 7 && now.Hour < 19)
            {
                return now.ToString("yyyy-MM-dd") + "|2";
            }

            if (now.Hour >= 19)
            {
                return now.AddDays(1).ToString("yyyy-MM-dd") + "|1";
            }

            return now.ToString("yyyy-MM-dd") + "|1";
        }

        private static string GetShiftStr()
        {
            var now = DateTime.Now;

            if (now.Hour > 7 && now.Hour < 19)
            {
                return "daytime";
            }

            return "night";
        }
    }
}
