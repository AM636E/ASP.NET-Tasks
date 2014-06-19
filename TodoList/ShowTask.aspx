<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowTask.aspx.cs" Inherits="TodoList.ShowTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBody" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="heading">
                <asp:Label ID="lblTaskTitle" runat="server"></asp:Label>
            </h4>
        </div>
        <div class="panel-body">
            <asp:Label ID="lblTaskBody" runat="server"></asp:Label>
        </div>
    </div>
    
</asp:Content>
