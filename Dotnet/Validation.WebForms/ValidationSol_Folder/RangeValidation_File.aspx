<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RangeValidation_File.aspx.cs" Inherits="WebApplication5.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            <asp:Label ID="lblString" runat="server" Text="Enter String"></asp:Label>
            <asp:TextBox ID="txtString" runat="server" >aaa</asp:TextBox> 
            <asp:RangeValidator ID="rgValString" runat="server" ErrorMessage="enter correct String between aaa to zzz" Text="String Range  not valied" ControlToValidate="txtString" Type="String" MaximumValue="zzz" MinimumValue="aaa" Display="Dynamic"></asp:RangeValidator>             
        </p>
        <p>
            <asp:Label ID="lblInteger" runat="server" Text="Enter Integer"></asp:Label>
            <asp:TextBox ID="txtInt" runat="server" >9000</asp:TextBox>     
            <asp:RangeValidator ID="rgValInt" runat="server" ErrorMessage="enter correct Integer between 22 to 44" Text="Integer Range  not valied" ControlToValidate="txtInt" Type="Integer" MaximumValue="44" MinimumValue="22" Display="Dynamic"></asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="lblDate" runat="server" Text="Enter Date"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" >1992/06/88</asp:TextBox>                  
            <asp:RangeValidator ID="rgValDate" runat="server" ErrorMessage="enter correct Date between 1992/06/16 to 2018/01/25" Text="Date Range  not valied" ControlToValidate="txtDate" Type="Date" MinimumValue="1992/06/16" MaximumValue="2018/01/25" Display="Dynamic"></asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="lblDouble" runat="server" Text="Enter Double"></asp:Label>
            <asp:TextBox ID="txtDouble" runat="server" >22.000007890000</asp:TextBox> 
            <asp:RangeValidator ID="rgValDouble" runat="server" ErrorMessage="enter correct Double between 22 to 44" Text="Double Range  not valied" ControlToValidate="txtDouble" Type="Double" MaximumValue="44" MinimumValue="22" Display="Dynamic"></asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="lblCurrency" runat="server" Text="Enter Currency"></asp:Label>
            <asp:TextBox ID="txtCurrency" runat="server" >22.900</asp:TextBox> 
            <asp:RangeValidator ID="rgValCurrency" runat="server" ErrorMessage="enter correct Currency between 22.10 to 44.99" Text="Currency Range  not valied" ControlToValidate="txtCurrency" Type="Currency" MaximumValue="44.99" MinimumValue="22.10" Display="Dynamic"></asp:RangeValidator>
        </p>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />        
    </div>
        <div>
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" />
        </div>
       
    </form>
</body>
</html>
