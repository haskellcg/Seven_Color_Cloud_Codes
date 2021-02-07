<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyWindow.aspx.cs" Inherits="BuyWindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="350px" align="center">
         <tr><td width="120px" align="right">会员ID</td><td>
             <asp:TextBox ID="TBMemID" runat="server"></asp:TextBox>
          </td></tr>
          <tr><td width="120px" align="right">密码</td><td>
             <asp:TextBox ID="TBPwd" runat="server"></asp:TextBox>
           </td></tr>
           <tr><td width="120px" align="right"></td>
               <td>
               <asp:Button ID="BntAssure" runat="server" Text="确认购买" BackColor="#009900"  
                       BorderStyle="Dotted" Height="40px" oncommand="BntAssure_Command" />
               <asp:Button ID="BntCancel" runat="server" Text="取消" Width="70px" BackColor="#009900" BorderStyle="Dotted" Height="40px"/></td></tr>
         </table>
    </div>
    
    </form>
</body>
</html>
