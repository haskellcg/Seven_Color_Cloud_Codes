<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUnionNews.aspx.cs" Inherits="UnionNewsSearchResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询新闻</title>
    <style type="text/css">
        .style1
        {
            height: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <table style="width:100%">
    <tr>
    <td>

        &gt;&gt;&gt;新闻查询</td></tr>
    
    <tr>
    <td class="style1">
        <br />
        输入关键词：<asp:TextBox ID="SearchNewsText" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="SearchNews" runat="server" Text="搜索" 
            onclick="SearchNews_Click" />
                    <asp:Button ID="SearchNewsReturn" runat="server" 
             Text="返回" onclick="SearchNewsReturn_Click1" />
                    <br />
                    <br />
    </td>
    </tr>
    <tr style="width:100%">
    <td style="width:100%">

    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" DataKeyNames="新闻ID" 
            DataSourceID="SearchNewsResult" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            style="margin-right: 1px" Width="100%">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="新闻ID" HeaderText="新闻ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="新闻ID" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="新闻标题" HeaderText="新闻标题" 
                    SortExpression="新闻标题" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="发布人" HeaderText="发布人" 
                    SortExpression="发布人" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="发布时间" HeaderText="发布时间" 
                    SortExpression="发布时间" >


                    
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>


                    
                <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Button ID="BtnEditNews" runat="server" Text="编辑" CommandName ="EditNews" oncommand="BtnEditNews_Command"
                        CommandArgument ='<%# Eval("新闻ID") %>' />
                        <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("新闻ID") %>' 
                            CommandName="Delete" oncommand="Button1_Command" Text="删除" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>


                    
            </Columns>
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </td></tr>
    
    
    <tr style="width:100%">
    <td style="width:100%">
    
        <asp:SqlDataSource ID="SearchNewsResult" runat="server" 
            ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
            DeleteCommand="DELETE FROM [tb_News] WHERE [news_id] = @news_id" 
            InsertCommand="INSERT INTO [tb_News] ([news_title], [news_text], [news_pub], [news_time]) VALUES (@news_title, @news_text, @news_pub, @news_time)" 
            SelectCommand="SELECT news_id AS 新闻ID, news_title AS 新闻标题, news_text AS 新闻内容, news_pub AS 发布人, news_time AS 发布时间 FROM tb_News WHERE (news_title LIKE '%' + @NewsTitle + '%')" 
            
            UpdateCommand="UPDATE [tb_News] SET [news_title] = @news_title, [news_text] = @news_text, [news_pub] = @news_pub, [news_time] = @news_time WHERE [news_id] = @news_id">

            

            <SelectParameters>
                <asp:ControlParameter ControlID="SearchNewsText" Name="NewsTitle" 
                    PropertyName="Text" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="news_id" Type="Decimal" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="news_title" Type="String" />
                <asp:Parameter Name="news_text" Type="String" />
                <asp:Parameter Name="news_pub" Type="String" />
                <asp:Parameter Type="Datetime" Name="news_time" />
                <asp:Parameter Name="news_id" Type="Decimal" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="news_title" Type="String" />
                <asp:Parameter Name="news_text" Type="String" />
                <asp:Parameter Name="news_pub" Type="String" />
                <asp:Parameter Type="Datetime" Name="news_time" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </td></tr>
    
    </table>
    </div>
    </form>
</body>
</html>
