<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysModifyPsw.aspx.cs" Inherits="SysMana_SysModifyPsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        #OldPswBtn
        {
            width: 190px;
        }
        #NewPassword1
        {
            width: 190px;
        }
        #NewPassword2
        {
            width: 188px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left; margin-left:20px; width:100%">
        <table style="width:100%">
            <tr style="width:100%">
                <td colspan="2">&gt;&gt;修改密码</td>
            </tr>
             <tr style="width:100%">
                <td style="width:30%; text-align:right;">原始密码</td>
                <td>
                    <input type="password" id="OldPswBtn" runat="server"/>
                </td>
            </tr>
             <tr style="width:100%">
                <td style="width:30%; text-align:right">新密码</td>
                <td>
                    <input type="password" id="NewPassword1" runat="server"/>
                </td>
            </tr>
             <tr style="width:100%">
                <td style="width:30%; text-align:right">确认新密码</td>
                <td>
                    <input type="password" id="NewPassword2" runat="server"/>
                </td>
            </tr>
             <tr style="width:100%">
                <td style="width:30%; text-align:right"></td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <button type="reset" value="">重置</button>
                    <asp:Button Text="提交" ID="AssureBtn" runat="server" onclick="AssureBtn_Click" />
                </td>
            </tr>
             <tr style="width:100%">
                <td style="width:30%; text-align:right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>    
    </div>
    </form>
</body>
</html>
