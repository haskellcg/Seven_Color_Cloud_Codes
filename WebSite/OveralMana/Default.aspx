<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="OveralMana_Default" Title="欢迎使用七彩云刷卡积分管理系统" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../css/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadBar" Runat="Server">
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="link1">
                    <tr>
                        <td width="75%" height="50">
                            &nbsp;<img alt="" src="../Images/logo.gif" />
                        </td>
                        <td width="25%" style="padding-top: 23px;">
                            欢迎您:<%=userName%>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label> | <a href="../SysMana/SysModifyPsw.aspx" target="frmMain">修改密码</a> | <a href="../SysMana/SysLogout.aspx" target="_top">
                                退出系统</a>
                        </td>
                    </tr>
                </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SearchBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBar" Runat="Server">
 <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style=" margin-left:0%; margin-top:-80px;">
        <tr>
            <td>
                <table border="0" style="margin-top: 1px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="padding: 0px;">
                        <div style="width:186px; height:600px; margin:0 0 0 0; padding:0 0 0 0; float:left;" id="frmLeft">
                            <asp:TreeView ID="ManaTree" runat="server" ImageSet="Arrows" ExpandDepth="3" >
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                                <Nodes>
                                    <asp:TreeNode NavigateUrl="http://www.baidu.com" ShowCheckBox="False" 
                                        Text="系统综合管理平台" Value="root" SelectAction="None"></asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="微软雅黑" Font-Size="15pt" ForeColor="Black" 
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
                       <td style="width:5%">
                       </td>
                        <td width="100%" valign="top" style="padding: 0px;">
                            <iframe width="90%" height="550" id="frmMain"
                                name="frmMain" scrolling="auto"  frameborder="0"></iframe>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>

