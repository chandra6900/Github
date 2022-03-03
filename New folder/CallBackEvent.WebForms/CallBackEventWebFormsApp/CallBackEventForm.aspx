<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallBackEventForm.aspx.cs" Inherits="CallBackEventWebFormsApp.CallBackEventForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <script type="text/javascript">
        function ClientCallbackFunction(arg, ctx)
        {
            document.all.txtDesc.value = arg;
        }
        
        function ClientErrorCallBack(arg)
        {
            alert("Error!: " + arg);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Regular Postback<br />
        <asp:DropDownList ID="ddlPostback" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPostback_SelectedIndexChanged"
            Width="117px">
            <asp:ListItem Value="0">- Select One -</asp:ListItem>
            <asp:ListItem Value="1">Item 1</asp:ListItem>
            <asp:ListItem Value="2">Item 2</asp:ListItem>
            <asp:ListItem Value="3">Item 3</asp:ListItem>
            <asp:ListItem Value="4">Item 4</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Async Callback<br />
        <asp:DropDownList ID="ddlAsync" runat="server" Width="110px" onclick="return DoTheCallback(document.all.ddlAsync.value,0);">
            <asp:ListItem Value="0">- Select One -</asp:ListItem>
            <asp:ListItem Value="1">Item 1</asp:ListItem>
            <asp:ListItem Value="2">Item 2</asp:ListItem>
            <asp:ListItem Value="3">Item 3</asp:ListItem>
            <asp:ListItem Value="4">Item 4</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        Text Description<br />
        <asp:TextBox ID="txtDesc" runat="server" Width="246px"></asp:TextBox><br />
        <br />
        <br />
        Other fields<br />
        1:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp; 2:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
