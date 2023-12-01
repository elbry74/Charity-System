<%@ Page Title="فئات المستفيدين" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="Ben_fe2a.aspx.cs" Inherits="Pages_ReportAid2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title" style="margin: 0">فئات المستفيدين
                    </h3>
                </div>
            </div>
        </div>
    </div>
    <div class="box-body">

        <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
            <ContentTemplate>

                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="inputemail" class="col-md-4 control-label">فئه المستفيد</label>

                            <div class="col-md-8">

                                <asp:TextBox ID="txtf2a" CssClass="form-control " runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">

                        <div class="">

                            <asp:Button ID="btnInsertAccount" OnClick="btnInsertAccount_Click" CssClass="btn btn-success" runat="server" Text="اضافه" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="row">
        <div class="col-md-12">

            <div class="box-body">

                <div class="row">

                    <div class="col-md-6">

                        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>

                                <asp:GridView ID="GridViewAccount" OnRowEditing="GridViewAccount_RowEditing" DataKeyNames="Category_ID" OnRowDeleting="GridViewAccount_RowDeleting" OnRowUpdating="GridViewAccount_RowUpdating" OnRowCancelingEdit="GridViewAccount_RowCancelingEdit" CssClass="table table-bordered table-hover  dataTable FullWidth" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField HeaderText="رقم فئه المستفيد" DataField="Category_ID" />
                                        <asp:BoundField HeaderText="فئه المستفيد" DataField="Category_Desc" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkButton2" CssClass="btn btn-primary" runat="server" CommandName="Edit">تعديل</asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" CommandName="Update">حفظ</asp:LinkButton>
                                                <%--                                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-danger" OnClientClick="return confirmOrderDel(this);return false;" CommandName="Delete">الغاء</asp:LinkButton>--%>
                                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-warning" CommandName="Cancel">رجوع</asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        var obj = { status: false, ele: null };

        function confirmOrderDel(me) {
            if (obj.status) return true;
            swal({
                title: '  تأكيد',
                text: 'هل انت متاكد من الإلغاء ؟',
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                cancelButtonText: 'رجوع',
                confirmButtonText: 'تأكيد',
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            },
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
<%--<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="Server">
</asp:Content>--%>