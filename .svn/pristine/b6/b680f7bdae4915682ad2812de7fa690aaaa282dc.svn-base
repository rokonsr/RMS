<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="AdvanceSaleReceive.aspx.cs" Inherits="RMS.UI.SaleUI.AdvanceSaleReceive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--Ataur--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenCustomerId" runat="server" />
    <div class="form-group">
        <table class="tablepadding">
            <tr>
                <td> Customer Username</td>
                <td> Transaction Type</td>
                <td> Amount</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCustomerUsername" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCustomerUsername" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlTransactionType" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtTransactionAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtTransactionAmount" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
