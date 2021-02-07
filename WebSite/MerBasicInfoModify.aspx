<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MerBasicInfoModify.aspx.cs" Inherits="Default2" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
   <style type="text/css">
        .Table_Style
        {
        	width:100%;
        	
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

    	.Intro_Style
    	{
    		width:300px;
    		height:150px;
    	}
    </style>
<script src="js/MerchantBasicInfoModifyMaster.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">

   <form id="MerchantBasicInfoModifyForm" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <table class="Table_Style">
            <tr>
                <td colspan="2" class="Title_Style">
                    商家基本信息<br /><br /></td>
            </tr>
            <tr>
                <td class="Label_Style">
                    商家名称(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Name" runat="server" Width="310px"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Name_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    商家介绍(*)</td>
                <td class="Intro_Style">
                    <asp:TextBox ID="MerInfoMod_Introduction" Width="300px" Height="150px" 
                        runat="server"  TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Intro_Info" runat="server"></asp:Label>
                </td>
            </tr>
             <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    商家图片</td>
                <td>
                    <div>
                    <img id="MerInfoMod_Pic" width="321" height="200"  runat="server" alt="" src="" />
                    </div>
                    <br />
                    <div>
                        <input id="uploadF" type="file"  runat="server"/><br /><br />
                    <asp:Button ID="UploadBtn" runat="server"   onclick="UploadBtn_Click" Text="上传" />
                    <asp:Label ID="MerInfoMod_Pic_Info" runat="server"></asp:Label>

                    </div>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    商家地址(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Address" runat="server" Width="310px"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Add_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    电话(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Telephone" runat="server" Width="310px"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Tel_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    网址</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Website" runat="server" Width="310px"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Web_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    电子邮箱</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Email" runat="server" Width="310px"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Email_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    联系人(*)</td>
                <td>
                    <asp:TextBox ID="MerInfoMod_Relat" runat="server" Width="310px"></asp:TextBox>
                    <asp:Label ID="MerInfoMod_Relat_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height:9px"></tr>


            <tr>
                <td class="Label_Style">
                    省(*)</td>
                <td>
                    <asp:DropDownList ID="MerInfoMod_Province" runat="server"  
                        ontextchanged="MerInfoMod_Province_TextChanged" AutoPostBack="True"> 
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td class="Label_Style">
                    市(*)</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="MerInfoMod_Province" 
                                EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                                <asp:DropDownList ID="MerInfoMod_City" runat="server" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                        </ContentTemplate>
                       
                    </asp:UpdatePanel>
                    
               </td>
            </tr>
            <tr style="height:9px"></tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td>
                    <asp:Button ID="MerInfoMod_Submit" runat="server" 
                        onclick="MerInfoMod_Submit_Click" Text="提交修改" />
                    <input id="MerInfoMod_Reset" type="reset" value="重置信息" /></td>
            </tr>
        </table>
    </div>
    </form>


</asp:Content>

