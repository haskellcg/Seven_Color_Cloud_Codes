<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="MerchantList.aspx.cs" Inherits="MerchantList" Title="商家展示" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
<script type="text/javascript" src="js/Merchant.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubContentBar" Runat="Server">
    <form id="form1" runat="server">
<section id="maincontainer" class="container clearfix">
  
  <h1 class="heading1">商家 <span>列表</span>
  </h1>
  <!--leftpart-->
  
  <section class="mb20 leftpart">
    <div>
        <iframe id="MrdFrm" width="100%" height="900px" scrolling="no" src="MerList.aspx" ></iframe>
    </div>
 
      
        
      

      

      <!--paging-->    
     <section>
      <ul>
    
     </ul>
     </section>
  </section>
  
  
  <!--Sidebar start-->
  <aside class="blogright">
  <div class="sidecontainer">
    <h4 class="heading4">商家分类 </h4>
    <ul class="blogcaterg">
    <%
        if (IndList.Tables[0].Rows.Count > 0) {
            for (int i = 0; i < IndList.Tables[0].Rows.Count; i++) { 
               %>
                 <li><a href="MerList.aspx?indID=<%=IndList.Tables[0].Rows[i]["ind_id"].ToString() %>" target="MrdFrm" ><%=IndList.Tables[0].Rows[i]["ind_type"] %></a></li>
               <%
            }
        }%>
    </ul>
    </div>
  </aside>
  <!--Sidebar end-->

  <!--行业信息结束-->

  </div>
  <!-- #container -->
  
        </section>

</form>
</asp:Content>

