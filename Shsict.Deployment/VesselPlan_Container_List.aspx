<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Container_List.aspx.cs" Inherits="Shsict.Web.VesselPlan_Container_List" Title="进箱计划查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
            <script type="text/javascript">
                $(function () {
                    VesselPlanQueryImpl();
                    var tbContainerTrace = $(".Vessel-Name .VesselName");

                    tbContainerTrace.attr("placeholder", "请输入船名(淮海)");

                    tbContainerTrace.change(function () {
                        VesselPlanQueryImpl();
                       
                    });
                });

                function VesselPlanQueryImpl() {
                    var _value1 = $(".Vessel-Name .VesselName").val();

                    var $listView = $("ul#listVesselPlan");
                    var $noDataView = $("ul#NoData").hide();
                    var $itemTemplate = $noDataView.find("li").first();

                    $.getJSON("VesselPlanContainerList.ashx", { VN: _value1 }, function (data, status, xhr) {

                        if (status == "success" && data != null) {
                            if (data.result != "error" && JSON.stringify(data) != "[]") {
                                $listView.empty();
                                $noDataView.hide();

                                $.each(data, function (entryIndex, entry) {

                                    var $item = $itemTemplate.clone();

                                    $item.css("cursor", "pointer");
                                    $item.click(function () {
                                        window.location.href = "VesselPlan_Container_Detail.aspx?VesselPlanID=" + entry.ID;

                                    });

                                    var $itemh3 = $item.find("h3");
                                    var itemHtmlh3 = String.format("{0}({1})", entry.VesselName, entry.VesselEnglishName);
                                    $itemh3.html(itemHtmlh3);
                                    var $itemContant = $item.find("p");
                             

                                    var itemHtmlContant = String.format("航次：{0} | 进箱开始时间：{1} ", entry.VoyageNumber, timeStamp2String(entry.ContainerBeginTime));
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



    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
           <div class="ui-body ui-body-c Vessel-Name">
            <div style="display: inline;">
                <asp:TextBox ID="txtVesselName" runat="server" CssClass="VesselName"></asp:TextBox>
            </div>
        </div>
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
