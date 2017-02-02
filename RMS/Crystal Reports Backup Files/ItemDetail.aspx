<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="ItemDetail.aspx.cs" Inherits="RMS.Report.ItemReport.ItemDetail" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .space input[type="radio"] { margin-right: 5px; }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="tablepadding">
        <tr>
            <td style="width: 120px;">Search Type</td>
            <td>
                <asp:RadioButtonList ID="rdItemDetailList" runat="server" CssClass="space" AutoPostBack="True" RepeatDirection="Horizontal">
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
        <CR:CrystalReportViewer ID="crItemDetails" runat="server" AutoDataBind="true" EnableParameterPrompt="False"/>
    </asp:Panel>

    <asp:Panel ID="pnlDisplayRegion" runat="server" Visible="False">
        
        <table class="tablepadding">
            <tr>
                <td style="width: 120px;">Region Name</td>
                <td>
                    <asp:TextBox ID="txtRegionName" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnRegion" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnRegion_OnClick" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="crRegionDetail" runat="server" AutoDataBind="true" EnableParameterPrompt="False"/>
    </asp:Panel>

    <asp:Panel ID="pnlFoodSchedule" runat="server" Visible="False">
        
        <table class="tablepadding">
            <tr>
                <td style="width: 120px;">Food Schedule</td>
                <td>
                    <asp:TextBox ID="txtFoodSchedule" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnFoodSchedule" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnFoodSchedule_OnClick" />
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="crFoodScheduleDetails" runat="server" AutoDataBind="true" EnableParameterPrompt="False"/>
    </asp:Panel>

</asp:Content>
