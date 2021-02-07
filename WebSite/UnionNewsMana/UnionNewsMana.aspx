<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnionNewsMana.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>联盟新闻管理</title>
    <script src="js/WebCalendar.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1">
        <table style="width:100%">
        <tr>
        <td>
        >>>联盟新闻管理<br /><br />
         
        </td></tr>
      
      <tr>
      <td>

        <asp:Button ID="Add_News" runat="server" Text="增加新闻" onclick="Add_News_Click" />
        <asp:Button ID="Search_News" runat="server" Text="查询新闻" onclick="Search_News_Click"/>
        <br />
        <br />
        </td></tr>
        
    </div>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        AutoGenerateColumns="False" Width="100%" 
        DataSourceID="UnionNewsSearch" AllowPaging="True" AllowSorting="True" 
        DataKeyNames="news_id" GridLines="None" 
        onrowcommand="GridView1_RowCommand" >
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:BoundField DataField="news_id" HeaderText="新闻ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="news_id" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="新闻标题" DataField="news_title" 
                SortExpression="news_title" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="发布人" DataField="news_pub" 
                SortExpression="news_pub" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="发布时间" DataField="news_time" 
                SortExpression="news_time" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnEditNews" runat="server" Text="编辑" CommandName ="EditNews"
                        CommandArgument ='<%# Eval("news_id") %>' />
                    <asp:Button ID="BtnDeleteNews" runat="server" Text="删除" CommandName ="Delete"
                        CommandArgument ='<%# Eval("news_id") %>' oncommand="BtnDeleteNews_Command"/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="UnionNewsSearch" runat="server" 
        ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
        
        SelectCommand="SELECT [news_title], [news_text], [news_time], [news_pub], [news_id] FROM [tb_News]" 
        DeleteCommand="DELETE FROM [tb_News] WHERE [news_id] = @news_id" 
        InsertCommand="INSERT INTO [tb_News] ([news_title], [news_text], [news_time], [news_pub]) VALUES (@news_title, @news_text, @news_time, @news_pub)" 
        UpdateCommand="UPDATE [tb_News] SET [news_title] = @news_title, [news_text] = @news_text, [news_time] = @news_time, [news_pub] = @news_pub WHERE [news_id] = @news_id">
        <DeleteParameters>
            <asp:Parameter Name="news_id" Type="Decimal" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="news_title" Type="String" />
            <asp:Parameter Name="news_text" Type="String" />
            <asp:Parameter Type="Datetime" Name="news_time" />
            <asp:Parameter Name="news_pub" Type="String" />
            <asp:Parameter Name="news_id" Type="Decimal" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="news_title" Type="String" />
            <asp:Parameter Name="news_text" Type="String" />
            <asp:Parameter Type="Datetime" Name="news_time" />
            <asp:Parameter Name="news_pub" Type="String" />
        </InsertParameters>




    </asp:SqlDataSource>
    
    </td></tr>
    </table>
    </form>
</body>
</html>
