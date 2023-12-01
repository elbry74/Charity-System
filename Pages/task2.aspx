<%@ Page Title="تقرير المستفيدين" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="task2.aspx.cs" Inherits="Pages_task2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="box">
        <div class="row ; text-center" style="margin-top: 25px">
            <asp:Button ID="Btn_CSV" OnClick="Btn_export_CSV" CssClass="btn bg-light-blue-gradient" runat="server" Text="Export to CSV" />
            <asp:Button ID="Btn_TextFile" OnClick="Btn_export_TextFile" CssClass="btn bg-light-blue-gradient" runat="server" Text="Export to Text File" />
        </div>
        <div class="row ; text-center" style="margin-top: 15px">
            <asp:FileUpload ID="TxtfileUpload" runat="server" />
            <br />
            <asp:Button ID="btnTxtfileUpload" runat="server" CssClass="btn bg-light-blue-gradient" Text="Upload" OnClick="btnTxtfileUpload_Click" />
        </div>

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
                                <asp:BoundField HeaderText="رقم المستفيد" DataField="Beneficiary_No" />
                                <asp:BoundField HeaderText="نوع المساعدة" DataField="Aid_Type" />
                                <asp:BoundField HeaderText="القيمه" DataField="Amount" />
                                <asp:BoundField HeaderText="تاريخ المساعدة" DataField="Aid_Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="طريقه الدفع" DataField="Pay_type" />
                                <asp:BoundField HeaderText="ملاحظات" DataField="Remarks" />
                                <asp:BoundField HeaderText="نوع الحساب" DataField="Account_Type" />
                                <asp:BoundField HeaderText="اسم المستفيد" DataField="Username" />
                                <asp:BoundField HeaderText="تاريخ الانشاء" DataField="Create_Date" />
                                <asp:BoundField HeaderText="تاريخ اخر تحديث" DataField="Last_Update" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>