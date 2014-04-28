<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Plan_Detail.aspx.cs" Inherits="Shsict.Web.Container_Plan_Detail" Title="箱货信息查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server"></asp:Content>

<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>

<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Panel ID="pnlContainerNo" CssClass="banner5 banner1" runat="server">
            <asp:Label ID="lblContainerNo" runat="server" Text=""></asp:Label>
        </asp:Panel>

        <div data-role="collapsible" data-inset="false" data-collapsed="false">
            <h3 class="tit">箱动态</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="persist">进场时间</th>
                        <th data-priority="2">出场时间</th>
                        <th data-priority="3">进场方式</th>
                        <th data-priority="4">出场方式</th>
                        <th data-priority="5">放关</th>
                        <th data-priority="6">配船</th>
                        <th data-priority="7">箱号</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblArriveTime" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDeparTureTime" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblArriveType" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDepartureType" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCustomsCLearance" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVesselID" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">基本信息</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="persist">尺寸</th>
                        <th data-priority="2">箱型</th>
                        <th data-priority="3">高度</th>
                        <th data-priority="4">状态</th>
                        <th data-priority="5">铅封号</th>
                        <th data-priority="6">提单号</th>
                        <th data-priority="7">重量</th>
                        <th data-priority="8">冷藏箱温度</th>
                        <th data-priority="9">危险品类型</th>
                        <th data-priority="10">持箱人</th>
                        <th data-priority="11">计划作业方式</th>
                        <th data-priority="12">计划作业时间</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblCTNSize" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNType" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNHeight" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNStat" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSealNO" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblBLNO" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNNetWeight" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRCTemerature" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDGType" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNOwner" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNIOType" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPlanWorkTime" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">船舶相关</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="1">箱变空时间</th>
                        <th data-priority="2">箱变空原因</th>
                        <th data-priority="3">一程船名</th>
                        <th data-priority="4">一程船航次</th>
                        <th data-priority="5">二程船名</th>
                        <th data-priority="6">二程船航次</th>
                        <th data-priority="7">装货港</th>
                        <th data-priority="8">卸货港</th>
                        <th data-priority="9">目的港</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblTCTNEmpty" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRCTNEmpty" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFirstVVessel" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFirstVVoyage" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSecondVVessel" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSecondVVoyage" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblLoadingPort" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDischargingPort" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDestinationPort" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">超箱信息</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="persist">超限箱类型</th>
                        <th data-priority="1">超重</th>
                        <th data-priority="2">超高</th>
                        <th data-priority="3">前超长</th>
                        <th data-priority="4">后超长</th>
                        <th data-priority="5">左超宽</th>
                        <th data-priority="6">右超宽</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblOverCTNType" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblOverWeight" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblOverHeight" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFOL" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblBOL" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblLOW" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblROW" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
