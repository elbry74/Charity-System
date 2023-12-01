<%@ Page Title="بيانات المستفيدين" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="Ben.aspx.cs" Inherits="Pages_Ben_Update" %>

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
                    <h2 class="">

                        بيانات المستفيدين
                      
                    </h2>
                </div>
                <div class="box-body">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-success" runat="server" Text="اضافه" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-hover  dataTable FullWidth" AutoGenerateColumns="false" runat="server" >
                                        <Columns>
                                            <asp:BoundField HeaderText="رقم المستفيد" ReadOnly="true" DataField="Beneficiary_No" />
                                            <asp:BoundField HeaderText="الاسم" DataField="Name" />
                                            <asp:BoundField HeaderText="رقم التليفون" DataField="Tell" />
                                            <asp:BoundField HeaderText="فعال" DataField="status_desc"></asp:BoundField>
                                            <asp:BoundField HeaderText="انواع المستفيدين" DataField="type_desc" />




                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--  <asp:Button ID="btnDelete" runat="server" Text="حذف" OnClientClick="return confirmOrderDel(this);return false;" CommandArgument='<%# Eval("Beneficiary_No") %>' CssClass="btn btn-danger" />--%>

                                                    <asp:Button ID="Button1" CssClass="btn btn-primary bg-light-blue-active" CommandArgument='<%# Eval("Beneficiary_No") %>' runat="server" Text="تفاصيل" />

