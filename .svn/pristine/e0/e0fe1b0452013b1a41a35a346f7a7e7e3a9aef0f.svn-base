 <%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="UpdateSupplier.aspx.cs" Inherits="RMS.UI.Item.UpdateSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<%--Created By Ataur--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="supplierName">Supplier</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtSupplierName" AutoPostBack="True" ClientIDMode="Static" CssClass="form-control" runat="server" PlaceHolder="Search" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <hr/>
    <asp:Panel ID="pnlDisplaySupplier" runat="server">      
        <asp:GridView ID="gvDisplaySupplier" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" DataKeyNames="SupplierId,IsActive" OnPageIndexChanging="gvDisplaySupplier_PageIndexChanging" OnSelectedIndexChanged="gvDisplaySupplier_SelectedIndexChanged" OnRowDataBound="gvDisplaySupplier_RowDataBound">
            <HeaderStyle CssClass="gvheaderstyle" />
            <RowStyle CssClass="gvrowstyle" />
            <Columns>
                <asp:BoundField DataField="SupplierId" HeaderText="Supplier Id" Visible="False"/>
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" />
                <asp:BoundField DataField="SupplierContactPerson" HeaderText="Supplier Contact Person" />
                <asp:BoundField DataField="SupplierDescription" HeaderText="Supplier Description" />
                <asp:BoundField DataField="SupplierAddress" HeaderText="Supplier Address" />
                <asp:BoundField DataField="SupplierContactNo" HeaderText="Suppplier Contact No" />
                <asp:BoundField DataField="SupplierEmail" HeaderText="Supplier Email" />
                <asp:BoundField DataField="SupplierReference" HeaderText="Supplier Reference" />
                <asp:BoundField DataField="SupplierReferenceContactNo" HeaderText="Supplier Reference Contact No" />
                <asp:BoundField DataField="IsActive" HeaderText="Supplier Status" />
                <asp:CommandField HeaderText="Action" ButtonType="Button" SelectText="Update" ShowSelectButton="True" CausesValidation="False" />
            </Columns>
            <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
    </asp:Panel>

    <asp:Button ID="UpdatSupplier" runat="server" style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalUpdateSupplier" runat="server" TargetControlID="UpdatSupplier" PopupControlID="pnlUpdateSupplier" CancelControlID="btnHide" BackgroundCssClass="tableBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlUpdateSupplier" runat="server" Style="display: none;" BackColor="White" CssClass="updatemodal fade-in fade-out">
        <div class="form-group">
             <h3>Update Supplier</h3>
            <hr/>
            <table class="tablepadding">
                <tr>
                    <td class="titletd">
                        <label for="supplierName">Name</label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtUpdateSupplierName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtUpdateSupplierName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateSupplierName" ValidationExpression="^[a-zA-Z-'\s\.]{1,100}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtUpdateSupplierName" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
               
                <tr>
                    <td>
                        <label for="supplierContactPerson">Contact Person</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierContactPerson" runat="server" CssClass="form-control"></asp:TextBox>
                  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtUpdateSupplierContactPerson" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateSupplierContactPerson" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtUpdateSupplierContactPerson" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
             
                <tr>
                    <td>
                        <label for="supplierDescription">Description</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierDescription" runat="server" Placeholder="(Optional)" CssClass="form-control"></asp:TextBox>
                                   
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateSupplierDescription" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtUpdateSupplierDescription" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
          
                <tr>
                    <td>
                        <label for="supplierAddress">Address</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUpdateSupplierAddress" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Address should be 500 characters" ControlToValidate="txtUpdateSupplierAddress" ValidationExpression="^[a-zA-Z0-9#,.-/''-'\s]{1,500}$"></asp:RegularExpressionValidator>

                    </td>
                </tr>
       
                <tr>
                    <td>
                        <label for="supplierContactNo">Contact No</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                   
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUpdateSupplierContactNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtUpdateSupplierContactNo" ValidationExpression="^[0-9''-'\d]{1,25}$"></asp:RegularExpressionValidator>

                    </td>
                </tr>
     
                <tr>
                    <td>
                        <label for="supplierEmail">Email</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierEmail" runat="server" CssClass="form-control" placeholder="(Optional)"></asp:TextBox>
                      
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUpdateSupplierEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email!" ForeColor="Red" Display="Dynamic" />

                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="supplierReferance">Reference Name</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierReference" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtUpdateSupplierReference" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtUpdateSupplierReference" ValidationExpression="^[a-zA-Z-'\s\.]{1,95}$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Must be less than 100 characters long" ControlToValidate="txtUpdateSupplierReference" ValidationExpression="^[\s\S\.]{1,100}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
 
                <tr>
                    <td>
                        <label for="supplierReferenceContactNo">Ref. Contact No</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdateSupplierReferenceContactNo" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="txtUpdateSupplierReferenceContactNo" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Invalid Phone Number!" ControlToValidate="txtUpdateSupplierReferenceContactNo" ValidationExpression="^[0-9''-'\d]{1,25}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <label for="supplierstatus">Status</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUpdateSupplierStatus" CssClass="form-control">
                            <asp:ListItem Text="Active" Value="True" />
                            <asp:ListItem Text="Inactive" Value="False" />
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdateCategory" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdateSupplier_OnClick" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnHide" CssClass="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
</asp:Content>
