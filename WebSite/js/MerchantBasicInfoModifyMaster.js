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

function IsTelephone(value)
{
    return /^\d{7}$/.test(value);
}

function IsPhone(value)
{
    return /^\d{12}$/.test(value);
}

function IsEmail(value)
{
    return /^\S+@\S+\.\S+$/.test(value);
}

function IsFax(value)
{
    return /^(\d{3,4})?\d{7,8}$/.test(value);
}

function IsImgFile(value)
{
    var valueStr=new String(value);
    var strArray=valueStr.split(".");
    return /jpg|ico|bmp|png|gif/.test(strArray[strArray.length-1].toLowerCase());
}

function IsWebsite(value)
{
    var reg=new RegExp("^[a-zA-Z]+://[^\s]*$");
    return reg.test(value);
}

window.onload=function()
{
    
    var MerInfoMod_Submit=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Submit");
    MerInfoMod_Submit.disabled=true;
    
    var MerInfoMod_Name_Flag=false;
    var MerInfoMod_Introduction_Flag=false;
	var MerInfoMod_Telephone_Flag=false;
	var MerInfoMod_Relat_Flag =false;
	var MerInfoMod_Address_Flag=false;   
    var MerInfoMod_Website_Flag=true;
    var MerInfoMod_Email_Flag =true;
    
    function submitCheck()
    {
        MerInfoMod_Submit.disabled=!(MerInfoMod_Address_Flag & MerInfoMod_Email_Flag & MerInfoMod_Introduction_Flag & MerInfoMod_Name_Flag & MerInfoMod_Relat_Flag & MerInfoMod_Telephone_Flag & MerInfoMod_Website_Flag);
    }


    var MerInfoMod_Name=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Name");
    var MerInfoMod_Name_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Name_Info");
    MerInfoMod_Name.onblur=CheckName;
    MerInfoMod_Name.onkeyup=CheckName;
    function CheckName()
    {
        if(IsNull(MerInfoMod_Name.value))
        {
            MerInfoMod_Name_Info.innerHTML="<span style='color:Red;'>名称不可为空！</span>";
            MerInfoMod_Name_Flag=false;
        }
        else
        {
            MerInfoMod_Name_Info.innerHTML="";
            MerInfoMod_Name_Flag=true;
        }
        submitCheck();
    }
    
    var MerInfoMod_Introduction=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Introduction");
    var MerInfoMod_Intro_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Intro_Info");
    MerInfoMod_Introduction.onfocus=function()
    {
        MerInfoMod_Intro_Info.innerHTML="<span style='color:Red;'>字数限制4~80</span>";
    }
    MerInfoMod_Introduction.onblur=CheckIntro;
    MerInfoMod_Introduction.onkeyup=CheckIntro;
    function CheckIntro()
    {
        if(IsMore(MerInfoMod_Introduction.value,80))
        {
            MerInfoMod_Intro_Info.innerHTML="<span style='color:Red;'>字数多于80,请重新输入！</span>";
            MerInfoMod_Introduction_Flag=false;
        }else if(IsLess(MerInfoMod_Introduction.value,4))
        {
            MerInfoMod_Intro_Info.innerHTML="<span style='color:Red;'>字数少于4,请重新输入！</span>";
            MerInfoMod_Introduction_Flag=false;
        }else
        {
            MerInfoMod_Intro_Info.innerHTML="输入正确";
            MerInfoMod_Introduction_Flag=true;
        }
        
        submitCheck();
    }
    
    
    var MerInfoMod_Address=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Address");
    var MerInfoMod_Add_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Add_Info");
    MerInfoMod_Address.onfocus=function()
    {
        MerInfoMod_Add_Info.innerHTML="<span style='color:Red;'>字数限制，不得大于50</span>";
    }
    MerInfoMod_Address.onblur=CheckAddr;
    MerInfoMod_Address.onkeyup=CheckAddr;
    function CheckAddr()
    {
        if(IsMore(MerInfoMod_Address.value,50))
        {   
            MerInfoMod_Add_Info.innerHTML="<span style='color:Red;'>字数超过50，请重新输入！</span>";
            MerInfoMod_Address_Flag=false;
        }else
        {
           MerInfoMod_Add_Info.innerHTML="";
           MerInfoMod_Address_Flag=true;
            
        }
        
        submitCheck();
    }
    
    
    var MerInfoMod_Telephone=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Telephone");
    var MerInfoMod_Tel_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Tel_Info");
    MerInfoMod_Telephone.onfocus=function()
    {
        MerInfoMod_Tel_Info.innerHTML="<span style='color:Red;'>请输入7位的电话号码</span>";
    }
    MerInfoMod_Telephone.onblur=CheckTele;
    MerInfoMod_Telephone.onkeyup=CheckTele;
    function CheckTele()
    {
        if(IsNull(MerInfoMod_Telephone.value))
        {
            MerInfoMod_Tel_Info.innerHTML="<span style='color:Red;'>不可为空！</span>";
            MerInfoMod_Telephone_Flag=false;
        }
        else if(!IsTelephone(MerInfoMod_Telephone.value))
        {
           MerInfoMod_Tel_Info.innerHTML="<span style='color:Red;'>非法固话号码！</span>";
           MerInfoMod_Telephone_Flag=false;
        }else
        {
            MerInfoMod_Tel_Info.innerHTML="输入正确";
            MerInfoMod_Telephone_Flag=true;
        }
        
        submitCheck();

    }
 
    

    var MerInfoMod_Website=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Website");
    var MerInfoMod_Web_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Web_Info");
    MerInfoMod_Website.onblur=CheckWeb;
    MerInfoMod_Website.onkeyup=CheckWeb
    function CheckWeb()
    {
        if(!IsWebsite(MerInfoMod_Website.value))
        {
            MerInfoMod_Web_Info.innerHTML="<span style='color:Red;'>非法网址，请重新输入！</span>";
            MerInfoMod_Website_Flag=false;
        }else
        {
            MerInfoMod_Web_Info.innerHTML="";
            MerInfoMod_Website_Flag=true;
        }
        
        submitCheck();
    }

    var MerInfoMod_Email=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Email");
    var MerInfoMod_Email_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Email_Info");
    MerInfoMod_Email.onblur=CheckEmail;
    MerInfoMod_Email.onkeyup=CheckEmail;
    function CheckEmail()
    {
        if(!IsEmail(MerInfoMod_Email.value))
        {
            MerInfoMod_Email_Info.innerHTML="<span style='color:Red;'>非法邮箱地址！</span>";
            MerInfoMod_Email_Flag=false;

        }else
        {
            MerInfoMod_Email_Info.innerHTML="";
            MerInfoMod_Email_Flag=true;
        }
        submitCheck();

    }
    
    var MerInfoMod_Relat=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Relat");
    var MerInfoMod_Relat_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerInfoMod_Relat_Info");
    MerInfoMod_Relat.onblur=CheckRelat;
    MerInfoMod_Relat.onkeyup=CheckRelat;
    function CheckRelat()
    {
        if(IsNull(MerInfoMod_Relat.value))
        {
            MerInfoMod_Relat_Info.innerHTML="<span style='color:Red;'>不可以为空！</span>";
            MerInfoMod_Relat_Flag=false;
        }else
        {
            MerInfoMod_Relat_Info.innerHTML="";
            MerInfoMod_Relat_Flag=true;
        }
        
        submitCheck();
    }
    
    CheckAddr();
    CheckEmail();
    CheckIntro();
    CheckName();
    CheckRelat();
    CheckWeb();
    CheckTele();

}