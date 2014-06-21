<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TodoList.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBody" runat="server">
    <div class="form-group">
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnRegisterUser" runat="server" Text="Register" />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
