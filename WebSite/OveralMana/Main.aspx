<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="OveralMana_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width:100%; height:109px;">
            <asp:Repeater ID="Rep" runat="server">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
                <div >
                    <a href="<%# Eval("mer_url") %>"></a>
                </div>
            </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
