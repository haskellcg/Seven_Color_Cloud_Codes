<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="MerchantJoin.aspx.cs" Inherits="MerchantManage_MerchantJoin_MerchantJoin" Title="商家加盟" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>欢迎加盟七彩云</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 242px;
        }
        #Text1
        {
            height: 120px;
            width: 172px;
        }
        .style2
        {
            width: 43%;
            height: 26px;
        }
        .style3
        {
            height: 26px;
        }
        #MerJoin_Info
        {
            height: 155px;
            width: 178px;
        }
        #TextArea1
        {
            height: 122px;
            width: 178px;
        }
        #TextArea
        {
            height: 109px;
        }
        .style5
        {
            height: 30px;
        }
        .style9
        {
            width: 43%;
        }
        .style10
        {
            height: 30px;
            width: 43%;
        }
        .style11
        {
            height: 8px;
        }
        .style12
        {
            width: 43%;
            height: 22px;
        }
        .style14
        {
            height: 22px;
        }
        .style15
        {
            height: 62px;
        }
        .style16
        {
            height: 28px;
            width: 43%;
        }
        .style17
        {
            height: 28px;
        }
    </style>
    <script type="text/javascript" src ="../../JS/MerchainJoin.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SearchBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBar" Runat="Server">
<section id="maincontainer" class="container clearfix">

<h1 class="heading1"><img src="../../images/logo.gif">
   <div style="float:right; margin-right:330px; font-weight:600;"><h5>商家入盟</h5></div>
  </h1>

<form id="MerchantJoinForm" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="style1">
            <tr>
                <td align="left" colspan="2">&gt;&gt;商家加盟信息</td>
            </tr>
            <tr>
                <td class="style15"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style12"></td>
                <td class="style14">&nbsp; 商家信息</td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">商家名称：</td>
                <td>
                    <asp:TextBox ID="MerJoin_Name" runat="server"></asp:TextBox>
                    <asp:Label ID="MerJoin_Name_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">商家类型：</td>
                <td>
                    <asp:DropDownList ID="MerJoin_Type" runat="server">
                        <asp:ListItem Value="1">饮食</asp:ListItem>
                        <asp:ListItem Value="2">住房</asp:ListItem>
                        <asp:ListItem Value="3">旅行</asp:ListItem>
                        <asp:ListItem Value="4">游玩</asp:ListItem>
                        <asp:ListItem Value="5">购物</asp:ListItem>
                        <asp:ListItem Value="6">娱乐</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
                        <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style16">
                    注册手机（登陆用）：</td>
                <td class="style17">
                    <asp:TextBox ID="MerJoin_RelaTelePhone" runat="server" ></asp:TextBox>
                    <asp:Label ID="MerJoin_RelaTelephone_Info" runat="server"></asp:Label>
                </td>
            </tr>
            
            
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">商家密码：</td>
                <td>
                    <input id="MerJoin_Pwd" type="password" runat="server" />
                    <asp:Label ID="MerJoin_Pwd_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">请再次输入密码：</td>
                <td>
                    <input id="MerJoin_Pwd2" type="password" runat="server" />
                    <asp:Label ID="MerJoin_Pwd_Info2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">所在城市：</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="Provinceddl" runat="server"  AutoPostBack="true" 
                                onselectedindexchanged="Provinceddl_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="Cityddl" runat="server" >
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>                   
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">会员折扣比例：</td>
                <td>
                    <asp:DropDownList ID="MerJoin_MemberDiscountRate" runat="server">
                        <asp:ListItem>10%</asp:ListItem>
                        <asp:ListItem>20%</asp:ListItem>
                        <asp:ListItem>30%</asp:ListItem>
                        <asp:ListItem>40%</asp:ListItem>
                        <asp:ListItem>50%</asp:ListItem>
                        <asp:ListItem>60%</asp:ListItem>
                        <asp:ListItem>70%</asp:ListItem>
                        <asp:ListItem>80%</asp:ListItem>
                        <asp:ListItem>90%</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style10">联系地址：</td>
                <td class="style5">
                    <asp:TextBox ID="MerJoin_Address" runat="server"></asp:TextBox>
                    <asp:Label ID="MerJoin_Address_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style2">商家网址：</td>
                <td class="style3">
                    <asp:TextBox ID="MerJoin_WebSite" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style10">联系电话：</td>
                <td class="style5">
                    <asp:TextBox ID="MerJoin_Phone" runat="server"></asp:TextBox>
                    <asp:Label ID="MerJoin_Phone_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style2">
                    邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 编：</td>
                <td class="style3">
                    <asp:TextBox ID="MerJoin_PostCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">商家介绍：</td>
                <td>
                    <textarea id="MerJoin_Info" name="S1" rows="3" cols="20" 
                    runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
        </table>        
    </div>
        <table class="style1">
            <tr>
                <td style="text-align:right;" class="style12"></td>
                <td class="style14">&nbsp;&nbsp; 联系人信息</td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">
                    姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名：</td>
                <td>
                    <asp:TextBox ID="MerJoin_RelaName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">
                    职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 务：</td>
                <td>
                    <asp:TextBox ID="MerJoin_RelaDuty" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">
                    电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 话：</td>
                <td>
                    <asp:TextBox ID="MerJoin_RelaPhone" runat="server"></asp:TextBox>
                    <asp:Label ID="MerJoin_RelaPhone_Info" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style11"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9">电子邮箱地址：</td>
                <td>
                    <asp:TextBox ID="MerJoin_RelaEmail" runat="server" >
                    </asp:TextBox>
                    <asp:Label ID="MerJoin_RelaEmail_Info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style14"></td>
            </tr>
            <tr>
                <td style="text-align:right;" class="style9"></td>
                <td>
                    <asp:Button ID="MerJoin_Submit" runat="server" 
                    onclick="MerJoin_Submit_Click" Text="提交" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="MerJoin_Reset" type="reset" value="重置" />
                </td>
            </tr>
        </table>
   </form>
</section>   
</asp:Content>

