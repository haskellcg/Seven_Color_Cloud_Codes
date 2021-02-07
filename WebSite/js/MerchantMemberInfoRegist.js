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
   return (/^[0-9]{1,}$/).test(value);
}

function IsLisenceCard(value)
{   
    return /(^\d{15}$)|(^\d{17}([0-9]|X|x)$)/.test(value);
}

function IsPhone(value)
{
    return /^\d{12}$/.test(value);
}

function IsEmail(value)
{
    return /^\S+@\S+\.\S+$/.test(value);
}
window.onload=function()
{   
    var MerMemReg_Submit=document.getElementById("MerMemReg_Submit");
    MerMemReg_Submit.disabled=true;
    
    
    var MerMemReg_MemID_Flag=false;
    var MerMemReg_MemCardID_Flag=false;
    var MerMemReg_LisenceID_Flag=false;
    var MerMemReg_MemName_Flag=false;
    var MerMemReg_Phone_Flag=false;
    var MerMemReg_MerID_Flag=false;
    var MerMemReg_Optor_Flag=false;
    var MerMemReg_OptTime_Flag=false;
     var MerMemReg_Address_Flag=true;
     var MerMemReg_Email_Flag=true;

    function SubmitCheck()
    {
        MerMemReg_Submit.disabled=!(MerMemReg_LisenceID_Flag & MerMemReg_MemCardID_Flag & MerMemReg_MemID_Flag & MerMemReg_MemName_Flag & MerMemReg_MerID_Flag & MerMemReg_Optor_Flag & MerMemReg_OptTime_Flag & MerMemReg_Phone_Flag & MerMemReg_Email_Flag & MerMemReg_Address_Flag);
    }


    var MerMemReg_MemID=document.getElementById("MerMemReg_MemID");
    var MerMemReg_MemID_Info=document.getElementById("MerMemReg_MemID_Info");
    MerMemReg_MemID.onfocusout=function()
    {
        if(!IsNumber(MerMemReg_MemID.value))
        {
            MerMemReg_MemID_Info.innerHTML="非法会员ID！";
            MerMemReg_MemID_Flag=false;
        }else
        {
            MerMemReg_MemID_Info.innerHTML="合法ID";
            MerMemReg_MemID_Flag=true;
        }
        SubmitCheck();
    }
    
    var MerMemReg_MemCardID=document.getElementById("MerMemReg_MemCardID");
    var MerMemReg_MemCardID_Info=document.getElementById("MerMemReg_MemCardID_Info");
    MerMemReg_MemCardID.onfocusout=function()
    {
        if(!IsNumber(MerMemReg_MemCardID.value))
        {
            MerMemReg_MemCardID_Info.innerHTML="非法会员卡ID！";
            MerMemReg_MemCardID_Flag=false;
        }else
        {
            MerMemReg_MemCardID_Info.innerHTML="合法ID";
            MerMemReg_MemCardID_Flag=true;
        }
        
        SubmitCheck();
    }
    
    
    var MerMemReg_LisenceID=document.getElementById("MerMemReg_LiID");
    var MerMemReg_LisenceID_Info=document.getElementById("MerMemReg_LiID_Info");
    MerMemReg_LisenceID.onfocus=function()
    {   
        MerMemReg_LisenceID_Info.innerHTML="请输入15位或18位的身证号码";
    }
    MerMemReg_LisenceID.onfocusout=function()
    {
        if(!IsLisenceCard(MerMemReg_LisenceID.value))
        {
            MerMemReg_LisenceID_Info.innerHTML="非法的身份证号！";
            MerMemReg_LisenceID_Flag=false;
        }else
        {
            MerMemReg_LisenceID_Info.innerHTML="输入正确";
            MerMemReg_LisenceID_Flag=true;
        }
        SubmitCheck();
    }
    
    var MerMemReg_Phone=document.getElementById("MerMemReg_Phone");
    var MerMemReg_Phone_Info=document.getElementById("MerMemReg_Phone_Info");
    MerMemReg_Phone.onfocus=function()
    {
        MerMemReg_Phone_Info.innerHTML="请输入12位的电话号码！";
    }
    MerMemReg_Phone.onfocusout=function()
    {
        if(!IsPhone( MerMemReg_Phone.value))
        {
            MerMemReg_Phone_Info.innerHTML="非法电话号码！";
            MerMemReg_Phone_Flag=false;
         }else
         {
             MerMemReg_Phone_Info.innerHTML="输入正确";
             MerMemReg_Phone_Flag=true;
         }
         
         SubmitCheck();
    }
    
    var MerMemReg_MerID=document.getElementById("MerMemReg_MerID");
    var MerMemReg_MerID_Info=document.getElementById("MerMemReg_MerId_Info");
    MerMemReg_MerID.onfocusout=function()
    {
        if(!IsNumber(MerMemReg_MerID.value))
        {
            MerMemReg_MerID_Info.innerHTML="非法的商家ID！";
            MerMemReg_MerID_Flag=false;
        }else
        {
            MerMemReg_MerID_Info.innerHTML="合法商家ID";
            MerMemReg_MerID_Flag=true;
        }
        
        SubmitCheck();
    }
    
    var MerMemReg_MemName=document.getElementById("MerMemReg_MemName");
    var MerMemReg_MemName_Info=document.getElementById("MerMemReg_MemName_Info");
    MerMemReg_MemName.onfocusout=function()
    {
        if(IsNull(MerMemReg_MemName.value))
        {
            MerMemReg_MemName_Info.innerHTML="姓名不可为空";
            MerMemReg_MemName_Flag=false;
        }else
        {
            MerMemReg_MemName_Info.innerHTML="";
            MerMemReg_MemName_Flag=true;
        }
        SubmitCheck();
    }
    
    var MerMemReg_Optor=document.getElementById("MerMemReg_Optor");
    var MerMemReg_Optor_Info=document.getElementById("MerMemReg_Optor_Info");
    MerMemReg_Optor.onfocusout=function()
    {
        if(IsNull(MerMemReg_Optor.value))
        {
            MerMemReg_Optor_Info.innerHTML="操作人姓名不可为空";
            MerMemReg_Optor_Flag=false;
        }else
        {
            MerMemReg_Optor_Info.innerHTML="";
            MerMemReg_Optor_Flag=true;
        }
        SubmitCheck();
    }
    
    var MerMemReg_OptTime=document.getElementById("MerMemReg_OptTime");
    MerMemReg_OptTime.onfocusout=function()
    {
        if(!IsNull(MerMemReg_OptTime.defaultvalue))
        {
            MerMemReg_OptTime_Flag=true;
        }else
        {
            
        }
        
        SubmitCheck();
    }
            
            
    var MerMemReg_Address=document.getElementById("MerMemReg_MemAddress");
    var MerMemReg_Address_Info=document.getElementById("MerMemReg_Address_Info");
    MerMemReg_Address.onfocus=function()
    {
        MerMemReg_Address_Info.innerHTML="限制字数不得超过100字";
    }
    MerMemReg_Address.onfocusout=function()
    {
        if(IsMore(MerMemReg_Address.value,100))
        {
            MerMemReg_Address_Info.innerHTML="字数超过100，请重新输入！";
            MerMemReg_Address_Flag=false;
        }else
        {
            MerMemReg_Address_Info.innerHTML="";
            MerMemReg_Address_Flag=true;
        }
        SubmitCheck();
    }
    
    var MerMemReg_Email=document.getElementById("MerMemReg_Email");
    var MerMemReg_Email_Info=document.getElementById("MerMemReg_Email_Info");
    MerMemReg_Email.onfocusout=function()
    {
        if(!IsEmail(MerMemReg_Email.value))
        {
            MerMemReg_Email_Info.innerHTML="非法的邮箱地址！";
            MerMemReg_Email_Flag=false;
        }else
        {
            MerMemReg_Email_Info.innerHTML="";
            MerMemReg_Email_Flag=true;
        }
        SubmitCheck();
    }
}