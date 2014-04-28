<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Port_List.aspx.cs" Inherits="Shsict.Web.Container_Port_List" Title="运抵报告发送情况" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var tbContainerPort = $(".Container-Port .ContainerPort");
            var ddlContainerNoOrbill = $(".Container-Port select.ddlContainerNoOrbill");

            tbContainerPort.attr("placeholder", "请输入箱号(MRKU3189099)/提单号");

            tbContainerPort.change(function () {
                tbContainerPort.val(tbContainerPort.val().toUpperCase());
                QueryImpl();
            });
            ddlContainerNoOrbill.change(function () {
                QueryImpl();
            });

        });

        function QueryImpl() {
            var _value1 = $(".Container-Port .ContainerPort").val();
            var _value2 = $(".Container-Port select.ddlContainerNoOrbill").val();

            var $listView = $("ul#listContainerPort");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("ContainerPortList.ashx", { ContainerPort: _value1, Type: _value2 }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();
                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {

                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");
                            $item.click(function () {
                                window.location.href = String.format("Container_Port_Detail.aspx?ContainerID={0}&Type={1}", entry.ID, _value2);
                                load();

                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.ContainerNo;
                            $itemh3.html(itemHtmlh3);

                            var $itemp = $item.find("p");
                            var itemHtmlp = String.format("船名：{0} | 航次：{1} | 进港时间：{2}  ", entry.VesselName, entry.VoyageNumber, timeStamp2String(entry.SendPackingListTime));
                            $itemp.html(itemHtmlp);

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
    <div class="ui-body ui-body-c Container-Port">
        <div style="display: inline;">
            <asp:TextBox ID="txtContainerPort" runat="server" CssClass="ContainerPort"></asp:TextBox>
            <asp:DropDownList ID="ddlContainerNoOrbill" runat="server" CssClass="ddlContainerNoOrbill">
                <asp:ListItem Value="c" Text="箱号" Selected="True"></asp:ListItem>
                <asp:ListItem Value="b" Text="提单号"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listContainerPort">
        </ul>
        <ul data-role="listview" id="NoData">
            <li>
                <h3>暂无相关数据</h3>
                <p></p>
            </li>
        </ul>
    </div>
</asp:Content>
