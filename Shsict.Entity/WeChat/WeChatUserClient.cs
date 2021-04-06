using System;

namespace Shsict.Entity.WeChat
{
    public class WeChatUserClient : WeChatApiClient
    {
        public string GetUser(string userid)
        {
            //https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&userid=USERID

            var uri = $"{ServiceUrl}user/get?access_token={AccessToken}&userid={userid}";

            var responseResult = ApiGet(uri);

            if (string.IsNullOrEmpty(responseResult))
            {
                throw new Exception("WeChatUserClient.GetUser() responseResult is null");
            }

            return responseResult;
        }

        public string GetDepartmentList(int departmentid)
        {
            //https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token=ACCESS_TOKEN&id=ID

            var uri = $"{ServiceUrl}department/list?access_token={AccessToken}&userid={departmentid}";

            var responseResult = ApiGet(uri);

            if (string.IsNullOrEmpty(responseResult))
            {
                throw new Exception("WeChatUserClient.GetDepartmentList() responseResult is null");
            }

            return responseResult;
        }
    }
}