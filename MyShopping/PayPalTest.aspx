<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayPalTest.aspx.cs" Inherits="MyShopping.PayPalTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="https://www.sandbox.paypal.com/us/cgi-bin/webscr" id="form1" runat="server" method="post">
        <input type="hidden" name="cmd" value="_xclick" />
        <input type="hidden" name="business" value="murale28-facilitator@gmail.com" />
        <input id="item_name" type="hidden" value="My painting" runat="server"/>
        <input type="hidden" name="amount" value="5.00" />
        <input type="hidden" name="shipping" value="3.00" />
        <input type="hidden" name="handling" value="2.00" />
        <input type="hidden" name="return" value="http://localhost:20950/PayPalTest.aspx"/>
        <input type="submit" value="Buy with additional parameters!" />
    </form>
</body>
</html>
