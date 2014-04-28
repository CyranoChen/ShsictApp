<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Trace_List.aspx.cs" Inherits="Shsict.Web.Container_Trace_List" Title="进箱信息跟踪" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {

            var tbContainerTrace = $(".container-trace .ContainerTrace");

            tbContainerTrace.attr("placeholder", "请输入箱号(IRSU2611715)/提单号");
            var ddlContainerNoOrbill = $(".container-trace select.ddlContainerNoOrbill");

            tbContainerTrace.change(function () {

                tbContainerTrace.val(tbContainerTrace.val().toUpperCase());
                QueryImpl();


            });

            ddlContainerNoOrbill.change(function () {

                if (tbContainerTrace.val() != "") {
                    QueryImpl();
                }
                else {
                    $listView.empty();
                    $noDataView.show();
                }
            })

            function QueryImpl() {

                var _value1 = $(".container-trace .ContainerTrace").val();
                var _value2 = $(".container-trace select.ddlContainerNoOrbill").val();

                var $listView = $("ul#listContainerTrace");
                var $noDataView = $("ul#NoData").hide();
                var $itemTemplate = $noDataView.find("li").first();

                $.getJSON("ContainerPlanList.ashx", { ContainerNoOrbill: _value1, Type: _value2 }, function (data, status, xhr) {
                    if (status == "success" && data != null) {
                        if (data.result != "error" && JSON.stringify(data) != "[]") {
                            $listView.empty();
                            $noDataView.hide();

                            $.each(data, function (entryIndex, entry) {

                                var $item = $itemTemplate.clone();

                                $item.css("cursor", "pointer");
                                $item.click(function () {
                                    window.location.href = String.format("Container_Trace_Detail.aspx?ContainerID={0}&Type={1}", entry.ID, _value2);
                                    //load();

                                });

                                var $itemh3 = $item.find("h3");
                                var itemHtmlh3 = entry.ContainerNo;
                                $itemh3.html(itemHtmlh3);

                                var $itemp = $item.find("p");
                                var itemHtmlp = "计划安排时间:" + timeStamp2String(entry.ArrivalContainerTime);
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
        });
    </script>

</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <div class="ui-body ui-body-c container-trace">
        <div style="display: inline;">
            <asp:TextBox ID="txtContainerTrace" runat="server" CssClass="ContainerTrace"></asp:TextBox>
            <asp:DropDownList ID="ddlContainerNoOrbill" runat="server" CssClass="ddlContainerNoOrbill">
                <asp:ListItem Value="c" Text="箱号" Selected="True"></asp:ListItem>
                <asp:ListItem Value="b" Text="提单号"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listContainerTrace"></ul>
        <ul data-role="listview" id="NoData">
            <li>
                <h3>暂无相关数据</h3>
                <p></p>
            </li>
        </ul>
    </div>
</asp:Content>
