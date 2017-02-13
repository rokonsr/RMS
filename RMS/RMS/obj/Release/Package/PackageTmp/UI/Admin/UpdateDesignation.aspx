<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateDesignation.aspx.cs" Inherits="RMS.UI.Admin.UpdateDesignation" %>

<%@ MasterType VirtualPath="~/Rms.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="form-group">
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="txtDesignationSearch">Designation</label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox runat="server" ID="txtDesignationSearch" AutoPostBack="True" ClientIDMode="Static" CssClass="form-control" PlaceHolder="Search"></asp:TextBox>
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
                    <asp:GridView runat="server" ID="gvDesignation" AutoGenerateColumns="False" DataKeyNames="DesignationId" OnRowDataBound="gvDesignation_RowDataBound" OnSelectedIndexChanged="gvDesignation_SelectedIndexChanged">
                        <HeaderStyle CssClass="gvheaderstyle" />
                        <RowStyle CssClass="gvrowstyle" />
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="DesignationId" Visible="False" />
                            <asp:BoundField HeaderText="Designation" DataField="DesignationName" />
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
    <br />
    <asp:Button ID="modelPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="modelPopup" PopupControlID="pnlUpdateDes" CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUpdateDes" runat="server" Visible="False" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Designation</h3>
        <hr />
        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td>
                        <label for="designationNameEdit">Name</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtDesignationNameEdit" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" ControlToValidate="txtDesignationNameEdit" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="ddlUserStatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUserStatus" CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdateDesignation" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdateDesignation_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>
    <script>
        function UpdateStatusFadeOut(id, miliSec) {
            // alert(element);
            $("#" + id).fadeOut(miliSec);
        }
    </script>
</asp:Content>
