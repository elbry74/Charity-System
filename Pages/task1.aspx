<%@ Page Title="تقرير المستفيدين" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="task1.aspx.cs" Inherits="Pages_task1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
                    نوع المستفيد
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="DropList_ben_type" CssClass="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-3">
                <div class="col-md-5">
                    نوع العمله
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="DropList_cur_type" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-3">
                <div class="col-md-5">
                    نوع الحساب
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="DropList_acc_type" css="from-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <br />

        <div class="row ; text-center">
            <asp:Button ID="Btn_Print" OnClick="Btn_Show_Click" CssClass="btn bg-light-blue-gradient" runat="server" Text="عرض" />
            <asp:Button ID="Button2" OnClick="Btn_Print_Click" Enabled="false" CssClass="btn bg-light-blue-gradient" runat="server" Text="طباعه" />
        </div>

        <br />
        <br />
        <br />
        <br />
    </div>

    <div class="box-body">
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="GridView" CssClass="table table-bordered table-hover dataTable FullWidth " AutoGenerateColumns="false" runat="server">

                            <Columns>
                                <asp:BoundField HeaderText="رقم المساعدة" DataField="Aid_No" />
                                <asp:BoundField HeaderText="اسم المستفيد" DataField="Username" />
                                <asp:BoundField HeaderText="نوع المساعدة" DataField="Aid_Desc" />
                                <asp:BoundField HeaderText="القيمه" DataField="Amount" />
                                <asp:BoundField HeaderText="تاريخ المساعدة" DataField="Aid_Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="طريقه الدفع" DataField="Pay_Desc" />
                                <asp:BoundField HeaderText="نوع الحساب" DataField="Account_Desc" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>