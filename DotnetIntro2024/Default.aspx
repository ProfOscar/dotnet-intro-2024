<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotnetIntro2024.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h3>
        Introduzione a ASPX (Web Forms)
    </h3>
    <form id="form1" runat="server">
        <!--<div>
            UserName: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password: <input id="txtPassword" />
            <br />
            <asp:Button ID="btnInvia" runat="server" Text="INVIA" />
            <br />
            <asp:Label runat="server" Text="Label" ID="lblMessaggio"></asp:Label>
        </div>-->
        <h5>
            Filtra per classe:
            <asp:DropDownList ID="cmbClasse" runat="server" OnSelectedIndexChanged="cmbClasse_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </h5>
        <asp:GridView ID="gridStudenti" runat="server"></asp:GridView>
    </form>
</body>
</html>
