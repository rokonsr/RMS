<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateCustomer.aspx.cs" Inherits="RMS.UI.Admin.UpdateCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Created By Ataur--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="customerUsername">Username</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtCustomerUsername" AutoPostBack="True" ClientIDMode="Static" CssClass="form-control" runat="server" Placeholder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlDisplayCustomerInfo" runat="server">
        <hr />

        <asp:GridView ID="gvDisplayCustomerInfo" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" DataKeyNames="CustomerId,IsActive" OnPageIndexChanging="gvDisplayCustomerInfo_PageIndexChanging" OnSelectedIndexChanged="gvDisplayCustomerInfo_SelectedIndexChanged" OnRowDataBound="gvDisplayCustomerInfo_RowDataBound" OnRowCommand="gvDisplayCustomerInfo_OnRowCommand">
            <HeaderStyle CssClass="gvheaderstyle" />
            <RowStyle CssClass="gvrowstyle" />
            <Columns>
                <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" Visible="False" />
                <asp:BoundField DataField="CustomerUsername" HeaderText="Customer Username" />
                <%-- <asp:BoundField DataField="CustomerPassword" HeaderText="Customer Password" />--%>
                <asp:BoundField DataField="CustomerContactNumber" HeaderText="Customer Contact Number" />
                <asp:BoundField DataField="CustomerFullName" HeaderText="Customer FullName" />
                <asp:BoundField DataField="CustomerDescription" HeaderText="Customer Description" />
                <asp:BoundField DataField="CustomerAddress" HeaderText="Customer Address" />
                <asp:BoundField DataField="CustomerEmail" HeaderText="Customer Email" />
                <asp:BoundField DataField="IsActive" HeaderText="Customer Status" />
                <asp:CommandField HeaderText="Action" ButtonType="Button" SelectText="Update" ShowSelectButton="True" CausesValidation="False" />
                <asp:ButtonField HeaderText="Password" ButtonType="Link" Text="Change Password" CommandName="PasswordCommand" CausesValidation="False" />
            </Columns>
            <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
    </asp:Panel>

    <%--Update Customer Informations--%>

    <asp:Button ID="UpdatCustomerInfo" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalUpdateCustomerInfo" runat="server" TargetControlID="UpdatCustomerInfo" PopupControlID="pnlUpdateCustomerInfo" CancelControlID="btnCancle" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlUpdateCustomerInfo" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Customer Information</h3>
        <hr />
        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td class="titletd">
                        <label for="customerUsername">Username</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtUpdateCustomerUsername" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtUpdateCustomerUsername" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateCustomerUsername" ValidationExpression="^[a-zA-Z0-9-'\s]{1,}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtUpdateCustomerUsername" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="contactNo">Contact No</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerContactNo" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCustomerContactNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtCustomerContactNo" ValidationExpression="^[0-9''-'\d]{1,20}$"></asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="customerfullName">Full Name</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateCustomerFullName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtUpdateCustomerFullName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateCustomerFullName" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 90 characters long" ControlToValidate="txtUpdateCustomerFullName" ValidationExpression="^[\s\S\.]{1,90}$"></asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="customerDescription">Description</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateCustomerDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="(Optional)"></asp:TextBox>
                       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Description" ControlToValidate="txtUpdateCustomerDescription" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ErrorMessage="Description Should be 500 characters long" ControlToValidate="txtUpdateCustomerDescription" ForeColor="Red" ValidationExpression="^[\s\S]{1,500}"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="customerAddress">Address</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateCustomerAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="(Optional)"></asp:TextBox>
                       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Address" ControlToValidate="txtUpdateCustomerAddress" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" Display="Dynamic" ErrorMessage="Address Should be 250 characters long" ControlToValidate="txtUpdateCustomerAddress" ForeColor="Red" ValidationExpression="^[\s\S]{1,500}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="customerEmail">Email</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateCustomerEmail" runat="server" CssClass="form-control" Placeholder="(Optional)"></asp:TextBox>

                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUpdateCustomerEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="customerstatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUpdateCustomerStatus" CssClass="form-control">
                            <asp:ListItem Text="Active" Value="True" />
                            <asp:ListItem Text="Inactive" Value="False" />
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdateCustomerInfo" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdateCustomerInfo_OnClick" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancle" CssClass="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>

    <%--Customer Password Changed By Admin--%>

    <asp:Button ID="dummyButton" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderForChangepassword" runat="server" TargetControlID="dummyButton" PopupControlID="pnlForChangePassword" CancelControlID="btnCancle2" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlForChangePassword" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Change Customer Password</h3>
        <hr />
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="customerUsernameforpassword">Username</label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtGetuserNameForPasswordChange" CssClass="form-control" runat="server" Width="300px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="customerPassword">New Password</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateCustomerPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ValidationGroup="SM" ControlToValidate="txtUpdateCustomerPassword" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Regex1" runat="server" ValidationGroup="SM" Display="Dynamic" ControlToValidate="txtUpdateCustomerPassword"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="Password must contain: Minimum 6 characters, atleast 1 Alphabet and 1 Number" ForeColor="Red" />

                </td>
            </tr>

            <tr>
                <td>
                    <label for="customerConfirmPassword">Confirm Password</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateCustomerConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="SM" ControlToValidate="txtUpdateCustomerConfirmPassword" Display="Dynamic" runat="server" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="SM" Display="Dynamic" ControlToValidate="txtUpdateCustomerConfirmPassword" ControlToCompare="txtUpdateCustomerPassword" ErrorMessage="Not matched!" ForeColor="Red"></asp:CompareValidator>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnChangeCustomerPassword" ValidationGroup="SM" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnChangeCustomerPassword_OnClick" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancle2" CssClass="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" />
                </td>
            </tr>

        </table>

    </asp:Panel>

</asp:Content>
