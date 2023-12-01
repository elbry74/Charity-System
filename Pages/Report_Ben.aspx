<%@ Page Title="تقرير المستفيدين" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="Report_Ben.aspx.cs" Inherits="Pages_ReportAid2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="box">

        <br />

        <div class="row ; text-center">
            <h3>انواع المستفيدين </h3>
        </div>
        <br />

        <div class="row">
            <div class="col-md-3">
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