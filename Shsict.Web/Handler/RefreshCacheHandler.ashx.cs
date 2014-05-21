using Shsict.AutoRefresh;
using System;
using System.Web;


namespace Shsict.Web
{
    /// <summary>
    /// RefreshCacheHandler 的摘要说明
    /// </summary>
    public class RefreshCacheHandler : IHttpHandler
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
                        try
                        {
                            CacheRefresh.Start();
                            responseText = CacheRefresh.thdRefreshCach.ThreadState.ToString();
                        }
                        catch (Exception ex) { responseText = "Start Exception:" + ex.Message; }
                    }

                    else if (context.Request.QueryString["condition"].Equals("abort"))
                    {
                        try
                        {
                            CacheRefresh.Abort();
                            responseText = CacheRefresh.thdRefreshCach.ThreadState.ToString();
                        }
                        catch (Exception ex) { responseText = "Abort Exception:" + ex.Message; }
                    }
                    else if (context.Request.QueryString["condition"].Equals("status"))
                    {
                        if (CacheRefresh.thdRefreshCach != null)
                        {
                            responseText = CacheRefresh.thdRefreshCach.ThreadState.ToString();
                        }
                        else
                        {
                            responseText = "Has not open";               
                        }
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