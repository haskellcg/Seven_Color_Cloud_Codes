<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MerchantJoinCheck.aspx.cs" Inherits="MerchantMana_MerchantJoinCheck" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>商家入盟审核</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        入盟商家审核页面&gt;&gt;<asp:GridView ID="JionMerListGrd" runat="server" CellPadding="4" 
        AutoGenerateColumns="False" Width="100%" ForeColor="#333333" 
            GridLines="None"  >
        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:BoundField HeaderText="商家类型" DataField="mer_type" />
            <asp:BoundField HeaderText="商家名称" DataField="mer_name" />
            <asp:BoundField HeaderText="联系地址" DataField="mer_address" />
            <asp:BoundField HeaderText="联系电话" DataField="mer_phone" />
            <asp:BoundField HeaderText="状态" DataField="mer_state" />
            <asp:BoundField HeaderText="邮编" DataField="mer_postcode" />
            <asp:BoundField HeaderText="会员折扣比" DataField="mer_discount" />
            <asp:BoundField HeaderText="联系人电话" DataField="reg_telephone" />
            <asp:BoundField HeaderText="联系人Email" DataField="reg_email" />
            <asp:TemplateField HeaderText="审核">
                <ItemTemplate>
                    <asp:Button ID="CheckYes" runat="server" Text="通过" CommandName="CheckYes" 
                        CommandArgument='<%#Eval("mer_id")%>'
                        oncommand="CheckYes_Command"/>
                    <asp:Button ID="CheckNo" runat="server" Text="未通过" CommandName="CheckNo" 
                        CommandArgument='<%#Eval("mer_id")%>'
                        oncommand="CheckNo_Command"/>
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
    <webdiyer:AspNetPager ID="MerJionCheckPager" runat="server" 
        CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
        NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
        AlwaysShowFirstLastPageNumber="True" 
        onpagechanged="MerJionCheckPager_PageChanged" PageSize="5">
    </webdiyer:AspNetPager>
    </form>
</body>
</html>