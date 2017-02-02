<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="RMS.UI.Item.CreateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="tablepadding" width="100%">
        <tr>
            <td width="180px">Select Category</td>
            <td>
                <asp:DropDownList ID="ddlFirstCategory" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlFirstCategory_OnSelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlFirstCategory" ErrorMessage="Select Category!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
            <td style="padding-left: 35px;">
                <asp:DropDownList ID="ddlSecondCategory" AutoPostBack="True" CssClass="form-control" runat="server" Enabled="False" OnSelectedIndexChanged="ddlSecondCategory_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlSecondCategory" ErrorMessage="Select Category!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
            <td style="padding-left: 35px;">
                <asp:DropDownList ID="ddlThirdCategory" AutoPostBack="True" CssClass="form-control" runat="server" Enabled="False" OnSelectedIndexChanged="ddlThirdCategory_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlThirdCategory" ErrorMessage="Select Category!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
            <td style="padding-left: 35px;">
                <asp:DropDownList ID="ddlRegion" AutoPostBack="True" CssClass="form-control" runat="server" Enabled="False" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlRegion" ErrorMessage="Invalid Region!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <table class="tablepadding" width="100%">
        <tr>
            <td width="180px">Product Name</td>
            <td>
                <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ControlToValidate="txtProductName" ErrorMessage="Required Field!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>

            <td width="180px">Product Description</td>
            <td rowspan="2" colspan="2">
                <asp:TextBox ID="txtProductDescription" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" Placeholder="(Optional)"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Invalid Description" ControlToValidate="txtProductDescription" ValidationExpression="^[a-zA-Z0-9#,-.()-/''-'\s]{1,450}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Brand Name</td>
            <td>
                <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlBrand" ErrorMessage="Select Brand!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <table class="tablepadding" width="100%">
        <tr>
            <td width="180px">Measurement</td>
            <td>
                <asp:DropDownList ID="ddlMeasurement" CssClass="form-control" runat="server"></asp:DropDownList>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlMeasurement" ErrorMessage="Select Measurement!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
            <td>Sell Price</td>
            <td>
                <asp:TextBox ID="txtSellPrice" CssClass="form-control" runat="server" Placeholder="0.00" Width="100px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ControlToValidate="txtSellPrice" ErrorMessage="Required Field!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic" ControlToValidate="txtSellPrice" ForeColor="#cc3300" ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Only decimal allowed!"></asp:RegularExpressionValidator>
            </td>
            <td>Vat(%)</td>
            <td>
                <asp:TextBox ID="txtVatOnProduct" CssClass="form-control" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>Food Schedule</td>
            <td>
                <asp:DropDownList ID="ddlFoodSchedule" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddlFoodSchedule" ErrorMessage="Select Food Schedule!" ForeColor="#cc3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Image</td>
            <td>
                <asp:FileUpload ID="flProductImage" CssClass="btn btn-default" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCreateProduct" runat="server" CssClass="btn btn-primary" Text="Create Product" OnClick="btnCreateProduct_OnClick" />
            </td>
            <td>
                <asp:Button ID="btnResetProduct" CssClass="btn btn-danger" runat="server" Text="Reset" CausesValidation="False" OnClick="btnResetProduct_OnClick"  />
            </td>
        </tr>
    </table>

</asp:Content>
