﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CompanyDetail.aspx.cs" Inherits="RMS.UI.Admin.CompanyDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="form-group">

    <table class="tablepadding" >
           
        <tr>
            <td>
                <label for="ddlCompanyName">Company Name</label>
            </td>
            <td style="width: 350px">
                <asp:DropDownList runat="server" ID="ddlCompanyName" CssClass="form-control">
                </asp:DropDownList>
                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="ddlCompanyName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
        </tr>
    </table>
        </div>
    
     <div class="form-group">

    <table class="tablepadding" >
     

        <tr style="width: 100%">
            <td style="width: 50%">
                <div class="form-group">
                <table class="tablepadding">
                    <tr>
                        <td class="titletd">
                    <label for="companyName">Company Name</label>
                </td>
                <td style="width: 350px">                   
                    <asp:TextBox ID="txtUpdateCompanyName" runat="server" value=" " ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                    <input  hidden=""/>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUpdateCompanyName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Company Name" ControlToValidate="txtUpdateCompanyName" ValidationExpression="^[a-zA-Z0-9\s]{0,}"></asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Company Name should be 4-150 character Long" ControlToValidate="txtUpdateCompanyName" ValidationExpression="^[\s\S]{4,20}"></asp:RegularExpressionValidator>
                </td>
                
                    </tr>
                    <tr>
                       <td>
                    <label for="companyAddress">Company Address</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateCompanyAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUpdateCompanyAddress" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Company Address" ControlToValidate="txtUpdateCompanyAddress" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ErrorMessage="Address Should be 250 characters long" ControlToValidate="txtUpdateCompanyAddress" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>
                </td>
                
                    </tr>
                    <tr>
                        <td>
                    <label for="companyPhoneNo">Company Phone No</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateCompanyPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUpdateCompanyPhoneNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtUpdateCompanyPhoneNo" ValidationExpression="^[0-9''-'\d]{1,20}$"></asp:RegularExpressionValidator>

                </td>
               
                    </tr>
                    <tr>
                        <td>
                    <label for="companyFax">Company Fax</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateCompanyFax" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUpdateCompanyFax" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Fax!" ControlToValidate="txtUpdateCompanyFax" ValidationExpression="^[0-9''-'\d]{1,20}$"></asp:RegularExpressionValidator>
                </td>
                
                    </tr>
                    <tr>
                        <td>
                    <label for="companyEmail">Company Email</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateCompanyEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUpdateCompanyEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUpdateCompanyEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />
                </td>
                
                    </tr>
                </table>
                 </div>
            </td>
            
            <td style="width: 50%">
                <div class="form-group">
                <table class="tablepadding">
                    <tr>
                <td>
                    <label for="tradeLicense">Trade License</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateTradeLicense" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtUpdateTradeLicense" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Trade License" ControlToValidate="txtUpdateTradeLicense" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Trade LIcense Should be 100 characters long" ControlToValidate="txtUpdateTradeLicense" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>
                </td>
               
               
                    </tr>
                    <tr>
                        <td>
                    <label for="tinCertificate">TIN Certificate</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateTINCertificate" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtUpdateTINCertificate" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid TIN Certificate" ControlToValidate="txtUpdateTINCertificate" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="TIN Certificate Should be 100 characters long" ControlToValidate="txtUpdateTINCertificate" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>
                </td>
                
                    </tr>
                    <tr>
                        <td>
                    <label for="bstiApproval">BSTI Approval</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateBSTIApproval" runat="server" CssClass="form-control" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="txtUpdateBSTIApproval"  ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid BSTI Approval" ControlToValidate="txtUpdateBSTIApproval" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="BSTI Approval Should be 100 characters long" ControlToValidate="txtUpdateBSTIApproval" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>
                </td>
               
                    </tr>
                    <tr>
                       <td>
                    <label for="vatRegNumber">VAT Reg Number</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateVATRegNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtUpdateVATRegNumber" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid VAT Reg Number" ControlToValidate="txtUpdateVATRegNumber" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="VAT Reg Number Should be 10 characters long" ControlToValidate="txtUpdateVATRegNumber" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>
                </td>
                
                    </tr>
                </table>
                </div>
            </td>
        </tr>
        <tr>
                <td></td>
                    <td>
                        <asp:Button ID="btnCompanyInfoUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnCompanyInfoUpdate_Click" />
                        &nbsp; &nbsp;             
                         <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" CausesValidation="False" />
                    </td>
            </tr>
    </table>
         </div>
     


</asp:Content>
