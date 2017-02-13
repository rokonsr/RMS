<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateRegion.aspx.cs" Inherits="RMS.UI.Item.UpdateRegion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--created by enamul haque--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="RegionSearch">Region</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox runat="server" ID="txtRegionName" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" Placeholder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>
    <hr />
    <table>
        <tr>
            <td style="width: 160px;"></td>
            <td>
                <asp:GridView runat="server" ID="gvRegion" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" DataKeyNames="RegionId" OnRowDataBound="gvRegion_OnRowDataBound" OnSelectedIndexChanged="gvRegion_OnSelectedIndexChanged">
                    <HeaderStyle CssClass="gvheaderstyle"></HeaderStyle>
                    <RowStyle CssClass="gvrowstyle"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="RegionId" HeaderText=" Region Id" Visible="False" />
                        <asp:BoundField DataField="RegionName" HeaderText="Region Name" />
                        <asp:BoundField DataField="RegionDescription" HeaderText="Region Description" />
                        <asp:BoundField DataField="IsActive" HeaderText="Status" />
                        <asp:CommandField HeaderText="Action" ShowSelectButton="True" ButtonType="Button" SelectText="Update" CausesValidation="False" />
                    </Columns>
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" NextPageText="Next" LastPageText="Last" PreviousPageText="Previous"></PagerSettings>
                    <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label runat="server" ID="lblUpdateStatus" Text=""></asp:Label>
    <asp:Button runat="server" ID="UpdtRegion" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalUpdateRegion" TargetControlID="UpdtRegion" PopupControlID="pnlUpdateRegion" CancelControlID="btnHide" BackgroundCssClass="tableBackground" />

    <asp:Panel runat="server" ID="pnlUpdateRegion" Visible="False" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Region</h3>
        <hr />
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="UpdateRegionName">Name</label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox runat="server" ID="txtUpdateRegionName" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUpdateRegionName" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateRegionName" ValidationExpression="^[a-zA-Z-'\s]{1,}$"></asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="region name should be 2-90 character" ControlToValidate="txtUpdateRegionName" ValidationExpression="^[\s\S.]{2,90}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="UpdateRegionDescription">Description</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUpdateRegionDescription" Placeholder="(Optional)" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="description should be 90 characters long" ControlToValidate="txtUpdateRegionDescription" ValidationExpression="^[\s\S.]{1,90}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="UpdateStatus">Status</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlUpdateRegionStatus" CssClass="form-control" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnUpdateRegion" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdateRegion_OnClick" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnHide" CssClass="btn btn-danger" Text="Cancel" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>


</asp:Content>
