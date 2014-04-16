using Shsict.AutoRefresh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState; 

namespace Shsict.Web
{
    /// <summary>
    /// RefreshCacheHandler 的摘要说明
    /// </summary>
    public class RefreshCacheHandler : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(context.Request.QueryString["condition"]))
                {
                    if (context.Request.QueryString["condition"].Equals("start"))
                    {
                        string _ThreadId = CacheRefresh.Start().ToString();
                        context.Session["ThreadId"] = _ThreadId;
                        responseText = _ThreadId;

                    }
                    else if (context.Request.QueryString["condition"].Equals("suspend"))
                    {
                        try
                        {
                            responseText = CacheRefresh.Suspend().ToString();
                            //responseText = "success";
                        }
                        catch { responseText = "error"; }
                    }
                    else if (context.Request.QueryString["condition"].Equals("resume"))
                    {
                        try
                        {
                            responseText = CacheRefresh.Resume().ToString();
                            //responseText = "success";
                        }
                        catch { responseText = "error"; }
                    }
                    else if (context.Request.QueryString["condition"].Equals("status"))
                    {

                        responseText = CacheRefresh.thdRefreshCach.ThreadState.ToString();
                    }
                }
                else
                {
                    throw new Exception("Invalid Medthod Parameter");
                }

            }
            catch (Exception ex)
            {
                responseText = ex.Message;
            }
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(responseText);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}