<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentBar" Runat="Server">

    <form id="form1" runat="server">
    <div style="float:left; margin-left:15%;">

      <h1 style="font-family: 隶书; font-size: x-large">新闻列表</h1><br /><br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        
        <HeaderTemplate>
        <table>

        </HeaderTemplate>
        <ItemTemplate>

        <tr>
        <td style="width:60%" height="30px" ><%#Eval ("news_title") %> </td>  
        <td style="width:20%">发布时间：<%#Eval ("news_time") %> <asp:LinkButton ID="LinkButton1" runat="server" CommandName ="NewsPage" CommandArgument ='<%# Eval("news_id") %>' oncommand="NewsPage_Command">更多 </asp:LinkButton></td>      
        </tr>

        </ItemTemplate>
     
        
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>  
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
            SelectCommand="SELECT [news_id],[news_title], [news_time] FROM [tb_News]">
        </asp:SqlDataSource>
        
        
        
        
    </div>
    </form>
</asp:Content>

