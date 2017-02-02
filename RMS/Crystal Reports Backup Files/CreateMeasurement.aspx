<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateMeasurement.aspx.cs" Inherits="RMS.UI.Item.CreateMeasurement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<%--Created By Enamul Haque--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="MeasurementName">Name</label>
            </td>
            <td style="width: 350px;">
                <asp:TextBox runat="server" ID="txtMeasurementName" CssClass="form-control" ClientIDMode="Static"></asp:TextBox> 
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMeasurementName" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="MeasurementDescription">Description</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMeasurementDescription" TextMode="MultiLine" Placeholder="(Optional)" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnMeasurementNameSave" Text="Submit" CssClass="btn btn-primary" OnClick="btnMeasurementNameSave_Click"/>
            </td>
        </tr>
    </table>

</asp:Content>
