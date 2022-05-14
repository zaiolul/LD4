<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="LD4.Form1" %>

<!DOCTYPE html>
<link href="Style1.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divStart" runat="server">
            <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            <br />
            Autorius:<br />
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Vykdyti" />
            <br />
        </div>
        <div id="divData" runat="server">
        </div>
        <div id="divResults" runat="server">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />Vietos, kurias galima lankyti savaitgaliais:savaitgaliais:<br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            Pagal autorių atrinkti paminklai:<br />
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
            <br />
            Naujausios vietovės:<br />
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