<%--                                                    <asp:Button ID="Button4" CssClass="btn btn-primary bg-light-blue" OnClick="Button4_Click" runat="server" Text="صرف" />--%>
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
    <!-- Modal PopUp  -->
    <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1_BenfNo" runat="server" />
            <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="Button2" PopupControlID="Panel2" runat="server"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel2" role="document" Style="display: none" runat="server">

                <div class="modal-dialog modal-lg  fade in">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" onclick="$('#btnExit').click();" aria-label="">X</button>
                            <h4 class="modal-title" id="myModalLabel4">
                                <i class="fa fa-user"></i>
                                <asp:Literal ID="Literal4" runat="server" Text="تفاصيل"></asp:Literal>
                            </h4>
                        </div>
                        <div class=" modal-body modal-lg">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">اسم المستفيد</label>

                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtName1" CssClass="form-control " ReadOnly="true" runat="server"></asp:TextBox>


                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">رقم الموبايل </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtMobile1" CssClass="form-control " runat="server" AutoCompleteType="None" autocomplete="off"  onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">الرقم المدني </label>

                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtCivil1"  CssClass="form-control " ReadOnly="true" runat="server" AutoCompleteType="None" autocomplete="off"  onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))"   ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />

                                             

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">ملاحظات </label>


                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtinfo" CssClass="form-control " runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">انواع المستفيدين </label>

                                                        <div class="col-md-8">

                                                            <asp:DropDownList ID="DDLIST" CssClass="form-control" runat="server"></asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">

                                                        <div class="col-md-8">
                                                            <asp:Label ID="lblcheck" runat="server" Text="فعال"></asp:Label>
                                                            <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                            <br />
                                                            <br />
                                                </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" CssClass="btn btn-danger" Text="تعديل" />
                                    <asp:Button ID="btnExit" runat="server" ClientIDMode="Static" OnClick="btnExit_Click" CssClass="btn btn-danger" Text="خروج" />


                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal PopUp  -->
    <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none;"  />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" TargetControlID="Button3" PopupControlID="Panel12" runat="server"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel12" role="document" Style="display: none; z-index: 9999999999999999" runat="server">

                <div class="modal-dialog modal-lg  fade in">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" onclick="$('#btnExit').click();" aria-label="">X</button>
                         
                            <h4 class="modal-title" id="myModalLabel44">
                                <i class="fa fa-user"></i>
                                <asp:Literal ID="Literal1" runat="server" Text="اضافه"></asp:Literal>
                            </h4>
                        </div>
                        <div class=" modal-body modal-lg">
                                  <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">اسم المستفيد</label>

                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtlabelname" CssClass="form-control "  runat="server"></asp:TextBox>


                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">رقم الموبايل </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtlabelnum" CssClass="form-control " runat="server" AutoCompleteType="None" autocomplete="off"  onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">الرقم المدني </label>

                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtlabelcivil"  CssClass="form-control " runat="server" AutoCompleteType="None" autocomplete="off"  onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))"  ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />

                                             

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">ملاحظات </label>


                                                        <div class="col-md-8">

                                                            <asp:TextBox ID="txtlabelinfo" CssClass="form-control " runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="inputEmail1" class="col-md-4 control-label">انواع المستفيدين </label>

                                                        <div class="col-md-8">

                                                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">

                                                        <div class="col-md-8">
                                                            <asp:Label ID="Label1" runat="server" Text="فعال"></asp:Label>
                                                            <asp:CheckBox ID="CheckBox2" Checked="true" runat="server" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                            <br />
                                                            <br />
                                                </div>

                               <div class="modal-footer">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <asp:Button ID="btnAddSave" OnClick="btnAddSave_Click"  runat="server" CssClass="btn btn-danger" Text="حفظ" />
                                    <asp:Button ID="btnExit2" OnClick="btnExit2_Click" runat="server" ClientIDMode="Static" CssClass="btn btn-danger" Text="خروج" />


                                </ContentTemplate>

                            </asp:UpdatePanel>
                        </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>



    
    <!-- Modal PopUp  -->

    <asp:UpdatePanel runat="server" ID="UpdatePanel6" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />

            <ajaxToolkit:ModalPopupExtender ID="ModalPopup" TargetControlID="Button1" PopupControlID="Panel3" runat="server"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel3" role="document" Style="display: none; z-index: 9999999999999999" runat="server">

                <div class="modal-dialog modal-lg  fade in">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" onclick="$('#btnExit').click();" aria-label="">X</button>

                            <h4 class="modal-title" id="myModalLabel2">
                                <i class="fa fa-user"></i>
                               <%-- <asp:Literal ID="Literal1" runat="server" Text="اضافه"></asp:Literal>--%>
                            </h4>
                        </div>
                        <div class=" modal-body modal-lg">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">اسم المستفيد</label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="TextBox1" CssClass="form-control " runat="server"></asp:TextBox>


                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">نوع المساعدة </label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="Droppop" css="from-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">القيمه </label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtvalue" TextMode="Number" CssClass="form-control " runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />



                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">تاريخ المساعدة </label>


                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtlbldate" CssClass="form-control " runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">طريقه الدفع</label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtpaytype" CssClass="form-control " runat="server"></asp:TextBox>


                                        </div>

                                    </div>
                                </div>



                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-4 control-label">نوع الحساب</label>

                                        <div class="col-md-8">

                                            <asp:TextBox ID="txtaccount" CssClass="form-control " runat="server"></asp:TextBox>


                                        </div>

                                    </div>
                                </div>



                                <br />
                                <br />
                            </div>

                            <div class="modal-footer">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <asp:Button ID="Save" OnClick="Save_Click"  runat="server" CssClass="btn btn-danger " Text="حفظ" />
                                        <asp:Button ID="Button5" OnClick="btnExit2_Click" runat="server" ClientIDMode="Static" CssClass="btn btn-danger" Text="خروج" />


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
































    AutoCompleteType="None" autocomplete="off"  onselectstart="return false" ondragstart="return false" onkeypress="return(mobiel_nom(this,event))" onkeydown="(mobiel_nom(this,event))" 


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="Server">
    <script>
        function mobiel_nom(fld, e) {

            var strCheck = "0123456789";
            var whichCode = e.which ? e.which : e.keyCode;

            if (whichCode == 13 || whichCode == 8 || whichCode == 9) return true;
            key = String.fromCharCode(whichCode);
            if (strCheck.indexOf(key) == -1)
                return false;

            return true;
        }
    </script>
</asp:Content>