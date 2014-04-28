<%@ Page  Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_ArrangeTime_Detail.aspx.cs" Inherits="Shsict.Web.Container_ArrangeTime_Detail" Title="直装直提计划安排情况" Theme="Shsict"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
       <div data-role="content">
        <div class="ui-content"></div>
        <!--<img src="css/1.gif">-->
    </div>
    <div>
        <asp:Label ID="lblContainerNo" runat="server" Text=""> </asp:Label>

        <table data-role="table" class="table-stroke detail-list">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="plan-arrange-t">
                       <asp:Label ID="lblPlanAarrangeTime" runat="server" Text="Label"></asp:Label>
                    </td>
                    
                </tr>
            </tbody>
        </table>

        
    </div>
</asp:Content>
