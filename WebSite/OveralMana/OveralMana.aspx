<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OveralMana.aspx.cs" Inherits="OveralMana_OveralMana" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>欢迎使用七彩云刷卡积分管理系统</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var leftWidth = 256;
        function HideList() {
            var pic = document.getElementById("imgpic");
            document.getElementById("frmLeft").style="width:150px";
            if (frmLeft.displayWidth == "0") {

                pic.src = "../Images/21b.jpg";
            }
            else {
                pic.src = "../Images/21.jpg";
            }

            var width = frmLeft.width;
            frmLeft.width = 256;
            leftWidth = width;

        }
    </script>
</head>
<body style="margin: 0 auto; background-color: #0a6c6d;">
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="1231" height="120" valign="bottom" background="../Images/top_001.jpg">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="link1">
                    <tr>
                        <td width="65%" height="50">
                            &nbsp;
                        </td>
                        <td width="35%" style="padding-top: 23px;">
                            欢迎您: 
                            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label> | <a href="Changepsw.aspx" target="frmMain">修改密码</a> | <a href="../SysMana/SysLogout.aspx" target="_top">
                                退出系统</a>
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" style="margin-top: 1px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="padding: 0px;">
                        <div style="width:186px; height:600px; margin:0 0 0 0; padding:0 0 0 0; float:left;" id="frmLeft">
                            <asp:TreeView ID="ManaTree" runat="server" ImageSet="Arrows" ExpandDepth="1" >
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                                <Nodes>
                                    <asp:TreeNode NavigateUrl="http://www.baidu.com" ShowCheckBox="False" 
                                        Text="系统综合管理平台" Value="root" SelectAction="None"></asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="宋体" Font-Size="15pt" ForeColor="Black" 
                                    HorizontalPadding="5px" NodeSpacing="3px" VerticalPadding="3px" BackColor="" />
                            </asp:TreeView>
                        </div>
                        
                           <!-- <iframe width="186" scrolling="no" height="600" marginheight="0" marginwidth="0"
                                style="padding: 0px; margin: 0px;" displayWidth='0' frameborder="0" id="frmLeft"
                                name="frmLeft" src="Left.aspx"></iframe> !-->
                        </td>
                        <td valign="middle" width="10">
                            <table background="../Images/22.jpg" width="100%" height="100%" border="0" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td style="cursor: hand" onclick="HideList()">
                                        <div align="center">
                                            <img src="../Images/21.jpg" id="imgpic" border="0" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="100%" valign="top" style="padding: 0px;">
                            <iframe width="100%" height="600" id="frmMain" src="Main.aspx"
                                name="frmMain" scrolling="auto"  frameborder="0"></iframe>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
