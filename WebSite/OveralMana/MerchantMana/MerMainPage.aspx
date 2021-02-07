<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MerMainPage.aspx.cs" Inherits="OveralMana_MerchantMana_MerMainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:260px;">
        <div style="width:30%; height:260px; float:left;">
            <img src="<%= Request.ApplicationPath+"/" %><%= merPicPath %>" alt="商家图片" width="350px" height="250px"/>
        </div>
        <div style="width:70%; height:260px; float:left;" >
            <asp:Repeater ID="MerDetailRpt" runat="server">
               <HeaderTemplate>
                <table style="width:100%;" id="MerDetailTb">
                </HeaderTemplate>
                <ItemTemplate>
                    <br />
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">商家名称&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("mer_name") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">商家商家详细地址&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("mer_address") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">商家电话&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("mer_phone") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">邮编&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("mer_postcode") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">联系人姓名&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("reg_name") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">联系人职务&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("reg_duty") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">联系人手机&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("reg_telephone") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">商家介绍&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("mer_info") %></td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">是否为推荐商家&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("rec_mer_state") %>
                        </td>
                        
                    </tr>
                    <tr style="width:100%">
                        <td style="width:30%; text-align:right;">商家星级&nbsp;</td>
                        <td style="width:70%; text-align:left;"><%# Eval("mer_star_level") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                 </table>
                </FooterTemplate>
             </asp:Repeater>
        </div>
        
        <div style =" width:100%;">
            <div style=" float:left;">
                <asp:Button ID="RcmBtn" runat="server" CommandName="SetMerRcm" 
                oncommand="RcmBtn_OnCommand" Text="设置为推荐商家" />
                            <asp:Button ID="SendMsgBtn" runat="server" 
                                CommandArgument='<%# Eval("mer_id") %>' CommandName="SendMessage" 
                                oncommand="SendMsgBtn_Command" Text="发送消息" />
            </div>
            <div style="clear:both; width:100%;"></div>
            <div style=" float:left;">
                 <p> &gt;&gt;商品列表</p>
                    <asp:Repeater ID="PrdRpt" runat="server">
                        <HeaderTemplate> 
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="width:200px; height:250px; float:left;">
                                
                                <img alt="商品图片<%# Eval("pd_pic") %>" src="<%= Request.ApplicationPath+"/" %><%# Eval("pd_pic") %>" width="150px" height="100px" />
                                <br />
                                <label>商品名称:&nbsp</label><%# Eval("pd_name") %><br />
                                <label>商品价格:&nbsp</label><%# Eval("pd_price") %> <br />
                                <label>商品会员价格:&nbsp</label> <%# Eval("pd_mem_price") %> <br />
                                <label>商品介绍:&nbsp</label> <%# Eval("pd_info") %><br />
                                <br />
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
            </div>
            
        </div>
    
     </div>
    </form>
</body>
</html>
