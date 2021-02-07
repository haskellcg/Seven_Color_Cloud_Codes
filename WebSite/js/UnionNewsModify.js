
function IsMore(value,length)
{
    return value.length>length;
}

function IsLess(value,length)
{
    return value.length<length;
}

function isNull(value)
{
    valueStr=new String(value);
    return valueStr=="";
} 

window.onload=function()
{
    var NewMod_Submit=document.getElementById("NewMod_Submit");
    NewMod_Submit.disabled=true;
    
    var NewMod_Title_Flag=false;
    var NewMod_Content_Flag=false;
    var NewMod_Publisher_Flag=false;
    var NewMod_PublishTime_Flag=false;
    
    function SubmitCheck()
    {
        NewMod_Submit.disabled = !(NewMod_Content_Flag & NewMod_Title_Flag & NewMod_Publisher_Flag & NewMod_PublishTime_Flag);
    }

    var NewMod_Title=document.getElementById("NewMod_Title");
    var NewMod_Title_Info=document.getElementById("NewMod_Title_Info");
    NewMod_Title.onfocus=function()
    {
        NewMod_Title_Info.innerHTML="限制字数10~50";
    }
    NewMod_Title.onfocusout=function()
    {
        if(IsMore(NewMod_Title.value,50))
        {
            NewMod_Title_Info.innerHTML="输入的字数大于50，请重新输入！";
            NewMod_Title_Flag=false;
        }else if(IsLess(NewMod_Title.value,10))
        {
            NewMod_Title_Info.innerHTML="输入的字数少于10，请重新输入！";
            NewMod_Title_Flag=false;
        }else
        {
            NewMod_Title_Info.innerHTML="输入正确";
            NewMod_Title_Flag=true;
        }
        
        SubmitCheck();
    }
    
    var NewMod_Content=document.getElementById("NewMod_Content");
    var NewMod_Content_Info=document.getElementById("NewMod_Content_Info");
    NewMod_Content.onfocus=function()
    {
        NewMod_Content_Info.innerHTML="限制字数50~200";
    }
    NewMod_Content.onfocusout=function()
    {
        if(IsMore(NewMod_Content.value,200))
        {
            NewMod_Content_Info.innerHTML="输入字数多于200,请重新输入！";
            NewMod_Content_Flag=false;
        }else if(IsLess(NewMod_Content.value,50))
        {
            NewMod_Content_Info.innerHTML="输入字数少于50,请重新输入！";
            NewMod_Content_Flag=false;
        }else
        {
            NewMod_Content_Info.innerHTML="输入正确";
            NewMod_Content_Flag=true;
        }
        
        SubmitCheck();
        
    }
    
    var NewMod_Publisher=document.getElementById("NewMod_Publisher");
    NewMod_Publisher.onfocusout=function()
    {
        if(!isNull(NewMod_Publisher.value))
        {
            NewMod_Publisher_Flag=true;
          
        }
        
        SubmitCheck();
    }
    
    var NewMod_PublishTime=document.getElementById("NewMod_PublishTime");
    NewMod_PublishTime.onfocusout=function()
    {   
        if(!isNull(NewMod_PublishTime.defaultvalue))
        {
            NewMod_PublishTime_Flag=true;
        }
        SubmitCheck();
    }
}