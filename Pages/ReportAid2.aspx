<%@ Page Title="تقرير المساعدات" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="ReportAid2.aspx.cs" Inherits="Pages_ReportAid2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="box">
        <div class="row">
            <div class="col-md-12">

                <div class="box-header">
                    <html>
                    <head>
                        <title>صرف المساعدات</title>
                        <style>
                            body {
                                background-color: black;
                            }

                            h1 {
                                color: black;
                            }
                        </style>
                    </head>
                    <body>

                        <h1>تقرير المساعدات</h1>
                    </body>
                    </html>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <div class="col-md-3">
                    اسم المستفيد
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddBeneficiar" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-4">
                    نوع المساعدة
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="DropAidType" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-4">
                    طريقه الدفع
                </div>
                <div class="col-md-8">

                    <asp:DropDownList ID="DropDownpayTaype" CssClass="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="col-md-4">
                <div class="col-md-3">
                    <label for="inputEmail1">الحاله</label>
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="DropDownstutes" CssClass="from-control" runat="server">
                        <asp:ListItem Selected="True" Text="الكل" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="سارية" Value="0"></asp:ListItem>
                        <asp:ListItem Text="ملغاة" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-4">
                    فئة المستفيد
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="Drop_f2a" AutoPostBack="true" OnSelectedIndexChanged="Drop_f2a_SelectedIndexChanged" CssClass="from-control " runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-3">
                <div class="col-md-5">
                    نوع المستفيد
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="Drop_ben_type" Enabled="false" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="col-md-4">
                <div class="col-md-3">
                    <label for="inputEmail1">نوع الحساب</label>
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="DropDownAcount" CssClass="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-4">
                <div class="col-md-3">
                    تاريخ البدايه
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txt_Stertdate" TextMode="Date" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-3">
                    تاريخ النهايه
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txt_Enddate" TextMode="Date" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div class="row ; text-center">

            <asp:Button ID="Btn_Print" OnClick="Btn_Print_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="طباعه" />
        </div>

        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="Server">
    <script>
        function mobiel_nom(fld, e) {

            var strCheck = ".0123456789";
            var whichCode = e.which ? e.which : e.keyCode;

            if (whichCode == 13 || whichCode == 8 || whichCode == 9) return true;
            key = String.fromCharCode(whichCode);
            if (strCheck.indexOf(key) == -1)
                return false;

            return true;
        }
    </script>
</asp:Content>