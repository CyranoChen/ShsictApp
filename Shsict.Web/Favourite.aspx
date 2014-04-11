<%@ Page Title="我的收藏" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Favourite.aspx.cs" Inherits="Shsict.Web.Favourite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Repeater ID="rptrFavourite" runat="server" OnItemDataBound="rptrFavourite_ItemDataBound">
            <HeaderTemplate>
                <ul data-role="listview" id="listFavourite">
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Literal ID="ltrlFavourites" runat="server"></asp:Literal>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
