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
                            if (CacheRefresh.thdRefreshCach == null)
                            {
                                responseText = CacheRefresh.Start().ToString();
                            }
                            else
                            {
                                responseText = CacheRefresh.Resume().ToString();

                            }
                        }
                        catch (Exception ex) { responseText = "Start Exception:" + ex.Message; }
                    }

                    else if (context.Request.QueryString["condition"].Equals("suspend"))
                    {
                        try
                        {
                            if (CacheRefresh.thdRefreshCach != null)
                            {
                                responseText = CacheRefresh.Suspend().ToString();
                            }
                            else
                            {
                                responseText = "error";
                            }
                        }
                        catch (Exception ex) { responseText = "Suspend Exception:" + ex.Message; }
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