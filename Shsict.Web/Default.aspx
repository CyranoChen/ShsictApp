<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shsict.Web.Default" Theme="Shsict" %>

<!DOCTYPE html>
<html lang="en">
<head id="masterHead" runat="server">
    <title>盛东公司信息管理平台 - 引导页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            InitCache("Favourite");
            InitCache("Notice");
            InitCache("ContainerDetail");
            InitCache("ContainerEload");
            InitCache("ContainerMain");
            InitCache("ContainerPlan");
            InitCache("OTruck");
            InitCache("OVesselPlan");
            InitCache("PortOfCall");

            $("#btnRefreshCache").click(function () {
                var $pnlMain = $("div.main");
                var viewMsg = "";
                var _btnRefreshCache = $("#btnRefreshCache");
              
         
                if (_btnRefreshCache.text().trim().indexOf("开始更新")>-1) {
                    $.get("Handler/RefreshCacheHandler.ashx", { condition: "star" }, function (data, status, xhr) {
                        if (status == "success" && data != null) {
                            if (data == "success") {
                                viewMsg = "Begin Refresh Cache....";
                                _btnRefreshCache.text("结束更新");
                            }
                            else if (data == "HasOpen")
                            {
                                viewMsg = "Refresh Has Open....";
                                _btnRefreshCache.text("结束更新");
                            }
                            else {
                                viewMsg = "Refresh Cache Failed. Ex: " + data;
                            }
                        } else {
                            alert("调用接口失败(DefaultHandler.ashx)");
                        }

                        $pnlMain.find("ul").append($pnlMain.find("li").first().clone().text(viewMsg));
                    });
                } else {
                    $.get("Handler/RefreshCacheHandler.ashx", { condition: "end" }, function (data, status, xhr) {
                        if (status == "success" && data != null) {
                            if (data == "success") {
                                viewMsg = "Refresh Cache end";

                                _btnRefreshCache.text("开始更新");
                            } else {
                                viewMsg = "Refresh Cache Failed. Ex: " + data;

                                _btnRefreshCache.text("开始更新");
                            }
                        } else {
                            alert("调用接口失败(DefaultHandler.ashx)");
                        }

                        $pnlMain.find("ul").append($pnlMain.find("li").first().clone().text(viewMsg));
                    });

                }
            });
        });

        function InitCache(objName) {
            var resultMsg = "";
            var $pnlMain = $("div.main");

            $.get("Handler/DefaultHandler.ashx", { object: objName }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data == "success") {
                        resultMsg = "【" + objName + "】 Cache Initial Successfully";
                    } else {
                        resultMsg = "【" + objName + "】 Cache Initial Failed. Ex: " + data;
                    }
                } else {
                    alert("调用接口失败(DefaultHandler.ashx)");
                }

                $pnlMain.find("ul").append($pnlMain.find("li").first().clone().text(resultMsg));
            });
        }
    </script>
    <style type="text/css">
        .RefreshCache {
        }
    </style>
</head>
<body class="loading">
    <form id="form1" runat="server">
        <button id="btnRefreshCache" style="float: right;" onclick="return false;">开始更新</button>
        <div class="main" onclick="window.location.href='Portal.aspx'" style="cursor: pointer">
            <ul>
                <li>Server Cache Initialing...</li>
            </ul>
        </div>
    </form>
</body>
</html>
