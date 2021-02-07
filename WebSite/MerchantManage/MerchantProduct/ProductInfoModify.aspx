<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="ProductInfoModify.aspx.cs" Inherits="MerchantManage_MerchantProduct_ProductInfoModify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
<script type="text/javascript" src="../../js/ProductInfoModifyMaster.js"></script>
    <style type="text/css">
        .Table_Style
        {
        	width:100%;
        	color:Green;
        }
        .Title_Style
        {
            text-align:center;
            vertical-align:middle;
            font-family:@华文琥珀;
            font-size:x-large;
            font-weight:bold;
       	}
    	.Label_Style
    	{
    		text-align:right;
    		vertical-align:middle;
    		font-family:@华文琥珀;
    		font-size:medium;
    		font-weight:normal;
    		width:35%;
    	}
    	.Content_Style
    	{
    	}
    	.Intro_Style
    	{
    		width:300px;
    		height:150px;
    	}
    	.Info_Style
    	{
    		width:300px;
    		height:150px;
   		}
  
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
<form id="ProductInfoModifyForm" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="Table_Style">
        <tr>
            <td colspan="2" align="center" class="Title_Style">
                商品信息维护
            </td>
        </tr>
        <tr>
            
            <td class="Label_Style">
                商品名称(*)：</td>
            <td class="Content_Style">
                <asp:TextBox ID="ProdInfo_Name" runat="server" BorderColor="#66FFFF"></asp:TextBox>
                <asp:Label ID="ProdInfo_Name_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label_Style">
                商品价格(*)：</td>
            <td class="Content_Style">
                <asp:TextBox ID="ProdInfo_Price" runat="server" BorderColor="#66FFFF" ></asp:TextBox>
                <asp:Label ID="ProdInfo_Price_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label_Style">
                会员价格(*)：</td>
            <td class="Content_Style">
                <asp:TextBox ID="ProdInfo_DiscountPrice" runat="server" BorderColor="#66FFFF"></asp:TextBox>
                <asp:Label ID="ProdInfo_DisPrice_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label_Style">
                商品介绍(*)：</td>
            <td class="Intro_Style">
                <asp:TextBox Width="300px" Height="150px" ID="ProdMod_Introduce" runat="server" TextMode="MultiLine" BorderColor="#66FFFF"></asp:TextBox>
                <asp:Label ID="ProdInfo_Introduce_Info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label_Style">
                商品图片(*)：</td>
            <td class="Content_Style">

                            <div>
                                <img id="ProdMod_Pic" width="321" height="200" runat="server" alt="" src="" />
                            </div>
                            <div>
                                <input id="uploadF" type="file"  runat="server" />
                                <asp:Button ID="UploadBtn" runat="server" onclick="UploadBtn_Click" Text="上传" />
                                <asp:Label ID="ProdMod_Pic_Info" runat="server"></asp:Label>
                            </div>

                
              </td>
        </tr>
        <tr>
            <td class="Label_Style">
                可用状态：</td>
            <td class="Content_Style">
                <asp:DropDownList ID="ProdMod_Able" runat="server">
                    <asp:ListItem Value="1">可用</asp:ListItem>
                    <asp:ListItem Value="0">不可用</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="Label_Style">
                备注：</td>
            <td class="Info_Style">
                <asp:TextBox Width="300px" Height="150px" ID="ProdMod_Info" runat="server" TextMode="MultiLine" BorderColor="#66FFFF"></asp:TextBox>
                    <asp:Label ID="ProdMod_Info_Info" runat="server"></asp:Label>
                    </td>
        </tr>
        <tr>
            <td>
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

