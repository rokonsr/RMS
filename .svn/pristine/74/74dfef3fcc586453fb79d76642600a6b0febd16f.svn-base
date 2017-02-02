<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateBrand.aspx.cs" Inherits="RMS.UI.Item.CreateBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<%--Created by Enamul Haque--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="BrandName">Name</label>
            </td>
            <td style="width: 350px">
                <asp:TextBox runat="server" ID="txtBrandName" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Required!" ControlToValidate="txtBrandName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="BrandDescription">Description</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBrandDescription" TextMode="MultiLine" Placeholder="(Optional)" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>                
            </td>
            <td>
                <asp:Button runat="server" ID="btnBrandSave" Text="Submit" CssClass="btn btn-primary" OnClick="btnBrandSave_OnClick"/>
            </td>
        </tr>
    </table>
</asp:Content>
