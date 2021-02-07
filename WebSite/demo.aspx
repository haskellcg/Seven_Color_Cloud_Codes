<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="demo" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--    <asp:DataList ID="dLGoodsList" runat="server" RepeatColumns="3" 
            RepeatDirection="Horizontal" OnItemCommand="dLGoodsList_ItemCommand" 
            DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                         <table border=0; cellpadding =0; cellspacing =0 style ="vertical-align :top ;  height: 120px">
                            <tr>
                                <td rowspan="5" style="width: 29px">
                                 <asp:Image ID="imageIcon" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/>
                                </td>
                                <td colspan="2">
                                <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="detailSee"  Font-Underline=false  CommandArgument =<%#DataBinder.Eval(Container.DataItem, "BookID")%>>
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </asp:LinkButton>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    市场价：</td>
                                <td>
                                 <%#GetVarMKP(DataBinder.Eval(Container.DataItem, "MarketPrice").ToString())%>￥
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    热卖价：</td>
                                <td>
                                  <%#GetVarHot(DataBinder.Eval(Container.DataItem, "HotPrice").ToString())%>￥
                                </td>
                            </tr>
                             <tr>
                                <td colspan="2">
                                    <asp:ImageButton ID="imagebtnBuy" runat="server" CommandName="buy" CommandArgument =<%#DataBinder.Eval(Container.DataItem, "BookID")%> ImageUrl="~/images/购买.jpg" />
                                    </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>--%>


    </div>
    </form>
</body>
</html>
