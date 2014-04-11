using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class Container_ArrangeTime_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void BindData()
        {
            try
            {
                List<Container> list = Container.Cache.ContainerList.FindAll(delegate(Container c)
                {
                    Boolean returnValue = true;
                    string tmpString = string.Empty;
                    if (ViewState["ArrangeTime"] != null)
                    {
                        tmpString = ViewState["ArrangeTime"].ToString();
                        if (!string.IsNullOrEmpty(tmpString))
                            returnValue = returnValue && (c.ContainerNo.Equals(tmpString, StringComparison.OrdinalIgnoreCase) || c.BillOfLadingNum.Equals(tmpString, StringComparison.OrdinalIgnoreCase));
                    }

                    return returnValue;
                });

                if (list == null)
                    throw new Exception("未找到相关船舶计划数据。");


                rptrContainerArrangeTime.DataSource = list;
                rptrContainerArrangeTime.DataBind();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(typeof(string), "failed", string.Format("alert('{0}');", ex.Message.ToString()), true);
            }
        }

        protected void txtTrackingSituation_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrackingSituation.Text))
            {
                ViewState["ArrangeTime"] = txtTrackingSituation.Text;
            }
            else
                ViewState["ArrangeTime"] = string.Empty;

            BindData();
        }

        protected void rptrContainerArrangeTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _strCP_Info = string.Empty;
                Container c = e.Item.DataItem as Container;

                Literal ltrlContainerArrangeTime = e.Item.FindControl("ltrlContainerArrangeTime") as Literal;

                if (ltrlContainerArrangeTime != null && c != null)
                {
                    string _tmpltrlText = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'Container_ArrangeTime_Detail.aspx?ContainerID={0}\'\"><h3>{1}</h3><p>计划安排时间：{2} </p></li>";

                    _strCP_Info = string.Format(_tmpltrlText, c.ID, c.ContainerNo, c.PlanAarrangeTime);

                    ltrlContainerArrangeTime.Text = _strCP_Info;

                }
                else { }

            }
            else { }
        }
    }
}