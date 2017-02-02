<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="PurchaseLedgerDetails.aspx.cs" Inherits="RMS.UI.PurchaseUI.PurchaseLedgerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        function currentBalance() {
            var txtTotalBalance = document.getElementById('<%= txtTotalBalance.ClientID %>').value;
            var txtReceivedAmount = document.getElementById('<%= txtReceivedAmount.ClientID %>').value;
            if (txtTotalBalance == "")
                txtTotalBalance = 0;
            if (txtReceivedAmount == "")
                txtReceivedAmount = 0;

            var result = (parseFloat(txtTotalBalance) - parseFloat(txtReceivedAmount)).toFixed(2);
            if (!isNaN(result)) {
                document.getElementById('<%= txtCurrentBalance.ClientID %>').value = result;
            }
            currentDue();
        }

        function currentDue() {
            var txtInvoiceDue = document.getElementById('<%= txtInvoiceDue.ClientID %>').value;
            var txtReceivedAmount = document.getElementById('<%= txtReceivedAmount.ClientID %>').value;
            if (txtInvoiceDue == "")
                txtInvoiceDue = 0;
            if (txtReceivedAmount == "")
                txtReceivedAmount = 0;

            var result = (parseFloat(txtInvoiceDue) - parseFloat(txtReceivedAmount)).toFixed(2);
            if (!isNaN(result)) {
                document.getElementById('<%= txtCurrentDue.ClientID %>').value = result;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="tablepadding" style="width: 100%">
        <tr>
            <td>Supplier Name</td>
            <td>
                <asp:DropDownList ID="ddlSupplier" Enabled="False" CssClass="form-control" runat="server"></asp:DropDownList>
            </td>
            <td>Invoice Number</td>
            <td>
                <asp:TextBox ID="txtInvoiceNumber" ClientIDMode="Static" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtInvoiceNumberList_OnTextChanged"></asp:TextBox>
            </td>
            <td>Invoice Due</td>
            <td>
                <asp:TextBox ID="txtInvoiceDue" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Receiving Type</td>
            <td>
                <asp:DropDownList ID="ddlReceivingType" CssClass="form-control" runat="server"></asp:DropDownList>
            </td>
            <td>Received Amount</td>
            <td>
                <asp:TextBox ID="txtReceivedAmount" CssClass="form-control" runat="server" onkeyup="currentBalance();" AutoComplete="off"></asp:TextBox>
            </td>
            <td>Total Balance</td>
            <td>
                <asp:TextBox ID="txtTotalBalance" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCreateLedger" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnCreateLedger_OnClick"/>
            </td>
            <td>Current Due</td>
            <td>
                <asp:TextBox ID="txtCurrentDue" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>Current Balance</td>
            <td>
                <asp:TextBox ID="txtCurrentBalance" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
    </table>

</asp:Content>
