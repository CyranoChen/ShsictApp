<%@ Page Title="公告栏" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs"   Inherits="Shsict.Web.Notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
            <asp:Repeater ID="rptNotice" runat="server" OnItemDataBound="rptNotice_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="ltrlNotice" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:Repeater>
</asp:Content>
