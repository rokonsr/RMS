<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="RMS.UI.Item.UpdateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
    <script type="text/javascript">
        
        function LoadDiv(url) {
            var img = new Image();
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";
 
            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }
    </script>

    <style type="text/css">
        .modal {
            display: none;
            background-color: black;
            z-index: 100;
            opacity: 0.7;
            filter: alpha(opacity=60);
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
            height: 650px;
            width: 700px;
            border: solid 5px blue;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="productname">Product Name</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtProductName" AutoPostBack="True" ClientIDMode="Static" CssClass="form-control" runat="server" Placeholder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="pnlDisplayProduct" runat="server">
        <hr />
        <asp:GridView ID="gvDisplayProduct" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" DataKeyNames="ProductId, RegionId, BrandId, MeasurementId, FoodScheduleId, IsActive" EnableViewState="False" OnPageIndexChanging="gvDisplayProduct_PageIndexChanging" OnSelectedIndexChanged="gvDisplayProduct_OnSelectedIndexChanged" OnRowDataBound="gvDisplayProduct_RowDataBound">
            <HeaderStyle CssClass="gvheaderstyle" />
            <RowStyle CssClass="gvrowstyle" />
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" />
                <asp:BoundField DataField="RegionName" HeaderText="Region" />
                <asp:BoundField DataField="FirstCategory" HeaderText="First Category" />
                <asp:BoundField DataField="SecondCategory" HeaderText="Second Category" />
                <asp:BoundField DataField="ThirdCategory" HeaderText="Third Category" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:BoundField DataField="MeasurementName" HeaderText="Measurement" />
                <asp:BoundField DataField="ProductStock" HeaderText="Stock" />
                <asp:BoundField DataField="ProductSellPrice" HeaderText="Sell Price" />
                <asp:BoundField DataField="Vat" HeaderText="Vat(%)" />
                <asp:BoundField DataField="FoodScheduleName" HeaderText="Food Schedule" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" ImageUrl='<%# (Eval("ProductImage") != System.DBNull.Value ? "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProductImage")) : "No Image") %>' Style="cursor: pointer" onclick="LoadDiv(this.src);" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Action" ButtonType="Button" SelectText="Update" ShowSelectButton="True" CausesValidation="False" />
            </Columns>
            <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
        </asp:GridView>
        <br/>
    </asp:Panel>

    <asp:Button ID="UpdateProductInfo" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalUpdateProduct" runat="server" TargetControlID="UpdateProductInfo" PopupControlID="pnlUpdateProduct" CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlUpdateProduct" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Product</h3>
        <hr />
        <div class="form-group">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="tablepadding">
                        <tr>
                            <td class="titletd">Region</td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlRegion" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>First Category</td>
                            <td>
                                <asp:DropDownList ID="ddlFirstCategory" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlFirstCategory_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Second Category</td>
                            <td>
                                <asp:DropDownList ID="ddlSecondCategory" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlSecondCategory_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Third Category</td>
                            <td>
                                <asp:DropDownList ID="ddlThirdCategory" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlThirdCategory_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Name</td>
                            <td>
                                <asp:TextBox ID="txtUpdateProductName" ClientIDMode="Static" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                
                                <div id="divOutput"></div>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtUpdateProductName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="txtUpdateProductName" runat="server" ErrorMessage="Invalid Product Name" ValidationExpression="^((?!--Select--).)*$" ForeColor="#cc3300"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Description</td>
                            <td>
                                <asp:TextBox ID="txtUpdateProductDescription" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Image</td>
                            <td>
                                <asp:FileUpload ID="flUpdateProductImage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Brand</td>
                            <td>
                                <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Measurement</td>
                            <td>
                                <asp:DropDownList ID="ddlMeasurement" CssClass="form-control" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Stock</td>
                            <td>
                                <asp:TextBox ID="txtProductStock" CssClass="form-control" runat="server" Placeholder="0.00" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Sell Price</td>
                            <td>
                                <asp:TextBox ID="txtSellPrice" CssClass="form-control" runat="server" Placeholder="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSellPrice" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Vat(%)</td>
                            <td>
                                <asp:TextBox ID="txtUpdateVat" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUpdateVat" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Food Schedule</td>
                            <td>
                                <asp:DropDownList ID="ddlFoodSchedule" CssClass="form-control" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Status</td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlUpdateProductStatus" CssClass="form-control">
                                    <asp:ListItem Text="Active" Value="True" />
                                    <asp:ListItem Text="Inactive" Value="False" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnUpdateProduct" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdateProduct_OnClick" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_OnClick" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnCancel" />
                    <asp:PostBackTrigger ControlID="btnUpdateProduct" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </asp:Panel>

    <div id="divBackground" class="modal">
    </div>
    <div id="divImage" class="fade-in">
        <table style="height: 100%; width: 100%">
            <tr>
                <td valign="middle" align="center">
                    <img id="imgLoader" alt="" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProductImage")) %>' />
                    <img id="imgFull" alt="" src="" style="display: none; height: 600px; width: 690px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <input id="btnClose" type="button" class="btn btn-warning" value="Close" onclick="HideDiv()" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
