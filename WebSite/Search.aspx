<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Search.aspx.cs" Inherits="Search" %>


<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ca</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <%--<script src="JS/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script> 
    --%>
    <style type="text/css" media="screen">
    body
    {
        font:11px arial;
    }
    /*设置提示提示列表上的样式表*/
    .search_link
    {         
         background-color:#FFFFFF;
         cursor: pointer;
         line-height:24px;
         text-indent:6px;
    }
    /*设置当鼠标移动到提示列表上的样式表*/
    .search_link_over
    {     
         background-color:#E8F2FE;
         cursor: pointer;
         line-height:24px;
         text-indent:6px;

    }
    
    /*设置显示搜索提示div的样式表*/
    #search_div
    {
        position:absolute;
        background-color:#FFFFFF;
        text-align:left;
        border:1px solid #000000;
        border-top:0px;
        display:none;
        min-width:553px;
        width:553px;
    }
    
    /*文本框样式*/
    .mainInput  {
    line-height: 26px;
    height: 28px;
    width: 550px;
    font-size: 16px;
    font-family: "微软雅黑", "宋体", Candara;
    font-weight: normal;
    color: #666;
    margin: auto;
    border: none;
    text-indent: 8px;
}
    
    /*鼠标放上文本框样式*/
    .mainInputOver  {
    width:552px;
    height:30px;
    border-top-width: 1px;
    border-right-width: 1px;
    border-bottom-width: 1px;
    border-left-width: 1px;
    border-top-style: solid;
    border-right-style: solid;
    border-bottom-style: solid;
    border-left-style: solid;
    border-top-color: #b7b7b7;
    border-right-color: #d0d0d0;
    border-bottom-color: #d0d0d0;
    border-left-color: #d0d0d0;
}
/*鼠标离开文本框样式*/
.mainInputFocus  {
    width:552px;
    height:30px;
    border: 1px solid #41b5f2;
}

/*点击文本框样式*/
.myBorder
{
    width:552px;
    height:30px;
    border-top: 1px solid #CCCCCC;
    border-bottom: 1px solid #DDDDDD;
    border-left: 1px solid #DDDDDD;
    border-right: 1px solid #DDDDDD;    
}
    </style>
