﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="ReturnSale.aspx.cs" Inherits="RMS.UI.SaleUI.ReturnSale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-group{ margin: 0;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlInvoiceNo">
        <table class="tablepadding" style="width: 100%">
            <tr>
                <td>
                    <div class="form-group">
                        <label for="invoiceNumber">Invoice No.</label>
                        
                        <asp:TextBox runat="server" ID="txtSaleInvoiceNumber" CssClass="form-control" ClientIDMode="Static" ></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="grandTotal">Grand Total</label>
                        
                        <asp:TextBox runat="server" ID="txtSaleReturnGrandTotal" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="vatAmount">Vat Amount</label>
                        
                        <asp:TextBox runat="server" ID="txtVatAmountTotal" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="adjustment">Adjustment</label>
                        
                        <asp:TextBox runat="server" ID="txtAdjustmentAmount" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="totalDiscountAmount">Discount Amount</label>
                        
                        <asp:TextBox runat="server" ID="txtTotalDiscountAmount" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="paidAmount">Paid Amount</label>
                        
                        <asp:TextBox runat="server" ID="txtPaidAmount" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
            </tr>
            </table>
        </asp:Panel>

    <asp:Panel runat="server" ID="pnlCustomer" Visible="False" >
        <table class="tablepadding">
            <tr>
                <td>
                    <div class="form-group">
                        <label for="customerUsername">Customer Username</label>
                        
                        <asp:TextBox runat="server" ID="txtCustomerUsername" CssClass="form-control" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                    </div>
                </td>

            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <label>Customer Username</label>
                </td>
                <td>
                    
                </td>
                <td>
                    <label>Paid by this invoice</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPaidByThisInvoice" CssClass="form-control" ClientIDMode="Static" ReadOnly="False"></asp:TextBox>
                </td>
                <td>
                    <label>Due by this invoice</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDueByThisInvoice" CssClass="form-control" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <label>Total due</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTotalDue" CssClass="form-control" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br/>
    </asp:Panel>
    
    <div id="divProductList" style="display: none">
        <table class="tablepadding" style="width: 100%">
            <tr>
                <td>
                    <div class="form-group">
                        <label for="productCode">Product Code</label>
                        
                        <asp:TextBox runat="server" ID="txtSaleReturnProductCode" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="productName">Product Name</label>
                        
                        <asp:TextBox runat="server" ID="txtSaleReturnProductName" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="unitPrice">Unit Price</label>
                        
                        <asp:TextBox runat="server" ID="txtPricePerUnitReturnSale" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="vat">Vat(%)</label>
                        
                        <asp:TextBox runat="server" ID="txtVatReturnSale" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="discountRate">Discount(%)</label>
                        
                        <asp:TextBox runat="server" ID="txtDiscountRate" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-group">
                        <label for="returnQuantity">Return Quantity</label>
                        
                        <asp:TextBox runat="server" ID="txtSaleReturnQty" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="saleQuantity">Sale Quantity</label>
                        
                        <asp:TextBox runat="server" ID="txtSaleQuantity" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="unitPriceTotal">Total Unit Price</label>
                        
                        <asp:TextBox runat="server" ID="txtReturnUnitPrice" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="productVatAmount">Vat Amount</label>
                        
                        <asp:TextBox runat="server" ID="txtProductVat" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="discountAmount">Discount Amount</label>
                        
                        <asp:TextBox runat="server" ID="txtDiscountAmount" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <label for="returnAmount">
                            <label for="returnAmount">Return Amount</label>
                            
                            <asp:TextBox runat="server" ID="txtTotalPricePerProductSaleReturn" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btn btn-primary" ClientIDMode="Static" OnClick="btnAdd_Click"/>
                </td>
            </tr>
        </table>
        
        <asp:GridView runat="server" ID="GvReturnSell" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ProductId" ShowHeaderWhenEmpty="True" EmptyDataText="No product sell yet." OnRowDataBound="GvReturnSell_OnRowDataBound" ShowFooter="True" OnRowDeleting="GvReturnSell_OnRowDeleting">
            <HeaderStyle CssClass="gvheaderstyle"></HeaderStyle>
            <RowStyle CssClass="gvrowstyle"></RowStyle>
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Product Id" Visible="False"/>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
                <asp:BoundField DataField="ProductQty" HeaderText="Quantity"/>
                <asp:BoundField DataField="ProductPricePerUnit" HeaderText="Price Per Unit"/>
                <asp:BoundField DataField="ProductVat" HeaderText="VAT(%)"/>
                <asp:BoundField DataField="ProductTotalPrice" HeaderText="Total Price"/>
                <asp:CommandField HeaderText="Action" ButtonType="Button" ShowDeleteButton="True" CausesValidation="False" />
            </Columns>
            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" NextPageText="Next" LastPageText="Last" PreviousPageText="Previous"></PagerSettings>
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />

        </asp:GridView>

    </div>

    <asp:Panel runat="server" ID="pnlToBeReturn" Visible="False">
        <br/>
        <table>
            <tr>
                <td>
                    <label>Total Return Amount</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtReturnTotalAmount" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </td>

                <td>
                    <label>To be return</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtToBeReturnSale" CssClass="form-control" ClientIDMode="Static" ReadOnly="True" Enabled="False"></asp:TextBox>
                </td>
                
                <td>
                    <label>Remark</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRemark" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSaveReturn" Text="Return" CssClass="btn btn-primary" ClientIDMode="Static" OnClick="btnSaveReturn_Click"/>
                </td>
            </tr>

        </table>
    </asp:Panel>
    <script>
        $(function () {

            $("#txtSaleReturnQty").keyup(function () {
                var qty = parseFloat($(this).val());
                //Calculate vat amount as per unit price
                var price = parseFloat($("#txtPricePerUnitReturnSale").val());
                var vat = parseFloat($("#txtVatReturnSale").val());
                var vatAmount = parseFloat((price * vat / 100) * qty).toFixed(2);
                $("#txtProductVat").val(vatAmount);

                //Calculate total unit price
                var unitPriceTotal = parseFloat($("#txtPricePerUnitReturnSale").val());
                var totalUnitPriceAmount = (unitPriceTotal * qty).toFixed(2);
                $("#txtReturnUnitPrice").val(totalUnitPriceAmount);

                //Calculate discount amount as per unit price
                var unitPrice = parseFloat($("#txtPricePerUnitReturnSale").val());
                var discount = parseFloat($("#txtDiscountRate").val());
                var discountAmount = parseFloat((unitPrice * discount / 100) * qty).toFixed(2);
                $("#txtDiscountAmount").val(discountAmount);

                //Return Amount
                var returnUnitPrice = parseFloat($("#txtReturnUnitPrice").val());
                var returnVatAmount = parseFloat($("#txtProductVat").val());
                var returnDiscountAmount = parseFloat($("#txtDiscountAmount").val());
                var returnAmount = (returnUnitPrice + returnVatAmount - returnDiscountAmount).toFixed(2);
                $("#txtTotalPricePerProductSaleReturn").val(returnAmount);
            });
        });
    </script>
    <script>
        
        $(function () {
            $('#txtSaleInvoiceNumber').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../WebServices/AutoCompleteService.asmx/SearchSaleInvoiceNumber",
                        data: "{'searchText': '" + request.term + "' }",
                        type: "POST",
                        dataType: "Json",
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert('Not Match');
                        }
                    });
                },
                 
                change: function () {
                    $.ajax({
                        url: "../WebServices/AutoCompleteService.asmx/GetInvoiceInfo",
                        data: "{'invoiceNo': '" + this.value + "' }",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            $('#txtSaleReturnGrandTotal').val(data.d.TotalAmount.toFixed(2));
                            $('#txtAdjustmentAmount').val(data.d.AdjustmentAmount.toFixed(2));
                            $('#txtPaidAmount').val(data.d.PaidAmount.toFixed(2));
                            $('#txtVatAmountTotal').val(data.d.VatAmountTotal.toFixed(2));
                            $('#txtTotalDiscountAmount').val(data.d.DiscountAmountTotal.toFixed(2));

                            $('pnlProductList').show();
                        },
                        error: function (result) {
                            alert('Not Match');
                        }
                    });
                }
            });
            ///////////////////////////////////////
            $('#txtSaleReturnProductCode').autocomplete({
                source: function (request, response) {
                    var invoice = $('#txtSaleInvoiceNumber').val();
                    $.ajax({
                        url: "../WebServices/AutoCompleteService.asmx/SearchProductIdForSaleReturn",
                        data: "{'productId': '" + request.term + "', 'invoiceNumber': '" + invoice + "' }",
                        type: "POST",
                        dataType: "Json",
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert('Not Match');
                        }
                    });
                },
                change: function () {
                    var invoice = $('#txtSaleInvoiceNumber').val();
                    $.ajax({
                        url: "../WebServices/AutoCompleteService.asmx/GetSaleProductInfo",
                        data: "{'productId': '" + this.value + "', 'invoiceNumber': '" + invoice + "' }",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            $('#txtSaleReturnProductName').val(data.d.ProductName);
                            $('#txtPricePerUnitReturnSale').val(data.d.SellPrice.toFixed(2));
                            $('#txtVatReturnSale').val(data.d.Vat.toFixed(2));
                            $('#txtDiscountRate').val(data.d.Discount.toFixed(2));
                            $('#txtSaleQuantity').val(data.d.SellQuantity.toFixed(2));
                        },
                        error: function (result) {
                            alert('Not Match');
                        }
                    });
                }

                 


            });
        });

        // Search product details by product name
        $('#txtSaleReturnProductName').autocomplete({
            source: function (request, response) {
                var invoice = $('#txtSaleInvoiceNumber').val();
                $.ajax({
                    url: "../WebServices/AutoCompleteService.asmx/SearchProductNameForSaleReturn",
                    data: "{'productname': '" + request.term + "', 'invoiceNumber': '" + invoice + "' }",
                    type: "POST",
                    dataType: "Json",
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert('Not Match');
                    }
                });
            },
            change: function () {
                var invoice = $('#txtSaleInvoiceNumber').val();
                $.ajax({
                    url: "../WebServices/AutoCompleteService.asmx/GetSaleProductNameInfo",
                    data: "{'productname': '" + this.value + "', 'invoiceNumber': '" + invoice + "' }",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        $('#txtSaleReturnProductCode').val(data.d.ProductId);
                        $('#txtPricePerUnitReturnSale').val(data.d.SellPrice.toFixed(2));
                        $('#txtVatReturnSale').val(data.d.Vat.toFixed(2));
                        $('#txtDiscountRate').val(data.d.Discount.toFixed(2));
                        $('#txtSaleQuantity').val(data.d.SellQuantity.toFixed(2));
                    },
                    error: function (result) {
                        alert('Not Match2');
                    }
                });
            }
        });

        // Show / Hide Product Details

        $('#txtSaleInvoiceNumber').on('change', function () {
            if ($(this).val() == 0)
                $('#divProductList').hide();
            else
                $('#divProductList').show();
        });

    </script>

</asp:Content>
