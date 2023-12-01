<%@ Page Title="كشف حساب " Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="ReportAid_Kshf.aspx.cs" Inherits="Pages_ReportAid2" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
                        <title>كشف حساب</title>
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

                        <h1>كشف حساب</h1>
                    </body>
                    </html>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <div class="col-md-4">
                    اسم المستفيد
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddBeneficiar" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <div class="col-md-4">
                    تاريخ البدايه
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txt_Stertdate" TextMode="Date" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-4">
                    تاريخ النهايه
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txt_Enddate" TextMode="Date" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
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