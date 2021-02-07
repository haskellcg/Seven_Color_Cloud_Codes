function IsMore(value,length)
{
    return value.length>length;
}

function IsLess(value,length)
{
    return value.length<length;
}

function IsNull(value)
{
    var valueStr=new String(value);
    return (valueStr=="");
} 

function IsNumber(value)
{
   return (/^([0-9]*|\d*.\d{1}?\d*)$/).test(value);
}

function IsImgFile(value)
{
    var valueStr=new String(value);
    var strArray=valueStr.split(".");
    return /jpg|ico|bmp|png|gif/.test(strArray[strArray.length-1].toLowerCase());
}

window.onload=function()
{   
    
    var ProdMod_Submit=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdMod_Submit");
    ProdMod_Submit.disabled=true;
    
    var ProdInfo_Name_Flag=false;
    var ProdInfo_Price_Flag=false;
    var ProdInfo_DiscountPrice_Flag=false;
    var ProdInfo_Introduce_Flag=false;
    var ProdMod_Info_Flag=true;
    
    function SubmitCheck()
    {
        ProdMod_Submit.disabled=!(ProdInfo_Price_Flag & ProdInfo_Name_Flag & ProdInfo_DiscountPrice_Flag & ProdInfo_Introduce_Flag & ProdMod_Info_Flag);
    }
    
    
    var ProdInfo_Name=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_Name");
    var ProdInfo_Name_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_Name_Info");
    ProdInfo_Name.onfocus=function()
    {
        ProdInfo_Name_Info.innerHTML="<span style='color:Red;'>请输入1~50的字数</span>";
    }
    ProdInfo_Name.onblur=CheckName;
    ProdInfo_Name.onkeyup=CheckName;
    function CheckName()
    {
        if(IsMore(ProdInfo_Name.value,50))
        {
            ProdInfo_Name_Info.innerHTML="<span style='color:Red;'>输入字数大于50，请重新输入！</span>";
            ProdInfo_Name_Flag=false;
        }else if(IsLess(ProdInfo_Name.value,1))
        {
            ProdInfo_Name_Info.innerHTML="<span style='color:Red;'>输入字数少于1，请重新输入！</span>";
            ProdInfo_Name_Flag=false;
        }else
        {
            ProdInfo_Name_Info.innerHTML="输入正确";
            ProdInfo_Name_Flag=true;
        }
        
        SubmitCheck();
    }
    
    
    var ProdInfo_Price=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_Price");
    var ProdInfo_Price_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_Price_Info");
    var ProdInfo_DiscountPrice=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_DiscountPrice");
    var ProdInfo_DisPrice_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_DisPrice_Info");

    ProdInfo_Price.onblur=CheckPrice;
    ProdInfo_Price.onkeyup=CheckPrice;
    function CheckPrice()
    {   
        if(!IsNumber(ProdInfo_Price.value))
        {
            ProdInfo_Price_Info.innerHTML="<span style='color:Red;'>错误,请输入数字</span>";
            ProdInfo_Price_Flag=false;
            
        }else
        {
            ProdInfo_Price_Info.innerHTML="正确";
            ProdInfo_Price_Flag=true;
        }
        SubmitCheck();
    }
    

    ProdInfo_DiscountPrice.onblur=CheckDisPrice;
    ProdInfo_DiscountPrice.onkeyup=CheckDisPrice;
    function CheckDisPrice()
    {   
        if(!IsNumber(ProdInfo_DiscountPrice.value))
        {
            ProdInfo_DisPrice_Info.innerHTML="<span style='color:Red;'>错误,请输入数字</span>";
            ProdInfo_DiscountPrice_Flag=false;
        }else
        {
            ProdInfo_DisPrice_Info.innerHTML="正确";
            ProdInfo_DiscountPrice_Flag=true;
        }
        SubmitCheck();
    }
    
    var ProdInfo_Introduce=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdMod_Introduce");
    var ProdInfo_Introduce_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdInfo_Introduce_Info");
    
    ProdInfo_Introduce.onfocus=function()
    {
        ProdInfo_Introduce_Info.innerHTML="<span style='color:Red;'>字数限制10~200</span>";
    }
    ProdInfo_Introduce.onblur=CheckIntro;
    ProdInfo_Introduce.onkeyup=CheckIntro;
    function CheckIntro()
    {
        if(IsMore(ProdInfo_Introduce.value,200))
        {
             ProdInfo_Introduce_Info.innerHTML="<span style='color:Red;'>输入字数大于200,请重新输入！</span>";
             ProdInfo_Introduce_Flag=false;
        }else if(IsLess( ProdInfo_Introduce.value,10))
        {
            ProdInfo_Introduce_Info.innerHTML="<span style='color:Red;'>输入字数小于10,请重新输入！</span>"; 
            ProdInfo_Introduce_Flag=false;  
        }else
        {
            ProdInfo_Introduce_Info.innerHTML="输入正确";
            ProdInfo_Introduce_Flag=true;
        }
       SubmitCheck();
    }
    
    var ProdMod_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdMod_Info");
    var ProdMod_Info_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdMod_Info_Info");
    ProdMod_Info.onfocus=function()
    {
        ProdMod_Info_Info.innerHTML="<span style='color:Red;'>限制字数，不得多于200字</span>";
    }
    ProdMod_Info.onblur=CheckInfo;
    ProdMod_Info.onkeyup=CheckInfo;
    function CheckInfo()
    {
        
        if(IsMore(ProdMod_Info.value,200))
        {
            ProdMod_Info_Info.innerHTML="<span style='color:Red;'>字数多于200，请重新输入！</span>";
            ProdMod_Info_Flag=false;
        }else
        {
            ProdMod_Info_Info.innerHTML="输入正确";
            ProdMod_Info_Flag=true;
        }
        
        SubmitCheck();
    }
    
    var ProdMod_Pic=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdMod_Pic");
    var ProdMod_UploadF=document.getElementById("ctl00_ctl00_ContentBar_MerContent_uploadF");
    var ProdMod_Pic_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_ProdMod_Pic_Info");
    
    ProdMod_UploadF.onfocus=function()
    {
    }
  
    CheckDisPrice();
    CheckInfo();
    CheckIntro();
    CheckName();
    CheckPrice();
}