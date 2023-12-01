<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Layout_View" %>

<!DOCTYPE dir="<%= GlobalFunction.isArabic()?"rtl":"ltr"  %>" html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div dir="<%= GlobalFunction.isArabic()?"rtl":"ltr"  %>">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
