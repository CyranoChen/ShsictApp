using System;

namespace Shsict.Web
{
    public partial class Container_ArrangeTime_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

            if (!IsPostBack)
            {
                BindData();
            }
        }
        private int _ContainerID = int.MinValue;
        private int ContainerID
        {
            get
            {
                int _res;
                if (_ContainerID == 0)
                    return _ContainerID;
                else if (!string.IsNullOrEmpty(Request.QueryString["ContainerID"]) && int.TryParse(Request.QueryString["ContainerID"], out _res))
                    return _res;
                else
                    return int.MinValue;
            }
            set { _ContainerID = value; }
        }
        private void BindData()
        {

            if (ContainerID > 0)
            {
                Container con = Container.Cache.Load(ContainerID);
                lblContainerNo.Text = string.Format("<h3 class=\"p15\">{0}</h3>", con.ContainerNo);
                lblPlanAarrangeTime.Text = con.PlanAarrangeTime.ToString();
           
            }
        }
    }
}