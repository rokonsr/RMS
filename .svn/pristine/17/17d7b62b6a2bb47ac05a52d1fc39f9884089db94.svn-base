<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateBrand.aspx.cs" Inherits="RMS.UI.Item.UpdateBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="BrandSearch">Brand</label>
            </td>
            <td style="width: 300px;">
                <asp:TextBox runat="server" ID="txtBrandName" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" PlaceHolder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>
    <hr />
    <table>
        <tr>
              <td style="width: 160px;"></td>
            <td>
                <asp:GridView runat="server" ID="gvBrand" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" DataKeyNames="BrandId" OnRowDataBound="gvBrand_OnRowDataBound" OnSelectedIndexChanged="gvBrand_OnSelectedIndexChanged">
                    <HeaderStyle CssClass="gvheaderstyle"></HeaderStyle>
                    <RowStyle CssClass="gvrowstyle"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="BrandId" HeaderText=" Brand Id" Visible="False" />
                        <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                        <asp:BoundField DataField="BrandDescription" HeaderText="Brand Description" />
                        <asp:BoundField DataField="IsActive" HeaderText="Status" />
                        <asp:CommandField HeaderText="Action" ShowSelectButton="True" ButtonType="Button" SelectText="Update" CausesValidation="False" />
                    </Columns>
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" NextPageText="Next" LastPageText="Last" PreviousPageText="Previous"></PagerSettings>
                    <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br/>
    <asp:Label runat="server" ID="lblUpdateStatus" Text=""></asp:Label>
    <asp:Button runat="server" ID="UpdtBrand" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalUpdateBrand" TargetControlID="UpdtBrand" PopupControlID="pnlUpdateBrand" CancelControlID="btnHide" BackgroundCssClass="tableBackground" />
    <asp:Panel runat="server" ID="pnlUpdateBrand" Visible="False" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Brand</h3>
        <hr />
        <table class="tablepadding">
            <tr>
                <td class="titletd">
                    <label for="UpdateBrandName">Name</label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox runat="server" ID="txtUpdateBrandName" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUpdateBrandName" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>              
                </td>
            </tr>
            <tr>
                <td>
                    <label for="UpdateBrandDescription">Description</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUpdateBrandDescription" Placeholder="(Optional)" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
                    <label for="UpdateStatus">Status</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlUpdateBrandStatus" CssClass="form-control"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnUpdateBrand" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdateBrand_OnClick" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnHide" CssClass="btn btn-danger" Text="Cancel" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
