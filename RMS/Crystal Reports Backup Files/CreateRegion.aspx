<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateRegion.aspx.cs" Inherits="RMS.UI.Item.CreateRegion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<%--Create by Enamul Haque--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="RegionName">Name</label>
            </td>
            <td style="width: 350px">
                <asp:TextBox runat="server" ID="txtRegionName" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRegionName" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtRegionName" ValidationExpression="^[a-zA-Z-'\s]{1,}$"></asp:RegularExpressionValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="region name should be 2-90 character" ControlToValidate="txtRegionName" ValidationExpression="^[\s\S.]{2,90}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="Region Description">Description</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtRegionDescription" TextMode="MultiLine" CssClass="form-control" ClientIDMode="Static" PlaceHolder="(Optional)"></asp:TextBox>
            </td>
            <td>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="description should be 90 characters long" ControlToValidate="txtRegionDescription" ValidationExpression="^[\s\S.]{1,90}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>                
            </td>
            <td>
                <asp:Button runat="server" ID="btnRegionSave" Text="Submit" CssClass="btn btn-primary" OnClick="btnRegionSave_OnClick"/>
            </td>
        </tr>
    </table>

  

</asp:Content>
