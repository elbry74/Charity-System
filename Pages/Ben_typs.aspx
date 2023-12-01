<%@ Page Title="انواع المستفيدين" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="Ben_typs.aspx.cs" Inherits="Pages_ReportAid2" %>

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
                        <title>انواع المستفيدين</title>
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

                        <h1>انواع المستفيدين</h1>
                    </body>
                    </html>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <div class="col-md-4">
                    فئة المستفيد
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="Drop_f2a" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-3">
                <div class="col-md-5">
                    نوع المستفيد
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_ben_type" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />

        <div class="row ; text-center">

            <asp:Button ID="Btn_Add" OnClick="Btn_Add_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="إضافه" />
        </div>

        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover dataTable FullWidth " AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="الرقم" DataField="Type_ID" />
                                <asp:BoundField HeaderText="نوع المستفيد" DataField="Type_Desc"></asp:BoundField>
                                <asp:BoundField HeaderText="فئة المستفيد" DataField="Category_Desc" />
                                <asp:BoundField></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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