<script type="text/javascript">
    var searchReq = createAjaxObj();
    var OsTyep = '';
    var isCheckDiv = true;
    var index = -1; //表示当前选中的行索引
    
    function getOs() {
        //判断浏览器类型
        if (navigator.userAgent.indexOf("MSIE") > 0) {
            document.getElementById('txtSearch').attachEvent("onpropertychange", search);
            OsTyep = "MSIE";
        } else if (navigator.userAgent.indexOf("Firefox") > 0) {
            document.getElementById('txtSearch').addEventListener("input", search, false);
            OsTyep = "Firefox";
        } else {
            document.getElementById('txtSearch').addEventListener("input", search, false);  
        }
        document.onkeydown = keyDown;
    }

    function ClearOS() {
        if (navigator.userAgent.indexOf("MSIE") > 0) {
            document.getElementById('txtSearch').detachEvent("onpropertychange", search);
            OsTyep = "MSIE";
        } else if (navigator.userAgent.indexOf("Firefox") > 0) {
            document.getElementById('txtSearch').removeEventListener("input", search, false);
            OsTyep = "Firefox";
        } else {
            document.getElementById('txtSearch').removeEventListener("input", search, false);   
        }
    }

    function createAjaxObj() {
        var httpRequest = false;

        //判断是否包含XMLHttpRequest对象 PS:将来IE高也有可能继承次对象
        if (window.XMLHttpRequest) {
            //火狐 , Safari 等浏览器
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType)
                httpRequest.overrideMimeType('text/xml');

            //ie: onpropertychange
            //ff: oninput
        } //判断是否支持Active控件对象
        else if (window.ActiveXObject) {
            //IE浏览器
            try {
                //IE5.0
                httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e) {
                try {
                    //IE5.5以上
                    httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (e) { }
            }
        }
        //返回创建好的AJAX对象
        return httpRequest;
    }
    //异步请求服务器获取搜索结果
    function search() {
//         if (searchReq.readyState == 4 || searchReq.readyState == 0) {
//            //获得文本框中的值
//             var valStr = escape(document.getElementById("txtSearch").value);
//             var ncheck;
//             if (document.getElementById("PrdRb").checked) { ncheck = "prd"; }
//             else ncheck = "mer";
//             //建立连接
//            searchReq.open("GET", encodeURI('Search.aspx?search=' + valStr + '&ch=' + ncheck), true);
//            //当请求状态改变时调用 handleSearch方法
//            searchReq.onreadystatechange = handleSearch;
//            searchReq.send(null);
        //        }
        //$("#divuser").html("nimei");
        var jsdate;
        if (document.getElementById("PrdRb").checked) { jsdate = "ch=prd"; }
        else jsdate = "ch=mer";
        jsdate += "&search=" + $("#txtSearch").val();
        $.ajax({
            type: "POST",
            url: "Search.aspx",
            data: jsdate,
            async: true,
            dataType: 'html',
            complete: function(result) {
                handleSearch(result);
            }
        });
        
    }
    

    //返回结果处理方法
    function handleSearch(searchRe) {
        //if (searchReq.readyState == 4) {
            //获得搜索提示结果的元素DIV
            var searchDIV = document.getElementById("search_div");
            
            //用''将返回的文本数据分割成数组
            var resultStrArr = searchRe.responseText.split("^");
            searchDIV.innerHTML = " ";

            //循环构建HTML代码
            for (var i = 0; i < resultStrArr.length - 1; i++) {
                var htmlStr = '<div onmouseover="selectOverDiv(this,' + i + ');" ';
                htmlStr += 'onmouseout="selectOutDiv(this,' + i + ');" ';
                htmlStr += 'onclick="setSearch(this.innerHTML);" ';
                htmlStr += 'class="search_link " style="display:block;width:100%;" >' + resultStrArr[i] + '</div>';

                searchDIV.innerHTML += htmlStr;
            }
            ShowDiv();
            index = -1;
        //}
    }
    function selectOverDiv(div_value, i) {
        div_value.className = "search_link_over";
        var my_div = document.getElementById("search_div").getElementsByTagName("div")
        var the_num = my_div.length;
        for (var k = 0; k < the_num; k++) {
            selectOut(my_div[k]);
            if (k == i) {
                selectOver(my_div[k])
            }
        }
        isCheckDiv = true;
        index = i;
    }

    function selectOutDiv(div_value, i) {
        isCheckDiv = false;
        div_value.className = "search_link";
    }
    
    function selectOver(div_value) {
        div_value.className = "search_link_over";
        isCheckDiv = true;
    }
    
    function selectOut(div_value) {
        div_value.className = "search_link";
    }
    function setSearch(value) {
        //清空文本框的内容改变事件是因为我们给选中值复制时 该事件会触发 
        //所以先清空次事件
        ClearOS();
        document.getElementById("txtSearch").value = value;
        //设置该属性为false 在调用HiddenDiv函数会隐藏提示结果DIV
        isCheckDiv = false;
        HiddenDiv();
        //在赋值完成后再次附加修改时间
        getOs();
    }

    function ShowDiv() {
        var content = document.getElementById("txtSearch").value;
        var divConten = document.getElementById("search_div").innerHTML;
        if (content != '' && divConten != '') {
            document.getElementById("search_div").style.display = "block"
        } else {
            isCheckDiv = false;
            HiddenDiv();
        }

    }
    function HiddenDiv() {
        if (isCheckDiv == false) {
            document.getElementById("search_div").style.display = "none";
            document.getElementById("search_div").innerHTML = '';
        }
    }
    function keyDown() {
        var value = event.keyCode
        //向上38，向下40，回车13
        var the_key = event.keyCode
        //判断提示DIV是否是现实状态
        if (document.getElementById("search_div").style.display != "none") {
            //获取里面所用行
            var my_div = document.getElementById("search_div").getElementsByTagName("div")
            var the_num = my_div.length;
            switch (the_key) {
                case 40: //向下
                    //判断index是否已经到最下面
                    if (index != the_num - 1) {
                        index++;
                    }
                    //清楚所有选中
                    for (var i = 0; i < the_num; i++) {
                        selectOut(my_div[i]);
                    }
                    //根据index选中对应索引行
                    for (i = 0; i < the_num; i++) {
                        if (i == index) {
                            selectOver(my_div[i])
                        }
                    }
                    break;
                case 38: //向上
                    //判断index是否已经到最上面
                    if (index != -1) {
                        index--; 
                    }
                    //清楚所有选中
                    for (var i = 0; i < the_num; i++) {
                        selectOut(my_div[i]);
                    }
                    //根据index选中对应索引行
                    for (i = 0; i < the_num; i++) {
                        if (i == index) {
                            selectOver(my_div[i])
                        }
                    }
                    break;
                case 13: //回车
                    //将选中的内容放入文本框中
                    if (my_div[index].innerHTML != null) {
                        setSearch(my_div[index].innerHTML);
                    }
                    break;
            } 
        } 
    }
    function selectPrd() {
        var PrdRb = document.getElementById("PrdRb");
        if (PrdRb.checked) {
            document.getElementById("dvPrd").style.display = "block";
            document.getElementById("dvMer").style.display = "none";
        } else {
            document.getElementById("dvMer").style.display = "block";
            document.getElementById("dvPrd").style.display = "none";
        }
    }
