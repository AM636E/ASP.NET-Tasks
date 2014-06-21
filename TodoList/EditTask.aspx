<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTask.aspx.cs" Inherits="TodoList.EditTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBody" runat="server">
    <div class="form-group">
        <asp:TextBox ID="txtTaskTitle" runat="server" />
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtTaskText" runat="server" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
