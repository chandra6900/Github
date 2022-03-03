<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegularExpressionValidator_File.aspx.cs" Inherits="ValidationNmsp.RegularExpressionValidatorClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="emailvalidator" runat="server" ErrorMessage="Enter correct Email" ControlToValidate="txtEmail" Text="Entered wrong email" ValidationExpression="[a-zA-z\d]+@[a-zA-z]+\.[a-zA-Z]+$"></asp:RegularExpressionValidator>
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
