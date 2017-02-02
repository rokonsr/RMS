<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="ItemDetail.aspx.cs" Inherits="RMS.Report.ItemReport.ItemDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td style="width: 120px;">Search Type</td>
            <td>
                <asp:RadioButtonList ID="rdItemDetailList" runat="server" CssClass="space" AutoPostBack="True" EnableViewState="True" ViewStateMode="Enabled" RepeatDirection="Horizontal"  OnSelectedIndexChanged="rdItemDetailList_OnSelectedIndexChanged">
                    <asp:ListItem Value="1">Item</asp:ListItem>
                    <asp:ListItem Value="2">Region</asp:ListItem>
                    <asp:ListItem Value="3">Food Schedule</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlDisplayItem" runat="server" Visible="False">
        
        <table class="tablepadding">
            <tr>
                <td style="width: 120px;">Item Name</td>
                <td>
                    <asp:TextBox ID="txtItemName" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnItem" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnItem_OnClick" />
                </td>
            </tr>
        </table>
        
    </asp:Panel>

    <asp:Panel ID="pnlDisplayRegion" runat="server" Visible="False">
        
        <table class="tablepadding">
            <tr>
                <td style="width: 120px;">Region Name</td>
                <td>
                    <asp:DropDownList ID="ddlRegion" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlFoodSchedule" runat="server" Visible="False">
        
        <table class="tablepadding">
            <tr>
                <td style="width: 120px;">Food Schedule</td>
                <td>
                    <asp:DropDownList ID="ddlFoodSchedule" CssClass="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlFoodSchedule_OnSelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>

    </asp:Panel>

</asp:Content>
