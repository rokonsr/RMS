<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="PurchaseDetail.aspx.cs" Inherits="RMS.Report.PurchaseReport.SupplierwisePurchaseDetail1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="tablepadding">
        <tr>
            <td style="width: 120px;">Search Type</td>
            <td>
                <asp:RadioButtonList ID="rdPurchaseDetailList" runat="server" CssClass="space" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdPurchaseDetailList_OnSelectedIndexChanged">
                    <asp:ListItem Value="1">Supplier</asp:ListItem>
                    <asp:ListItem Value="2">Invoice</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    
    <asp:Panel ID="pnlDisplaySupplier" runat="server" Visible="False">
        <table class="tablepadding">
            <tr>
            <td style="width: 120px;">Supplier Name</td>
            <td>
                <asp:DropDownList ID="ddlSupplier" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlSupplier_OnSelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlDisplayInvoice" runat="server" Visible="False">
        <table class="tablepadding">
            <tr>
                <td style="width: 120px;">Invoice Number</td>
                <td>
                    <asp:TextBox ID="txtInvoiceNumber" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_OnClick"/>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
