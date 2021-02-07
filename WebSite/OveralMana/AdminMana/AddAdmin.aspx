<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="OveralMana_AdminMana_AddAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        #PswTb
        {
            width: 186px;
        }
        .style1
        {
            width: 25%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="AddAdmin" style="width:100%">
        <tr style="width:100%;">
            <td style="text-align:left;" colspan="2">&gt;&gt;添加管理员</td>
        </tr>
        <tr style="width:100%;">
            <td style="text-align:right;" class="style1">用户名</td>
            <td style="text-align:left;">
                <asp:TextBox ID="UserNameTb" runat="server" Width="189px"></asp:TextBox>
                    </td>
        </tr>
        <tr style="width:100%;">
            <td style="text-align:right;" class="style1">密码</td>
            <td style=" text-align:left;">
                <input type="password" ID="PswTb" runat="server" />
            </td>
        </tr>
         <tr style="width:100%;">
            <td style="text-align:right;" class="style1">权限</td>
            <td style=" text-align:left;">
                <asp:CheckBoxList ID="AuthCbl" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="auth_name" DataValueField="auth_id" 
                    RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:shuakaConnectionString %>" 
                    
                    SelectCommand="SELECT [auth_id], [auth_name] FROM [mana_auth] WHERE ([auth_id] &lt;&gt; @auth_id)" 
                    DeleteCommand="DELETE FROM [mana_auth] WHERE [auth_id] = @auth_id" 
                    InsertCommand="INSERT INTO [mana_auth] ([auth_name]) VALUES (@auth_name)" 
                    UpdateCommand="UPDATE [mana_auth] SET [auth_name] = @auth_name WHERE [auth_id] = @auth_id">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="auth_id" Type="Decimal" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="auth_id" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="auth_name" Type="String" />
                        <asp:Parameter Name="auth_id" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="auth_name" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                    </td>
        </tr>
        
        
         <tr style="width:100%;">
            <td style="text-align:right;" class="style1">
                &nbsp;</td>
            <td style=" text-align:left;">
                <button ID="CancelBtn" runat="server" type="reset" >取消</button>.
                <asp:Button ID="EnsureBtn" runat="server" onclick="EnsureBtn_Click" Text="添加" />
                    </td>
        </tr>
        
        
    </table>
    </div>
    </form>
</body>
</html>
