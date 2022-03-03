<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomValidation_File.aspx.cs" Inherits="ValidationNmsp.CustomValidationClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblGoldenBox" runat="server" Text="Enter Text" AssociatedControlID="txtGoldenBox"></asp:Label>
        <asp:TextBox ID="txtGoldenBox" runat="server" AutoPostBack="False"></asp:TextBox>
        <asp:customvalidator ID="cmvaldr" runat="server" errormessage="Enter correct value" ControlToValidate="txtGoldenBox" OnServerValidate="Unnamed_ServerValidate" EnableClientScript="True" ClientValidationFunction="clientvaliedate" Text="Enter GOLD to submit"></asp:customvalidator>
        <script type="text/javascript">
            function clientvaliedate(source, arguments) {

                var tID = '<%= txtGoldenBox.ClientID %>';
                if (document.getElementById(tID).value == 'GOLD')
                    arguments.IsValid = true;
                else
                    arguments.IsValid = false;
            }
        </script>
    </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    </form>
</body>
</html>
