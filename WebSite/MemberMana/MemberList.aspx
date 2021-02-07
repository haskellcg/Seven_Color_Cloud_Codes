<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="Default2" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
    <script type="text/javascript">
        function ChargeForm()
        {
            var obj;
            var ret=window.showModalDialog("ChargeForMem.aspx",obj,"dialogWidth=500px;dialogHeight=200px;scroll=no;resizable=no;status=no");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">


     <form id="form1" runat="server">
     <section id="maincontainer" class="container clearfix">
       
       <h1 class="heading1">会员<span>列表</span> </h1>
         <!--leftpart--> 
       <section class="mb20 leftpart">
       <asp:Button ID="AddMemBtn" runat="server" Text="增加会员" 
            onclick="AddMemBtn_Click" />
        <asp:Button ID="SearchMemBtn" runat="server" Text="查询会员" 
            onclick="SearchMemBtn_Click" />
        <asp:Button ID="Button1" runat="server" Text="会员充值" 
            OnClientClick="ChargeForm();" />
        <br /><br />        <br />
    </section>
<table style="width:100%">

  <tr >
    <td >
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="mem_id" DataSourceID="MemberList" ForeColor="#333333" 
            GridLines="None" onrowcommand="GridView1_RowCommand"  >
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
        <asp:SqlDataSource ID="MemberList" runat="server" 
            ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
            DeleteCommand="DELETE FROM [mb_BasicInfo] WHERE [mem_id] = @mem_id" 
            InsertCommand="INSERT INTO [mb_BasicInfo] ([mer_id], [card_type], [card_id], [mem_name], [mem_sex], [mem_telephone], [mem_addr], [mem_email], [mem_psw], [mem_money]) VALUES (@mer_id, @card_type, @card_id, @mem_name, @mem_sex, @mem_telephone, @mem_addr, @mem_email, @mem_psw, @mem_money)" 
            SelectCommand="SELECT [mem_id], [mer_id], [card_type], [card_id], [mem_name], [mem_sex], [mem_telephone], [mem_addr], [mem_email], [mem_psw], [mem_money] FROM [mb_BasicInfo] WHERE ([mer_id] = @mer_id)"
            
            
            
            UpdateCommand="UPDATE [mb_BasicInfo] SET [mer_id] = @mer_id, [card_type] = @card_type, [card_id] = @card_id, [mem_name] = @mem_name, [mem_sex] = @mem_sex, [mem_telephone] = @mem_telephone, [mem_addr] = @mem_addr, [mem_email] = @mem_email, [mem_psw] = @mem_psw, [mem_money] = @mem_money WHERE [mem_id] = @mem_id">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="mer_id" SessionField="user_ID" 
                    Type="Decimal" />
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
                <asp:Parameter Name="mem_psw" Type="String" />
                <asp:Parameter Name="mem_money" Type="Double" />
            </InsertParameters>
        </asp:SqlDataSource>
    
</td>
</tr>
    </table>
    
    </div>
    </form>
</section>
</asp:Content>

