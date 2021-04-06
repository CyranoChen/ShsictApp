using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using Shsict.Entity;
using Shsict.Entity.WeChat;

namespace Shsict.InternalWeb.Controllers
{
    public class LoginController : Controller
    {
        public static string ToUrl;
        private readonly bool _weChatActive = Convert.ToBoolean(ConfigurationManager.AppSettings.GetValues("WeChatActive")?[0]);

        public ActionResult Index(string returnUrl)
        {
            if (returnUrl == null)
            {
                returnUrl = ToUrl;
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
            }

            if (!string.IsNullOrEmpty(returnUrl) && returnUrl.IndexOf("Pad", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return RedirectToAction("Pad");
            }
            else
            {
                return RedirectToAction("Phone");
            }
        }

        public ActionResult Phone(string weChatUserId = null, bool weChatRedirect = true, string returnUrl = null)
        {
            if (weChatRedirect)
            {
                if (_weChatActive && IsWeChatClient())
                {
                    // 自动跳转微信认证机制
                    return RedirectToAction("WeChatLogin", "Login", new { returnUrl });
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.WeChatUserId = weChatUserId;

            return View();
        }

        // 
        // GET: /Account/WeChatLogin

        public ActionResult WeChatLogin(string returnUrl)
        {
            // 开启微信认证，并通过微信内部浏览器访问时，跳转微信OAuth认证接口
            if (HttpContext.Request.Url != null && _weChatActive && IsWeChatClient())
            {
                var client = new WeChatAuthClient();

                var authUri = client.GetOAuthUrl($"http://{HttpContext.Request.Url.Authority}/Login/WeChatAuth?returnUrl={returnUrl}",
                    ScopeType.snsapi_base, "ShsictApp");

                if (!string.IsNullOrEmpty(authUri))
                {
                    return Redirect(authUri);
                }
            }

            return RedirectToAction("Phone", "Login", new { weChatRedirect = false });
        }

        // 
        // GET: /Account/WeChatAuth

        public ActionResult WeChatAuth(string code, string state, string returnUrl)
        {
            if (!string.IsNullOrEmpty(code) &&
                !string.IsNullOrEmpty(state) && state.Equals("ShsictApp"))
            {
                // 获取微信授权access_token
                var client = new WeChatAuthClient();
                var result = client.GetUserInfo(code);

                if (!string.IsNullOrEmpty(result))
                {
                    var json = JToken.Parse(result);

                    if (json["UserId"] != null && json["DeviceId"] != null)
                    {
                        // 企业成员授权时返回 {"UserId":"cyrano","DeviceId":"3cc38f93c7d87eec0103c06feca4779f"}
                        var userid = json["UserId"].Value<string>();
                        var deviceId = json["DeviceId"].Value<string>();

                        // 查询当前微信用户的对应账号
                        var user = InternalUser.AuthenticateWeChat(userid);

                        if (user != null)
                        {
                            // 认证用户登录，读取权限并写入cookie
                            Authentication(user);

                            // 设置Cookie
                            //FormsAuthentication.SetAuthCookie(userid, true);

                            // 授权成功跳转内网界面
                            //return RedirectToAction("Index", "Reservation");
                            return RedirectToAction("Index", "Portal");
                        }
                        else
                        {
                            // 跳转登录界面，并传入微信用户账号
                            return RedirectToAction("Phone", "Login", new { weChatUserId = userid, weChatRedirect = false });
                        }
                    }
                    //else if (json["OpenId"] != null && json["DeviceId"] != null)
                    //{
                    //    // 非企业成员授权时返回 
                    //    var openId = json["OpenId"].Value<string>();
                    //    var deviceId = json["DeviceId"].Value<string>();

                    //    // 授权非企业号成员的关注者
                    //    var auth = new AuthorizeManager();

                    //    if (auth.AuthorizeGuest(openId, deviceId))
                    //    {
                    //        // 设置Cookie
                    //        FormsAuthentication.SetAuthCookie(openId, true);

                    //        // 授权成功跳转内网界面
                    //        //return RedirectToAction("Index", "Account");
                    //        return RedirectToAction("Index", "Portal");
                    //    }
                    //}

                    // 其他情况下均跳转登录界面
                }
            }

            // 授权失败跳转登录界面
            return RedirectToAction("Phone", "Login", new { weChatRedirect = false });
        }

        public ActionResult Pad(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        public ActionResult Password()
        {
            //ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public void Password(PasswordModel model)
        {
            Response.ContentType = "text/html";

            try
            {
                var username = Request.Cookies["uid"]?.Value;
                var passwordOld = GetMd5Hash(model.PasswordOld);
                var user = InternalUser.Authenticate(username, passwordOld);

                if (user != null)
                {
                    user.SUR_PASSWORD = GetMd5Hash(model.PasswordNew);
                    user.SUR_CREATETIME = DateTime.Now;
                    user.Save();

                    Response.Write("success");
                }
                else
                {
                    throw new Exception("提示：用户或密码不正确");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        [HttpPost]
        public void LogOn(FormCollection collection, InternalUser model)
        {
            Response.ContentType = "text/html";

            if (model.SUR_USERACCOUNT != null && model.SUR_PASSWORD != null)
            {
                var password = GetMd5Hash(model.SUR_PASSWORD);

                var user = InternalUser.Authenticate(model.SUR_USERACCOUNT, password);

                if (user != null)
                {
                    // 同步微信用户账号
                    if (string.IsNullOrEmpty(user.SUR_WECHATUSERID) && !string.IsNullOrEmpty(model.SUR_WECHATUSERID))
                    {
                        user.SUR_WECHATUSERID = model.SUR_WECHATUSERID; // 在认证用户登录时，持久化写入
                    }

                    // 认证用户登录，读取权限并写入cookie
                    Authentication(user);

                    // 密码过期，需要提示密码重置
                    var expireDays =
                        Convert.ToInt16(ConfigurationManager.AppSettings["PasswordExpireDays"]);

                    if (expireDays > 0 && (DateTime.Now - user.SUR_CREATETIME).TotalDays > expireDays)
                    {
                        Response.Write("redirect");
                    }
                    else
                    {
                        Response.Write("success");
                    }
                }
                else
                {
                    user = InternalUser.Load(model.SUR_USERACCOUNT);

                    if (user != null)
                    {
                        user.SUR_ERRORCOUNT += 1;
                        user.SUR_ISLOOKED = user.SUR_ERRORCOUNT >= Convert.ToInt16(ConfigurationManager.AppSettings["MaxLoginFailed"]);
                        user.Save();

                        Response.Write(s: $"提示：用户名或密码不正确 ({user.SUR_ERRORCOUNT}) {(user.SUR_ISLOOKED ? "已锁定" : string.Empty)}");
                    }
                    else
                    {
                        Response.Write("提示：用户名或密码不正确");
                    }
                }
            }
            else
            {
                Response.Write("error");
            }
        }


        public void LogOff()
        {
            Response.Cookies.Remove("uid");
            ToUrl = "phone";
            FormsAuthentication.SignOut();
            Response.Write("success");
        }

        public void PadLogOff()
        {
            Response.Cookies.Remove("uid");
            ToUrl = "Pad";
            FormsAuthentication.SignOut();
            Response.Write("success");
        }

        private void Authentication(InternalUser user)
        {
            var uid = user.SUR_USERACCOUNT;

            user.SUR_ERRORCOUNT = 0;
            user.SUR_ISLOOKED = false;
            user.Save();

            List<UserResource> userResources = UserResource.GetUserResourceByUserName(uid);

            string permissions = "";

            if (userResources.Count > 0)
            {

                foreach (UserResource items in userResources)
                {
                    switch (items.SUR_RESOURCECODE)
                    {
                        case "1":
                            permissions += "ZY,";
                            break;
                        case "2":
                            permissions += "SC,";
                            break;
                        case "3":
                            permissions += "ZYL,";
                            break;
                        case "4":
                            permissions += "JX,";
                            break;
                        case "5":
                            permissions += "CQ,";
                            break;
                    }
                }
                if (permissions.IndexOf(',') > 0)
                {
                    permissions = permissions.Substring(0, permissions.Length - 1);
                }
            }

            Response.SetCookie(new HttpCookie("uid", uid));

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                  1,
                  uid,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(30),
                  false,
                  permissions
                  );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        private string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            // Edit By Cyrano
            //byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            var data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private bool IsWeChatClient()
        {
            if (HttpContext == null)
            {
                return false;
            }

            var bc = HttpContext.Request.Browser;

            return bc.Capabilities[""].ToString().IndexOf("MicroMessenger", StringComparison.OrdinalIgnoreCase) > 0;
        }

        //// GET: Login/RefreshPassword
        //[HttpGet]
        //public object RefreshPassword()
        //{
        //    try
        //    {
        //        var users = LoginModel.GetLoginModels();

        //        if (users != null && users.Count > 0)
        //        {
        //            foreach (var u in users)
        //            {
        //                u.SUR_PASSWORD = GetMd5Hash(u.SUR_PASSWORD);
        //                u.Save();
        //            }

        //            return users.Count;
        //        }

        //        return -1;
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //}
    }
}
