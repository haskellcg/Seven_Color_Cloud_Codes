<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsPage.aspx.cs" Inherits="UnionNewsMana_NewsPage" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻页面</title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width:100%">
    <tr>
    <td>
    >>>新闻展示
    </td>
    </tr>


    <tr align=center>
    <td>
    <%= newstitle%>  
    </td></tr>
    <tr align=center>
    <td>
    发布人：<%=newspub%>  发布时间：<%=newstime %></td></tr>
    
    <tr>
    <td>
    <%=newstext %>
    </td></tr>
   


    
    </table>
    </div>
    </form>
</body>
</html>
