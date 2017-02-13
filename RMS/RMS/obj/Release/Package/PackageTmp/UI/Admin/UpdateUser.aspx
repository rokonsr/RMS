<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="RMS.UI.Admin.UpdateUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Created by Enamul--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="form-group">
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="txtUserInfoSearch">Username</label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox runat="server" ID="txtCreateUserName" AutoPostBack="True" ClientIDMode="Static" CssClass="form-control" PlaceHolder="Search"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div class="form-group">
        <table>
            <tr>
                <td style="width: 160px;"></td>
                <td>
                    <asp:GridView runat="server" ID="gvUserInfo" AutoGenerateColumns="False" DataKeyNames="UserId" OnRowDataBound="gvUserInfo_RowDataBound" OnSelectedIndexChanged="gvUserInfo_SelectedIndexChanged">
                        <HeaderStyle CssClass="gvheaderstyle" />
                        <RowStyle CssClass="gvrowstyle" />
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="UserId" Visible="False" />
                            <asp:BoundField HeaderText="Username" DataField="Username" />
                            <asp:BoundField HeaderText="Designation" DataField="DesignationName" />
                            <asp:BoundField HeaderText="Full Name" DataField="UserFullName" />
                            <asp:BoundField HeaderText="Email" DataField="UserEmail" />
                            <asp:BoundField HeaderText="Phone No" DataField="UserPhoneNo" />
                            <asp:BoundField HeaderText="Address" DataField="UserAddress" />
                            <asp:BoundField HeaderText="Status" DataField="IsActive" />
                            <asp:CommandField HeaderText="Action" ButtonType="Button" SelectText="Update" ShowSelectButton="True" CausesValidation="False" />
                        </Columns>
                        <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
                        <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="modelPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="modelPopup" PopupControlID="pnlUserInfoUpdate" CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUserInfoUpdate" runat="server" Visible="False" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update User Information</h3>
        <hr />
        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td class="titletd">
                        <label for="userNameEdit">Username</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtUserNameEdit" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUserNameEdit" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Username" ControlToValidate="txtUserNameEdit" ValidationExpression="^[a-zA-Z0-9-'\s]{1,}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Username should be 4-20 character" ControlToValidate="txtUserNameEdit" ValidationExpression="^[a-zA-Z0-9-'\s]{4,20}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="ddlUserInfoDesignation">Designation</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserInfoDesignation" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="ddlUserInfoDesignation" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="UserFullName">Full Name</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserFullName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtUserFullName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUserFullName" ValidationExpression="^[a-zA-Z-'\s\.]{1,}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Username should be 90 characters" ControlToValidate="txtUserFullName" ValidationExpression="^[\s\S]{1,90}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="userEmail">Email</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUserEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="userPhoneNo">Phone No.</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUserPhoneNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtUserPhoneNo" ValidationExpression="^[0-9''-'\d]{1,20}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="userAddress">Address</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUserAddress" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Address" ControlToValidate="txtUserAddress" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ErrorMessage="Address Should be 250 characters long" ControlToValidate="txtUserAddress" ForeColor="Red" ValidationExpression="^[\s\S]{1,250}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="userInfoStatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserInfoStatus" CssClass="form-control">
                            <asp:ListItem Text="Active" Value="True" />
                            <asp:ListItem Text="Inactive" Value="False" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUserInfoUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUserInfoUpdate_Click" />
                        &nbsp; &nbsp;             
                         <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" CausesValidation="False"/>
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>

</asp:Content>
