<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="ediet_users.aspx.cs" Inherits="Pages_ReportAid2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="box">

        <br />

        <div class="row ; text-center">
            <h2>تعديل بيانات مستخدم </h2>
        </div>
        <br />

        <br />
        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <asp:Panel ID="Panel_grid" runat="server">
                        <div class="row">
                            <div class="row ; text-center">
                                <asp:Button ID="btn_Add_User" OnClick="btn_Add_User_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="إضافه مستخدم جديد" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-hover  dataTable FullWidth" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField HeaderText=" اسم المستخدم" ReadOnly="true" DataField="Username" />
                                    <asp:BoundField HeaderText="الحالة" DataField="Status" />
                                    <asp:BoundField HeaderText="Admin" DataField="Admin"></asp:BoundField>

                                    <asp:TemplateField>
                                        <ItemTemplate>

                                            <asp:Button ID="Button1" CssClass="btn btn-primary bg-light-blue-active" CommandArgument='<%# Eval("Username") %>' runat="server" Text="تعديل" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_data" Visible="false" runat="server">
                    <div class="row">

                        <div class="col-md-5">
                            <div class="col-md-3">
                                اسم المستخدم
                            </div>
                            <div class="col-md-8">

                                <asp:TextBox ID="txt_usere_id" CssClass="form-control " ReadOnly="true" AutoPostBack="true" OnTextChanged="txt_usere_TextChanged" runat="server" AutoCompleteType="None" autocomplete="off" onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-md-5">
                                    <div class="col-md-3">
                                        تغير كلمه السر
                                    </div>
                                    <div class="col-md-8">
                                        <asp:CheckBox ID="Check_Pass" AutoPostBack="true" OnCheckedChanged="Check_Pass_CheckedChanged" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="Panel_Pass" Visible="false" runat="server">

                                <div class="row">

                                    <div class="col-md-5">
                                        <div class="col-md-3">
                                            كلمه السر
                                        </div>
                                        <div class="col-md-8">

                                            <asp:TextBox ID="txt_Password" CssClass="form-control " runat="server" AutoCompleteType="None" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="col-md-3">
                                            تأكيد كلمه السر
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txt_Confirm_Password" CssClass="form-control " AutoPostBack="true" OnTextChanged="txt_Confirm_Password_TextChanged" runat="server" AutoCompleteType="None" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <br />

                    <div class="row">
                        <div class="col-md-5">
                            <div class="col-md-3">
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
                        <asp:Button ID="Btn_Print" OnClick="Btn_Print_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="تعديل" />
                        <asp:Button ID="btn_retern" OnClick="btn_retern_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="رجوع" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <br />
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="Server">
    <script>
        function mobiel_nom(fld, e) {

            var strCheck = "0123456789-_abcdefghijklmnopqrstuvwxyz";
            var whichCode = e.which ? e.which : e.keyCode;

            if (whichCode == 13 || whichCode == 8 || whichCode == 9) return true;
            key = String.fromCharCode(whichCode);
            if (strCheck.indexOf(key) == -1)
                return false;

            return true;
        }
    </script>
</asp:Content>