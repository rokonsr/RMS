<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div>
         <div class="col-sm-2 col-sm-offset-5 horizontally-center">
            <div class="form-group">
                <label for="username">Username</label>
                <asp:TextBox ID="txtUserName" runat="server" Width="220px" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Invalid User Name" ControlToValidate="txtUsername" ValidationExpression="^[a-zA-Z0-9-'\s]{1,95}$"></asp:RegularExpressionValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="#cc3300" ErrorMessage="Username should be 4-20 character Long" ControlToValidate="txtUsername" ValidationExpression="^[a-zA-Z0-9-'\s]{4,20}$"></asp:RegularExpressionValidator>
               
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="220px" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
           
                 </div>
            <div class="form-group">
                <label for="button"></label>
                <asp:Button ID="btnLogin" runat="server" Text="Login" Width="110px" CssClass="btn btn-primary" OnClick="btnLogin_Click"  CausesValidation="True"/>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
