<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreatePurchase.aspx.cs" Inherits="RMS.UI.PurchaseUI.CreatePurchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        function productTotal() {
            var txtPurchaseQuantity = document.getElementById('<%= txtPurchaseQuantity.ClientID %>').value;
            var txtPurchasePrice = document.getElementById('<%= txtPurchasePrice.ClientID %>').value;
            if (txtPurchaseQuantity == "")
                txtPurchaseQuantity = 0;
            if (txtPurchasePrice == "")
                txtPurchasePrice = 0;

            var result = (parseFloat(txtPurchaseQuantity) * parseFloat(txtPurchasePrice)).toFixed(2);
            if (!isNaN(result)) {
                document.getElementById('<%= txtProductTotal.ClientID %>').value = result;
            }
        }

        function grandTotal() {
            var txtDueAmount = document.getElementById('<%= txtDueAmount.ClientID %>').value;
            var txtTotalPurchaseAmount = document.getElementById('<%= txtTotalPurchaseAmount.ClientID %>').value;
            var txtPaidAmount = document.getElementById('<%= txtPaidAmount.ClientID %>').value;
            var txtDiscountAmount = document.getElementById('<%= txtDiscountAmount.ClientID %>').value;
            if (txtDueAmount == "")
                txtDueAmount = 0;
            if (txtTotalPurchaseAmount == "")
                txtTotalPurchaseAmount = 0;
            if (txtPaidAmount == "")
                txtPaidAmount = 0;
            if (txtDiscountAmount == "")
                txtDiscountAmount = 0;

            var totalWithDue = parseFloat(txtDueAmount) + parseFloat(txtTotalPurchaseAmount);
            var paidWithDiscount = parseFloat(txtPaidAmount) + parseFloat(txtDiscountAmount);

            var result = (totalWithDue - paidWithDiscount).toFixed(2);

            if (!isNaN(result)) {
                document.getElementById('<%= txtCurrentDue.ClientID %>').value = result;
            }
        }

        //Date Picker Start
        $(function () {
            $('#<%= txtPurchaseDate.ClientID %>').datepicker({ dateFormat: 'dd-mm-yy', type: Text }).click(function () { $(this).focus(); });
        });

        $('input[type=date]').each(function () {
            this.type = "text";
        });
        //Date Picker End
    </script>
    
    <!--Date Picker Start-->
        <link href="../../Scripts/DatePicker/jquery-ui.css" rel="stylesheet" />
        <script src="../../Scripts/DatePicker/jquery-1.10.2.js"></script>
        <script src="../../Scripts/DatePicker/jquery-ui.js"></script>
    <!--Date Picker End-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="pnlPurchase" runat="server">
        <table class="tablepadding" style="width: 100%;">
            <tr>
                <td style="width: 10%;">Supplier Name</td>
                <td style="width: 20%;">
                    <asp:DropDownList ID="ddlSupplier" AutoPostBack="True" CssClass="form-control" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSupplier_OnSelectedIndexChanged"></asp:DropDownList>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server" Display="Dynamic" ControlToValidate="ddlSupplier" ValidationGroup="AddPurchase" ErrorMessage="Required Field!" ForeColor="Red">
                </asp:RequiredFieldValidator>
                </td>
                <td>Invoice Number</td>
                <td style="width: 20%;">
                    <asp:TextBox ID="txtInvoiceNumber" ClientIDMode="Static" CssClass="form-control" runat="server" TabIndex="2"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ForeColor="#cc3300" ErrorMessage="Invalid Invoice Number!" ControlToValidate="txtInvoiceNumber" ValidationGroup="AddPurchase" ValidationExpression="^[a-zA-Z0-9-''-'\s]{1,20}$"></asp:RegularExpressionValidator>
                </td>
                <td>Upload Invoice</td>
                <td style="width: 20%;">
                    <asp:FileUpload ID="flUploadInvoice" CssClass="btn btn-default" runat="server" TabIndex="3" />
                </td>
            </tr>
            <tr>
                <td>Purchase Date</td>
                <td>
                    <asp:TextBox ID="txtPurchaseDate" CssClass="form-control" runat="server" TabIndex="4"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtPurchaseDate" ValidationGroup="AddPurchase" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                </td>
                <td>Remarks</td>
                <td colspan="3" rowspan="2">
                    <asp:TextBox ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Due Amount</td>
                <td>
                    <asp:TextBox ID="txtDueAmount" CssClass="form-control" runat="server" Enabled="False" TabIndex="-1" onkeyup="grandTotal();"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table class="tablepadding" style="width: 100%">
            <tr>
                <td style="width: 10%;">Purchase Amount</td>
                <td>
                    <asp:TextBox ID="txtTotalPurchaseAmount" CssClass="form-control" runat="server" Enabled="False" TabIndex="-1" onkeyup="grandTotal();"></asp:TextBox>
                </td>
                <td>Total Amount</td>
                <td>
                    <asp:TextBox ID="txtPurchaseGrandTotal" CssClass="form-control" runat="server" Enabled="False" TabIndex="-1"></asp:TextBox>
                </td>
                <td>Paid Amount</td>
                <td>
                    <asp:TextBox ID="txtPaidAmount" CssClass="form-control" runat="server" onkeyup="grandTotal();" TabIndex="6"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ControlToValidate="txtPaidAmount" ValidationGroup="AddPurchase" ForeColor="Red" ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Invalid Amount!"></asp:RegularExpressionValidator>
                </td>
                <td>Discount Amount</td>
                <td>
                    <asp:TextBox ID="txtDiscountAmount" CssClass="form-control" runat="server" onkeyup="grandTotal();" TabIndex="7"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="txtDiscountAmount" ValidationGroup="AddPurchase" ForeColor="Red" ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Invalid Amount!"></asp:RegularExpressionValidator>
                </td>
                <td>Current Due</td>
                <td>
                    <asp:TextBox ID="txtCurrentDue" CssClass="form-control" runat="server" Enabled="False" TabIndex="-1"></asp:TextBox>
                </td>
                
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlPurchaseDetail" runat="server">
        <hr/>
        
        <table class="tablepadding" style="vertical-align: top">
            <tr style="vertical-align: top">
                <td>Product Code</td>
                <td style="width: 300px;">Product Name</td>
                <td>Stock</td>
                <td>Purchase Quantity</td>
                <td>Purchase Price</td>
                <td>Update Sell Price | <asp:CheckBox ID="ckUpdateSellPrice" runat="server" style="vertical-align: middle;" TabIndex="-1" AutoPostBack="True" OnCheckedChanged="ckUpdateSellPrice_CheckedChanged" /></td>
                <td>Total</td>
                <td></td>
            </tr>
            <tr style="vertical-align: top">
                <td>
                    <asp:TextBox ID="txtProductCode" ClientIDMode="Static" CssClass="form-control" type="number" AutoPostBack="True" runat="server" Width="100px" OnTextChanged="txtProductCode_OnTextChanged" TabIndex="8"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode" Display="Dynamic" ValidationGroup="AddPurchaseDetails" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" Display="Dynamic" ForeColor="#cc3300" ErrorMessage="Invalid Code!" ControlToValidate="txtProductCode" ValidationGroup="AddPurchaseDetails" ValidationExpression="^[0-9''-'\s]{1,20}$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtProductName" ClientIDMode="Static" CssClass="form-control" AutoPostBack="True" runat="server" OnTextChanged="txtProductName_OnTextChanged" TabIndex="10"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtProductName" Display="Dynamic" ValidationGroup="AddPurchaseDetails" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" Display="Dynamic" ForeColor="#cc3300" ErrorMessage="Invalid Product Name!" ControlToValidate="txtProductName" ValidationGroup="AddPurchaseDetails" ValidationExpression="^[a-zA-z0-9-''-'\s]{1,90}$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCurrentStock" CssClass="form-control" runat="server" Width="75px" Enabled="False" TabIndex="-1"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPurchaseQuantity" CssClass="form-control" AutoComplete="off" runat="server" onkeyup="productTotal();" TabIndex="11"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtPurchaseQuantity" Display="Dynamic" ValidationGroup="AddPurchaseDetails" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="txtPurchaseQuantity" ValidationGroup="AddPurchaseDetails" ForeColor="Red" ValidationExpression="^([0-9]*[1-9][0-9]*(\.[0-9]+)?|[0]+\.[0-9]*[1-9][0-9]*)$" ErrorMessage="Invalid Quantity!"></asp:RegularExpressionValidator>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasePrice" CssClass="form-control" AutoComplete="off" runat="server" onkeyup="productTotal();" TabIndex="12"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPurchasePrice" Display="Dynamic" ValidationGroup="AddPurchaseDetails" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPurchasePrice" ValidationGroup="AddPurchaseDetails" ForeColor="Red"  ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Invalid Quantity!"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtSalePrice" CssClass="form-control" ReadOnly="True" runat="server" MinimumValue="1" TabIndex="-1"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtSalePrice" Display="Dynamic" ValidationGroup="AddPurchaseDetails" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSalePrice" ValidationGroup="AddPurchaseDetails" ForeColor="Red" ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Invalid Quantity!"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtProductTotal" CssClass="form-control" runat="server" Width="100px" TabIndex="-1" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add" ValidationGroup="AddPurchaseDetails" OnClick="btnAdd_OnClick" TabIndex="13" />
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlAddPurchaseDetailstoGridView" Visible="False" runat="server">
        <hr/>
        <asp:GridView ID="gvDisplayPurchaseDetail" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCommand="gvDisplayPurchaseDetail_RowCommand" OnRowDataBound="gvDisplayPurchaseDetail_RowDataBound">
            <HeaderStyle CssClass="gvheaderstyle" />
            <RowStyle CssClass="gvrowstyle" />
            <Columns>
                <asp:TemplateField HeaderText="Product Code">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="ProductCode" Text='<%# Bind("ProductCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="ProductName" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Purchase Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="PurchaseQuantity" Text='<%# Bind("PurchaseQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Purchase Price">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="PurchasePrice" Text='<%# Bind("PurchasePrice", "{0:n}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sale Price">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="SalePrice" Text='<%# Bind("SalePrice", "{0:n}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="ProductTotal" Text='<%# Bind("TotalAmount", "{0:n}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="RowDelete" Text="<img src='../../Images/delete.png' />"></asp:LinkButton> |
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="RowEdit" Text="<img src='../../Images/edit.png' />"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle CssClass="footertotal" />
        </asp:GridView>
        <hr />
        <asp:Button ID="btnPurchase" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="AddPurchase" OnClick="btnPurchase_OnClick" />

    </asp:Panel>

</asp:Content>
