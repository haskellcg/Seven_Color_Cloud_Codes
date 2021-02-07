<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="MerchantInfoShow.aspx.cs" Inherits="MerchantInfoShow" Title="商家信息展示" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        	width:20%;
        	text-align:left;
        	font-family:@宋体;
        }
        .style3
        {
            text-align:left;
            font-family:@宋体;


        	}  
        .style4
        {
        	text-align:left;
        	font-family:@宋体;
        	font-weight:bolder;
        	font-size:large;
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
        <h1 class="heading1">商品<span>列表</span> </h1>   
        <!--leftpart-->
         <section class="mb20 leftpart">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate> 
         <div style=" width:100%; float:left;">          
                        	    <ul class="recipelist">
                         <asp:Repeater ID="PrdRpt" runat="server">
                            <HeaderTemplate> 
                            </HeaderTemplate>
                            <ItemTemplate>
        	                 <li class="clearfix"  style="float:left; width:25%; height:30%"  > 
                                    <div class="recipegridimage">
                                    <a href="PdInfoShow.aspx?pdID=<%# Eval("pd_id") %>"><img alt="商品图片<%# Eval("pd_pic") %>" src="<%# Eval("pd_pic") %>" width="150px" height="100px" /></a>
                                    <br /><br /></div>
                            
                            <div class="recipedetails" >
                                    <label>商品名称:&nbsp;</label><%# Eval("pd_name") %><br /><br />
                                    <label>商品价格:&nbsp;</label><%# Eval("pd_price") %> <br /><br />
                                    <label  style="font; color: #FF0000;" >会员价格:&nbsp;<%# Eval("pd_mem_price") %></label> <br /><br />
                                    <br />
                            </div>
                            </li>
                                    
                               </ItemTemplate>
                               
                             <FooterTemplate></FooterTemplate>
                             </asp:Repeater>
                      </ul>

        	
<%--                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                 ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
                         
                              SelectCommand="SELECT [pd_id], [mer_id], [pd_price], [pd_mem_price], [pd_info], [pd_pic], [pd_name] FROM [mc_PdMaintain] WHERE ([mer_id] = @mer_id)">
                             <SelectParameters>
                             <asp:QueryStringParameter Name="mer_id" QueryStringField="mer_id" 
                                 Type="Decimal" />
                         </SelectParameters>
                            </asp:SqlDataSource>--%>
        </div>
     
             

        <div style="clear:both;"></div>
        <div style=" width:100%; float:none;">
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

    </form>
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
</asp:Content>

