<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateFoodSchedule.aspx.cs" Inherits="RMS.UI.Item.UpdateFoodSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Created By Ataur--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="searchFoodScheduleName">Schedule Name</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtFoodScheduleName" runat="server" ClientIDMode="Static" AutoPostBack="True" CssClass="form-control" Placeholder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>
    <hr />
    <asp:Panel ID="pnlDisplayFoodSchedule" runat="server">
        <table>
            <tr>
                <td style="width: 160px;"></td>
                <td>
                    <asp:GridView runat="server" ID="gvDisplayFoodSchedule" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" DataKeyNames="FoodScheduleId" OnRowDataBound="gvDisplayFoodSchedule_OnRowDataBound" OnSelectedIndexChanged="gvDisplayFoodSchedule_OnSelectedIndexChanged">
                        <HeaderStyle CssClass="gvheaderstyle"></HeaderStyle>
                        <RowStyle CssClass="gvrowstyle"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField="FoodScheduleId" HeaderText="FoodSchedule Id" Visible="False" />
                            <asp:BoundField DataField="FoodScheduleName" HeaderText="Schedule Name" />
                            <asp:BoundField DataField="ScheduleDescription" HeaderText="Description" />
                            <asp:BoundField DataField="IsActive" HeaderText="Status" />
                            <asp:CommandField HeaderText="Action" ShowSelectButton="True" ButtonType="Button" SelectText="Update" CausesValidation="False" />
                        </Columns>
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" NextPageText="Next" LastPageText="Last" PreviousPageText="Previous"></PagerSettings>
                        <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </asp:Panel>
    <br />
    <asp:Label runat="server" ID="lblUpdateStatus" Text=""></asp:Label>
    <asp:Button runat="server" ID="UpdtFoodSchedule" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalUpdateFoodSchedule" runat="server" TargetControlID="UpdtFoodSchedule" PopupControlID="pnlUpdateFoodSchedule" CancelControlID="btnCancel" BackgroundCssClass="tableBackground"></ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlUpdateFoodSchedule" runat="server" Visible="False" BackColor="white" CssClass="updatemodal fade-in fade-out">
        <h3>Update Food Schedule</h3>
        <hr />
        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td class="titletd">
                        <label for="FoodScheduleName">Name</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtUpdateFoodScheduleName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtUpdateFoodScheduleName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateFoodScheduleName" ValidationExpression="^[a-zA-Z-'\s]{1,}$"></asp:RegularExpressionValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="schedule name should be 4-90 character" ControlToValidate="txtUpdateFoodScheduleName" ValidationExpression="^[\s\S.]{4,90}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="FoodScheduleDescription">Description</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateFoodScheduleDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUpdateFoodScheduleDescription" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid description" ControlToValidate="txtUpdateFoodScheduleDescription" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" Display="Dynamic" ErrorMessage="Description Should be 250 characters long" ControlToValidate="txtUpdateFoodScheduleDescription" ForeColor="Red" ValidationExpression="^[\s\S]{1,500}"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="UpdateStatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUpdateFoodScheduleStatus" runat="server" CssClass="form-control" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdateFoodSchedule" runat="server" CssClass="btn btn-primary" OnClick="btnUpdateFoodSchedule_OnClick" Text="Update" />
                        &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
