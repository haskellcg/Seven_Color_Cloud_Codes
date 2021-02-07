function IsNumberOrLetter(value)
{
   return (/^[0-9a-zA-Z]{1,}$/).test(value);
}

function IsNumber(value)
{
    return /^[0-9]{1,}$/.test(value);
}

window.onload=function()
{

    var MerLog_Submit=document.getElementById("MerLog_Submit");
    MerLog_Submit.disabled=true;
    
    var MerLog_Name_Flag=false;
    var MerLog_Pwd_Flag=false;
    
    function SubmitCheck()
    {
        MerLog_Submit.disabled=!(MerLog_Name_Flag & MerLog_Pwd_Flag);
    } 
 

    var MerLog_Name=document.getElementById("MerLog_Name");
    var MerLog_Name_Info=document.getElementById("MerLog_Name_Info");
    MerLog_Name.onfocusout=function()
    {
        if(!IsNumber(MerLog_Name.value))
        {
            MerLog_Name_Info.innerHTML="非法登录名！";
            MerLog_Name_Flag=false;
        }else
        {
            MerLog_Name_Info.innerHTML="输入正确";
            MerLog_Name_Flag=true;
        }
        
        SubmitCheck();
    }
    
    var MerLog_Pwd=document.getElementById("MerLog_Pwd");
    var MerLog_Pwd_Info=document.getElementById("MerLog_Pwd_Info");
    MerLog_Pwd.onfocusout=function()
    {
        if(!IsNumberOrLetter(MerLog_Pwd.value))
        {
            MerLog_Pwd_Info.innerHTML="非法密码！";
            MerLog_Pwd_Flag=false;
        }
        else
        {
            MerLog_Pwd_Info.innerHTML="输入正确";
            MerLog_Pwd_Flag=true;
        }
        SubmitCheck();
    }
}