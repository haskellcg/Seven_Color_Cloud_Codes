<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MerchantMana.aspx.cs" Inherits="OveralMana_MerchantMana_MerchantMana" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style =" width:100%; height:80px; clear:both; margin:5px 0 0 5px; padding:0 0 0 0; font-size:16px;" >
            
           <!-- <asp:TextBox ID="SearchTextBox" runat="server" Columns="30" MaxLength="30" style="margin:5px 5px 2px 20px; padding:3px 2px 3px 2px; float:left;"></asp:TextBox>
            <div id="Div1" runat="server" style="margin:9px 5px 2px 20px; float:right;">搜索商家</div>!-->
            
            <asp:TextBox ID="SrchTextbox" runat="server" MaxLength="30" Rows="1" 
                Width="302px"></asp:TextBox>
            <asp:Button ID="SearchBtn" runat="server" onclick="SearchBtn_Click" Text="搜索" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="商家所在城市"></asp:Label>
            <asp:DropDownList ID="CityDpl" runat="server">
                <asp:ListItem Selected="True" Value="AllCity">全部城市</asp:ListItem>
            </asp:DropDownList>
            商家状态<asp:DropDownList ID="StateDpl" runat="server">
                <asp:ListItem Selected="True" Value="-1">全部类型</asp:ListItem>
                <asp:ListItem Value="1">已加盟</asp:ListItem>
                <asp:ListItem Value="0">待审核</asp:ListItem>
                <asp:ListItem Value="2">已拒绝</asp:ListItem>
            </asp:DropDownList>
            
        </div>
        <br />    
        <div style="width:100%">
            <asp:GridView ID="MerListGrd" runat="server" CellPadding="4" 
            AutoGenerateColumns="False" Width="100%" ForeColor="#333333" 
                GridLines="None"  >
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField HeaderText="商家类型" DataField="mer_type" />
                <asp:BoundField HeaderText="商家名称" DataField="mer_name" />
                <asp:BoundField HeaderText="联系地址" DataField="mer_address" />
                <asp:BoundField HeaderText="联系电话" DataField="mer_phone" />
                <asp:BoundField HeaderText="Email" DataField="reg_email" />
                <asp:BoundField HeaderText="状态" DataField="mer_state" />
                <asp:BoundField DataField="rec_mer_state" HeaderText="推荐状态" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="SendMsgBtn" runat="server" 
                            CommandArgument='<%# Eval("mer_id") %>' CommandName="SendMessage" 
                            oncommand="SendMsgBtn_Command" Text="发送消息" />
                        <asp:Button ID="LookMerBtn" runat="server" 
                            CommandArgument='<%# Eval("mer_id") %>' CommandName="LookMer" 
                            oncommand="LookMerBtn_Command" Text="查看商家" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        
        
    </div>
    <webdiyer:AspNetPager ID="MerManaPager" runat="server" 
        CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
        NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
        AlwaysShowFirstLastPageNumber="True" PageSize="5">
    </webdiyer:AspNetPager>
    </form>
</body>
</html>
