using Shsict.Entity;
using System;
using System.Collections.Generic;

namespace Shsict.Web
{
    public partial class Container_ArrangeTime_Detail : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //login
            AnonymousRedirect = true;

            base.OnInitComplete(e);

            if (!IsPostBack)
            {
                BindData();
            }

        }
        private string NoType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["NoType"]))
                {
                    return Request.QueryString["NoType"];
                }
                else
                {
                    return null;
                }
            }
        }
        private string ArrangeTime
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ArrangeTime"]))
                {
                    return Request.QueryString["ArrangeTime"];
                }
                else
                {
                    return null;
                }
            }
        }
        private void BindData()
        {

            if (!string.IsNullOrEmpty(ArrangeTime))
            {
                TVDangerPlan tcDanger = TVDangerPlan.Cache.Load(ArrangeTime);
                if (!string.IsNullOrEmpty(NoType) && NoType.ToUpper() == "A")
                {
                    lblTitleNo.Text = string.Format("<h3 class=\"p15\">申请编号:{0}</h3>", tcDanger.ID);
                }
                else
                {
                    lblTitleNo.Text = string.Format("<h3 class=\"p15\">计划号:{0}</h3>", tcDanger.PLANNO);
                }
            
                lblVesselVoyage.Text = tcDanger.VESSELVOYAGE;
                lblArrivePlanTime.Text = tcDanger.ARRIVE_PLAN_TIME.ToString();
                lblDeparturePlanTime.Text = tcDanger.DEPARTURE_PLAN_TIME.ToString();
                lblTVDate.Text = tcDanger.TVDATE.ToString();
                lblExActTvDate.Text = tcDanger.EXACTTVDATE.ToString();


                string _ContainerNo="";
                 List<TVDangerContainer> list = TVDangerContainer.GetTVDangerContainers(tcDanger.PLANNO).FindAll(delegate(TVDangerContainer t)
                {
                 _ContainerNo+=t.CONTAINERNO+"<br>";
                  return true;
                 });

                 lblContainerNo.Text = _ContainerNo;
            }
        }

    }
}