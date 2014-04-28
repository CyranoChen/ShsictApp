<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Period_Name.aspx.cs" Inherits="Shsict.Web.VesselPlan_Period_Name" Title="船舶计划查询-船名" Theme="Shsict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {

            VesselPlanQueryImpl();
            var tbPeriodName = $(".VesselPlan_Period_Name .PeriodName");
            tbPeriodName.attr("placeholder", "请输入船舶英文名(ZK19)");
            tbPeriodName.change(function () {
                VesselPlanQueryImpl();
            });
        });

        function VesselPlanQueryImpl() {
            var _value1 = $(".VesselPlan_Period_Name .PeriodName").val();

            var $listView = $("ul#listVesselPlan");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("VesselPlanPeriodName.ashx", { EnglishName: _value1 }, function (data, status, xhr) {

                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();
                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {

                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");
                            $item.click(function () {
                                window.location.href = "VesselPlan_Period_List.aspx?EnglishName=" + entry.EnglishName;

                            });

                            var $itemh3 = $item.find("h3");

                            var itemHtmlh3 = entry.EnglishName;
                            $itemh3.html(itemHtmlh3);

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
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <div class="ui-body ui-body-c VesselPlan_Period_Name">
        <div style="display: inline;">
            <asp:TextBox ID="txtPeriodName" runat="server" CssClass="PeriodName"></asp:TextBox>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
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
