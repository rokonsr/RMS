<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="RMS.UI.Item.CreateCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group">
        <table>
            <tr>
                <td width="180px">
                    <label for="ddldropdown">Select Category Type</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategoryType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryType_SelectedIndexChanged">
                        <asp:ListItem Text="--Select Type--" Value="0" />
                        <asp:ListItem Text="New Category" Value="1" />
                        <asp:ListItem Text="Sub Category" Value="2" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    
    <asp:Panel ID="pnlSubCategory" Visible="False" runat="server">
        <hr/>
        <table>
            <tr>
                <td width="180px">Select Category</td>
                <td>
                    <asp:DropDownList ID="ddlFirstCategory" AutoPostBack="True" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlFirstCategory_OnSelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="padding-left: 35px;">
                    <asp:DropDownList ID="ddlSecondCategory" AutoPostBack="True" CssClass="form-control" runat="server" Visible="False" OnSelectedIndexChanged="ddlSecondCategory_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="padding-left: 35px;">
                    <asp:DropDownList ID="ddlThirdCategory" AutoPostBack="True" CssClass="form-control" runat="server" Visible="False" OnSelectedIndexChanged="ddlThirdCategory_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
    
    <asp:Panel ID="pnlCreateCategory" Visible="False" runat="server">
        <hr />
        <div class="form-group">
            <table>
                <tr>
                    <td width="180px">
                        <label for="categoryname">Category Name</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryName" ClientIDMode="Static" CssClass="form-control" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>    
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCategoryName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="category name should be 2-80 character Long" ControlToValidate="txtCategoryName" ValidationExpression="^[a-zA-Z0-9-'\s]{2,80}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <label for="categorydescription">Description</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryDescription" CssClass="form-control" runat="server" MaxLength="450" Rows="3" TextMode="MultiLine" Placeholder="(Optional)"></asp:TextBox>
                    </td>
                    <td>    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="category name should be 2-400 character Long" ControlToValidate="txtCategoryDescription" ValidationExpression="^[a-zA-Z0-9-'\s]{2,400}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAddFirstCategory" Visible="False" CssClass="btn btn-primary" runat="server" Text="First Category" OnClick="btnAddFirstCategory_Click" />
                        <asp:Button ID="btnAddSecondCategory" Visible="False" CssClass="btn btn-primary" runat="server" Text="Second Category" OnClick="btnAddSecondCategory_Click" />
                        <asp:Button ID="btnAddThirdCategory" Visible="False" CssClass="btn btn-primary" runat="server" Text="Third Category" OnClick="btnAddThirdCategory_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
