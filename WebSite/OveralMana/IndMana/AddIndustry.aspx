<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddIndustry.aspx.cs" Inherits="OveralMana_IndMana_AddIndustry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 28px;
            width: 229px;
        }
        .style3
        {
            width: 229px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%">
            <tr>
                <td style="text-align:left" colspan="2">&gt;&gt;添加新行业</td>
            </tr>
            <tr>
                <td style="text-align:right" class="style2" >新行业类型</td>
                <td class="style1">
                    <asp:TextBox ID="IndTypeBox" runat="server" Width="262px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right" class="style3" ></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right" class="style3" ></td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="rtRest" type="reset" value="重置" /><asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="添加" />
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
