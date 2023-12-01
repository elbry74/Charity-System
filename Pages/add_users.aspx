<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="add_users.aspx.cs" Inherits="Pages_ReportAid2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="box">

        <br />

        <div class="row ; text-center">
            <h2>إضافه مستخدم </h2>
        </div>
        <%--        <asp:Panel runat="server" ID="test" Visible="false">

            <div class="row">
                <div class="col-md-4">
                    <div class="col-md-3">
                        اسم المستخدم
                    </div>
                    <div class="col-md-8">

                        <asp:TextBox ID="TextBox1" CssClass="form-control " AutoPostBack="true" OnTextChanged="txt_usere_TextChanged" runat="server" AutoCompleteType="None" autocomplete="off" onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="col-md-3">
                        كلمه السر
                    </div>
                    <div class="col-md-8">

                        <asp:TextBox ID="TextBox2" CssClass="form-control " runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="col-md-3">
                        تأكيد كلمه السر
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox3" CssClass="form-control " runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:Panel>--%>
        <br />
        <div class="row">

            <div class="col-md-5">
                <div class="col-md-3">
                    اسم المستخدم
                </div>
                <div class="col-md-8">

                    <asp:TextBox ID="txt_usere_id" CssClass="form-control " AutoPostBack="true" OnTextChanged="txt_usere_TextChanged" runat="server" AutoCompleteType="None" autocomplete="off" onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))"></asp:TextBox>
                </div>
            </div>
        </div>

        <br />

        <div class="row">

            <div class="col-md-5">
                <div class="col-md-3">
                    كلمه السر
                </div>
                <div class="col-md-8">

                    <asp:TextBox ID="txt_Password" CssClass="form-control " runat="server" AutoCompleteType="Disabled" autocomplete="off" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-5">
                <div class="col-md-3">
                    تأكيد كلمه السر
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txt_Confirm_Password" CssClass="form-control " AutoPostBack="true" OnTextChanged="txt_Confirm_Password_TextChanged" runat="server" AutoCompleteType="Disabled" autocomplete="off" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-5">
                <div class="col-md-2">
                    فعال
                </div>
                <div class="col-md-8">
                    <asp:CheckBox ID="Check_Status" Checked="true" runat="server" />
                </div>
            </div>

            <div class="col-md-5">
                <div class="col-md-2">
                    Admin
                </div>
                <div class="col-md-8">
                    <asp:CheckBox ID="Check_Admin" runat="server" />
                </div>
            </div>
        </div>

        <br />

        <div class="row ; text-center">
            <asp:Button ID="Btn_Print" OnClick="Btn_Print_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="Submit" />
        </div>

        <br />
        <div class="row ; text-center">
            <asp:Button ID="Btn_Exit" OnClick="Btn_Exit_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="Exit" />
        </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="Server">
    <script>
        function mobiel_nom(fld, e) {

            var strCheck = "0123456789-_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var whichCode = e.which ? e.which : e.keyCode;

            if (whichCode == 13 || whichCode == 8 || whichCode == 9) return true;
            key = String.fromCharCode(whichCode);
            if (strCheck.indexOf(key) == -1)
                return false;

            return true;
        }
    </script>
</asp:Content>