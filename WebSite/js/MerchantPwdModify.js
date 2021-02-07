//验证字符串的长度是否大于所要求的长度，大于则为TRUE，否则为false
function isOver(value,length){
    value1=new String(value);
    if(value1.length>length){
        return true;    
    }
    return false;

}

function isLess(value,length)
{
    value1=new String(value);
    if(value1.length<length)
    {
        return true;
    }
    
    return false;
}
//验证字符串是否为空，如果为空,返回true,否则返回false
function isNull(value){
    value1=new String(value);
    if(value1.length<=0){
        return true;
    }
    return false;
}
//验证密码的格式是否正确，只能为英文字母或者数字
function isRightPwd(Pwd){

    if(/^[0-9a-zA-Z]{6,20}$/.test(Pwd)){
        return false;
    }
    return true;
    
}

window.onload=function()
{
    var MerPwdMod_Submit=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_Submit");
    MerPwdMod_Submit.disabled=true;
    
    var MerPwdMod_OldPwd_Flag=false;
    var MerPwdMod_NewPwd_Flag=false;
    var MerPwdMod_PwdConfirm_Flag=false;
    
    function submitCheck()
    {
        MerPwdMod_Submit.disabled=!(MerPwdMod_NewPwd_Flag & MerPwdMod_OldPwd_Flag & MerPwdMod_PwdConfirm_Flag);
    }

    var MerPwdMod_OldPwd=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_OldPwd");
    var MerPwdMod_OldPwd_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_OldPwd_Info");
    MerPwdMod_OldPwd.onfocus=function()
    {
        MerPwdMod_OldPwd_Info.innerHTML="请输入原密码";
    }
    MerPwdMod_OldPwd.onblur=function()
    {
        var Pwd_Value=MerPwdMod_OldPwd.value;
        
        if(isNull(Pwd_Value)){
            MerPwdMod_OldPwd_Info.innerHTML="你还没有输入密码，请重新输入！";
            MerPwdMod_OldPwd_Flag=false;
            submitCheck();
            return;
        }else if(isRightPwd(Pwd_Value)){
            MerPwdMod_OldPwd_Info.innerHTML="只能输入英文字符或者数字";
            MerPwdMod_OldPwd_Flag=false;
            submitCheck();
            return;
        }else if(isLess(Pwd_Value,6)){
            MerPwdMod_OldPwd_Info.innerHTML="输入的密码长度小于6，请重新输入！";
            MerPwdMod_OldPwd_Flag==false;
            submitCheck();
            return;   
        }
        else if(isOver(Pwd_Value,20)){
            MerPwdMod_OldPwd_Info.innerHTML="你输入的密码的长度大于20,请重新输入！";
            MerPwdMod_OldPwd_Flag==false;
            submitCheck();
            return;
        }else{
            MerPwdMod_OldPwd_Info.innerHTML="密码输入正确！";
            MerPwdMod_OldPwd_Flag=true;
            submitCheck();
            return;
         }
    }
    
    var MerPwdMod_NewPwd=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_NewPwd");
    var MerPwdMod_NewPwd_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_NewPwd_Info");
    MerPwdMod_NewPwd.onfocus=function()
    {
        MerPwdMod_NewPwd_Info.innerHTML="请输入新密码";
    }
    MerPwdMod_NewPwd.onblur=function()
    {
        var Pwd_Value=MerPwdMod_NewPwd.value;
        
        if(isNull(Pwd_Value)){
            MerPwdMod_NewPwd_Info.innerHTML="你还没有输入密码，请重新输入！";
            MerPwdMod_NewPwd_Flag=false;
            submitCheck();
            return;
        } else if(isRightPwd(Pwd_Value)){
            MerPwdMod_NewPwd_Info.innerHTML="只能输入英文字符或者数字";
            MerPwdMod_NewPwd_Flag=false;
            submitCheck();
            return;
        }else if(isLess(Pwd_Value,6)){
            MerPwdMod_NewPwd_Info.innerHTML="输入的密码长度小于6，请重新输入！";
            MerPwdMod_NewPwd_Flag==false;
            submitCheck();
            return;   
        }else if(isOver(Pwd_Value,20)){
            MerPwdMod_NewPwd_Info.innerHTML="你输入的密码的长度大于20,请重新输入！";
            MerPwdMod_NewPwd_Flag==false;
            submitCheck();
            return;
        }else{
            MerPwdMod_NewPwd_Info.innerHTML="密码输入正确！";
            MerPwdMod_NewPwd_Flag=true;
            submitCheck();
            return;
           } 
    }
    
    var MerPwdMod_PwdConfirm=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_PwdConfirm");
    var MerPwdMod_PwdConfirm_Info=document.getElementById("ctl00_ctl00_ContentBar_MerContent_MerPwdMod_PwdConfirm_Info");
    MerPwdMod_PwdConfirm.onfocus=function()
    {
        if(MerPwdMod_NewPwd_Flag==false){
            MerPwdMod_PwdConfirm_Info.innerHTML="请先输入正确的新密码！";
            MerPwdMod_PwdConfirm_Flag=false;
            submitCheck();
            return;
        }
        else
            MerPwdMod_PwdConfirm_Info.innerHTML="请重新输入密码！";

        return;
    }
    MerPwdMod_PwdConfirm.onblur=function()
    {
         var Pwd2_Value=MerPwdMod_PwdConfirm.value;
        if(MerPwdMod_NewPwd_Flag==false){
            MerPwdMod_PwdConfirm_Info.innerHTML="请先输入正确的新密码！";
            MerPwdMod_PwdConfirm_Flag=false;
            submitCheck();
            return;
        }else if(Pwd2_Value!=MerPwdMod_NewPwd.value)
        {
            MerPwdMod_PwdConfirm_Info.innerHTML="两次输入密码不一样！";
            MerPwdMod_PwdConfirm_Flag=false;
            submitCheck();
            return;
        }else
        {
            MerPwdMod_PwdConfirm_Info.innerHTML="输入一致！";
            MerPwdMod_PwdConfirm_Flag=true;
            submitCheck();
            return;
        }
    }
}