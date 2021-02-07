<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="SearchMemberMana.aspx.cs" Inherits="MemberMana_SearchMemberMana" Title="查询会员" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SearchBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBar" Runat="Server">
<section id="maincontainer" class="container clearfix">

<h1 class="heading1"><img src="../images/logo.gif">
   <div style="float:right; margin-right:330px; font-weight:600;"><h5>商家管理</h5></div>
  </h1>


    <form id="form1" runat="server">
    <div>
    <table style="width:100%">
    <tr>
    <td>查询会员<br /><br /></td></tr>
    
        <tr>
    <td style="width:20%">
        手机号查询：<asp:TextBox ID="SearchMemTextBox" runat="server"></asp:TextBox>   </td> <td>     <asp:Button ID="SearchMemBtn" runat="server" Text="搜索" onclick="SearchMemBtn_Click" />

        <asp:Button ID="SearchMemRtn" runat="server" Text="返回" onclick="SearchMemRtn_Click" />
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
                <asp:BoundField DataField="mem_telephone" HeaderText="手机" 
                    SortExpression="mem_telephone" />
                <asp:BoundField DataField="card_type" HeaderText="证件类型" 
                    SortExpression="card_type" />
                <asp:BoundField DataField="card_id" HeaderText="证件号码" 
                    SortExpression="card_id" />
                <asp:BoundField DataField="mem_name" HeaderText="会员名称" 
                    SortExpression="mem_name" />
                <asp:BoundField DataField="mem_sex" HeaderText="性别" 
                    SortExpression="mem_sex" />
                <asp:BoundField DataField="mem_addr" HeaderText="家庭地址" 
                    SortExpression="mem_addr" />
                <asp:BoundField DataField="mem_email" HeaderText="邮箱" 
                    SortExpression="mem_email" />
                <asp:BoundField DataField="mem_operator" HeaderText="登记人" 
                    SortExpression="mem_operator" />
                <asp:BoundField DataField="mem_op_time" HeaderText="登记时间" 
                    SortExpression="mem_op_time" />
                <asp:BoundField DataField="mem_psw" HeaderText="密码" 
                    SortExpression="mem_psw" />
                <asp:BoundField DataField="mem_money" HeaderText="余额" 
                    SortExpression="mem_money" />
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
            DeleteCommand="DELETE FROM [mb_BasicInfo] WHERE [mem_id] = @mem_id" 
            InsertCommand="INSERT INTO [mb_BasicInfo] ([mer_id], [card_type], [card_id], [mem_name], [mem_sex], [mem_telephone], [mem_addr], [mem_email], [mem_operator], [mem_op_time], [mem_psw], [mem_money]) VALUES (@mer_id, @card_type, @card_id, @mem_name, @mem_sex, @mem_telephone, @mem_addr, @mem_email, @mem_operator, @mem_op_time, @mem_psw, @mem_money)" 
            SelectCommand="SELECT [mem_id], [mer_id], [card_type], [card_id], [mem_name], [mem_sex], [mem_telephone], [mem_addr], [mem_email], [mem_operator], [mem_op_time], [mem_psw], [mem_money] FROM [mb_BasicInfo] WHERE ([mem_telephone] LIKE '%' + @mem_telephone + '%')" 
            UpdateCommand="UPDATE [mb_BasicInfo] SET [mer_id] = @mer_id, [card_type] = @card_type, [card_id] = @card_id, [mem_name] = @mem_name, [mem_sex] = @mem_sex, [mem_telephone] = @mem_telephone, [mem_addr] = @mem_addr, [mem_email] = @mem_email, [mem_operator] = @mem_operator, [mem_op_time] = @mem_op_time, [mem_psw] = @mem_psw, [mem_money] = @mem_money WHERE [mem_id] = @mem_id">
            <SelectParameters>
                <asp:ControlParameter ControlID="SearchMemTextBox" Name="mem_telephone" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="mem_id" Type="Decimal" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="mer_id" Type="Decimal" />
                <asp:Parameter Name="card_type" Type="String" />
                <asp:Parameter Name="card_id" Type="String" />
                <asp:Parameter Name="mem_name" Type="String" />
                <asp:Parameter Name="mem_sex" Type="Int32" />
                <asp:Parameter Name="mem_telephone" Type="String" />
                <asp:Parameter Name="mem_addr" Type="String" />
                <asp:Parameter Name="mem_email" Type="String" />
                <asp:Parameter Name="mem_operator" Type="String" />
                <asp:Parameter Type="Datetime" Name="mem_op_time" />
                <asp:Parameter Name="mem_psw" Type="String" />
                <asp:Parameter Name="mem_money" Type="Double" />
                <asp:Parameter Name="mem_id" Type="Decimal" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="mer_id" Type="Decimal" />
                <asp:Parameter Name="card_type" Type="String" />
                <asp:Parameter Name="card_id" Type="String" />
                <asp:Parameter Name="mem_name" Type="String" />
                <asp:Parameter Name="mem_sex" Type="Int32" />
                <asp:Parameter Name="mem_telephone" Type="String" />
                <asp:Parameter Name="mem_addr" Type="String" />
                <asp:Parameter Name="mem_email" Type="String" />
                <asp:Parameter Name="mem_operator" Type="String" />
                <asp:Parameter Type="Datetime" Name="mem_op_time" />
                <asp:Parameter Name="mem_psw" Type="String" />
                <asp:Parameter Name="mem_money" Type="Double" />
            </InsertParameters>
        </asp:SqlDataSource>
    </td></tr>
    
        <tr>
    <td>
    </td></tr>
    
    
    </table>
    
    </div>
    </form>
</section>
</asp:Content>

