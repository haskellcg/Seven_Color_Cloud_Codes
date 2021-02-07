<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MerShowInfoMaintain.aspx.cs" Inherits="Default2" Title="无标题页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">

     <form id="form1" runat="server">
     <section id="maincontainer" class="container clearfix">
       
       <h1 class="heading1">商品<span>列表</span> </h1>
         <!--leftpart--> 
         
       <section class="mb20 leftpart">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate> 
    	    <div style="width:100%; float:left;">
    	      
            
              
            <ul class="recipelist">    
                <asp:Repeater ID="MerProductList" runat="server" onitemcommand="MerProductList_ItemCommand">
                  <HeaderTemplate >  
                    </HeaderTemplate>
                    
                    <ItemTemplate>
        	             <li class="clearfix"  style="float:left; width:27%; height:35%"  > 
                                <div class="recipegridimage">                                <img alt="商品图片<%# Eval("pd_pic") %>" src="<%= Request.ApplicationPath %>/<%# Eval("pd_pic") %>" width="150px" height="100px" />
                                <br /><br /></div>                                                                                <div class="recipedetails" >                                <label>商品名称:&nbsp;</label><%# Eval("pd_name") %><br /><br />
                                <label>商品价格:&nbsp;</label><%# Eval("pd_price") %> <br /><br />
                                <label  style="font; color: #FF0000;" >会员价格:&nbsp;<%# Eval("pd_mem_price") %></label><br /> 
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="修改信息"   CommandName="MerProductListCmd" CommandArgument='<%# Eval("pd_id") %>' />
                        </div>
                        </li>

                                

                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
             </asp:Repeater>
        </ul>
        
    	    </div>
    	    <div style="clear:both;"></div>
    	 
     
         
           <div style="width:100%; float:left;">
    	        <webdiyer:AspNetPager runat="server" ID="AspNetPager1" FirstPageText="首页" 
                    LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" 
                    onpagechanging="AspNetPager1_PageChanging"  
                    PageSize="6">
                </webdiyer:AspNetPager>

                
    	    </div>
            
                 </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="AspNetPager1" EventName="PageChanging" />  
                </Triggers>
        </asp:UpdatePanel>


        

     
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
                    <br /><br />商家星级：<asp:Label ID="MerBas_StarLevel" runat="server"></asp:Label>
    <br /><br />所在城市：<asp:Label ID="MerBas_Province" runat="server"></asp:Label><asp:Label ID="MerBas_City" runat="server"></asp:Label>
                    <br /><br />审核状态：<asp:Label ID="MerBas_State" runat="server"></asp:Label>
                    
                    <br /><br /><asp:Button ID="MerchantBasicInfoModifyBtn" runat="server" Text="修改信息" 
            onclick="MerchantBasicInfoModifyBtn_Click" style="height: 26px;" />
                    <asp:Button ID="Button2" runat="server" Text="修改密码" 
            onclick="Button2_Click" style="height: 26px;" />
            <br /><br />
                   <asp:Button ID="Button3" runat="server" Text="添加会员" 
            onclick="Button3_Click" style="height: 26px;" />
                   <asp:Button ID="Button4" runat="server" Text="会员管理" 
            onclick="Button4_Click" style="height: 26px;" />
                       <br /><br /><asp:Button ID="Button5" runat="server" Text="查看评论" 
            onclick="Button5_Click" style="height: 26px;" />
             <asp:Button ID="Button6" runat="server" Text="查看报表" 
            onclick="Button6_Click" style="height: 26px;" />
                                   <br /><br /><asp:Button ID="Button7" runat="server" Text="增加商品" 
            style="height: 26px;" onclick="Button7_Click"  />
    </div>

  </aside>
  <!--Sidebar end-->
 </section>   

            
        </div>
     </form>

</asp:Content>

