<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="MerchantBasicInfoModify.aspx.cs" Inherits="MerchantManage_MerInfoMaint_MerchantBasicInfoModify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
    <script src="../../JS/MerchantBasicInfoModify.js" type="text/javascript"></script>
    <title>商家基本信息维护</title>
    <style type="text/css">
        .style2
        {
        	text-align:right;
        	width:40%;
        	
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubContentBar" Runat="Server">
    <form id="MerchantBasicInfoModifyForm" runat="server">
    <div>
         <table width="100%">
            <tr>
                <td align="center" colspan="2">
                    商家基本信息</td>
            </tr>
            <tr>
                <td class="style2">
                    商家名称(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Name" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Name_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    商家介绍(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Introduction" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Intro_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    商家图片(*)</td>
                <td>
                    <asp:Image ID="MerInfoMod_Pic" runat="server" />
                    <input id="MerInfoMod_PicFile" type="file" runat="server"  /><asp:Label 
                        ID="MerInfoMod_Pic_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    商家地址</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Address" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Add_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    电话(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Telephone" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Tel_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    网址</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Website" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Web_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    电子邮箱</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Email" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Email_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    联系人(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Relat" runat="server"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Relat_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    星级</td>
                <td>
                    <asp:DropDownList ID="MerInfoMod_StarLevel" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    省(*)</td>
                <td>
                    <asp:DropDownList ID="MerInfoMod_Province" runat="server">
                        <asp:ListItem Value="0">四川</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    市(*)</td>
                <td>
                    <asp:DropDownList ID="MerInfoMod_City" runat="server">
                        <asp:ListItem Value="0">成都</asp:ListItem>
                    </asp:DropDownList>
                     </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="MerInfoMod_Submit" runat="server" 
                        onclick="MerInfoMod_Submit_Click" Text="提交修改" />
                </td>
                <td>
                    <input id="MerInfoMod_Reset" type="reset" value="重置信息" /></td>
            </tr>
        </table>
    </div>
    </form>
</asp:Content>

