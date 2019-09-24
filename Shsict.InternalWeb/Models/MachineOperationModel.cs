using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    public class MachineOperationDto
    {
        public List<MachineOperationUnit> UnitList { get; set; }
        public MachineOperationSummary Summary { get; set; }
        public string[] OpDate { get; set; }
    }

    public class MachineOperationSummary
    {
        public MachineOperationSummary() { }

        public MachineOperationSummary(DataRow dr)
        {
            InitMachineOperationSummaryModel(dr);
        }

        public void InitMachineOperationSummaryModel(DataRow dr)
        {
            if (dr != null)
            {
                MAXUNIT = dr["MAXUNIT"].ToString();
                MINUNIT = dr["MINUNIT"].ToString();
                AVGUNIT = dr["AVGUNIT"].ToString();
                DUTYMACH = dr["DUTYMACH"].ToString();
                SMACHTYPE = dr["SMACHTYPE"].ToString();
            }
            else
            {
                throw new Exception("Unable to init MachineOperationSummary.");
            }
        }

        #region members and propertis

        public string MAXUNIT { get; set; }

        public string MINUNIT { get; set; }

        public string AVGUNIT { get; set; }

        public string DUTYMACH { get; set; }

        public string SMACHTYPE { get; set; }

        #endregion

        // 如果需要对汇总数据进行分类，可以修改这个方法
        public static List<MachineOperationSummary> GetMachineOperationSummary(string opdate)
        {
            var dt = Shsict.DataAccess.MachineOperation.GetMachineOperationSummaryByDate(opdate);

            var list = new List<MachineOperationSummary>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MachineOperationSummary(dr));
                }
            }

            return list;
        }
    }


    public class MachineOperationUnit
    {
        public MachineOperationUnit() { }
        public MachineOperationUnit(DataRow dr)
        {
            InitMachineOperationUnit(dr);
        }

        public void InitMachineOperationUnit(DataRow dr)
        {
            if (dr != null)
            {
                
                MACHNO = dr["MACHNO"].ToString();
                MACHTYPE = dr["MACHTYPE"].ToString();
                UNIT = dr["UNIT"].ToString();
                LASTOPTM = dr["LASTOPTM"].ToString();
                LASTLOC = dr["LASTLOC"].ToString();
            }
            else
            {
                throw new Exception("Unable to init MachineOperationUnit.");
            }
        }

        #region members and propertis

    

        public string MACHNO { get; set; }

        public string MACHTYPE { get; set; }

        public string UNIT { get; set; }

        public string LASTOPTM { get; set; }

        public string LASTLOC { get; set; }


        #endregion

        // 重载这个方法，已加入时间参数
        public static List<MachineOperationUnit> GetMachineOperationUnit(string opdate)
        {
            var dt = Shsict.DataAccess.MachineOperation.GetMachineUnitByDate(opdate);

            var list = new List<MachineOperationUnit>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MachineOperationUnit(dr));
                }
            }

            return list;
        }
    }
}