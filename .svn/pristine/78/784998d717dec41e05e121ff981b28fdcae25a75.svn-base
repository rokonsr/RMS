<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="RMS.UI.Admin.CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--Created by Ataur--%>
    <%--Update by Enamul--%>
    <div class="form-group">

        <table class="tablepadding" >
            <tr>
                <td class="titletd">
                    <label for="username">Username</label>
                </td>
                <td style="width: 350px">                   
                    <asp:TextBox ID="txtCreateUserName" runat="server" value=" " ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                    <input  hidden=""/>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCreateUserName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid User Name" ControlToValidate="txtCreateUserName" ValidationExpression="^[a-zA-Z0-9\s]{0,}"></asp:RegularExpressionValidator>
                    

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Username should be 4-20 character Long" ControlToValidate="txtCreateUserName" ValidationExpression="^[\s\S]{4,20}"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <label for="userpassword">Password</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCreateUserPassword" runat="server" CssClass="form-control" Value=" " TextMode="Password" ClientIDMode="Static" style="text-indent: -99px"></asp:TextBox>
                    
                </td>
                <td>

                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCreateUserPassword" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Regex1" runat="server" Display="Dynamic" ControlToValidate="txtCreateUserPassword"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="Password must contain: Minimum 6 characters, atleast 1 Alphabet and 1 Number" ForeColor="Red" />
         
                </td>
            </tr>

            <tr>
                <td>
                    <label for="confirmPassword">Confirm Password</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCreateConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCreateConfirmPassword" Display="Dynamic" runat="server" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="txtCreateConfirmPassword" ControlToCompare="txtCreateUserPassword" ErrorMessage="Not matched!" ForeColor="Red"></asp:CompareValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="designation">Designation</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                    </asp:DropDownList>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="fullName">Full Name</label>
                </td>
                <td>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtFullName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtFullName" ValidationExpression="^[a-zA-Z-'\s\.]{1,}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 90 characters long" ControlToValidate="txtFullName" ValidationExpression="^[\s\S\.]{1,90}$"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="email">Email</label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />

                </td>
            </tr>

            <tr>
                <td>
                    <label for="phoneNo">Phone No</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtPhoneNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtPhoneNo" ValidationExpression="^[0-9''-'\d]{1,20}$"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="address">Address</label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtAddress" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Address" ControlToValidate="txtAddress" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Address Should be 250 characters long" ControlToValidate="txtAddress" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>

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
    
    
    <script>
        setTimeout(function () {
            $('#txtCreateUserName').val('');
            $('#txtCreateUserPassword').val('').css('text-indent', '0px');
        },111);
        

    </script>
</asp:Content>
