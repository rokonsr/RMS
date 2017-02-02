<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateMeasurement.aspx.cs" Inherits="RMS.UI.Item.UpdateMeasurement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--Create by Enamul Haque--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="MeasurementSearch">Measurement</label>
            </td>
            <td style="width: 300px;">
                <asp:TextBox runat="server" ID="txtMeasurementName" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" PlaceHolder="Search"></asp:TextBox>

            </td>
        </tr>
    </table>
    <hr />
    <table>
        <tr>
            <td style="width: 160px;"></td>
            <td>
                <asp:GridView runat="server" ID="gvMeasurement" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" DataKeyNames="MeasurementId" OnRowDataBound="gvMeasurement_OnRowDataBound" OnSelectedIndexChanged="gvMeasurement_OnSelectedIndexChanged">
                    <HeaderStyle CssClass="gvheaderstyle"></HeaderStyle>
                    <RowStyle CssClass="gvrowstyle"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="MeasurementId" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="MeasurementName" HeaderText="Measurement Name" />
                        <asp:BoundField DataField="MeasurementDescription" HeaderText="Measurement Description" />
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
    <asp:Button runat="server" ID="UpdtMeasurement" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalUpdateMeasurement" TargetControlID="UpdtMeasurement" PopupControlID="pnlUpdateMeasurement" CancelControlID="btnHide" BackgroundCssClass="tableBackground" />

    <asp:Panel runat="server" ID="pnlUpdateMeasurement" Visible="False" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Measurement</h3>
        <hr />
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="UpdateMeasurementName">Name</label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox runat="server" ID="txtUpdateMeasurementName" CssClass="form-control" ClientIDMode="Static" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUpdateMeasurementName" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>
                    <label for="UpdateMeasurementDescription">Description</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUpdateMeasurementDescription" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td>
                    <label for="UpdateStatus">Status</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlUpdateMeasurementStatus" CssClass="form-control" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnUpdateMeasurement" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdateMeasurement_OnClick" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnHide" CssClass="btn btn-danger" Text="Cancel" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
