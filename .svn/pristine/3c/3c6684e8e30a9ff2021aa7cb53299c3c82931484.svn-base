<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="RMS.UI.Item.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="productname">Product Category</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtProductCategorySearch" ClientIDMode="Static" CssClass="form-control" runat="server" Placeholder="Search"></asp:TextBox>
            </td>
            <td></td>
            <td class="titletd">
                <label for="stockQuantity">Stock Quantity</label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtStockQuantitySearch" ClientIDMode="Static" CssClass="form-control" runat="server" Placeholder="Search"></asp:TextBox>
            </td>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_OnClick"/>
            </td>
        </tr>
        

    </table>
    <br />
    <asp:Panel ID="pnlDisplayProductStock" runat="server">
        <hr />
        <asp:GridView ID="gvDisplayProductStock" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" EnableViewState="False" OnPageIndexChanging="gvDisplayProduct_PageIndexChanging">
            <HeaderStyle CssClass="gvheaderstyle" />
            <RowStyle CssClass="gvrowstyle" />
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="FirstCategory" HeaderText="First Category" />
                <asp:BoundField DataField="SecondCategory" HeaderText="Second Category" />
                <asp:BoundField DataField="ThirdCategory" HeaderText="Third Category" />
                <asp:BoundField DataField="ProductStock" HeaderText="Stock"/>
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
            <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
        </asp:GridView>
        <br/>
    </asp:Panel>
    
    
    
    
    

</asp:Content>
