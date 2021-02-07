
function IsFloat(value)
{
   return (/^([0-9]*|\d*.\d{1}?\d*)$/).test(value);
}
function IsNull(value)
{
    valueStr=new String(value);
    return valueStr=="";
} 

function IsNumber(value)
{
    return /^[0-9]{1,}$/.test(value);
}

window.onload=function()
{
    var Charge_Submit=document.getElementById("Charge_Submit");
    Charge_Submit.disabled=true;
    
    var Charge_MemID_Flag=false;
    var Charge_ReMemID_Flag=false;
    var Charge_Money_Flag=false;
    
    function submitCheck()
    {
        Charge_Submit.disabled=!(Charge_MemID_Flag & Charge_ReMemID_Flag & Charge_Money_Flag);
    }

    var Charge_MemID=document.getElementById("Charge_MemID");
    var Charge_ReMemID=document.getElementById("Charge_ReMemID");
    var Charge_Money=document.getElementById("Charge_Money");
    var Charge_MemID_Info=document.getElementById("Charge_MemID_Info");
    var Charge_ReMemID_Info=document.getElementById("Charge_ReMemID_Info");
    var Charge_Money_Info=document.getElementById("Charge_Money_Info");
    
    Charge_MemID.onfocus=function()
    {
        Charge_MemID_Info.innerHTML="";
    }
    
    Charge_MemID.onblur=CheckMemID;
    Charge_MemID.onkeyup=CheckMemID;
    function CheckMemID()
    {
        if(!IsNumber(Charge_MemID.value))
        {
            Charge_MemID_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>请输入数字</span>";
            Charge_MemID_Flag=false;
        }else if(!IsNull(Charge_ReMemID.value) & Charge_ReMemID_Flag==true)
        {
            if( Charge_MemID.value != Charge_ReMemID.value)
            {
                Charge_ReMemID_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>两次输入不一致</span>";
                Charge_MemID_Flag=false;
            }else
            {
                Charge_ReMemID_Info.innerHTML="";
                Charge_MemID_Info.innerHTML="";
                Charge_MemID_Flag=true;
            }
        }else
        {
            Charge_MemID_Info.innerHTML="";
            Charge_MemID_Flag=true;
        }
        window.returnValue=Charge_MemID.value;
        submitCheck();
    }
    
    Charge_ReMemID.onfocus=function()
    {
        Charge_ReMemID_Info.innerHTML="";
    }
    Charge_ReMemID.onblur=CheckReMemID;
    Charge_ReMemID.onkeyup=CheckReMemID;
    function CheckReMemID()
    {
        if(!IsNumber(Charge_ReMemID.value))
        {
            Charge_ReMemID_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>请输入数字</span>";
            Charge_ReMemID_Flag=false;
        }else if(IsNull(Charge_MemID.value))
        {
            Charge_ReMemID_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>请先填写会员ID</span>";
            Charge_ReMemID_Flag=false;
        }else if(Charge_MemID.value != Charge_ReMemID.value)
        {
            Charge_ReMemID_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>两次输入不一致</span>";
            Charge_ReMemID_Flag=false;
        }else
        {
             Charge_ReMemID_Info.innerHTML="";
            Charge_ReMemID_Flag=true;
        }
        
        submitCheck();
    }
    
    
    Charge_Money.onfocus=function()
    {
        Charge_Money_Info.innerHTML="";
    }
    Charge_Money.onblur=CheckMoney;
    Charge_Money.onkeyup=CheckMoney;
    function CheckMoney()
    {
        if(IsNull(Charge_Money.value))
        {
             Charge_Money_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>请填写金额</span>";
            Charge_Money_Flag=false;
        }else if(!IsFloat(Charge_Money.value))
        {
            Charge_Money_Info.innerHTML="<span style='color:red;font-family:@华文楷体;font-size:smaller;font-weight:lighter;'>请输入非负数</span>";
            Charge_Money_Flag=false;
        }else
        {
            Charge_Money_Info.innerHTML="";
            Charge_Money_Flag=true;
        }
        submitCheck();
    }
    
    CheckMemID();
    CheckMoney();
    CheckReMemID();
    
    
}

