﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MerMessage.aspx.cs" Inherits="OveralMana_MerchantMana_MerMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
<style type="text/css" id="message1">

</style>
<style type="text/css" id="message2">
    
</style>
</head>
<body>
   <%-- <div dir="ltr">
        消息标题: <asp:TextBox ID="TitleBox" runat="server" Width="300px"></asp:TextBox>
        <br />
        消息内容：<textarea id="MsgContent" style="width:300px; height:200px;" runat="server"></textarea>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CancleBtn" runat="server" Text="取消" onclick="CancleBtn_Click" />
        <asp:Button ID="AssureBtn" runat="server" Text="确定" onclick="AssureBtn_Click" />
    </div>
    <br />
    <div>
      <asp:Repeater ID="MessageRpt" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <div style="width:80%; height:100px; border:1px">
                <h3><%# Eval("msg_title") %></h3>
                <br />
                发件人：<%# Eval("admin_name") %> 收件人：<%# Eval("mer_name") %>  消息日期：<%# Eval("msg_time") %>
                <br />
                <%# Eval("msg_cont") %>
            </div>
            <br />
            <br />
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    </div>--%>
    <form id="form2" runat="server">
    <div style="width:80%; padding:0 0 0 15%;">
        <div dir="ltr">
             消息标题：<asp:TextBox ID="TitleBox" runat="server" Width="294px"></asp:TextBox>
            <br />
             消息内容：<textarea id="MsgContent" style="width:300px; height:200px;" runat="server" 
                cols="20" name="S1" rows="1"></textarea>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CancleBtn" runat="server" Text="取消" onclick="CancleBtn_Click" />
            <asp:Button ID="AssureBtn" runat="server" Text="确定" onclick="AssureBtn_Click" />
        </div>
        <br />
        <asp:Repeater ID="MessageRpt" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <div style="width:80%; border:1px; float:left;">
                <h3><%# Eval("msg_title") %></h3>
                <br />
                发件人：<%# Eval("admin_name") %> 收件人：<%# Eval("mer_name") %>  消息日期：<%# Eval("msg_time") %>
                <br />
                <%# Eval("msg_cont") %>
            </div>
            <div style="clear:both;"></div>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    </div>
    </form>
</body>
</html>
