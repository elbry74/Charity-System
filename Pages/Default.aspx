<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/HomeMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyTitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" Runat="Server">

<button type="button" class="btn dropdown-toggle bg-gray" data-toggle="dropdown" role="button" 
    data-id="BodyContent_ddEmpNameAR" title="فادى عبدالرحمن" aria-expanded="false"><span class="filter-option pull-left">فادى عبدالرحمن</span>&nbsp;<span class="bs-caret"><span class="caret"></span></span></button>


   <div class="col-md-9">
         <asp:DropDownList onchange="syncddar()" CssClass="form-control selectpickerdefault" ID="ddEmpNameAR" runat="server"></asp:DropDownList>
                </div>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" Runat="Server">
</asp:Content>



