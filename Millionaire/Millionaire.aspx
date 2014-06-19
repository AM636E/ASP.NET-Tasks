<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Millionaire.aspx.cs"
    Inherits="Millionaire.Millionaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Millionaire</title>
    <link rel="stylesheet" href="/css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblQuestionNum" runat="server" Text="" />
            </div>
            <div class="form-item">
                <asp:Label ID="lblQuestionText" runat="server" />
            </div>
            <div class="form-item">
                <asp:RadioButtonList ID="rblAnswers" runat="server" AutoPostBack="true">
                </asp:RadioButtonList>
            </div>
            <div class="form-item">
                <asp:Button ID="btnSubmit" runat="server" Text="Answer" />
            </div>
           <asp:Label ID="lblStatus" runat="server" />
        </div>
         <div class="page">
        <div>Score: <%# this.ViewState["score"] %></div>
        <div class="answers" data-from="input[type=radio]" data-text="label">
        </div>
    </div>
    <script src="/Scripts/jquery-2.1.1.js"></script>
    <script src="js/main.js"></script>
    </form>
   
</body>
</html>
