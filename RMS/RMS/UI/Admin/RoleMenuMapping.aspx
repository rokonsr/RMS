<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="RoleMenuMapping.aspx.cs" Inherits="RMS.UI.Admin.RoleMenuMapping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="../../Scripts/tvRoleManagement.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="form-group">
            <table>
                <tr style="height: 45px;">
                    <td style="width: 140px;">
                        <label for="ddluserrolelist">Select Role</label>
                    </td>
                    <td style="width: 300px;">
                        <asp:DropDownList ID="ddlUserRoleList" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlUserRoleList_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px;">
                        <label for="selectmenu"></label>
                    </td>
                    <td>
                        <asp:TreeView ID="tvMenuRoleManagement" runat="server" ShowCheckBoxes="All"></asp:TreeView>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 45px;">
                    <td>
                        <label for="submitbutton"></label>
                    </td>
                    <td>
                        <asp:Button ID="btnAssignMenuToRole" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnAssignMenuToRole_Click" />
                    </td>
                </tr>

            </table>
        </div>

</asp:Content>
