<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateDesignation.aspx.cs" Inherits="RMS.UI.Admin.CreateDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%---Created by Ataur--%>
    <%--updated by Enamul--%>

    <div class="form-group">

        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="designationNameAdd">Name</label>
                </td>
                <td style="width: 350px;">
                    <asp:TextBox ID="txtDesignationSearch" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtDesignationSearch" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtDesignationSearch" ValidationExpression="^[a-zA-Z-'\s\.]{1,}$">
                    </asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Designation name should be 2-90 character" ControlToValidate="txtDesignationSearch" ValidationExpression="^[\s\S\.]{2,90}$"></asp:RegularExpressionValidator>
                    
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
