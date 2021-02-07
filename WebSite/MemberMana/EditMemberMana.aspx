<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="EditMemberMana.aspx.cs" Inherits="MemberMana_EditMemberMana" Title="会员信息维护" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../js/WebCalendar.js" type="text/javascript"></script>
    <script src="../js/MerchantMemberInfoRegist.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 40%;
            text-align:right;
        }
                .style11
        {
            height: 8px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SearchBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBar" Runat="Server">
<section id="maincontainer" class="container clearfix">

<h1 class="heading1"><img src="../images/logo.gif">
   <div style="float:right; margin-right:330px; font-weight:600;"><h5>商家管理</h5></div>
  </h1>

   <form id="MerchantMemberInfoRegForm" runat="server">
    <div>

        <table class="style1">
            <tr>
                <td align="center" colspan="2">
                    会员信息维护<br /><br /></td>
            </tr>
            
            <tr>
                <td class="style2">
                    会员姓名(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_MemName" runat="server"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style11"></td>
            </tr>
            
                        <tr>
                <td class="style2">
                    密码(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_Psw" runat="server"></asp:TextBox>

                </td>
            </tr>
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
                <td class="style2">
                    手机号码(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_Phone" runat="server"></asp:TextBox>

                </td>
            </tr>
                        <tr>
                <td class="style11"></td>
            </tr>
            


            <tr>
                <td class="style2">
                    证件类型(*)</td>
                <td>
                    <asp:DropDownList ID="MerMemReg_LicenseType" runat="server">
                        <asp:ListItem Value="0">身份证</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
                <td class="style2">
                    证件号(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_LiID" runat="server"></asp:TextBox>
                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>

<%--            <tr>
                <td class="style2">
                    性别(*)</td>
                <td>
                    <asp:RadioButton ID="MerMemReg_Male" runat="server" Text="男" 
                        GroupName="SexName" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="MerMemReg_Female" runat="server" Text="女" Checked="True" 
                        GroupName="SexName" />
                </td>
            </tr>--%>
                <tr>
                <td class="style2">
                    性别</td>
                <td>
                    <asp:DropDownList ID="MerMemReg_Male" runat="server">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
<%--            <tr>
                <td class="style2">
                    会员卡类型</td>
                <td>
                    <asp:DropDownList ID="MerMemReg_CardType" runat="server">
                        <asp:ListItem Value="0">普通卡</asp:ListItem>
                        <asp:ListItem Value="1">VIP卡</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td class="style2">
                    家庭地址</td>
                <td>
                    <asp:TextBox ID="MerMemReg_MemAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
                <td class="style2">
                    Email地址</td>
                <td>
                    <asp:TextBox ID="MerMemReg_Email" runat="server"></asp:TextBox>
                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
                <td class="style2">
                    发卡商家编号(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_MerID" runat="server"></asp:TextBox>
                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
                <td class="style2">
                    操作人(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_Optor" runat="server"></asp:TextBox>
                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
                <td class="style2">
                    操作时间(*)</td>
                <td>
                    <input id="MerMemReg_Time" runat="server" readonly="readonly" type="text" onclick="return SelectDate(this,'yyyy-MM-dd');" />
                    </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
            
                        <tr>
                <td class="style2">
                    余额(*)</td>
                <td>
                    <asp:TextBox ID="MerMemReg_Money" runat="server"></asp:TextBox>

                </td>
            </tr>
            
                        <tr>
                <td class="style11"></td>
            </tr>
            
            <tr>
            <td class="style2">
            <td>
                <asp:Button ID="EditMemSaveBtn" runat="server" Text="保存" 
                    onclick="EditMemSaveBtn_Click" />
                <asp:Button ID="EditMemRtnBtn" runat="server" Text="返回" 
                    onclick="EditMemRtnBtn_Click" />
            </td>
            </td></tr>
            

        </table>
    
    </div>
    </form>
</section>
</asp:Content>

