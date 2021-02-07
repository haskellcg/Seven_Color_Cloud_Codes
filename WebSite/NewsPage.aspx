<%@ Page Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="NewsPage.aspx.cs" Inherits="NewsPage" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RegisterAEntry" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CityBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubContentBar" Runat="Server">

    <form id="form1" runat="server">
    <div style="float:left; margin-left:15%;">
    <table align="center" width="80%">

    <tr align=center>
    <td style="font-family: 微软雅黑; font-size: large; font-weight: normal">
    <%= newstitle%><br /> <br /> 
    </td></tr>
    <tr align=center>
    <td> 
    发布人：<%=newspub%> &nbsp; &nbsp; 发布时间：<%=newstime %></td></tr>
    
    <tr>
    <td>
    <%=newstext %>
    </td></tr>
   


    
    </table>
    </div>
    </form>

</asp:Content>

