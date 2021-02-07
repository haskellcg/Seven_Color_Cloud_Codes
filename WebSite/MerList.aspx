<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MerList.aspx.cs" Inherits="MerList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
<link href="index_files/css.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="index_files/style.css">
<link id="color" rel="stylesheet" href="index_files/color1.css">
<link rel="stylesheet" type="text/css" href="index_files/jquery.css" media="screen">
<link rel="stylesheet" href="index_files/mediaelementplayer.css">
<link href="colorbox/colorbox.html" rel="stylesheet" type="text/css" media="screen">
<script src="index_files/commonutilstats.js" charset="UTF-8" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
         
      
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <asp:Repeater ID="Repeater1" runat="server">
      <HeaderTemplate>

      </HeaderTemplate>
      <ItemTemplate>
        <ul class="recipelist">     
	      <li class="clearfix">
          <div class="recipegridimage">
          <img src="<%#Eval ("mer_pic") %>" alt="" width="275" height="190">            </div>
          <div class="recipedetails">
          <a class="title" href="MerchantInfoShow.aspx?mer_id=<%#Eval ("mer_id") %>"  ><%#Eval ("mer_name") %> </a>
          <p> <%#Eval("mer_info")%></p>
          <ul class="rate">
             <li class="on"></li>             
             <li class="on"></li>
             <li class="on"></li>
             <li class="on"></li>
             <li class="off"></li>
          </ul>
          <a href="MerchantInfoShow.aspx?mer_id=<%#Eval ("mer_id") %>" class="fr">进入商家展示页面 
           &gt;&gt;</a>        </div>
          </li>
        </ul>

      </ItemTemplate>
      <FooterTemplate>

      </FooterTemplate></asp:Repeater>
          
      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
            NextPageText="下一页" LastPageText="末页" PrevPageText="上一页" 
            onpagechanging="AspNetPager1_PageChanging"  PageSize="5"></webdiyer:AspNetPager>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AspNetPager1" EventName="PageChanging" />
            </Triggers>
      </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
