<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="AssignRole.aspx.cs" Inherits="RMS.UI.Admin.AssignRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../Scripts/tvRoleManagement.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="form-group">
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="assignrole">Username</label>
                </td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtUserName" ClientIDMode="Static" AutoPostBack="True" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <table>
        <tr>
            <td class="titletd"></td>
            <td>
                <asp:Panel ID="pnlDisplayUser" runat="server" Style="padding: 10px;">

                    <asp:GridView ID="gvDisplayUserInfo" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvDisplayUserInfo_PageIndexChanging" OnSelectedIndexChanged="gvDisplayUserInfo_SelectedIndexChanged" DataKeyNames="UserId, RoleId" OnRowDataBound="gvDisplayUserInfo_RowDataBound">
                        <HeaderStyle CssClass="gvheaderstyle" />
                        <RowStyle CssClass="gvrowstyle" />
                        <Columns>
                            <asp:BoundField DataField="Username" HeaderText="User Name" />
                            <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
                            <asp:BoundField DataField="UserFullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="IsActive" HeaderText="User Status" />
                            <asp:BoundField DataField="HasRole" HeaderText="Has Role" />
                            <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtn" runat="server" ClientIDMode="Static" CausesValidation="False" CommandName="Select"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
                        <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                    </asp:GridView>

                </asp:Panel>
            </td>
        </tr>
    </table>


    <asp:HiddenField ID="hfLoginId" runat="server" />

    <asp:Button ID="ActiveUser" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalActiveUserStatus" runat="server" TargetControlID="ActiveUser" PopupControlID="pnlActiveUserStatus" CancelControlID="btnCancel1" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlActiveUserStatus" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Active User</h3>
        <hr />
        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td class="titletd">
                        <label for="username">Username</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtUserNameForUpdateStatus" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUserNameForUpdateStatus" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="ActiveUserStatus"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="userstatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserRoleListForUpdateStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Active" Value="True" />
                            <asp:ListItem Text="Inactive" Value="False" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdateUserStatus" runat="server" Text="Update Status" CssClass="btn btn-primary" OnClick="btnUpdateUserStatus_Click" ValidationGroup="ActiveUserStatus" />
                        <asp:Button ID="btnCancel1" runat="server" Text="Cancel" CssClass="btn btn-danger" ValidationGroup="ActiveUserStatus" />
                    </td>
                </tr>
            </table>
        </div>
        <hr />
    </asp:Panel>

    <asp:Button ID="modelPopupForAssignRole" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupForAssignRoleAndMenu" runat="server" TargetControlID="modelPopupForAssignRole" PopupControlID="pnlAssignRole" CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlAssignRole" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">

        <h3>Assign / Modify Role</h3>
        <hr />
        <div class="form-group">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table class="tablepadding">
                        <tr>
                            <td class="titletd">
                                <label for="username">Username</label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtSelectedUserName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="ddluserrolelist">Role</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserRoleList" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlUserRoleList_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                    <div style="padding: 10px 30px; max-height: 520px; overflow-y: auto;">
                        <table>
                            <tr>
                                <td style="height: 45px; width: 200px;"></td>
                                <td>
                                    <asp:TreeView ID="tvMenuRoleManagement" runat="server" ShowCheckBoxes="All"></asp:TreeView>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <table>
                        <tr style="height: 45px;">
                            <td style="width: 200px;">
                                <label for="submitbutton"></label>
                            </td>
                            <td>
                                <asp:Button ID="btnAssignRole" runat="server" Text="Assign Role" CssClass="btn btn-primary" OnClick="btnAssignRole_Click" />
                                <asp:Button ID="btnUpdateRole" runat="server" Text="Update Role" CssClass="btn btn-primary" OnClick="btnUpdateRole_Click" ValidationGroup="AssignRoleAndMenu" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnCancel" />
                    <asp:PostBackTrigger ControlID="btnAssignRole" />
                    <asp:PostBackTrigger ControlID="btnUpdateRole" />
                </Triggers>
            </asp:UpdatePanel>
            <hr />
        </div>

    </asp:Panel>

</asp:Content>
