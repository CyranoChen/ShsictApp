﻿using Shsict.InternalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Shsict.InternalWeb.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IIsUpdateService”。
    [ServiceContract]
    public interface IIsUpdateService
    {
        [OperationContract]
        [WebGet(UriTemplate = VersionRouting.GetClientRoute, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string IsNeedToUpadate(string version);
    }
}
