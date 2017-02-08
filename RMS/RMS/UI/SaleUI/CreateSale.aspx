﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateSale.aspx.cs" Inherits="RMS.UI.SaleUI.CreateSale" %>

<%@ MasterType VirtualPath="~/Rms.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlCode" Style="margin-bottom: 10px; text-align: left;">

        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label for="productCode">Code</label>

                        <asp:TextBox runat="server" pattern="^[0-9]{1,5}$" ID="txtProductCode" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode" runat="server" Display="Dynamic" ErrorMessage="Required!" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="saleQuantity">Quantity</label>

                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtQty" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                            <asp:Label runat="server" ID="lblUnitSell" CssClass="input-group-addon" Text="Unit" TabIndex="-1"></asp:Label>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtQty" runat="server" ErrorMessage="Required!" Display="Dynamic" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="currentStock">Stock</label>

                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtProductStock" ClientIDMode="Static" CssClass="form-control" TabIndex="-1"></asp:TextBox>
                            <asp:Label runat="server" ID="lblUnit" CssClass="input-group-addon" Text="Unit" TabIndex="-1"></asp:Label>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="unitPrice">Unit Price</label>

                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtProductPricePerUnit" ReadOnly="True" ClientIDMode="Static" CssClass="form-control" TabIndex="-1"></asp:TextBox>

                            <span class="input-group-addon">BDT</span>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="productTotal">Product Total</label>

                        <div class="input-group">

                            <asp:TextBox runat="server" ID="txtTotalPriceOfWholeQty" ClientIDMode="Static" CssClass="form-control" TabIndex="-1"></asp:TextBox>

                            <span class="input-group-addon">BDT</span>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="vat">Vat(%)</label>

                        <div class="input-group">

                            <asp:TextBox runat="server" ID="txtVat" ClientIDMode="Static" CssClass="form-control" TabIndex="-1"></asp:TextBox>

                            <span class="input-group-addon">%</span>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="totalWithVat">Grand Total</label>

                        <div class="input-group">

                            <asp:TextBox runat="server" ID="txtTotalPriceOfWholeProduct" ClientIDMode="Static" CssClass="form-control" TabIndex="-1"></asp:TextBox>

                            <span class="input-group-addon">BDT</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Product Name</b>

                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" ClientIDMode="Static" TabIndex="-1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btn btn-primary" Style="margin-left: 10px;" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlSaleDetail" runat="server" Visible="False">
        <hr style="margin: 0; border-color: green; border-width: 3px;" />
        <div style="width: 50%; float: left; padding: 10px;">

            <asp:CheckBox ID="ckbCustomerVisibility" runat="server" CssClass="mycheckbox" Text="Is Existing Customer &nbsp;" TextAlign="Left" AutoPostBack="False" ClientIDMode="Static" />

            <div id="divCustomerDetail" style="display: none">
                <hr style="margin: 5px 1px; border-color: #a9a9a9" />
                <table>
                    <tr>
                        <td>
                            <div class="form-group">
                                <label for="customerUsername">Username</label>

                                <asp:TextBox runat="server" ID="txtCustomerUsername" CssClass="form-control" ClientIDMode="Static" Placeholder="Customer Username" OnTextChanged="txtCustomerUsername_OnTextChanged"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <label for="customerFullName">Full Name</label>

                                <asp:TextBox runat="server" ID="txtCustomerFullName" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" Placeholder="Customer Full Name" OnTextChanged="txtCustomerFullName_OnTextChanged"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <label for="customerContactNo.">Phone No.</label>

                                <asp:TextBox runat="server" ID="txtCustomerContactNo" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" Placeholder="Customer Contact No." OnTextChanged="txtCustomerContactNo_OnTextChanged"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr style="vertical-align: top">
                        <td colspan="2">
                            <div class="form-group">
                                <label for="remarks">Remarks</label>

                                <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <label for="customerDueAmount">Due Amount</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtCustomerDue" CssClass="form-control" ReadOnly="True" TabIndex="-1"></asp:TextBox>

                                    <span class="input-group-addon">BDT</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="divPaymentDetail">
                <hr style="margin: 5px 1px; border-color: #a9a9a9" />
                <table>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="paidAmount">Paid Amount</label>

                                <div class="input-group">
                                    <asp:TextBox runat="server" pattern="^\d+(\.\d{1,2})?$" ID="txtAmountPaid" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtAmountPaid_OnTextChanged"></asp:TextBox>
                                    <span class="input-group-addon">BDT</span>

                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="paymentMethod">Payment Method</label>

                                <asp:DropDownList runat="server" ID="ddlPaymentMethod" CssClass="form-control" ClientIDMode="Static">
                                    <asp:ListItem Text="Cash" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Cheque " Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Credit Card" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="bKash" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Roket" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Other" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="amountToBePaid">To Be Paid</label>

                                <div class="input-group">


                                    <asp:TextBox runat="server" ID="txtToBePaid" CssClass="form-control" ReadOnly="True" Enabled="False" TabIndex="-1" ForeColor="Red" BackColor="#F8F8F8" Font-Bold="True"></asp:TextBox>

                                    <span class="input-group-addon">BDT</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="changeAmount">Change Amount</label>

                                <div class="input-group">


                                    <asp:TextBox runat="server" ID="txtChangeAmount" CssClass="form-control" ReadOnly="True" Enabled="False" TabIndex="-1"></asp:TextBox>

                                    <span class="input-group-addon">BDT</span>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="discountAmount">Discount Amount</label>

                                <div class="input-group">


                                    <asp:TextBox runat="server" pattern="^\d+(\.\d{1,2})?$" ID="txtDiscount" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtDiscount_OnTextChanged"></asp:TextBox>

                                    <span class="input-group-addon">BDT</span>
                                </div>
                            </div>
                        </td>
                        <td style="vertical-align: bottom">
                            <br />
                            <asp:Button runat="server" ID="btnSell" CssClass="btn btn-primary" Style="margin-left: 10px;" CausesValidation="False" Text="Sell" ClientIDMode="Static" Width="155px" OnClick="btnSell_OnClick" />

                        </td>
                    </tr>
                </table>
            </div>

        </div>
        <div style="width: 50%; float: left; padding: 10px;">

            <asp:GridView ID="gvSellProduct" AutoGenerateColumns="False" ShowFooter="True" runat="server" OnRowCommand="gvSellProduct_OnRowCommand" OnRowDataBound="gvSellProduct_OnRowDataBound">
                <HeaderStyle CssClass="gvheaderstyle" />
                <RowStyle CssClass="gvrowstyle" />
                <Columns>
                    <asp:TemplateField HeaderText="Code">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ProductCode" Text='<%# Bind("ProductCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ProductName" Text='<%# Bind("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="SaleQuantity" Text='<%# Bind("SaleQuantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="SalePrice" Text='<%# Bind("SalePrice", "{0:n}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vat(%)">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ProductVat" Text='<%# Bind("ProductVat", "{0:n}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vat(Amt)">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="VatAmount" Text='<%# Bind("VatAmount", "{0:n}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ProductTotal" Text='<%# Bind("TotalAmount", "{0:n}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="RowDelete" Text="<img src='../../Images/delete.png'/>"></asp:LinkButton>
                            |
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="RowEdit" Text="<img src='../../Images/edit.png'/>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="footertotal" />
            </asp:GridView>

        </div>

    </asp:Panel>

    <script type="text/javascript">
        $(function () {

            $("#txtQty").keyup(function () {
                var qty = parseFloat($(this).val());
                var price = parseFloat($("#txtProductPricePerUnit").val());
                var total = (qty * price).toFixed(2);
                $("#txtTotalPriceOfWholeQty").val(total);

                var vat = parseFloat($("#txtVat").val());
                var totalAmount = (qty * price);
                var vatAmount = (totalAmount * vat / 100);

                var totalAmountWithVat = (totalAmount + vatAmount).toFixed(2);

                $("#txtTotalPriceOfWholeProduct").val(totalAmountWithVat);
            });
        });

        // Show / Hide Customer Details
        $(document).ready(function () {
            $('#ckbCustomerVisibility').change(function () {

                if (this.checked) {
                    $('#divCustomerDetail').show();
                }
                else {
                    $('#divCustomerDetail').hide();
                }
            });
        });
    </script>

</asp:Content>
