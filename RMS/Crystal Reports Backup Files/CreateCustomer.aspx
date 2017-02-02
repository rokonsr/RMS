<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateCustomer.aspx.cs" Inherits="RMS.UI.Admin.CreateCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Created By Ataur--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="customerUsername">Username</label>
                </td>
                <td style="width: 350px">
                    <asp:TextBox ID="txtCustomerUsername" runat="server" value=" " ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                    <input hidden="" />
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCustomerUsername" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid User Name" ControlToValidate="txtCustomerUsername" ValidationExpression="^[a-zA-Z0-9-'\s]{1,}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Username should be 4-100 character Long" ControlToValidate="txtCustomerUsername" ValidationExpression="^[a-zA-Z0-9-'\s]{4,100}$"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="custoterPassword">Password</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerPassword" runat="server" CssClass="form-control" value=" " TextMode="Password" ClientIDMode="Static" Style="text-indent: -99px"></asp:TextBox>

                </td>
                <td>

                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCustomerPassword" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Regex1" runat="server" Display="Dynamic" ControlToValidate="txtCustomerPassword"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="Password must contain: Minimum 6 characters, atleast 1 Alphabet and 1 Number" ForeColor="Red" />

                </td>
            </tr>
            <tr>
                <td>
                    <label for="customerConfirmPassword">Confirm Password</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCustomerConfirmPassword" Display="Dynamic" runat="server" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="txtCustomerConfirmPassword" ControlToCompare="txtCustomerPassword" ErrorMessage="Not matched!" ForeColor="Red"></asp:CompareValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="contactNo">Contact No</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerContactNo" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCustomerContactNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtCustomerContactNo" ValidationExpression="^[0-9''-'\d]{1,20}$"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="customerfullName">Full Name</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerFullName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtCustomerFullName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtCustomerFullName" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 90 characters long" ControlToValidate="txtCustomerFullName" ValidationExpression="^[\s\S\.]{1,90}$"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="customerDescription">Description</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="(Optional)"></asp:TextBox>
                </td>
                <td>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Description" ControlToValidate="txtCustomerDescription" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Description Should be 500 characters long" ControlToValidate="txtCustomerDescription" ForeColor="Red" ValidationExpression="^[\s\S]{1,500}"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <label for="customerAddress">Address</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="(Optional)"></asp:TextBox>

                </td>
                <td>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Address" ControlToValidate="txtCustomerAddress" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Address Should be 250 characters long" ControlToValidate="txtCustomerAddress" ForeColor="Red" ValidationExpression="^[\s\S]{1,500}"></asp:RegularExpressionValidator>
                </td>
            </tr>


            <tr>
                <td>
                    <label for="customerEmail">Email</label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerEmail" runat="server" CssClass="form-control" Placeholder="(Optional)"></asp:TextBox>

                </td>
                <td>
                    
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCustomerEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />

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
            $('#txtCustomerUsername').val('');
            $('#txtCustomerPassword').val('').css('text-indent', '0px');
        }, 111);
    </script>

</asp:Content>
