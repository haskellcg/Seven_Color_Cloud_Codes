<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddMemberMana.aspx.cs" Inherits="MemberMana_AddMemberMana" Title="会员信息登记" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    <script src="../JS/WebCalendar.js" type="text/javascript"></script>
    <script src="../JS/jquery.js" type="text/javascript"></script>
    <script src="../JS/jquery.validate.js" type="text/javascript"></script>
    <script src="../JS/jquery.form.js" type="text/javascript"></script>
    <script src="../JS/messages_cn.js" type="text/javascript"></script>
    <script type="text/javascript">
    
	$().ready(function() {
		$("#aspnetForm").validate({
			rules : {
				
				ctl00$ContentBar$MerMemReg_MemName: {
					required : true,
					rangelength : [ 1, 20 ]
				},
				ctl00$ContentBar$MerMemReg_Psw : {
					required : true,
					rangelength : [ 6, 20 ]
				},
				ctl00$ContentBar$MerMemReg_Psw2 : {
					required : true,
					equalTo: "#ctl00_ContentBar_MerMemReg_Psw"
				},
				ctl00$ContentBar$MerMemReg_Phone : {
				    required : true,
				    digits : true,
				    rangelength : [ 8, 11]
				},
				ctl00$ContentBar$MerMemReg_LiID : {
					required : true,
                    rangelength : [10,22]
		        },
				ctl00$ContentBar$MerMemReg_MemAddress : {
					required : true,
					rangelength : [ 5, 20 ]
				},
				ctl00$ContentBar$MerMemReg_Email : {
					required : true,
					email : true
				},
				ctl00$ContentBar$MerMemReg_Optor : {
					required : true,
					rangelength : [ 1, 20 ]
				},
				ctl00$ContentBar$MerMemReg_Money : {
					required : true,
					rangelength : [ 0, 20 ]
				},					
			},
			success : function(label) {
				// set &nbsp; as text for IE
				label.html("&nbsp;").addClass("checked");
				//label.addClass("valid").text("Ok!")
			}
		});
	});
</script>
<style type="text/css">
            .input {
	            float: left;
	            margin-left: 20px;
            }

            input.error {
	            border: 1px solid red;
            }

            label.error {
	            float: right;
	            font-weight: bold;
	            color: #EA5200;
            }

            label.valid 	  
            {
            	display:block;          
            }
           .style1
            {
                width: 80%;
                float:left;
            }
            .style2
            {
                width: 50%;
                text-align:right;
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
                    会员信息注册</td>
            </tr>
          
           <tr>
                <td class="style2">
                    会员姓名(*)</td>
                <td>
                    <input type="text" ID="MerMemReg_MemName" name="MerMemReg_MemName" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td class="style2">
                    密码(*)</td>
                <td>
                    <input type="password" ID="MerMemReg_Psw" name="MerMemReg_Psw" runat="server" />
            
                </td>
            </tr>
            <tr>
                <td class="style2">
                    重复密码(*)</td>
                <td>
                    <input type="password" ID="MerMemReg_Psw2" name="MerMemReg_Psw2" runat="server" />
            </tr>
                </td>
            </tr>
            
            <tr>
                <td class="style2">
                    手机号码(*)</td>
                <td>
                    <input type="text" ID="MerMemReg_Phone" name="MerMemReg_Phone" runat="server"/>
                </td>
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
                <td class="style2">
                    证件号(*)</td>
                <td>
                    <input type="text" ID="MerMemReg_LiID" name="MerMemReg_LiID" runat="server"/>

                </td>
            </tr>


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
                <td class="style2">
                    家庭地址</td>
                <td>
                    <input type="text" ID="MerMemReg_MemAddress" name="MerMemReg_MemAddress" runat="server"/>

                </td>
            </tr>
            <tr>
                <td class="style2">
                    Email地址</td>
                <td>
                    <input type="text" ID="MerMemReg_Email" name="MerMemReg_Email" runat="server"/>

                </td>
            </tr>
            <tr>
                <td class="style2">
                    操作人(*)</td>
                <td>
                    <input type="text" ID="MerMemReg_Optor" runat="server"/>

                </td>
            </tr>
            
       
          
            
            
                 <tr>
                <td class="style2">
                    余额(*)</td>
                <td>
                    <input type="text" ID="MerMemReg_Money" runat="server"/>

                </td>
            </tr>
            
            <tr>
                <td class="style2">

                <td><asp:Button ID="Button1" 
                        runat="server" onclick="Button1_Click" style="height: 30px" Text="注册" />
                    <input id="MerMemReg_Reset" type="reset" value="重置" style=" height:30px;" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</section>
</asp:Content>

