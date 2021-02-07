<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUnionNews.aspx.cs" Inherits="UnionNewsMana_EditUnionNews" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑新闻</title>
     <script src="../js/WebCalendar.js" type="text/javascript"></script>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/jquery.validate.js" type="text/javascript"></script>
    <script src="../js/jquery.form.js" type="text/javascript"></script>
    <script src="../js/messages_cn.js" type="text/javascript"></script>
    <script type="text/javascript">
    	$().ready(function() {
		$("#form1").validate({
			rules : {
				NewsTitle : {
					required : true,
					rangelength : [ 1, 20 ],
				},
				NewsPublisher: {
					required : true,
					rangelength : [ 1, 20 ],
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

            label.valid {
	            display: hidden;
            }
</style>


</head>

<body>
    <form id="form1" runat="server">
    <div>
    <table style="width:80%; float:left;">
    <tr>
    <td>
    >>>新闻编辑
    </td>
    </tr>
    
    <tr>
    <td>
    新闻标题：
    </td>
    <td>
        <asp:TextBox ID="NewsTitle" runat="server" Width="900px"></asp:TextBox>
    </td>
    </tr>
    
        <tr>
    <td>
    新闻内容：
    </td>
    <td>
        <FCKeditorV2:FCKeditor ID="NewsFCKeditor1" runat="server" Width="900px" Height="450px">
        
        </FCKeditorV2:FCKeditor>
    </td>
    </tr>
    
    <tr>
    <td>
    新闻作者：
    </td>
    <td>
        <asp:TextBox ID="NewsPublisher" runat="server"></asp:TextBox>
    </td>
    </tr>
    
<%--    <tr>
    <td>
    新闻时间：
    </td>
    <td>
        <asp:TextBox ID="NewsTime" runat="server"></asp:TextBox>
    </td>
    </tr>--%>
    
    <tr>
    <td>
    </td>
    <td>
        <asp:Button ID="NewsEditSave" runat="server" Text="保存" 
            onclick="NewsEditSave_Click" />
        <asp:Button ID="NewsEditRtn" runat="server" Text="返回" 
            onclick="NewsEditRtn_Click" />
    </td></tr>
    
    </table>
    </div>
    </form>
</body>
</html>
