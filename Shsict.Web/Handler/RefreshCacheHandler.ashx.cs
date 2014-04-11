using Shsict.AutoRefresh;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string responseText = string.Empty;
            try
            {
                CacheRefresh cr = new CacheRefresh();

                if (!string.IsNullOrEmpty(context.Request.QueryString["condition"]))
                {
                    if (context.Request.QueryString["condition"].Equals("star"))
                    {
                            bool _start=  cr.Start();
                            if (_start)
                        {
                            responseText = "success";
                        }
                        else
                        {
                            responseText = "HasOpen";
                        }
                    }
                    else if (context.Request.QueryString["condition"].Equals("end"))
                    {
                        Process[] ps = Process.GetProcesses();

                        bool _end = cr.End();

                        if (_end)
                        {
                            responseText = "success";
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