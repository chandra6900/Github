<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequiredFieldValidation_File.aspx.cs" Inherits="ValidationNmsp.RequiredFieldValidationClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblFName" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vltrFName" runat="server" ErrorMessage=" Please Enter FirstName "   Text=" * " SetFocusOnError="True" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
        <asp:Label ID="lblLName" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vltrLName" runat="server" ErrorMessage=" Please Enter LastName "   Text=" * " ControlToValidate="txtLName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
        <p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>

    </div>
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="false" />
    </div>
    </form>
</body>
</html>
