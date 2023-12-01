<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="OldBen.aspx.cs" Inherits="Pages_Beneficiary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" Runat="Server">
    <div class="row">
    <div class="col-md-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">

                    <span>
                        بيانات المستفدين
                    </span>
                </h3>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-12">
                         <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover  dataTable FullWidth" AutoGenerateColumns="false" runat="server">
                             <Columns>
                                   <asp:BoundField HeaderText="رقم المستفيد" DataField="Beneficiary_No" />
                                   <asp:BoundField HeaderText="الاسم" DataField="Name" />
                                   <asp:BoundField HeaderText="رقم التليفون" DataField="Tell" />
                             </Columns>
                         </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" Runat="Server">
</asp:Content>

