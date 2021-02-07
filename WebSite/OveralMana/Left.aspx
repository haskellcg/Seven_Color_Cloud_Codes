<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="OveralMana_OveralMana" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TreeView ID="ManaTree" runat="server" ImageSet="Arrows" ExpandDepth="1" 
            onselectednodechanged="ManaTree_SelectedNodeChanged">
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" />
            <Nodes>
                <asp:TreeNode NavigateUrl="http://www.baidu.com" ShowCheckBox="False" 
                    Text="七彩云积分刷卡系统综合管理平台" Value="root" SelectAction="None"></asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="宋体" Font-Size="15pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="3px" VerticalPadding="3px" BackColor="" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
