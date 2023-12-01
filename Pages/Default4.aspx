<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Pages_Default4" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }

        .auto-style2 {
            font-size: x-large;
        }

        .auto-style3 {
            font-weight: bold;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <strong>
                <asp:Button ID="btnPrint" OnClick="btnPrint_Click" runat="server" CssClass="auto-style3" Text="طباعه" />
            </strong>
            <br />
            <br />
            <strong>
                <asp:Label ID="lblNameBen" runat="server" CssClass="auto-style1" Text="اسم المستفيد"></asp:Label>
            </strong>
            <asp:DropDownList ID="DropDownName" runat="server"></asp:DropDownList>
            <br />
            <br />
            <strong>
                <asp:Label ID="lblAidType" runat="server" CssClass="auto-style1" Text="نوع المساعدة"></asp:Label>
            </strong>
            <asp:DropDownList ID="DropAidType" runat="server"></asp:DropDownList>
            <br />
            <br />
            <strong>
                <asp:Label ID="lblDate" runat="server" CssClass="auto-style1" Text="تاريخ المساعدة"></asp:Label>
            </strong>
            <asp:TextBox ID="txtlbldate" runat="server" Height="22px" TextMode="Date" Width="128px"></asp:TextBox>
            ا<strong><span class="auto-style2">الى</span></strong><asp:TextBox ID="txtDateTo" runat="server" Height="23px" TextMode="Date" Width="138px"></asp:TextBox>
            <br />
            <strong>
                <asp:Label ID="lblAidAccount" runat="server" CssClass="auto-style1" Text="نوع الحساب"></asp:Label>
            </strong>
            <asp:DropDownList ID="DropDownAcount" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblpayType" runat="server" CssClass="auto-style1" Text="طريقه الدفع"></asp:Label>
            <asp:DropDownList ID="DropDownpayTaype" runat="server"></asp:DropDownList>
            <br />
            <rsweb:ReportViewer ID="reportviewerAid" runat="server" Width="90%">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>