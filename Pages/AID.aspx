<%@ Page Title="صرف المساعدات" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="AID.aspx.cs" Inherits="Pages_AID2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <div class="box">
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

                        <h1>صرف المساعدات</h1>
                    </body>
                    </html>
                </div>
                <div class="box-body">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnAdd2" OnClick="btnAdd2_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="اضافه" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="box-body">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">

                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="GridView3" CssClass="table table-bordered table-hover dataTable FullWidth " AutoGenerateColumns="false" runat="server">

                                            <Columns>
                                                <asp:BoundField HeaderText="رقم المساعدة" ReadOnly="true" DataField="Aid_No" />
                                                <asp:BoundField HeaderText="اسم المستفيد" DataField="Name" />
                                                <asp:BoundField HeaderText="نوع المساعدة" DataField="Aid_Desc" />
                                                <asp:BoundField HeaderText="القيمه" DataField="Amount" />
                                                <asp:BoundField HeaderText="تاريخ المساعدة" DataField="Aid_Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HeaderText="طريقه الدفع" DataField="Pay_Desc" />
                                                <asp:BoundField HeaderText="نوع الحساب" DataField="Account_Desc" />

                                                <asp:TemplateField>
                                                    <ItemTemplate>

                                                        <asp:Button ID="btnDetails" CssClass="btn bg-purple-active" CommandArgument='<%# Eval("Aid_No") %>' runat="server" Text="تفاصيل" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal PopUp  -->
    <%--forADD--%>

    <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />

            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender9" TargetControlID="Button1" PopupControlID="Panel12" runat="server"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel12" role="document" Style="display: none; z-index: 9999999999999999" runat="server">

                <div class="modal-dialog modal-lg  fade in">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title"></h1>
                            <button type="button" class="close" onclick="$('#btnExitpop').click();" aria-label="">X</button>

                            <h1 class="modal-title" id="myModalLabel44">
                                <i class="fa fa-user"></i>
                                <asp:Literal ID="Literal1" runat="server" Text="اضافه"></asp:Literal>
                            </h1>
                        </div>
                        <div class=" modal-body modal-lg">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">اسم المستفيد</label>

                                        <div class="col-md-8">

                                            <asp:DropDownList onchange="syncddar()" CssClass="form-control selectpickerdefault" ID="DropDownName" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">تاريخ المساعدة </label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtlbldate" CssClass="form-control DateField  " runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">نوع المساعدة </label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="DropAidType" css="from-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">القيمه </label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtvalue" CssClass="form-control " runat="server" AutoCompleteType="None" autocomplete="off" onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">طريقه الدفع</label>

                                        <div class="col-md-8">

                                            <asp:DropDownList ID="DropDownpayTaype" CssClass="from-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                </br>
                                </br>
                                </br>
                                   </br>
                                </br>

                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">نوع الحساب</label>

                                        <div class="col-md-9">
                                            <asp:DropDownList ID="DropDownAcount" CssClass="from-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-7">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">ملاحظات </label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtNote" CssClass="form-control " runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSavepop" OnClick="btnSavepop_Click" CssClass="btn btn-success" runat="server" Text="حفظ" />
                                        <asp:Button ID="btnPrintAdd" OnClick="btnPrintAdd_Click" CssClass="btn bg-red-active" runat="server" Text="طباعه" />

                                        <asp:Button ID="btnExitpop" OnClick="btnExitpop_Click" ClientIDMode="Static" CssClass="btn bg-light-blue" runat="server" Text="خروج" />
                                        <asp:Button ID="btn_Add_new" OnClick="btn_Add_new_Click" Visible="false" ClientIDMode="Static" CssClass="btn bg-light-blue" runat="server" Text="إضافة جديد" />

                                        <%--                                        <rsweb:ReportViewer ID="ReportViewerAid" Width="90%" runat="server"></rsweb:ReportViewer>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnPrintAdd" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <br />

                            <br />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal PopUp  -->
    <%--  FORDETAILS--%>
    <asp:UpdatePanel runat="server" ID="UpdatePanel6" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1_AidNo" runat="server" />
            <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="Button2" PopupControlID="Panel6" runat="server"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel6" role="document" Style="display: none" runat="server">

                <div class="modal-dialog modal-lg  fade in">
                    <div class="modal-content">
                        <div class="modal-header">

                            <h1 class="modal-title"></h1>
                            <button type="button" class="close" onclick="$('#btnExitDetails').click();" aria-label="">X</button>
                            <h4 class="modal-title" id="myModalLabel4">
                                <i class="fa fa-user"></i>
                                <asp:Literal ID="Literal2" Text="تفاصيل" runat="server"></asp:Literal>
                            </h4>
                        </div>
                        <div class=" modal-body modal-lg">

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">اسم المستفيد</label>

                                                        <div class="col-md-6">

                                                            <asp:DropDownList onchange="syncddar()" CssClass="form-control selectpickerdefault" ID="DropNameDetails" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-5">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">تاريخ المساعدة </label>

                                                        <div class="col-md-6">

                                                            <asp:TextBox ID="txtDateAid" CssClass="form-control DateField " runat="server"></asp:TextBox>
                                                            <%--<asp:TextBox ID="TextBox1" CssClass="form-control DateField  " runat="server"></asp:TextBox>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                </br>
                                                 </br>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">نوع المساعدة </label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropAidDetails" css="from-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">القيمه </label>

                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtvalueDetails" CssClass="form-control " runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">طريقه الدفع</label>

                                                        <div class="col-md-8">

                                                            <asp:DropDownList ID="DropPayTaypeDetails" CssClass="from-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                </br>
                                                 </br>
                                                 </br>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">نوع الحساب</label>

                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropAcountTypeDetails" CssClass="from-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">ملاحظات </label>

                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtDetails" CssClass="form-control " runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            </br>
                                            </br>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="inputEmail1" class="col-md-4 control-label">اسم المستخدم</label>

                                                    <div class="col-md-8">

                                                        <asp:TextBox ID="txtusername" CssClass="form-control " runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="inputEmail1" class="col-md-4 control-label">اخر تعديل</label>

                                                    <div class="col-md-8">

                                                        <asp:TextBox ID="txtupdate" CssClass="form-control " runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="inputEmail1" class="col-md-4 control-label">تاريخ الادخال</label>

                                                    <div class="col-md-8">

                                                        <asp:TextBox ID="txtdateenter" CssClass="form-control " runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                </br>
                                </br>

                                <div class="modal-footer">

                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:Button ID="btnEdit" OnClick="btnEdit_Click2" CssClass="btn btn green-bg" runat="server" Text="تعديل" />

                                            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-danger" runat="server" Text="الغاء" />

                                            <asp:Button ID="btnprintDetails" OnClick="btnprintDetails_Click" CssClass="btn bg-blue" runat="server" Text="طباعه" />

                                            <asp:Button ID="btnExitDetails" OnClick="btnExitDetails_Click" ClientIDMode="Static" CssClass="btn bg-blue-gradient" runat="server" Text="خروج" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnprintDetails" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
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