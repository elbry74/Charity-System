<%@ Page Title="تحميل ملف الاكسيل" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="UploadExcel.aspx.cs" Inherits="Pages_UploadExcel" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="Server">

    <div>
        <div class="row text-center" style="margin-bottom: 15px">
            <div class="col-md-3">
                <asp:FileUpload ID="fileUploadFirst" runat="server" />
            </div>
            <div class="col-md-3">
                <asp:FileUpload ID="fileUploadSecond" runat="server" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnUpload" runat="server" CssClass="btn bg-light-blue-gradient" Text="Upload" OnClick="btnUpload_Click" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnExportToExcel" runat="server" Visible="false" CssClass="btn bg-light-blue-gradient" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title" style="margin: 0">بيانات ملف الاكسيل
                        </h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="box-body">
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">

                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView" CssClass="table table-bordered table-hover dataTable FullWidth " AutoGenerateColumns="false" runat="server">

                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="ID" />
                                    <asp:BoundField HeaderText="NAME" DataField="Name" />
                                    <asp:BoundField HeaderText="AGE" DataField="Age" />
                                    <asp:BoundField HeaderText="EMAIL" DataField="Email" />
                                    <asp:BoundField HeaderText="Address" DataField="Address" />
                                    <asp:BoundField HeaderText="Job" DataField="Job" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>