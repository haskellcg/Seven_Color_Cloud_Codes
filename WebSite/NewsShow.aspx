<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="NewsShow.aspx.cs" Inherits="NewsShow" Title="联盟新闻" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentBar" Runat="Server">

<section id="maincontainer" class="container clearfix">
  <h1 class="heading1">联盟<span>新闻</span>
  </h1>
  <!-- options -->
  <section id="options" class="clearfix">
    <ul id="filters" class="option-set clearfix" data-option-key="filter">
        <li><a class="" href="#filter" data-option-value=".Sea-Food">新闻展示</a></li>
    </ul>
  </section>
  <!-- Recipea -->
  <div style="position: relative; overflow: hidden; height: 389px;" id="recipecontainer" class="clearfix recipecolumn3 recipesortable isotope">
    <ul>
      <li style="position: absolute; left: 0px; top: 0px; -moz-transform: translate(0px, 0px) scale(1); opacity: 1;" class="element Cocktails Sea-Food Snacks isotope-item">
        <a href="UpFiles/2013/3/7/20131007031023.jpg" class="fancyboxpopup"><img src="UpFiles/2013/3/7/20131007031023.jpg" alt="" width="275" height="190"><span class="view">&nbsp;</span></a>
        <div class="recipedetails">
          <a class="title">神奇的万有引力</a>
          <p> 科学的力量神马的</p>
        <a class="fr" href="NewsList.aspx">阅读更多新闻&gt;&gt;</a>        </div>
      </li>
      
      <li style="position: absolute; left: 0px; top: 0px; -moz-transform: translate(0px, 0px) scale(1); opacity: 1;" class="element Cocktails Sea-Food Snacks isotope-item">
        <a href="UpFiles/2013/3/9/20132309072314.jpg" class="fancyboxpopup"><img src="UpFiles/2013/3/9/20132309072314.jpg" alt="" width="275" height="190"><span class="view">&nbsp;</span></a>
        <div class="recipedetails">
          <a class="title">陕西沙尘黄色预警</a>
          <p> 西安污染指数爆表</p>

        <a class="fr" href="NewsList.aspx">阅读更多新闻&gt;&gt;</a>        </div>
      </li>

      <li style="position: absolute; left: 0px; top: 0px; -moz-transform: translate(0px, 0px) scale(1); opacity: 1;" class="element Cocktails Sea-Food Snacks isotope-item">
        <a href="UpFiles/2013/3/9/20132009102036.jpg" class="fancyboxpopup"><img src="UpFiles/2013/3/9/20132009102036.jpg" alt="" width="275" height="190"><span class="view">&nbsp;</span></a>
        <div class="recipedetails">
          <a class="title">最美的背影</a>
          <p> 背影也可以很美丽</p>

        <a class="fr" href="NewsList.aspx">阅读更多新闻&gt;&gt;</a>        </div>
      </li>


    </ul>
  </div>
  <!-- #container -->
  
</section>



</asp:Content>

