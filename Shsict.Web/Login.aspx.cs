using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Attributes["data-role"] = "button";
            btnLogout.Attributes["data-role"] = "button";
            btnLogin.Attributes["data-inline"] = "true";
            btnLogout.Attributes["data-inline"] = "true";
            //if (base.UID != null)
            //{
            //    tbun.Text = base.UID;
            //    tbun.Enabled = false;
            //    tbpass.Enabled = false;
            //    btnsubmit.Enabled = false;
            //}



            if (!IsPostBack)
            {
                tbun.Text = this.UID;
            }

            //if (xml.HasChildNodes && !xml.FirstChild.NextSibling.Name.Equals("error_response"))
            //{
            //  context.Response.SetCookie(new HttpCookie("session_key", xml.GetElementsByTagName("session_key").Item(0).InnerText));
            //  context.Response.SetCookie(new HttpCookie("uid", xml.GetElementsByTagName("uid").Item(0).InnerText));
            //context.Response.SetCookie(new HttpCookie("user_name", HttpUtility.UrlEncode(xml.GetElementsByTagName("user_name").Item(0).InnerText)));
            //}
        }



        protected void btnLogout_Click(object sender, EventArgs e)
        {

            try
            {
                if (base.UID != null)
                {
                    if (Request.Cookies["uid"] != null)
                    {
                        HttpCookie mycookie;
                        mycookie = Request.Cookies["uid"];
                        TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
                        mycookie.Expires = DateTime.Now.Add(ts);//立即过期 
                        Response.Cookies.Remove("uid");//清除 
                        Response.Cookies.Add(mycookie);//写入立即过期的*/
                        Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);
                    }
                    if (Request.Cookies["custom"] != null)
                    {
                        HttpCookie mycookie;
                        mycookie = Request.Cookies["custom"];
                        TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
                        mycookie.Expires = DateTime.Now.Add(ts);//立即过期 
                        Response.Cookies.Remove("custom");//清除 
                        Response.Cookies.Add(mycookie);//写入立即过期的*/
                        Response.Cookies["custom"].Expires = DateTime.Now.AddDays(-1);
                    }
                    if (Request.Cookies["NextURL"] != null)
                    {
                        HttpCookie mycookie;
                        mycookie = Request.Cookies["NextURL"];
                        TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
                        mycookie.Expires = DateTime.Now.Add(ts);//立即过期 
                        Response.Cookies.Remove("NextURL");//清除 
                        Response.Cookies.Add(mycookie);//写入立即过期的*/
                        Response.Cookies["NextURL"].Expires = DateTime.Now.AddDays(-1);
                    }

                } Response.Redirect("Portal.aspx");
            }
            catch
            {
                Response.Redirect("Portal.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ContainerPlanUser user = new ContainerPlanUser();

            user.Username = tbun.Text.ToUpper();
            user.Userpasswd = tbpass.Text.ToUpper();

            user.Select();

            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Usercd) && !string.IsNullOrEmpty(user.Userpasswd))
            {
                Response.SetCookie(new HttpCookie("uid", user.Username));
                Response.SetCookie(new HttpCookie("custom", user.Usercd));

                if (!string.IsNullOrEmpty(NextURL) && UID != null)
                {

                    Response.Redirect(NextURL);
                }
                else
                {
                    Response.Redirect("Portal.aspx");
                }
            }
            else
            {
                lblwrong.Visible = true;

            }

        }
        //private string Usercd
        //{
        //    get
        //    {
        //        string _usercd;
        //        if (!string.IsNullOrEmpty(Request.QueryString["MemberID"]))
        //        {
        //            return _usercd;
        //        }
        //        else
        //            return null;
        //    }
        //}
        //private void InitForm()
        //{
        //    if (!string.IsNullOrEmpty(Usercd))
        //    {
        //        ContainerPlanUser u = new ContainerPlanUser();
        //        u.Usercd = Usercd;
        //        u.Select();


        //    }
        //}
    }
}