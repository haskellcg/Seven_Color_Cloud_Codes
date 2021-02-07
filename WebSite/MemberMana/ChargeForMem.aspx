<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeForMem.aspx.cs" Inherits="MemberMana_ChargeForMem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../js/ChargeForMem.js"></script>
    <title>在此页面充值</title>
     <style type="text/css">
        .Body_Style
        {
        	background-color:Silver;
       	}
        .Title_Style
        {
        	text-align:center;
        	font-family:@华文宋体;
        	font-weight:bold;
        	font-size:x-large;
        	color:Green;
        	height:40px;
       	}
       	.Main_Style
       	{
       		text-align:left;
       		font-family:@华文琥珀;
       		font-weight:bold;
       		font-size:medium;
       		margin-left:15%;
       		color:Green;
       		height:100px;
    	}
    	.MemID_Style
    	{
    		margin-top:10px;
   		}
   		.ReMemID_Style
   		{
   			margin-top:10px;
   		}
   		.Time_Style
   		{
   			margin-top:10px;
   		}
   		.Submit_Style
   		{
   			margin-top:10px;
   			margin-left:40px;
   		}
    </style>
</head>
<body class="Body_Style">
    <form id="form1" runat="server">
    <div>
        <div class="Title_Style">
            充值页面
        </div>
        <div class="Main_Style">
            <div class="MemID_Style">
                会员的ID：<asp:TextBox ID="Charge_MemID" runat="server"></asp:TextBox>
                <asp:Label ID="Charge_MemID_Info" runat="server" Text=""></asp:Label>
            </div>
            <div class="ReMemID_Style">
                再次输入：<asp:TextBox ID="Charge_ReMemID" runat="server"></asp:TextBox>
                <asp:Label ID="Charge_ReMemID_Info" runat="server" Text=""></asp:Label>
            </div>
            <div class="Time_Style">
                充值金额：<asp:TextBox ID="Charge_Money" runat="server"></asp:TextBox>
                <asp:Label ID="Charge_Money_Info" runat="server" Text=""></asp:Label>
            </div>
            <div class="Submit_Style">
                <div>
                <asp:Button ID="Charge_Submit" runat="server" Text="充值" 
                    onclick="Charge_Submit_Click" />
                <input id="Charge_Reset" type="reset"
                    value="重置" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
