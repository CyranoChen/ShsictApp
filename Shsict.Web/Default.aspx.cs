using System;

namespace Shsict.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////base.isFootVisible = true;
            //PageBase.PageBase myMasterPage = new PageBase.PageBase();
            //myMasterPage.IsFootVisible = true;
            Session["mode"] = "pc";
        }
    }
}