<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MerchantReport.aspx.cs" Inherits="MerchantManage_MerchantAccount_MerchantReport" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
 <p align="center" id="P1" runat="server" style="font-size: x-large; font-family: 微软雅黑">
        欢迎来到商家报表统计，您的营业收入为<%=MoneyAccount %>元</p>
    <p></p><p></p>
    <table ><tr><td height="150px""></td></tr></table>
    <form id="form1" runat="server">
    <div style="width:71%" align="right">
    <webdiyer:AspNetPager ID="MerReportPager" runat="server"  CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
        NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
        AlwaysShowFirstLastPageNumber="True" 
        onpagechanged="MerReportPager_PageChanged" PageSize="20">
        </webdiyer:AspNetPager>
        </div>
    <div style="width:90%" align="center">
        <asp:GridView ID="ReportGrdList" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" Width="625px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="mem_id" HeaderText="会员卡号" />
                <asp:BoundField DataField="mem_name" HeaderText="会员姓名" />
                <asp:BoundField DataField="cost_id" HeaderText="交易ID" />
                <asp:BoundField DataField="pd_name" HeaderText="商品名称" />
                <asp:BoundField DataField="cost_money" HeaderText="商品价格" />
                <asp:BoundField DataField="cost_time" HeaderText="交易时间" />
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        
        </asp:GridView>
    </div>
    </form>
</asp:Content>
