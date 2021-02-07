<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="index" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">

<script src="index_files/html5.js"></script>
<link href="index_files/css.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="index_files/style.css"/>
<link id="color" rel="stylesheet" href="index_files/color1.css"/>
<link rel="stylesheet" type="text/css" href="index_files/jquery.css" media="screen"/>
<link rel="stylesheet" href="index_files/mediaelementplayer.css"/>
<link href="colorbox/colorbox.html" rel="stylesheet" type="text/css" media="screen" />
<script src="index_files/commonutilstats.js" charset="UTF-8" type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubContentBar" Runat="Server">

<!--Slidr Part Start-->
<section id="flexslider" class="clearfix">
  <div class="flexslider">
    <ul class="slides">
      <li>
         <img src="index_files/indexP/0.jpg" alt="" title="" width="900" height="600">
        <p class="flex-caption">五月天即将在鸟巢开演唱会<b> 值得期待</b>
        <br />
          <span class="second">
          <br>
          地点：南京路xx号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间：2013-3-20</span></p>
      </li>
      <li>
        <img src="index_files/indexP/1.jpg" alt="" title="" width="900" height="600">
        <p class="flex-caption">《非常爱》五月聚集天下有情人展开浪漫爱之旅 <b> 赶快报名哦！</b>
        <br />
          <span class="second">
          <br>
           地点：北京梧桐西道26号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间：2013-5-20</span></p>
      </li>
      <li>
        <img src="index_files/indexP/2.jpg" alt="" title="" width="900" height="600">
        <p class="flex-caption">《雅饰》四月大特惠 -<b> 全部8折特惠</b>
        <br />
          <span class="second">
          <br>
          地点：成都国贸大厦7楼雅饰装饰有限公司&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间：2013-4-1至2013-4-30</span></p>
      </li>
      <li>
        <img src="index_files/indexP/4.jpg" alt="" title="" width="900" height="600">
        <p class="flex-caption">《走走停停》旅社将在四月开张 -<b> 累了就多出去走走吧！ </b>
        <br />
          <span class="second">
          <br>
          地点：北京海淀区山阴西路26号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间：2013-4-2 </span></p>
      </li>
	  <li>
        <img src="index_files/indexP/5.jpg" alt="" title="" width="900" height="600">
        <p class="flex-caption">《食府美食》推出传统美食DIY-<b> 有木有很诱惑</b>
        <br />
          <span class="second">
          <br>
          地点：成都市梧桐西道26号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间：2013-6-2至2012-6-10</span></p>
      </li>
	  <li>
        <img src="index_files/indexP/7.jpg" alt="" title="" width="900" height="600">
        <p class="flex-caption">《暖暖》精品套房开始出售啦 -<b> 千万不要错过！</b>
        <br />
          <span class="second">
          <br>
          地点：西安市兴庆路28号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间：2013-7-20 </span></p>
      </li>
	  
    </ul>
  </div>
</section>
<!--Slidr Part End-->


<section id="maincontainer" class="container clearfix">
  <h1 class="heading1">商家<span>推荐</span>
  </h1>


  <!-- options -->
  <section id="options" class="clearfix">
    <ul id="filters" class="option-set clearfix" data-option-key="filter">


    </ul>
  </section>
  <!-- Recipea -->
   
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

           
    
        
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      
      <ContentTemplate>
 
      <asp:Repeater ID="Repeater1" runat="server">
      <HeaderTemplate>

      </HeaderTemplate>
      <ItemTemplate>
      <div style="position: relative; float:left;  height: 389px; width:300px" id="recipecontainer" class="clearfix recipecolumn3 recipesortable isotope"> 
        <ul>  
        <li style="position: absolute; left: 0px; top: 0px; -moz-transform: translate(622px, 0px);" class="element Spicy Sea-Food Snacks isotope-item">
        <a href="<%#Eval ("mer_pic") %>" class="fancyboxpopup"><img src="<%#Eval ("mer_pic") %>" alt="" width="275" height="190"><span class="view">&nbsp;</span></a>
        <div class="recipedetails">
          <a href="MerchantInfoShow.aspx?mer_id=<%#Eval ("mer_id") %>" class="title"><%#Eval ("mer_name") %> </a>
          <p><%#Eval("mer_info")%></p>
          <ul class="rate">
            <li class="on"></li>
            <li class="on"></li>
            <li class="on"></li>
            <li class="on"></li>
            <li class="off"></li>
          </ul>
        <a class="fr" href="MerchantInfoShow.aspx?mer_id=<%#Eval ("mer_id") %>">阅读更多信息 &gt;&gt;</a>        </div>
      </li>
   </ul>  
  
        </div>
      </ItemTemplate>
      <FooterTemplate>

      </FooterTemplate></asp:Repeater>


      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
            NextPageText="下一页" LastPageText="末页" PrevPageText="上一页" 
            onpagechanging="AspNetPager1_PageChanging"  PageSize="6"></webdiyer:AspNetPager>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AspNetPager1" EventName="PageChanging" />
            </Triggers>
      </asp:UpdatePanel>
 

  <!-- #container -->
  
</section>

  

    </form>

</asp:Content>

