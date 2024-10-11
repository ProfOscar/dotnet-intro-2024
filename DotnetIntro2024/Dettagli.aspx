<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dettagli.aspx.cs" Inherits="DotnetIntro2024.Dettagli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Dettagli Studente</title>
</head>
<body>
    <h1>Dettagli Studente</h1>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlDatiStudente" runat="server" Visible="true">
            Nome: <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
            <br />
            Cognome: <asp:Label ID="lblCognome" runat="server" Text=""></asp:Label>
            <br />
            Genere: <asp:Label ID="lblGenere" runat="server" Text=""></asp:Label>
            <br />
            Classe: <asp:Label ID="lblClasse" runat="server" Text=""></asp:Label>
            <br />
            Leva: <asp:Label ID="lblAnnoNascita" runat="server" Text=""></asp:Label>
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlNonTrovato" runat="server" Visible="false">
            <h5>STUDENTE NON TROVATO</h5>
        </asp:Panel>
        <asp:Panel ID="pnlPrevNext" runat="server" Visible="false">
            <asp:Button ID="btnPrev" runat="server" Text="<<" OnClick="btnPrev_Click" Enabled="false" />
            <asp:Button ID="btnNext" runat="server" Text=">>" OnClick="btnNext_Click" CausesValidation="false" />
        </asp:Panel>
        <p>
            <asp:Button ID="btnHome" runat="server" Text="HOMEPAGE" OnClick="btnHome_Click" />
        </p>
    </form>
</body>
</html>