</script>
</head>
<body onload="getOs()" onkeydown="if(event.keyCode==13)return false;">
    <form id="form1" runat="server">
    <div>
    <div class="myBorder" onmouseover="this.className='mainInputOver'" onmouseout="this.className='myBorder'"  onclick="this.className='mainInputFocus'">
    <input type="text" id="txtSearch" runat="server" name="txtSearch" onblur="HiddenDiv()"   class="mainInput"  />
&nbsp;</div>
 <!--该DIV作为现实搜索提示的结果-->
    <div id="search_div" style="margin-top:0px" ></div>
     <asp:Button ID="SearchBtn" runat="server" onclick="SearchBtn_Click" Text="Button" />
     <input id="PrdRb" type="radio" name="ss" value="PrdRb" runat="server"  checked="true" 
     onclick="selectPrd()"  onpropertychange="selectPrd()"   />
     <label for="PrdRb">搜商品</label>
     <input id="MerRb" type="radio" name="ss" value="MerRb" runat="server" 
     onclick="selectPrd()"  onpropertychange="selectPrd()"/>
     <label for="MerRb">搜商家</label>
   
   <div id ="divuser"></div>
    
    <div style="width:100%;display:block" id="dvPrd" runat="server" >
        <asp:Label ID="Label1" runat="server" Text="所在城市"></asp:Label>
        <asp:DropDownList ID="CityDpl2" runat="server">
            <asp:ListItem Selected="True" Value="AllCity">全部城市</asp:ListItem>
        </asp:DropDownList>
            商家名称<asp:DropDownList ID="MerDpl" runat="server">
                <asp:ListItem Selected="True" Value="AllMer">所有商家</asp:ListItem>
            </asp:DropDownList>
         <div style="width:100%">
            <asp:GridView ID="PrdGrd" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="pd_name" HeaderText="商品名称" />
                <asp:BoundField DataField="pd_info" HeaderText="商品介绍" />
                <asp:BoundField DataField="pd_price" HeaderText="商品价格" />
                <asp:BoundField DataField="pd_mem_price" HeaderText="会员价格" />
                <asp:BoundField DataField="mer_name" HeaderText="所属商家" />
                <asp:BoundField DataField="city_name" HeaderText="所在地区" />
                <asp:BoundField DataField="pd_state" HeaderText="可用状态" />
                <asp:BoundField DataField="pd_note" HeaderText="备注" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="LookPrdBtn" runat="server" 
                            CommandArgument='<%# Eval("pd_id") %>' CommandName="LookPrd" 
                            oncommand="LookPrdBtn_Command" Text="禁用" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
       </div></div>
       
    <div style="width:100%;display:none" id="dvMer" runat="server" >
        <asp:Label ID="Label2" runat="server" Text="商家所在城市"></asp:Label>
            <asp:DropDownList ID="CityDpl" runat="server">
                <asp:ListItem Selected="True" Value="AllCity">全部城市</asp:ListItem>
            </asp:DropDownList>
            商家状态<asp:DropDownList ID="StateDpl" runat="server">
                <asp:ListItem Selected="True" Value="-1">全部类型</asp:ListItem>
                <asp:ListItem Value="1">已加盟</asp:ListItem>
                <asp:ListItem Value="0">待审核</asp:ListItem>
                <asp:ListItem Value="2">已拒绝</asp:ListItem>
            </asp:DropDownList> 
        <br />    
        <div style="width:100%">
            <asp:GridView ID="MerListGrd" runat="server" CellPadding="4" 
            AutoGenerateColumns="False" Width="100%" ForeColor="#333333" 
                GridLines="None"  >
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField HeaderText="商家类型" DataField="mer_type" />
                <asp:BoundField HeaderText="商家名称" DataField="mer_name" />
                <asp:BoundField HeaderText="联系地址" DataField="mer_address" />
                <asp:BoundField HeaderText="联系电话" DataField="mer_phone" />
                <asp:BoundField HeaderText="Email" DataField="reg_email" />
                <asp:BoundField HeaderText="状态" DataField="mer_state" />
                <asp:BoundField DataField="rec_mer_state" HeaderText="推荐状态" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="SendMsgBtn" runat="server" 
                            CommandArgument='<%# Eval("mer_id") %>' CommandName="SendMessage" 
                            oncommand="SendMsgBtn_Command" Text="发送消息" />
                        <asp:Button ID="LookMerBtn" runat="server" 
                            CommandArgument='<%# Eval("mer_id") %>' CommandName="LookMer" 
                            oncommand="LookMerBtn_Command" Text="查看商家" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div></div>
             
           
        
            
    <webdiyer:AspNetPager ID="MerManaPager" runat="server" 
        CurrentPageButtonPosition="Beginning" FirstPageText="首页" LastPageText="末页" 
        NextPageText="下一页" PrevPageText="上一页" UrlPaging="True" 
        AlwaysShowFirstLastPageNumber="True" PageSize="5">
    </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
