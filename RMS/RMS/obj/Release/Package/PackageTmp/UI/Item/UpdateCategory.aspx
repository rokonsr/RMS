<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateCategory.aspx.cs" Inherits="RMS.UI.Item.UpdateCatagory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="categoryname">Category</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtCategoryName" AutoPostBack="True" ClientIDMode="Static" CssClass="form-control" runat="server" PlaceHolder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlDisplayCategory" runat="server">
        <hr />
        <table>
            <tr>
                <td style="width: 160px;"></td>
                <td>
                    <asp:GridView ID="gvDisplayCategory" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" DataKeyNames="FirstCategoryId, SecondCategoryId, ThirdCategoryId, IsActive" OnPageIndexChanging="gvDisplayCategory_PageIndexChanging" OnSelectedIndexChanged="gvDisplayCategory_SelectedIndexChanged" OnRowDataBound="gvDisplayCategory_RowDataBound">
                        <HeaderStyle CssClass="gvheaderstyle" />
                        <RowStyle CssClass="gvrowstyle" />
                        <Columns>
                            <asp:BoundField DataField="FirstCategoryName" HeaderText="First Category" />
                            <asp:BoundField DataField="SecondCategoryName" HeaderText="Second Category" />
                            <asp:BoundField DataField="ThirdCategoryName" HeaderText="Third Category" />
                            <asp:BoundField DataField="CategoryDescription" HeaderText="Category Description" />
                            <asp:BoundField DataField="Status" HeaderText="Category Status" />
                            <asp:CommandField HeaderText="Action" ButtonType="Button" SelectText="Update" ShowSelectButton="True" CausesValidation="False" />
                        </Columns>
                        <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
                        <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <br />
    </asp:Panel>

    <asp:Button ID="UpdateCategory" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalUpdateCategory" runat="server" TargetControlID="UpdateCategory" PopupControlID="pnlUpdateCategory" CancelControlID="btnHide" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlUpdateCategory" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <h3>Update Category</h3>
        <hr />

        <div class="form-group">
            <table class="tablepadding">
                <tr>
                    <td class="titletd">
                        <label for="firstcategory">1st Category</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtFirstCategory" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtFirstCategory" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="category should be 2-80 character Long" ControlToValidate="txtFirstCategory" ValidationExpression="^[a-zA-Z0-9-'\s]{2,80}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="secondcategory">2nd Category</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecondCategory" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtSecondCategory" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="category should be 2-80 character Long" ControlToValidate="txtSecondCategory" ValidationExpression="^[a-zA-Z0-9-'\s]{2,80}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
          
                <tr>
                    <td>
                        <label for="categoryname">3rd Category</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtThirdCategory" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtThirdCategory" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="category should be 2-80 character Long" ControlToValidate="txtThirdCategory" ValidationExpression="^[a-zA-Z0-9-'\s]{2,80}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            
                <tr>
                    <td>
                        <label for="categorydescription">Description</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateCategoryDescription" CssClass="form-control" runat="server" MaxLength="450" TextMode="MultiLine"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="description should be 2-400 character Long" ControlToValidate="txtUpdateCategoryDescription" ValidationExpression="^[a-zA-Z0-9-'\s]{2,400}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="categorystatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUpdateCategoryStatus" CssClass="form-control">
                            <asp:ListItem Text="Active" Value="True" />
                            <asp:ListItem Text="Inactive" Value="False" />
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdateCategory" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdateCategory_OnClick" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnHide" CssClass="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>

</asp:Content>
