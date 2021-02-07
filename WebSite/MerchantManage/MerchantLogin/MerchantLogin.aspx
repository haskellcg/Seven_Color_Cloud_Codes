<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="MerchantLogin.aspx.cs" Inherits="MerchantManage_MerchantLogin_MerchantLogin" Title="商家登陆" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../JS/MerchantLogin.js" type="text/javascript"></script>
    <title>商家登录页面</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        	width: 43%;
            height: 22px;
        }
        .style3
        {
            height: 8px;
        }
        .style4
        {
        	height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SearchBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBar" Runat="Server">

<form id="MerchantLoginForm" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td style="text-align:right;" class="style2"></td>
                <td class="style4">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 用户登录</td>
            </tr>
            <tr>
                <td class="style3"></td>
            </tr>
            <tr>
                <td style="text-align:right;width:43%">用户名：</td>
                <td>
                    <asp:TextBox ID="MerLog_Name" runat="server"></asp:TextBox>
                    <asp:Label ID="MerLog_Name_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3"></td>
            </tr>
            <tr>
                <td style="text-align:right;width:43%" align="right">密&nbsp;&nbsp; 码：</td>
                <td>
                    <input id="MerLog_Pwd" type="password" runat="server"/>
                    <asp:Label ID="MerLog_Pwd_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4"></td>
            </tr>
            <tr>
                <td style="width:40%"></td>
                <td>
                    <asp:Button ID="MerLog_Submit" runat="server" 
                        onclick="MerLog_Submit_Click" Text="登录" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="MerLog_Reg" runat="server" Text="注册" 
                        onclick="MerLog_Reg_Click" />
                </td>
            </tr>
        </table>
    </div>
</form>

</asp:Content>

