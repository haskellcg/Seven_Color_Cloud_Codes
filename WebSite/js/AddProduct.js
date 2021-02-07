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
    valueStr=new String(value);
    return valueStr=="";
} 

function IsNumber(value)
{
   return (/^([0-9]*|\d*.\d{1}?\d*)$/).test(value);
}


window.onload=function()
{
    var AP_Submit=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Submit");
    AP_Submit.disabled=true;
    
    var AP_Name_Flag=false;
    var AP_Price_Flag=false;
    var AP_MemPrice_Flag=false;
    var AP_Intro_Flag=false;
    var AP_Note_Flag=true;
    
    function CheckSubmit()
    {
        AP_Submit.disabled =!(AP_Name_Flag & AP_Price_Flag & AP_MemPrice_Flag & AP_Intro_Flag & AP_Note_Flag);
    }

    var AP_Name=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Name");
    var AP_Name_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Name_Info");
    AP_Name.onblur=CheckName;
    AP_Name.onkeyup=CheckName;
    function CheckName()
    {
        if(IsNull(AP_Name.value))
        {
            AP_Name_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>商品名称不可以为空！</span>";
            AP_Name_Flag=false;
        }else
        {
            AP_Name_Info.innerHTML="";
            AP_Name_Flag=true;
        }
        CheckSubmit();
    }
    
    
    var AP_Price=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Price");
    var AP_Price_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Price_Info");
    AP_Price.onblur=CheckPrice;
    AP_Price.onkeyup=CheckPrice;
    function CheckPrice()
    {
        if(IsNull(AP_Price.value))
        {
            AP_Price_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>价格为必填项！</span>";
            AP_Price_Flag=false;
        }else if(!IsNumber(AP_Price.value))
        {
            AP_Price_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>必须输入数字！</span>";
            AP_Price_Flag=false;
        }else
        {
            AP_Price_Info.innerHTML="";
            AP_Price_Flag=true;
        }
        
       CheckSubmit();
    }
    
    
    var AP_MemPrice=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_MemPrice");
    var AP_MemPrice_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_MemPrice_Info");
    AP_MemPrice.onblur=CheckMemPrice;
    AP_MemPrice.onkeyup=CheckMemPrice;
    function CheckMemPrice()
    {
        if(IsNull(AP_MemPrice.value))
        {
            AP_MemPrice_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>价格为必填项！</span>";
            AP_MemPrice_Flag=false;
        }else if(!IsNumber(AP_MemPrice.value))
        {
            AP_MemPrice_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>必须输入数字！</span>";
            AP_MemPrice_Flag=false;
        }else
        {
            AP_MemPrice_Info.innerHTML="";
            AP_MemPrice_Flag=true;
        }
        CheckSubmit();
    }
    
    var AP_Intro=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Intro");
    var AP_Intro_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Intro_Info");
    AP_Intro.onfocus=function()
    {
        AP_Intro_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>限制字数10~50</span>";
    }
    AP_Intro.onblur=CheckIntro;
    AP_Intro.onkeyup=CheckIntro;
    function CheckIntro()
    {
        if(IsMore(AP_Intro.value,50))
        {
            AP_Intro_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>字数不得大于50！</span>";
            AP_Intro_Flag=false;
        }else if(IsLess(AP_Intro.value,10))
        {
            AP_Intro_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>字数不得少于10！</span>";
            AP_Intro_Flag=false;
        }else
        {
            AP_Intro_Info.innerHTML="";
            AP_Intro_Flag=true;
        }
        CheckSubmit();
    }
    
    var AP_Note=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Note");
    var AP_Note_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Note_Info");
    AP_Note.onfocus=function()
    {
        AP_Note_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>字数限制，不得超过100！</span>";
    }
    AP_Note.onblur=CheckNote;
    AP_Note.onkeyup=CheckNote;
    function CheckNote()
    {
        if(IsMore(AP_Note.value,100))
        {
            AP_Note_Info.innerHTML="<span style='color:Red;font-family:@幼圆'>字数超过100，请重新填写！</span>";
            AP_Note_Flag=false;
        }else
        {
            AP_Note_Info.innerHTML="";
            AP_Note_Flag=true;
        }
        CheckSubmit();
    }
    
    var AP_Pic=document.getElementById("ctl00_ctl00_ContentBar_MerContent_AddPro_Pic");
    var AP_PicFile=document.getElementById("ctl00_ctl00_ContentBar_MerContent_uploadF");
    AP_PicFile.onfocus=function()
    {
        AP_Pic.src=AP_PicFile.value;
    }
    
    CheckIntro();
    CheckMemPrice();
    CheckName();
    CheckNote();
    CheckPrice();
}