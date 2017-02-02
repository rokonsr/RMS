<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateRole.aspx.cs" Inherits="RMS.UI.Admin.CreateRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Created by Ataur--%>
    <%--updated by enamul--%>
    <div class="form-group">

        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="RoleName">Name</label>
                </td>
                <td style="width: 350px;">
                    <asp:TextBox ID="txtRoleName" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtRoleName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="only characters are allowed! " ControlToValidate="txtRoleName" ValidationExpression="^[a-zA-Z-'\s\.]{1,}$"></asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Role name should be 4-80 character" ControlToValidate="txtRoleName" ValidationExpression="^[\s\S.]{4,80}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>               
                <td>
                    <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
