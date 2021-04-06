using System;
using System.Web;
using System.Web.Caching;
using System.Web.Script.Serialization;

namespace Shsict.Entity.WeChat
{
    public class WeChatApiClient : RestClient
    {
        protected WeChatApiClient()
        {
            ServiceUrl = "https://qyapi.weixin.qq.com/cgi-bin/";
            AppKey = "wxed1e5aacdfc38665";
            CryptographicKey = "0Y-fzGekU1vOy7QJEaVi7ot6vo8_0msMKLSrcg4zBv5gXx9yDeX7r39jcbkvZolh";
        }

        #region Members and Properties

        protected string AccessToken
        {
            get
            {
                var context = HttpContext.Current;

                // Get access_token by using System.Web.Caching
                if (context?.Cache["AccessToken"] != null) { return context.Cache["AccessToken"].ToString(); }

                var serializer = new JavaScriptSerializer();
                var token = serializer.Deserialize<AccessToken>(GetAccessToken());

                //var json = JToken.Parse(GetAccessToken());
                //if (json["access_token"] != null && json["expires_in"] != null)
                //{
                //    // Set access_token by using System.Web.Caching
                //    return AddItemToCache("AccessToken", json["access_token"], json["expires_in"].Value<double>()).ToString();
                //}

                if (token != null && !string.IsNullOrEmpty(token.access_token) && token.expires_in > 0)
                {
                    // Set access_token by using System.Web.Caching
                    return AddItemToCache("AccessToken", token.access_token.ToString(), token.expires_in).ToString();
                }

                return null;
            }
        }

        #endregion

        private string GetAccessToken()
        {
            // Get access token
            // http请求方式: GET
            // https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=id&corpsecret=secrect
            // {"access_toke{ "access_token": "accesstoken000001", "expires_in": 7200}

            var uri = $"{ServiceUrl}gettoken?corpid={AppKey}&corpsecret={CryptographicKey}";

            var responseResult = ApiGet(uri);

            if (string.IsNullOrEmpty(responseResult))
            {
                throw new Exception("WeChatApiClient.GetAccessToken() responseResult is null");
            }

            return responseResult;
        }

        private object AddItemToCache(string key, object value, double expires)
        {
            if (HttpContext.Current != null && HttpContext.Current.Cache[key] == null)
            {
                HttpContext.Current.Cache.Add(key, value, null, DateTime.Now.AddSeconds(expires), TimeSpan.Zero,
                    CacheItemPriority.High, null);
            }

            return value;
        }
    }

    public enum ScopeType
    {
        snsapi_base,
        snsapi_userinfo
    }

    public class AccessToken
    {
        public string access_token { set; get; }
        public double expires_in { set; get; }
    }
}