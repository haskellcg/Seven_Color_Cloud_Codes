<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="SearchMember.aspx.cs" Inherits="Default2" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">

    <form id="form1" runat="server">
    <div>
    <table style="width:100%">
    <tr>
    <td>
        &gt;&gt;&gt;查询会员</td></tr>
    
        <tr>
    <td>
        手机号查询<asp:TextBox ID="SearchMemTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="SearchMemBtn" runat="server" Text="搜索" 
            onclick="SearchMemBtn_Click" />
        <asp:Button ID="SearchMemRtn" runat="server" Text="返回" 
            onclick="SearchMemRtn_Click" />
    </td></tr>
    
        <tr>
    <td>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="mem_id" 
            DataSourceID="SearchMem" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="mem_id" HeaderText="会员ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="mem_id" />
                <asp:BoundField DataField="mer_id" HeaderText="商家ID" 
                    SortExpression="mer_id" />
                <asp:BoundField DataField="card_type" HeaderText="证件类型" 
                    SortExpression="card_type" />
                <asp:BoundField DataField="card_id" HeaderText="证件号" 
                    SortExpression="card_id" />
                <asp:BoundField DataField="mem_name" HeaderText="姓名" 
                    SortExpression="mem_name" />
                <asp:BoundField DataField="mem_sex" HeaderText="性别" 
                    SortExpression="mem_sex" />
                <asp:BoundField DataField="mem_telephone" HeaderText="电话" 
                    SortExpression="mem_telephone" />
                <asp:BoundField DataField="mem_addr" HeaderText="地址" 
                    SortExpression="mem_addr" />
                <asp:BoundField DataField="mem_email" HeaderText="邮箱" 
                    SortExpression="mem_email" />
                <asp:BoundField DataField="mem_money" HeaderText="余额" 
                    SortExpression="mem_money" />
                <asp:BoundField DataField="mem_psw" HeaderText="密码" 
                    SortExpression="mem_psw" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SearchMem" runat="server" 
            ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
            
            SelectCommand="SELECT [mem_id], [mer_id], [card_type], [card_id], [mem_name], [mem_sex], [mem_telephone], [mem_addr], [mem_email], [mem_money], [mem_psw] FROM [mb_BasicInfo] WHERE (([mer_id] = @mer_id) AND ([mem_telephone] LIKE '%' + @mem_telephone + '%')) ORDER BY [card_id]">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="mer_id" SessionField="user_ID" 
                    Type="Decimal" />
                <asp:ControlParameter ControlID="SearchMemTextBox" Name="mem_telephone" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td></tr>
    
        <tr>
    <td>
    </td></tr>
    
    
    </table>
    
    </div>
    </form>

</asp:Content>

