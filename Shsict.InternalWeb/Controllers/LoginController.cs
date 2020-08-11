using Shsict.InternalWeb.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shsict.InternalWeb.Controllers
{
    public class LoginController : Controller
    {
        public static string ToUrl;

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

        public ActionResult Phone(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
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
                List<LoginModel> users = LoginModel.Authenticate(username, passwordOld);

                if (users != null && users.Count > 0)
                {
                    var user = users[0];

                    user.SUR_PASSWORD = GetMd5Hash(model.PasswordNew);
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
        public void LogOn(FormCollection collection, LoginModel model)
        {
            if (model.SUR_USERACCOUNT != null && model.SUR_PASSWORD != null)
            {
                var password = GetMd5Hash(model.SUR_PASSWORD);

                List<LoginModel> users = LoginModel.Authenticate(model.SUR_USERACCOUNT, password);

                Response.ContentType = "text/html";

                if (users != null && users.Count > 0)
                {
                    var user = users[0];
                    //isTrue = user.Exists(t => t.SUR_PASSWORD.Equals(model.SUR_PASSWORD));

                    List<UserResource> userResources = UserResource.GetUserResourceByUserName(model.SUR_USERACCOUNT);

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

                    Response.SetCookie(new HttpCookie("uid", collection[0]));

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                          1,
                          collection[0],
                          DateTime.Now,
                          DateTime.Now.AddMinutes(30),
                          false,
                          permissions
                          );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                    Response.Write("success");
                }
                else
                {
                    Response.Write("提示：用户名或密码不正确");
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
