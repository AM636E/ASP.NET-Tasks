<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TodoList.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBody" runat="server">
    <div class="form-group">
        <label for="txtLogin">Login</label>
        <asp:TextBox runat="server" ID="txtLogin" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtLogin">Login</label>
        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" />
    </div>
     <div class="form-group">
        
        <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-default"  Text="Login"/>
    </div>
    <asp:Label ID="lblStatus" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
