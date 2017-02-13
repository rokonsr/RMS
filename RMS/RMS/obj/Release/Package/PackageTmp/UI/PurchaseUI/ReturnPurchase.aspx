<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="ReturnPurchase.aspx.cs" Inherits="RMS.UI.PurchaseUI.ReturnPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function productTotal() {
            var txtReturnQuantity = document.getElementById('<%= txtReturnQuantity.ClientID %>').value;
            var txtPrice = document.getElementById('<%= txtPrice.ClientID %>').value;
            if (txtReturnQuantity == "")
                txtReturnQuantity = 0;
            if (txtPrice == "")
                txtPrice = 0;

            var result = (parseFloat(txtReturnQuantity) * parseFloat(txtPrice)).toFixed(2);
            if (!isNaN(result)) {
                document.getElementById('<%= txtTotal.ClientID %>').value = result;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="tablepadding" style="width: 100%;">
        <tr>
            <td style="font-weight: bold">Invoice Number</td>
            <td>
                <asp:TextBox ID="txtInvoiceNumber" ClientIDMode="Static" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtInvoiceNumber_OnTextChanged" runat="server"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtInvoiceNumber" Display="Dynamic" ValidationGroup="AddReturn" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ForeColor="#cc3300" ErrorMessage="Invalid Invoice Number!" ControlToValidate="txtInvoiceNumber" ValidationGroup="AddReturn" ValidationExpression="^[a-zA-Z0-9-''-'\s]{1,20}$"></asp:RegularExpressionValidator>
            </td>
            <td style="font-weight:bold">
                <div class="input-group">
                    <span class="input-group-addon" style="font-weight: bold">Ref.</span>
                    <asp:Label ID="lblPurchaseId" CssClass="form-control" runat="server" Text=""></asp:Label>
                </div>
            </td>
            <td style="font-weight: bold">Supplier Name</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlSupplierList" CssClass="form-control" ClientIDMode="Static" runat="server" Enabled="False" OnSelectedIndexChanged="ddlSupplierList_OnSelectedIndexChanged"></asp:DropDownList>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server" Display="Dynamic" ControlToValidate="ddlSupplierList" ValidationGroup="AddReturn" ErrorMessage="Required Field!" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="font-weight: bold">
            <td>Product Code</td>
            <td>Product Name</td>
            <td>Purchase Quantity</td>
            <td>Discount Amount</td>
            <td colspan="2">Remarks</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtReturnProductCode" ClientIDMode="Static" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtProductCode_OnTextChanged" type="number" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtReturnProductCode" Display="Dynamic" ValidationGroup="AddReturn" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="#cc3300" ErrorMessage="Invalid Code!" ControlToValidate="txtReturnProductCode" ValidationGroup="AddReturn" ValidationExpression="^[0-9''-'\s]{1,20}$"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtReturnProductName" ClientIDMode="Static" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtProductName_OnTextChanged" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtReturnProductName" Display="Dynamic" ValidationGroup="AddReturn" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" Display="Dynamic" ForeColor="#cc3300" ErrorMessage="Invalid Product Name!" ControlToValidate="txtReturnProductName" ValidationGroup="AddReturn" ValidationExpression="^[a-zA-z0-9-''-'\s]{1,90}$"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtPurchaseQuantity" CssClass="form-control" Enabled="False" runat="server"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtPurchaseQuantity" Display="Dynamic" ValidationGroup="AddReturn" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
            </td>
            <td>
                <div class="input-group">
                    <asp:TextBox ID="txtReturnDiscountAmount" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-addon" style="width: 80px; font-weight: bold; color: red;">
                        <asp:Label ID="lblDiscountAmount" runat="server" Text=""></asp:Label>
                    </span>
                </div>
                
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" Rows="1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="font-weight: bold">
            <td style="width: 16.5%">Return Quantity</td>
            <td style="width: 16.5%">Purchase Price</td>
            <td style="width: 16.5%">Total</td>
            <td style="width: 16.5%"></td>
            <td style="width: 16.5%"></td>
            <td style="width: 16.5%"></td>
        </tr>
        <tr style="vertical-align: top;">
            <td>
                <asp:TextBox ID="txtReturnQuantity" CssClass="form-control" type="number" runat="server" onkeyup="productTotal()"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtReturnQuantity" Display="Dynamic" ValidationGroup="AddReturn" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPrice" Display="Dynamic" ValidationGroup="AddReturn" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtTotal" CssClass="form-control" Enabled="False" runat="server"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:Button ID="btnAddReturn" CssClass="btn btn-primary" runat="server" ValidationGroup="AddReturn" Text="Add Return" OnClick="btnAddReturn_OnClick" />
            </td>
            <td style="text-align: right; font-weight: bold; vertical-align: middle;">Total Return Value</td>
            <td>
                <asp:TextBox ID="txtTotalReturnValue" CssClass="form-control" Enabled="False" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlDisplayReturnDetails" runat="server" Visible="False">
        <hr />
        <asp:GridView ID="gvReturnDetails" runat="server" AutoGenerateColumns="False" OnRowCommand="gvReturnDetails_OnRowCommand" OnRowDataBound="gvReturnDetails_OnRowDataBound" ShowFooter="True">
            <HeaderStyle CssClass="gvheaderstyle" />
            <RowStyle CssClass="gvrowstyle" />
                <Columns>
                    <asp:TemplateField HeaderText="Product Id">
                        <ItemTemplate>
                            <asp:Label ID="ProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label ID="ProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier Id">
                        <ItemTemplate>
                            <asp:Label ID="SupplierId" runat="server" Text='<%# Bind("SupplierId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier Name">
                        <ItemTemplate>
                            <asp:Label ID="SupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice Number">
                        <ItemTemplate>
                            <asp:Label ID="InvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Purchase Quantity">
                        <ItemTemplate>
                            <asp:Label ID="PurchaseQuantity" runat="server" Text='<%# Bind("PurchaseQuantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Return Quantity">
                        <ItemTemplate>
                            <asp:Label ID="ReturnQuantity" runat="server" Text='<%# Bind("ReturnQuantity", "{0:n3}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="Price" runat="server" Text='<%# Bind("Price", "{0:n}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Total">
                        <ItemTemplate>
                            <asp:Label ID="ProductTotal" runat="server" Text='<%# Bind("ProductTotal", "{0:n}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="RowDelete" Text="Delete"></asp:LinkButton> |
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="RowEdit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            <FooterStyle CssClass="footertotal" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnSubmitReturn" CssClass="btn btn-primary" runat="server" Text="Save Return" OnClick="btnSubmitReturn_OnClick" />

        <hr />
    </asp:Panel>

</asp:Content>
