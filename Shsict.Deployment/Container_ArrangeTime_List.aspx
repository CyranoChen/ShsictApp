<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_ArrangeTime_List.aspx.cs" Inherits="Shsict.Web.Container_ArrangeTime_List" Title="直装直提计划安排情况" Theme="Shsict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <div class="ui-body ui-body-c">

            <div style="display: inline;">
                <asp:TextBox ID="txtTrackingSituation" runat="server" AutoPostBack="true" OnTextChanged="txtTrackingSituation_TextChanged"></asp:TextBox>
            </div>
        </div>
        <asp:Repeater ID="rptrContainerArrangeTime" runat="server" OnItemDataBound="rptrContainerArrangeTime_ItemDataBound">
            <HeaderTemplate>
                <ul data-role="listview">
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Literal ID="ltrlContainerArrangeTime" runat="server"></asp:Literal>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
