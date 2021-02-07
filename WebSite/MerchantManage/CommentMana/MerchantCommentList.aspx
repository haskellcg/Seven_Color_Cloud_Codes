<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MerchantCommentList.aspx.cs" Inherits="MerchantManage_CommentMana_MerchantCommentList" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
<form id="form1" runat="server">
    <div >
        <table width="80%" align="center">
        <tr><td width="10%"></td><td>
        商家查看待点评页面&gt;&gt;
        </td></tr>
        <tr><td height="10px"></td><td></td></tr>
        <tr><td width="10%"></td><td align="center"><asp:GridView ID="CommentListGrd" runat="server" CellPadding="3" 
        AutoGenerateColumns="False" Width="100%" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  >
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField HeaderText="点评ID" DataField="pd_id" />
            <asp:BoundField HeaderText="点评产品" DataField="pd_name" />
            <asp:BoundField HeaderText="点评人姓名" DataField="mc_name" />
            <asp:BoundField HeaderText="点评内容" DataField="mc_content" />
            <asp:BoundField HeaderText="点评时间" DataField="mc_time" />
            <asp:BoundField HeaderText="点评人IP" DataField="mc_ip" />
            
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:Button ID="Reply" runat="server" Text="回复" CommandName="Reply" 
                        CommandArgument='<%#Eval("mc_id")%>'
                        oncommand="Reply_Command"/>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </td></tr>
    <tr><td height="10px"></td><td></td></tr>
    <tr><td width="10%"></td><td align="right">
    <webdiyer:AspNetPager ID="MerReplyPager" runat="server" CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
        NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
        AlwaysShowFirstLastPageNumber="True" 
        onpagechanged="MerReplyPager_PageChanged" PageSize="5">
    </webdiyer:AspNetPager>
    </td></tr></table>
        </div>
    </form>
</asp:Content>

