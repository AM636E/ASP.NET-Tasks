<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Translator.aspx.cs" Inherits="Translator.TranslatorForm" EnableViewState="false" %>

<%
    string token = Convert.ToInt32(((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)).ToString();
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Translator</title>

   
    <style>
    <% foreach (string style in new List<string> { 
            "/Content/bootstrap.css",
            "/Resources/Css/style.css"
        })
       { %>
            @import url("<%=style%>?token=<%=Convert.ToInt32(((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)).ToString()%>");
    <% } %>
        </style>
</head>
<body>
    <form id="form1" role="form" runat="server" class="container">
        <div>
            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlRes" CssClass="hidden" />
            <div class="form-group">
                <%-- <label for="lbxCountries">Translate from:</label>--%>
                <asp:DropDownList ID="lbxCountries" runat="server" DataValueField="key" DataTextField="value" AutoPostBack="true" CssClass="form-control">
                  
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <%--<label for="lbxCountries">Translate to:</label>--%>
                <asp:DropDownList ID="lbxCountriesTo" runat="server" CssClass="form-control disabled" DataValueField="key" DataTextField="value">
                 
                </asp:DropDownList>
            </div>
            <div class="form-group button">
                <asp:Button ID="btnTranslate" runat="server" OnClick="btnTranslate_Click" Text="Translate" CssClass="btn btn-info" />
            </div>
            <div class="form-group textbox">
                <asp:TextBox ID="txtTranslate" TextMode="MultiLine" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group translate-result">
                <asp:Label ID="lblResult" runat="server" Text="Test" />
            </div>
        </div>
    </form>
    <% foreach (string script in new List<string> { 
            "/Scripts/jquery-1.9.0.js",
            "/Scripts/bootstrap.js",
            "/Resources/Js/main.js"
        })
       { %>
    <script src="<%=script%>?token=<%=token%>"></script>
    <% } %>
</body>
</html>
