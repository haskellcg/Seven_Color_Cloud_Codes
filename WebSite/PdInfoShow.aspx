<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="PdInfoShow.aspx.cs" Inherits="PdInfoShow" Title="商品评论" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
<script src="JS/Common.js" type="text/javascript"></script>
<script type="text/javascript">
window.onload=function(){

    var bar1 = document.getElementById("bar1");
    var bar3 = document.getElementById("bar3");
    bar1.className = "";
    bar3.className = "active";
  
    buttonI.onclick=function(){
    divd.className="showDiv";
    
    }
}


function ChooseUser()
    {
        var url="BuyWindow.aspx?pd_id=<%=pdID %>";
        window.showModalDialog(url,"","dialogWidth=400px;dialogHeight=200px");
    }
   
</script>
   
<style type="text/css" >
    .showDiv
    {
    	display:block;
   }
   .hiddenDiv
   {
   	 display:none;
   	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubContentBar" Runat="Server">
    	 <form id="form1" runat="server">
<section id="maincontainer" class="container clearfix">
  <h1 class="heading1">产品&amp; <span>简介</span> </h1>
  <!--leftpart-->
  <section class="mb20 leftpart">
     <div style=" margin-left:0px;">
     
     <ul class="recipelist">
        	<li class="clearfix">
            <div class="recipegridimage">
            <asp:Repeater ID="PdInfoShowRep" runat="server">
                <HeaderTemplate> 
                </HeaderTemplate>
                <ItemTemplate>
        	<img alt="商品图片<%# Eval("pd_pic") %>" src="<%# Eval("pd_pic") %>" width="275px" height="220px" />           </div>
        <div class="recipedetails">
          <h1  style=" color:Green; font-weight:600; font-size:larger;"> <%# Eval("pd_name") %><br /></h1>
          <br /><span class="deatils"><label>商品价格:&nbsp;</label> <b><%# Eval("pd_price") %></b></span>
          <br /><br /><span class="deatils"><label>会员价格:&nbsp;</label> <b><%# Eval("pd_mem_price") %> </b></span>
          <br /><br /><span class="deatils"><label>商品介绍:&nbsp;</label><b><%# Eval("pd_info") %></b></span>
          <br /><br /><span class="deatils"><label>商品状态:&nbsp;</label><b><%# Eval("pd_state")%></b></span>
          <br /><br /><span class="deatils"><label>商品备注:&nbsp;</label><b><%# Eval("pd_note")%></b>
          <br /><br /><asp:Button ID="bntBuy" runat="server" Text="购买" OnClientClick ="javascript:return ChooseUser();"></asp:Button>
          </span>
        </div>
         </ItemTemplate>
                     <FooterTemplate></FooterTemplate>
           </asp:Repeater>
      </li>
      </ul>
    	</div>
    	  <div id="divd" align="center" style=" margin-bottom:80px; margin-left:10px;">
                        <table align="left" width="99%">
                        <tr><td width="5px">姓名</td></tr>
                        <tr><td align="left"><asp:TextBox ID="TBName" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入姓名!" ControlToValidate="TBName"></asp:RequiredFieldValidator></td></tr>
                        <tr><td>评论内容</td></tr><tr><td height="80%">
                            <asp:TextBox ID="TBComment" runat="server" Height="87px" TextMode="MultiLine" 
                                Width="113%" Text="" ></asp:TextBox>
                            </td></tr>
                            <tr>
                            <td style="width:90%;"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ErrorMessage="评论内容不能为空" ControlToValidate="TBComment"></asp:RequiredFieldValidator>
</td>
                            <td style="width:20%;" colspan="2">
                                <asp:Button ID="bntSubmit" runat="server" BorderStyle="Outset" 
                                    Text="提交评论" onclick="SubmitComment" />
                                                                 </td></tr>
                        </table>
                        
                <br /><br /><br /><br /><br /><br />
            </div>
            <h1 class="heading1">产品&amp; <span>评论</span>
        </h1>
    	<asp:Repeater ID="RepeaterComList" runat="server">
             <HeaderTemplate><ul class="recipelist"></HeaderTemplate>
                <ItemTemplate>
        	<li class="clearfix" style="height: 100px; background-color:#E9EEF2;">

            <div class="recipegridimage">
        	 </div>
        <div class="recipedetails">
          
		  <p><%# Eval("mc_name")%> <%# Eval("mc_time")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
		  <p>点评内容：<%# Eval("mc_content")%></p>
		  <p align="right" style="font-family: 微软雅黑; font-size: small; color: #008080">  &nbsp;&nbsp;<%# Eval("reply_content")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%# Eval("reply_time")%></p>
		  </div>
      </li>
      </ItemTemplate>
      <FooterTemplate> </ul></FooterTemplate>
      </asp:Repeater>
      <!--paging-->    
      <webdiyer:AspNetPager ID="CommentManaPager" runat="server"  CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
                        NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
                        AlwaysShowFirstLastPageNumber="True" 
                        onpagechanged="CommentManaPager_PageChanged" PageSize="3" >
     </webdiyer:AspNetPager>
  </section>
  <!--Sidebar start-->
  <aside class="blogright">
  <div class="sidecontainer">
    <h4 class="heading4">商家信息</h4>
	<asp:ImageMap ID="MerBas_Pic" runat="server"></asp:ImageMap>
    </div>
   <div class="sidecontainer"> 
     <br />商家名称：<asp:Label ID="MerBas_Name" runat="server"></asp:Label>
    <br /><br />商家介绍：<asp:Label ID="MerBas_Intro" runat="server"></asp:Label>
    <br /><br />商家地址：<asp:Label ID="MerBas_Address" runat="server"></asp:Label>
    <br /><br />联系电话：<asp:Label ID="MerBas_Phone" runat="server"></asp:Label>
    <br /><br />公司网址：<asp:Label ID="MerBas_Web" runat="server"></asp:Label>
    <br /><br />电子邮箱：<asp:Label ID="MerBas_Email" runat="server"></asp:Label>
    <br /><br />法人代表：<asp:Label ID="MerBas_Relat" runat="server"></asp:Label>
    <br /><br />商家星级： <asp:Label ID="MerBas_StarLevel" runat="server"></asp:Label>
    <br /><br />所在城市：<asp:Label ID="MerBas_Province" runat="server"></asp:Label><asp:Label ID="MerBas_City" runat="server"></asp:Label>
    </div>
   
  </aside>
  <!--Sidebar end-->
</section>




















<%--

     <div>
       <table class="style1" cellspacing="10">
            <tr>
                <td align="left" colspan="2"></td>
             
            </tr>
            <tr>
                <td>
                <div style=" float:left;">
                
                <div style="width:200px; height:250px; float:left;" id="PdInfoShowDiv" runat="server">

                 </div>
                 
                 </div>
                 
                 
                                      <div> 
                          <div><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                      <table width="80%" >
                                <tr><td width="90%"></td><td width="5%"><a href="javascript:showCommentBox()"><asp:Label 
                                ID="LabelComment" Text="评论" runat="server"></asp:Label></a></td></tr>
                             </table>
                        </div>
                        <div id="divd" style="width:70%" align="center">
                        <table width="80%" align="center">
                        <tr><td height="80%">
                            <asp:TextBox ID="TBComment" runat="server" Height="87px" TextMode="MultiLine" 
                                Width="100%" Text=""></asp:TextBox>
                            </td></tr>
                            <tr><td>
                                <asp:Button ID="bntSubmit" runat="server" BorderStyle="Outset" 
                                    OnClientClick="javascript:hideCommentBox()" Text="提交评论" 
                                    onclick="SubmitComment" /></td></tr>
                        </table>
                        </div>
                    </form>--%>
                        <%--<div style="width:70%" align="center">
                        <table><tr><td height="10px"></td></tr></table>
                            <webdiyer:AspNetPager ID="CommentManaPager" runat="server"  CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
                            NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
                            AlwaysShowFirstLastPageNumber="True" 
                            onpagechanged="CommentManaPager_PageChanged" PageSize="5">
                            </webdiyer:AspNetPager>
                            <table><tr><td height="10px"></td></tr></table>
                        <div id="CommentList" style="border-width: thin">
                            <asp:Repeater ID="RepeaterComList" runat="server">
                                <HeaderTemplate><table></HeaderTemplate>
                                <ItemTemplate>
                                <tr><td width="17%"style="font-family: 幼圆; font-size: larger; font-weight: 100; font-style: normal; color: #999966;"><%# Eval("mc_name")%></td>
                                <td width="68%"><%# Eval("mc_content")%></td>
                                <td width="18%" style="font-size: x-small"><%# Eval("mc_time")%></td>
                                </tr>
                                <tr>
                                <td width="10%"></td>
                                <td width="68%" style="font-size: small; color: #999999; "><%# Eval("reply_content")%></td>
                                <td width="18%" style="font-size: x-small; color: #999999;"><%# Eval("reply_time")%></td>
                                </tr>
                                <tr><td height="8px"></td></tr>
                                </ItemTemplate>
                                <FooterTemplate> </table></FooterTemplate>
                            </asp:Repeater>
                        </div>
                        </div>--%>
                 
<%--                 </div>
                 </td>
             </tr>
             </table>
            </div>--%>
 
    	 </form>
    	 
</asp:Content>
