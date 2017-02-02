<%@ Page Title="" Language="C#" MasterPageFile="~/Rms.Master" AutoEventWireup="true" CodeBehind="CreateFoodSchedule.aspx.cs" Inherits="RMS.UI.Item.CreateFoodSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Created By Ataur--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tablepadding">
        <tr>
            <td class="titletd">
                <label for="FoodScheduleName">Name</label>
            </td>
            <td style="width: 350px;">
                <asp:TextBox ID="txtFoodScheduleName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtFoodScheduleName" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
            
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtFoodScheduleName" ValidationExpression="^[a-zA-Z-'\s]{1,}$"></asp:RegularExpressionValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="schedule name should be 4-90 character" ControlToValidate="txtFoodScheduleName" ValidationExpression="^[\s\S.]{4,90}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="titletd">
                <label for="FoodScheduleDescription">Description</label>
            </td>
            <td>
                <asp:TextBox ID="txtFoodScheduleDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtFoodScheduleDescription" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Invalid Description" ControlToValidate="txtFoodScheduleDescription" ValidationExpression="^[a-zA-Z0-9?;&quot;&quot;:#,-.()-/''-'\s]{0,}"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Description Should be 500 characters long" ControlToValidate="txtFoodScheduleDescription" ForeColor="#CC3300" ValidationExpression="^[\s\S]{1,500}"></asp:RegularExpressionValidator>


            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
