<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndModify.aspx.cs" Inherits="OveralMana_IndMana_IndModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 238px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%">
            <tr>
                <td style="text-align:left" colspan="2">&gt;&gt;修改行业类型</td>
            </tr>
            <tr>
                <td style="text-align:right" class="style1">原行业类型：</td>
                <td>
                    <asp:DropDownList ID="ddlInd" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="ind_type" DataValueField="ind_type" Width="126px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="Data Source=127.0.0.1;Initial Catalog=shuaka;User ID=sa;Password=111111" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="SELECT [ind_type] FROM [ind_Classify]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align:right" class="style1">修改后的行业类型：</td>
                <td>
                    <asp:TextBox ID="tbModInd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right" class="style1"></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right" class="style1"></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="保存" />
                    <input id="rtRest" type="reset" value="重置" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
