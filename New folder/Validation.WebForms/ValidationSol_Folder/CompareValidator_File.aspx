<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompareValidator_File.aspx.cs" Inherits="ValidationNmsp.CompareValidatorClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <h1>Change Password.....</h1>
        <p>
            <asp:Label ID="lblNewPwd" runat="server" Text="Enter New Password"></asp:Label>
            <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" CssClass="usrBox"></asp:TextBox>     
            <asp:CompareValidator ID="cmpVal" runat="server" ControlToValidate="txtNewPwd" ControlToCompare="txtReNewPwd" ErrorMessage="CompareValidator" EnableClientScript="True"></asp:CompareValidator>
            </p>
        <p>
            <asp:Label ID="lblReNewPwd" runat="server" Text="Re-Enter New Password"></asp:Label>
            <asp:TextBox ID="txtReNewPwd" runat="server" TextMode="Password" ReadOnly="True" CssClass="usrBox"></asp:TextBox>     
        </p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </form>
</body>
</html>
