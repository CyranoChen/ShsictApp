using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace Shsict.Web
{
    /// <summary>
    /// SetFavouriteHandler 的摘要说明
    /// </summary>
    public class SetFavouriteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            try
            {
                string _url = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["PageUrl"]))
                    _url = context.Request.QueryString["PageUrl"];

                string _username = string.Empty;
                if (context.Request.Cookies["uid"] != null)
                {
                    _username = context.Request.Cookies["uid"].Values.ToString();
                }
                //else
                //{
                //    context.Response.Redirect ("Login.aspx?NextURL=" + _url);
                //    //context.Response.Write("location.href='指定链接';");
                //}

                string _objectContent = "";


                if (!string.IsNullOrEmpty(context.Request.QueryString["Method"]))
                {

                    if (context.Request.QueryString["Method"].Equals("get"))
                    {
                        MyFavourite mf = MyFavourite.Cache.FavouriteList_Active.Find(f =>
                            f.USERNAME.Equals(_username, StringComparison.OrdinalIgnoreCase) && f.URL.Equals(_url, StringComparison.OrdinalIgnoreCase));

                        if (mf != null)
                        {
                            mf.STATUS = 0;
                            mf.Update();

                            MyFavourite.Cache.RefreshCache();

                            responseText = Boolean.TrueString;
                        }
                        else
                        {
                            responseText = Boolean.FalseString;
                        }
                    }
                    else if (context.Request.QueryString["Method"].Equals("dele"))
                    {
                        MyFavourite mf = MyFavourite.Cache.FavouriteList_Active.Find(f =>
                           f.USERNAME.Equals(_username, StringComparison.OrdinalIgnoreCase) && f.URL.Equals(_url, StringComparison.OrdinalIgnoreCase));

                        if (mf != null)
                        {
                            mf.ISACTIVE = 0;
                            mf.Update();

                            MyFavourite.Cache.RefreshCache();

                            responseText = Boolean.TrueString;
                        }
                        else
                        {
                            responseText = Boolean.FalseString;
                        }


                    }
                    else if (context.Request.QueryString["Method"].Equals("post"))
                    {
                        string _objectID = string.Empty;
                        if (!string.IsNullOrEmpty(context.Request.QueryString["ObjectID"]))
                            _objectID = context.Request.QueryString["ObjectID"];

                        string _objectType = string.Empty;
                        if (!string.IsNullOrEmpty(context.Request.QueryString["ObjectType"]))
                            _objectType = context.Request.QueryString["ObjectType"];


                        if (MyFavourite.Cache.FavouriteList_Active.Exists(f =>
                           f.USERNAME.Equals(_username, StringComparison.OrdinalIgnoreCase) && f.URL.Equals(_url, StringComparison.OrdinalIgnoreCase)
                           && f.OBJECTID.Equals(_objectID, StringComparison.OrdinalIgnoreCase) && f.OBJECTTYPE.Equals(_objectType, StringComparison.OrdinalIgnoreCase)))
                        {

                            throw new Exception("该记录已被关注");
                        }

                        MyFavourite fav = new MyFavourite();

                        fav.ID = "";
                        fav.URL = _url;
                        fav.USERNAME = _username;
                        fav.UPDATETIME = DateTime.Now;
                        fav.CREATETIME = DateTime.Now;
                        fav.STATUS = 0;
                        fav.OBJECTID = _objectID;
                        fav.OBJECTTYPE = _objectType;

                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                        switch (_objectType)
                        {
                            case "ContainerEload":
                                ContainerEload listContainerEload = ContainerEload.Cache.Load(_objectID);
                                _objectContent = jsonSerializer.Serialize(listContainerEload);
                                break;
                            case "ContainerMain":
                            case "ContainerDetail":
                                ContainerMain listContainerMain = ContainerMain.Cache.Load(_objectID);

                                _objectContent = jsonSerializer.Serialize(listContainerMain);

                                break;
                            case "ContainerPlan":
                                ContainerPlan listContainerPlan = ContainerPlan.Cache.Load(_objectID);
                                _objectContent = jsonSerializer.Serialize(listContainerPlan);
                                break;
                            case "Truck":
                                OTruck listOTruck = OTruck.Cache.Load(_objectID);
                                _objectContent = jsonSerializer.Serialize(listOTruck);
                                break;
                            case "VesselPlan":
                                OVesselPlan listOVesselPlan = OVesselPlan.Cache.Load(_objectID);

                                _objectContent = jsonSerializer.Serialize(listOVesselPlan);

                                break;
                            default:
                                break;
                        }

                        fav.OBJECTCONTENT = _objectContent;
                        fav.ISACTIVE = 1;
                        fav.REMARK = "";

                        fav.Insert();

                        MyFavourite.Cache.RefreshCache();

                        responseText = "success";
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