<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Period_List.aspx.cs" Inherits="Shsict.Web.VesselPlan_Period_List" Title="船舶计划查询-船名" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            VesselPlanQueryImpl();
        });
        function VesselPlanQueryImpl() {
            var _value1 = $(".VesselPlan_Period_Name .PeriodName").val();

            var $listView = $("ul#listVesselPlan");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            var _EnglishName = GetQueryString("EnglishName");

            $.getJSON("VesselPlanPeriodList.ashx", { EnglishName: _EnglishName }, function (data, status, xhr) {


                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();
                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {

                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");
                            $item.click(function () {
                                window.location.href = "VesselPlan_Period_Detail.aspx?VesselPlanID=" + entry.ID;

                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = String.format("{0}({1})", entry.VesselName, entry.VesselEnglishName);
                            $itemh3.html(itemHtmlh3);
                            var $itemContant = $item.find("p");
                            var itemHtmlContant = String.format("航次：{0} | 进/出口：{1} | 范围: {2}", entry.VoyageNumber, entry.ImportOrExportFlag == "E" ? "出口" : "进口", entry.VesselPlanStatus);
                            $itemContant.html(itemHtmlContant);

                            $listView.prepend($item);
                        });

                    } else {
                        $listView.empty();
                        $noDataView.show();

                    }
                } else {
                    alert("调用数据接口失败(VesselPlanList)");
                }
            });
        }
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        String.format = function () {
            if (arguments.length == 0)
                return null;
            var str = arguments[0];
            for (var i = 1; i < arguments.length; i++) {
                var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
                str = str.replace(re, arguments[i]);
            }
            return str;
        };
    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listVesselPlan">
        </ul>
        <ul data-role="listview" id="NoData">
            <li>
                <h3>暂无相关数据</h3>
                <p></p>
            </li>
        </ul>
    </div>

</asp:Content>
