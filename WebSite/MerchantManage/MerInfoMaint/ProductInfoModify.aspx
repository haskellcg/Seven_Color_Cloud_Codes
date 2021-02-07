<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="ProductInfoModify.aspx.cs" Inherits="MerchantManage_MerInfoMaint_ProductInfoModify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SubHead" Runat="Server">
    <script src="../../JS/ProductInfoModify.js" type="text/javascript"></script>
    <title>商品信息维护</title>
    <style type="text/css">
        .style1
        {
        	text-align:right;
        	width:40%;
        	}
        #ProdMod_Introduce,#ProdMod_Info
        {
        	height:100px;
        	width:200px;
        	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubContentBar" Runat="Server">
    <form id="ProductInfoModifyForm" runat="server">
    <div>
        <table width="100%">
        <tr>
            <td colspan="2" align="center">
                商品信息维护</td>
        </tr>
        <tr>
            <td class="style1">
                商品名称(*)</td>
            <td>
                <asp:TextBox ID="ProdInfo_Name" runat="server"></asp:TextBox>
                <asp:Label ID="ProdInfo_Name_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                商品价格(*)</td>
            <td>
                <asp:TextBox ID="ProdInfo_Price" runat="server"></asp:TextBox>
                <asp:Label ID="ProdInfo_Price_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                会员价格(*)</td>
            <td>
                <asp:TextBox ID="ProdInfo_DiscountPrice" runat="server"></asp:TextBox>
                <asp:Label ID="ProdInfo_DisPrice_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                商品介绍(*)</td>
            <td>
                <asp:TextBox ID="ProdMod_Introduce" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:Label ID="ProdInfo_Introduce_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                商品图片(*)</td>
            <td>
                <asp:Image ID="ProdMod_Pic" runat="server" />
                <input id="ProdMod_PicFile" type="file" runat="server"/><asp:Label 
                    ID="ProdMod_Pic_Info" runat="server"></asp:Label>
                    </td>
        </tr>
        <tr>
            <td class="style1">
                可用状态</td>
            <td>
                <asp:DropDownList ID="ProdMod_Able" runat="server">
                    <asp:ListItem Value="1">可用</asp:ListItem>
                    <asp:ListItem Value="0">不可用</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                备注</td>
            <td>
                <asp:TextBox ID="ProdMod_Info" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="ProdMod_Info_Info" runat="server"></asp:Label>
                    </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="ProdMod_Submit" runat="server" Text="确认修改" 
                    onclick="ProdMod_Submit_Click" />
                <input id="ProdMod_Reset" type="reset" value="重置" /></td>
        </tr>
    </table>
    </div>
    </form>
</asp:Content>

