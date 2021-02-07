<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsContentDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻展示列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <talbe style="width:100%">
        <tr>
        <td>
        >>>新闻展示<br /><br />
        
        </td></tr></talbe>
        
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        
        <HeaderTemplate>
        <table style="width:100%">
        </HeaderTemplate>
        <ItemTemplate>
        <tr style="padding: inherit; margin: auto; border: medium solid #C0C0C0; font-size: medium; line-height: normal; list-style-type: circle; list-style-image: inherit; list-style-position: inherit; table-layout: auto; border-collapse: inherit; border-spacing: inherit; empty-cells: hide; caption-side: inherit;">
        <td >
        <%#Eval ("news_title") %>   
         <td align=right>&nbsp;&nbsp;发布时间：<%#Eval ("news_time") %></td>      
         <td><asp:LinkButton ID="LinkButton1" runat="server" CommandName ="NewsPage" CommandArgument ='<%# Eval("news_id") %>' oncommand="NewsPage_Command">更多 </asp:LinkButton></td>


        </tr>

        </ItemTemplate>

        
        
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>  
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:shuakaConnectionString2 %>" 
            SelectCommand="SELECT [news_title], [news_time] FROM [tb_News]">
        </asp:SqlDataSource>
        
        
        
        
    </div>
    </form>
    <p>
&nbsp;&nbsp;
    </p>
</body>
</html>
