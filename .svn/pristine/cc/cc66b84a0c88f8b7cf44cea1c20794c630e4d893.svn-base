<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateSupplier.aspx.cs" Inherits="RMS.UI.Item.CreateSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           
</asp:Content>

<%--Created By Ataur--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="supplierName">Name</label>
            </td>
            <td style="width: 350px">
                <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtSupplierName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtSupplierName" ValidationExpression="^[a-zA-Z-'\s\.]{1,100}$"></asp:RegularExpressionValidator>            
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtSupplierName" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="supplierContactPerson">Contact Person</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierContactPerson" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtSupplierContactPerson" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtSupplierContactPerson" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtSupplierContactPerson" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="supplierDescription">Description</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierDescription" runat="server" Placeholder="(Optional)" CssClass="form-control"></asp:TextBox>
            </td>
            <td>             
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtSupplierDescription" ValidationExpression="^[a-zA-Z-'\s\.]{1,100}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtSupplierDescription" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="supplierAddress">Address</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtSupplierAddress" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Address should be 500 characters" ControlToValidate="txtSupplierAddress" ValidationExpression="^[a-zA-Z0-9#,.-/''-'\s]{1,500}$"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td>
                <label for="  SupplierContactNo">Contact No</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierContactNo" runat="server" CssClass="form-control"></asp:TextBox>

            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtSupplierContactNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtSupplierContactNo" ValidationExpression="^[0-9''-'\d]{1,25}$"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td>
                <label for="supplierEmail">Email</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierEmail" runat="server" CssClass="form-control" placeholder="(Optional)"></asp:TextBox>

            </td>
            <td>
                
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtSupplierEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />

            </td>
        </tr>
        <tr>
            <td>
                <label for="supplierReferance">Reference</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierReference" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtSupplierReference" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtSupplierReference" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtSupplierReference" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="supplierReferenceContactNo">Ref. Contact No</label>
            </td>
            <td>
                <asp:TextBox ID="txtSupplierReferenceContactNo" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="txtSupplierReferenceContactNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtSupplierReferenceContactNo" ValidationExpression="^[0-9''-'\d]{1,25}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
