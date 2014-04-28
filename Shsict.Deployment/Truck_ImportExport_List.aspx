<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Truck_ImportExport_List.aspx.cs" Inherits="Shsict.Web.Truck_ImportExport_List" Title="外集卡进出查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var tbTruckImportExport = $(".Truck .Truck-ImportExport");
            tbTruckImportExport.attr("placeholder", "请输入集卡号(沪D57372)");

            tbTruckImportExport.change(function () {
                tbTruckImportExport.val(tbTruckImportExport.val().toUpperCase());
                QueryImpl()
            });
        });

        function QueryImpl() {
            var _value1 = $(".Truck .Truck-ImportExport").val();;

            var $listView = $("ul#listTruck");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("TruckImportExportList.ashx", { Truck: _value1 }, function (data, status, xhr) {

                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();
                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {

                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");
                            $item.click(function () {
                                window.location.href = "Truck_ImportExport_Detail.aspx?TruckID=" + entry.ID;

                            });
                            
                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.TruckNo;
                          
                            $itemh3.html(itemHtmlh3);
                            var $itemContant = $item.find("p");
                            var itemHtmlContant = String.format("进堆场时间：{0} | 出堆场时间：{1} ", timeStamp2String(entry.ArriveYardTime), timeStamp2String(entry.DepartureYardTime));
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
    <div class="ui-body ui-body-c Truck">
        <div style="display: inline;">
            <asp:TextBox ID="txtTruckImportExport" runat="server" CssClass="Truck-ImportExport"></asp:TextBox>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
 <div data-role="content">
        <ul data-role="listview" id="listTruck">
        </ul>
        <ul data-role="listview" id="NoData">
            <li>
                <h3>暂无相关数据</h3>
                <p></p>
            </li>
        </ul>
    </div>
</asp:Content>
