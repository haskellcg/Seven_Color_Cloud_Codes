<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrdMana.aspx.cs" Inherits="OveralMana_MerchantMana_PrdMana" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%">
            &gt;&gt;&gt;管理商品<br />
            <asp:TextBox ID="SrchTextbox" runat="server" MaxLength="30" Rows="1" 
                Width="268px"></asp:TextBox>
            <asp:Button ID="SearchBtn" runat="server" onclick="SearchBtn_Click" Text="搜索" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="所在城市"></asp:Label>
            <asp:DropDownList ID="CityDpl" runat="server">
                <asp:ListItem Selected="True" Value="AllCity">全部城市</asp:ListItem>
            </asp:DropDownList>
            商家名称<asp:DropDownList ID="MerDpl" runat="server">
                <asp:ListItem Selected="True" Value="AllMer">所有商家</asp:ListItem>
            </asp:DropDownList>
         <div style="width:100%">
            <asp:GridView ID="PrdGrd" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="pd_name" HeaderText="商品名称" />
                <asp:BoundField DataField="pd_info" HeaderText="商品介绍" />
                <asp:BoundField DataField="pd_price" HeaderText="商品价格" />
                <asp:BoundField DataField="pd_mem_price" HeaderText="会员价格" />
                <asp:BoundField DataField="mer_name" HeaderText="所属商家" />
                <asp:BoundField DataField="city_name" HeaderText="所在地区" />
                <asp:BoundField DataField="pd_state" HeaderText="可用状态" />
                <asp:BoundField DataField="pd_note" HeaderText="备注" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="LookPrdBtn" runat="server" 
                            CommandArgument='<%# Eval("pd_id") %>' CommandName="LookPrd" 
                            oncommand="LookPrdBtn_Command" Text="禁用" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
       </div>
    </div>
    </form>
</body>
</html>
