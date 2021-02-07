<%@ Page Language="C#" MasterPageFile="~/MerchantMaster.master" AutoEventWireup="true" CodeFile="MerReplyMana.aspx.cs" Inherits="MerchantManage_CommentMana_MerReplyMana" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MerHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MerContent" Runat="Server">
<section id="maincontainer" class="container clearfix">
<div style="width:100%" align="center">
    <h1>消费点评</h1>
     <form id="Form1" runat="server">
     
         <table  id="replyPage" style=" width:80%;">
            <tr>
                <td style=" width:15%;">
                    <label for="comment-name">点评内容<span class="required">*</span>:</label></td>
                <td  width="85%">
                    <asp:Label ID="MerComRe_Content" runat="server"
                        Rows="3" TextMode="MultiLine" Width="90%"
                        ToolTip="在这里输入您的点评" ReadOnly="True" Text="" Font-Size="Larger"></asp:Label>
                </td>
            </tr>
            <tr>
            <td><br /></td>
            </tr>
            <tr>
                <td style=" width:15%;">
                    <label for="comment-name">留言IP<span class="required">*</span>:</label></td>
                <td >
                    <asp:Label ID="TBip" runat="server" ReadOnly="True" Text="" Width="60%"></asp:Label>
                </td>
            </tr>
             <tr>
            <td><br /></td>
            </tr>
            <tr>
                <td style=" width:15%;">
                    <label for="comment-name">留言人姓名<span class="required">*</span>:</label></td>
                <td ><asp:Label ID="TBname" runat="server" ReadOnly="True" Text="" Width="60%"></asp:Label></td>
            </tr>
             <tr>
            <td><br /></td>
            </tr>
            <tr>
                <td style=" width:15%;">
                    <label for="comment-name">留言时间<span class="required">*</span>:</label></td>
                <td >
                    <asp:Label ID="TBtime" runat="server" ReadOnly="True" Text="" Width="60%"></asp:Label></td>
            </tr>
              <tr>
            <td><br /></td>
            </tr>
            <tr>
            <td colspan="2"><label for="comment-name" style="font-size:large;">我来回复:</label></td>
            </tr>
             <tr>
            <td><br /></td>
            </tr>
            <tr>
                <td  colspan="2">
                   <asp:TextBox ID="MerComRe_Reply" runat="server" TextMode="MultiLine" Width="100%" 
            Rows="6" Font-Size="Larger" Text=""></asp:TextBox></td>
            </tr>
              <tr>
            <td><br /></td>
            </tr>
            <tr>
            <td>
            <asp:Button ID="Button1" runat="server" Text="提交" oncommand="Button1_Command"  />
            </td>
            <td>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="MerComRe_Reply" ErrorMessage="回复内容不能为空"></asp:RequiredFieldValidator>
            </td>
            </tr>
        </table>
    </form>
    </div>
</section>
</asp:Content>

