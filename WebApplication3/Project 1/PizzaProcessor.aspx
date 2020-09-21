<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PizzaProcessor.aspx.cs" Inherits="WebApplication3.PizzaProcessor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Project 1/style/pizzaReceiptStyle.css" rel="stylesheet" runat="server" media="screen"/>
        <link href="../Content/bootstrap.min.css" rel="stylesheet" runat="server" />
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../Scripts/bootstrap.min.js"></script>
        <script src="../Scripts/popper.min.js"></script>

</head>
<body>
    <h1>Your pizza is being made as we speak, here's a summary of the perfection you're about to recieve...</h1>
    <form id="form1" runat="server">
        <div class="container container-narrow info" runat="server">
            <asp:Label ID="lblCustInfo" runat="server" Text="Label" ></asp:Label>
            <asp:Label ID="lblItems" runat="server" Text="Label" ></asp:Label>
            <asp:Label ID="lblTotal" runat="server" Text="Label" ></asp:Label>
       </div>
    </form>
</body>
</html>
