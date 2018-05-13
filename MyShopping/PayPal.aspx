<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayPal.aspx.cs" Inherits="MyShopping.PayPal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="https://www.sandbox.paypal.com/us/cgi-bin/webscr" id="form1" runat="server">
        <input type="hidden" name="cmd" value="_xclick" />
        <input type="hidden" name="business" value="murale28-facilitator@gmail.com" />
        <input id="item_name" type="hidden" value="" runat="server" />
        <input id="amount" type="hidden" name="amount" value="" runat="server"/>
        <input type="hidden" name="shipping" value="3.00" />
        <input type="hidden" name="handling" value="2.00" />
        <input type="hidden" name="return" value="http://localhost:20950/PayPalTest.aspx" />
        <input type="submit" value="Buy with paypal" />
    </form>
</body>
</html>
