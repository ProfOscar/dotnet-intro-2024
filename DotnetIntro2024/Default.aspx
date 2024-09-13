<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotnetIntro2024.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <% Response.Write("Introduzione a ASPX (Web Forms)"); %>
            </h3>
            UserName: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password: <input id="txtPassword" />
            <br />
            <asp:Button ID="btnInvia" runat="server" Text="INVIA" />
            <br />

        </div>
        <asp:Label runat="server" Text="Label" ID="lblMessaggio"></asp:Label>
    </form>
</body>
</html>
