<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MessageBox.aspx.cs" Inherits="MerchantManage_MessageMana_MessageBox" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
<form id="form1" runat="server">
<br /><br /><br /><br /><br /><br />
    <div style=" margin-top:-150px;">
<section id="maincontainer" class="container clearfix">   
<%--<h1 class="heading1" style=" width:100%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;未读<span>消息</span> </h1>--%>

<!--左侧-->
<section class="mb20 leftpart" style=" width:90%;">
     <div style=" margin-left:0px;">
     
     <ul class="recipelist">
        
        <asp:Repeater ID="RepeaterMsg" runat="server">
         <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
        
         <li class="clearfix" style="height:auto; background-color:#E9EEF2;">
         <div class="recipedetails">
            <table align="left" width ="100%" style=" margin-left:-100px;">
            <tr><td width="20%" align="right">发送人</td><td width="8px"></td><td width="75%"><%#Eval("admin_name")%></td></tr>
            <tr><td width="20%" align="right">标题</td><td width="8px"></td><td><%#Eval("msg_title")%></td></tr>
            <tr><td width="20%" align="right">内容</td><td width="8px"></td><td><%#Eval("msg_cont")%></td></tr>
            <tr><td width="20%" align="right">时间</td><td width="8px"></td><td><%#Eval("msg_time")%></td></tr>
            <tr><td height="20px"></td>
            </tr></table>
          
		  </div>
      </li>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
        </asp:Repeater>
      </ul>
      </div>
      </section>  
    </div>
    </form>
</asp:Content>

