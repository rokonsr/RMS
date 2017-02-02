<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateRole.aspx.cs" Inherits="RMS.UI.Admin.UpdateRole" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <%--Created By Ataur--%>
    <%-- Modified By Rokon --%>

    <table>
        <tr>
            <td style="width: 160px;"></td>
            <td>
                <asp:GridView ID="gvDisplayRoleInfo" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" DataKeyNames="RoleId, IsActive" OnPageIndexChanging="gvDisplayRoleInfo_PageIndexChanging" OnSelectedIndexChanged="gvDisplayRoleInfo_SelectedIndexChanged" OnRowDataBound="gvDisplayRoleInfo_RowDataBound">
                    <HeaderStyle CssClass="gvheaderstyle" />
                    <RowStyle CssClass="gvrowstyle" />
                    <Columns>
                        <asp:BoundField HeaderText="Role Name" DataField="RoleName" />
                        <asp:BoundField HeaderText="Role Status" DataField="RoleStatus" />
                        <asp:CommandField HeaderText="Action" ButtonType="Button" SelectText="Update" ShowSelectButton="True" CausesValidation="False" />
                    </Columns>
                    <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
                    <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br/>


    <asp:Button ID="modelPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="modelPopup" PopupControlID="pnlUpdateRole" CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
    </asp:ModalPopupExtender>


    <asp:Panel ID="pnlUpdateRole" runat="server" Visible="False" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Role</h3>
        <hr />
        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td style="width: 100px">
                        <label for="rolename">Name</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control"></asp:TextBox>
                       <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtRoleName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtRoleName" ValidationExpression="^[a-zA-Z-'\s]{1,}$"></asp:RegularExpressionValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Role name should be 4-80 character" ControlToValidate="txtRoleName" ValidationExpression="^[\s\S.]{4,80}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="ddluserrolelist">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserRoleList" CssClass="form-control">
                            <asp:ListItem Text="Active" Value="True" />
                            <asp:ListItem Text="Inactive" Value="False" />
                        </asp:DropDownList>                                          
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="submitbutton"></label>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>

</asp:Content>
