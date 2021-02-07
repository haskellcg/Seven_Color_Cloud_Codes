<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MerPwdModify.aspx.cs" Inherits="MerchantManage_MerchantPwdModify_MerPwdModify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
<script src="../../JS/MerchantPwdModify.js" type="text/javascript">
    </script>
    <title>修改账户密码</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #MerPwdMod_Submit
        {
            height: 26px;
        }
        .style2
        {
        	height: 8px;
        }
        .style3
        {
        	height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
<form id="MerchantPwdModifyForm" runat="server">
    <div>        
        <table class="style1">
            <tr>
                <td align="center" colspan="2" class="style3">修改用户密码</td>
            </tr>
            <tr>
                <td class="style2"></td>
            </tr>
            <tr>
                <td style="text-align:right;width: 43%">原密码：</td>
                <td>
                    <input id="MerPwdMod_OldPwd" type="password" runat="server" />
                    <asp:Label ID="MerPwdMod_OldPwd_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2"></td>
            </tr>
            <tr>
                <td style="text-align:right;width: 43%">新密码：</td>
                <td>
                    <input id="MerPwdMod_NewPwd" type="password" runat="server" />
                    <asp:Label ID="MerPwdMod_NewPwd_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2"></td>
            </tr>
            <tr>
                <td style="text-align:right;width: 43%">密码确认：</td>
                <td>
                    <input id="MerPwdMod_PwdConfirm" type="password" runat="server" />
                    <asp:Label ID="MerPwdMod_PwdConfirm_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3"></td>
            </tr>
            <tr>
                <td style="text-align:right;width: 43%">
                    &nbsp;</td>
                <td>
                    &nbsp;<asp:Button ID="MerPwdMod_Submit" runat="server" 
                        onclick="MerPwdMod_Submit_Click" Text="提交" Height="34px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="MerPwdMod_Reset" type="reset" value="重置" />
                </td>
            </tr>
        </table>        
    </div>
</form>

</asp:Content>

