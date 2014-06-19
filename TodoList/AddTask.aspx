<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TodoList.AddTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <asp:FormView ID="addTaskFrom" runat="server"
        DataSourceID="odsTask"
        DefaultMode="Insert"
        OnItemInserted="addTaskFrom_ItemInserted"
        CssClass="container">
        <InsertItemTemplate>
            <div class="form-group">
                <label for="#txtTaskTitle">Task title</label>
                <asp:TextBox ID="txtTaskTitle" runat="server" CssClass="form-control"
                    Text='<%# Bind("Title") %>' />
            </div>
            <div class="form-group">
                <label for="#txtTaskBody">Task title</label>
                <asp:TextBox ID="txtTaskBody" runat="server" TextMode="MultiLine" Text='<%# Bind("Text") %>' CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnInsert" runat="server" CommandName="Insert" Text="Add task" CssClass="btn btn-default" />
            </div>
            <div class="form-group">   
                <label>
                    <asp:CheckBox ID="chkDeadline" runat="server" />
                </label>
                
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
