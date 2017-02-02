<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="SaleLedgerDetails.aspx.cs" Inherits="RMS.UI.SaleUI.SaleLedgerDetails" %>
<%--Created by ataur--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function currentBalance() {
            var txtCurrentDue = document.getElementById('<%= txtCurrentDue.ClientID %>').value;
            var txtReceivedAmount = document.getElementById('<%= txtReceivedAmount.ClientID %>').value;
            if (txtCurrentDue == "")
                txtCurrentDue = 0;
            if (txtReceivedAmount == "")
                txtReceivedAmount = 0;

            var result = (parseFloat(txtCurrentDue) - parseFloat(txtReceivedAmount)).toFixed(2);
            if (!isNaN(result)) {
                document.getElementById('<%= txtTotalBalance.ClientID %>').value = result;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenCustomerId" runat="server" />
    <table class="tablepadding">
        <tr>
            <td style="width: 190px;">Customer Username</td>
            <td style="width: 250px;">
                <asp:TextBox ID="txtCustomerUsername" CssClass="form-control" runat="server" value="" ClientIDMode="Static" OnTextChanged="txtCustomerUsername_OnTextChanged" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="width: 190px;">Invoice Number</td>
            <td style="width: 250px;">
                <asp:TextBox runat="server" ID="txtSaleLedgerInvoiceNumber" CssClass="form-control" ClientIDMode="Static" OnTextChanged="txtSaleLedgerInvoiceNumber_OnTextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSaleLedgerInvoiceNumber" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Digits Only!" ControlToValidate="txtSaleLedgerInvoiceNumber"  ValidationExpression="^[0-9-''-'\s]{1,12}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Receiving Type</td>
            <td>
                <asp:DropDownList ID="ddlReceivingType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReceivingType_OnSelectedIndexChanged"></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlReceivingType" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Required!" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
            <td>Received Amount</td>
            <td>
                <asp:TextBox ID="txtReceivedAmount" CssClass="form-control" runat="server" onkeyup="currentBalance();"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtReceivedAmount" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Digits Only!" ControlToValidate="txtReceivedAmount"  ValidationExpression="^[0-9-''-'\s]{1,20}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Current Due</td>
            <td>
                <asp:TextBox ID="txtCurrentDue" CssClass="form-control" runat="server" ReadOnly="True" ForeColor="#CC3300"></asp:TextBox>
            </td>
            <td>Total Balance</td>
            <td>
                <asp:TextBox ID="txtTotalBalance" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtTotalBalance" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td></td>                       
            <td>
                <asp:Button ID="btnSubmitSaleLedgerDetails" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmitSaleLedgerDetails_Click" />
            </td>                     
        </tr>
    </table>

</asp:Content>
