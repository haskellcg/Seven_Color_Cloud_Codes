<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysLogin.aspx.cs" Inherits="ManaLogin_ManaLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录界面</title>
</head>
<br />
<body style="background-color:#CCCCCC">
<img src="../images/logo.gif">

<br />
<br />

<br />
<br />
    <form id="form1" runat="server">
        <div style="width:100%; height:100%" runat="server">
            <div style="width:40%; float:left; margin:50px 35% 0 35%;">
                <asp:Login ID="Sys_Login" runat="server" BackColor="#F7F6F3" 
                     BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                    DestinationPageUrl="~/OveralMana/Default.aspx" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#333333" Height="200px" onauthenticate="Sys_Login_Authenticate" 
                    Width="300px" onloginerror="Sys_Login_LoginError" 
                    onloggedin="Sys_Login_LoggedIn">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#06b7f1" Font-Bold="True" Font-Size="0.9em" 
                        ForeColor="White" />
                </asp:Login>
            </div> 
        </div>
       
    </form>
</body>
</html>
