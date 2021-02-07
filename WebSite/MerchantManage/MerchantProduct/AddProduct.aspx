<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="MerchantManage_MerchantProduct_AddProduct" Title="添加商品" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
        <script type="text/javascript" src="../../js/AddProduct.js"></script>
    <style type="text/css">
    .Title_Style
    {
    	text-align:center;
    	font-family:@华文琥珀;
    	font-size:x-large;
    	font-weight:bolder;
    	margin-bottom:30px;
    	color:Green;
    }
    .Main_Style
    {
        height:200px;
        clear:both;
        font-family:@华文琥珀;
        font-weight:bold;
        color:Silver;
    }
    .NamePrice_Style
    {
    	float:left;
    	width:40%;
   	}
   	.Name_Style
   	{
   		height:50px;
   		text-align:right;
   		margin-right:100px;
   		margin-top:10px;
   	}
   	.Price_Style
   	{
   		height:50px;
   		text-align:right;
   		margin-right:100px;
   		margin-top:10px;
   	}
   	.MemPrice_Style
   	{
   		height:50px;
   		text-align:right;
   		margin-right:100px;
   		margin-top:10px;
	}
	.UploadPic_Style
	{
		width:60%;
		float:left;
	}
	.Pic_Style
	{
		height:150px;
		width:358px;
	}
	.Upload_Style
	{
		height:30px;
	}
	.Info_Style
	{
		height:40px;
		text-align:center;
		vertical-align:middle;
		margin-right:249px;
		margin-top:0px;
		font-family:@华文琥珀;
        font-weight:bold;
        color:Silver;
		clear:left;
	}
	.StateNote_Style
	{
		
		clear:both;
		margin-top:130px;
		margin-left:200px;
		font-family:@华文琥珀;
        font-weight:bold;
        color:Silver;
        height:70px;
	}
	.State_Style
	{
	   	float:left;
	   	
	}
	.Note_Style
	{
		margin-left:295px;
	}
	.SubRes_Style
	{
		margin-top:40px;
		text-align:right;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
    <form id="AddProduct" runat="server">

    <div class="Title_Style">
        添加商品信息
    </div>
    <div class="Main_Style">
        <div class="NamePrice_Style">
            <div class="Name_Style">
                <div>
                    名称：<asp:TextBox ID="AddPro_Name" runat="server"></asp:TextBox>
                </div>
                <div style="text-align:left;font-family:@华文行楷;font-weight:normal;margin-left:278px;margin-top:6px;">
                <asp:Label ID="AddPro_Name_Info" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="Price_Style">
                <div>
                    价格：<asp:TextBox ID="AddPro_Price" runat="server"></asp:TextBox>
                </div>
                <div style="text-align:left;font-family:@华文行楷;font-weight:normal;margin-left:278px;margin-top:6px;">
                <asp:Label ID="AddPro_Price_Info" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="MemPrice_Style">
                <div>
                    会员价格：<asp:TextBox ID="AddPro_MemPrice" runat="server"></asp:TextBox>
                </div>
                <div style="text-align:left;font-family:@华文行楷;font-weight:normal;margin-left:278px;margin-top:6px;">
                <asp:Label ID="AddPro_MemPrice_Info" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="UploadPic_Style">
            <div class="Pic_Style">
               <img id="AddPro_Pic"  runat="server" width="358" height="150" src="~/images/src/1.gif"/>
            </div>
            <div class="Upload_Style">
               <input id="uploadF" type="file"  runat="server" />
            </div>
        </div>
    </div>
    <div class="Info_Style">
        <div>
            商品简介：<asp:TextBox ID="AddPro_Intro" runat="server" TextMode="MultiLine" Width="603" Height="100"></asp:TextBox>
        </div>
        <div style="text-align:left;font-family:@华文行楷;font-weight:normal;margin-left:278px;margin-top:10px;">
        <asp:Label ID="AddPro_Intro_Info" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="StateNote_Style">
        <div class="State_Style">
            商品状态：<asp:DropDownList ID="AddPro_State" runat="server">
                <asp:ListItem Value="1">可用</asp:ListItem>
                <asp:ListItem Value="0">不可用</asp:ListItem>
                       </asp:DropDownList>
        </div>
        <div class="Note_Style">
            <div>
                备注：<asp:TextBox ID="AddPro_Note" runat="server" TextMode="MultiLine"  Width="335" Height="50px"></asp:TextBox>
            </div>
            <div style="text-align:left;font-family:@华文行楷;font-weight:normal;margin-left:48px;margin-top:10px;">
            <asp:Label ID="AddPro_Note_Info" runat="server" Text=""></asp:Label>
            </div>
         </div>
    </div>
    <div class="SubRes_Style">
        <div style="text-align:center;margin-left:400px;">
        <asp:Button ID="AddPro_Submit" runat="server" Text="确认添加" 
                onclick="AddPro_Submit_Click" />
        <input id="AddPro_Reset" type="reset" value="重置内容" />
        </div>
    </div>
</form>
</asp:Content>

