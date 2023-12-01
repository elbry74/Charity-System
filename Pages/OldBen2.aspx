<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="OldBen2.aspx.cs" Inherits="Pages_Ben2" %>
<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">


    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">
                        <span>اضافه مستفيد
                        </span>
                    </h3>
                </div>

                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="inputEmail1" class="col-md-4 control-label">اسم المستفيد</label>
                                                <div class="col-md-8">

                                                    <asp:TextBox ID="txtName1" CssClass="form-control " runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="inputEmail1" class="col-md-4 control-label">رقم الموبايل </label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtMobile1" CssClass="form-control " runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="inputEmail1" class="col-md-4 control-label">الرقم المدني </label>

                                                <div class="col-md-8">

                                                    <asp:TextBox ID="txtCivil1" CssClass="form-control " runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <br />

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

                                                        <asp:DropDownList ID="DDLIST" CssClass="form-control"  runat="server" ></asp:DropDownList>

                                                        </div>
                                                </div>
                                            </div>
                                        
<%--
                                        <div class="col-md-4"> 6
                                            <div class="form-group">
                                                 <asp:Label ID="lbldrop" runat="server" Text="انواع المستفيدين"  />
                                                   <div class="col-md-8">
                                                       <asp:DropDownList ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList>
                                               


                                                    </div>
                                                </div>
                                            </div>--%>
                                       
                                        <div class="col-md-4">
                                            <div class="form-group">
                                              
                                                  <div class="col-md-8">
                                                        <asp:Label ID="lblcheck" runat="server" Text="فعال"></asp:Label>
                                                <asp:CheckBox ID="CheckBox1" Checked="true"  runat="server" />


                                        <br/>
                                        <br/>
                                                    <div class="row">
                                                        <div class="">
                                                            <asp:Button ID="btnInsert" OnClick="btnInsert_Click" CssClass="btn btn-success" runat="server" ValidationGroup="grInsert" Text="اضافه" />
                                                             <!-- Modal PopUp  -->
 


                                                        </div>
                                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>










                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">

                        <span>بيانات المستفدين
                        </span>
                    </h3>
                </div>
                <div class="box-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridView1" OnRowEditing="GridView1_RowEditing" DataKeyNames="Beneficiary_No" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" CssClass="table table-bordered table-hover  dataTable FullWidth" AutoGenerateColumns="false"  runat="server">
                                        <Columns>
                                            <asp:BoundField HeaderText="رقم المستفيد" ReadOnly="true" DataField="Beneficiary_No" />
                                            <asp:BoundField HeaderText="الاسم" DataField="Name" />
                                            <asp:BoundField HeaderText="رقم التليفون" DataField="Tell" />
                                            <asp:BoundField HeaderText="فعال" DataField="status_desc" ></asp:BoundField>
                                            <asp:BoundField HeaderText="انواع المستفيدين" DataField="type_desc" />




                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--  <asp:Button ID="btnDelete" runat="server" Text="حذف" OnClientClick="return confirmOrderDel(this);return false;" CommandArgument='<%# Eval("Beneficiary_No") %>' CssClass="btn btn-danger" />--%>

                                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" CommandName="Edit">تعديل</asp:LinkButton>
                                                </ItemTemplate>

                                                <EditItemTemplate>

                                                    


                                                  

                                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-success" CommandName="Update">حفظ</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger" OnClientClick="return confirmOrderDel(this);return false;" CommandName="Delete">الغاء</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-warning" CommandName="Cancel">رجوع</asp:LinkButton>
                                                </EditItemTemplate>
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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="Server">
    <script>
        var obj = { status: false, ele: null };

        function confirmOrderDel(me) {
            if (obj.status) return true;
            swal({
                title: 'تأكيد',
                text: 'هل انت متاكد من الإلغاء ؟',
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: 'تاكيد',
                cancelButtonText: 'رجوع',
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            }
                function () {
                    obj.status = true;
                    obj.ele = me;
                    obj.ele.click();
                    obj.status = false;
                    obj.ele = null;
                }
            );
            obj.status = false;
            obj.ele = null;
            return false;
        }


    </script>
</asp:Content>

