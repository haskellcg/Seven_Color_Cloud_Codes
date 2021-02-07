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

//验证是否为固定电话
function isTelephone(value){
    return /^\d{8}$/.test(value);
}

//验证是否为手机号码
function isPhone(value){
    return /^\d{11}$/.test(value);
}

//验证是否为合法邮箱地址
function isEmail(value){
    return /^\S+@\S+\.\S+$/.test(value);
}

window.onload=function(){
    
    var MerJoin_Submit=document.getElementById("ctl00_ContentBar_MerJoin_Submit");
    MerJoin_Submit.disabled=true;
    
    var MerJoin_Name_Flag=false;
    var MerJoin_Pwd_Flag=false;
    var MerJoin_Pwd2_Flag=false;
    var MerJoin_Address_Flag=false;
    var MerJoin_RelaEmail_Flag=false;
    var MerJoin_RelaTelephone_Flag=false;
    var MerJoin_RelaPhone_Flag=false;
    var MerJoin_Phone_Flag=false;
    
    function submitCheck()
    {
         MerJoin_Submit.disabled = !(MerJoin_Name_Flag & MerJoin_Pwd_Flag & MerJoin_Pwd2_Flag & MerJoin_Address_Flag & MerJoin_Phone_Flag & MerJoin_RelaTelephone_Flag & MerJoin_RelaPhone_Flag & MerJoin_RelaPhone_Flag & MerJoin_RelaEmail_Flag);
    }
    
    var MerJoin_Name=document.getElementById("ctl00_ContentBar_MerJoin_Name");
    var MerJoinNameInfo=document.getElementById("ctl00_ContentBar_MerJoin_Name_Info");
    //提示商家输入名称的格式
    MerJoin_Name.onfocus=function(){

            MerJoinNameInfo.innerHTML="请输入0~50个中文字符的商家名称";
       
    }
   //验证商家输入的名称的字符个数是否符合要求
   MerJoin_Name.onblur=function(){
        var Name_Value=MerJoin_Name.value;
        if(isOver(Name_Value,50)){
            MerJoinNameInfo.innerHTML="你输入的字符串的长度大于50，请重新输入";
            MerJoin_Name_Flag=false;
            submitCheck();
            return;
        }else if(isNull(Name_Value)){
        
            MerJoinNameInfo.innerHTML="你没有输入字符，请重新输入！";
            MerJoin_Name_Flag=false;
            submitCheck();
            return;
        }
        MerJoinNameInfo.innerHTML="输入正确";
        MerJoin_Name_Flag=true;
        submitCheck();
        return;
   }
   
   var MerJoin_Pwd=document.getElementById("ctl00_ContentBar_MerJoin_Pwd");
   var MerJoin_Pwd2=document.getElementById("ctl00_ContentBar_MerJoin_Pwd2");
   var MerJoin_Pwd_Info=document.getElementById("ctl00_ContentBar_MerJoin_Pwd_Info");
   var MerJoin_Pwd_Info2=document.getElementById("ctl00_ContentBar_MerJoin_Pwd_Info2");
   //提示商家输入密码
   MerJoin_Pwd.onfocus=function(){

            MerJoin_Pwd_Info.innerHTML="请输入6~20个英文字符或数字作为密码";
        return;   
   }
   //验证密码的字符个数是否符合要求
   MerJoin_Pwd.onblur=function(){
        var Pwd_Value=MerJoin_Pwd.value;
        if(isNull(Pwd_Value)){
            MerJoin_Pwd_Info.innerHTML="你还没有输入密码，请重新输入！";
            MerJoin_Pwd_Flag=false;
            submitCheck();
            return;
        }else if(isRightPwd(Pwd_Value)){
            MerJoin_Pwd_Info.innerHTML="只能输入英文字符或者数字";
            MerJoin_Pwd_Flag=false;
            submitCheck();
            return;
        }else if(isLess(Pwd_Value,6)){
            MerJoin_Pwd_Info.innerHTML="输入的密码长度小于6，请重新输入！";
            MerJoin_Pwd_Flag==false;
            submitCheck();
            return;   
        }else if(isOver(Pwd_Value,20)){
            MerJoin_Pwd_Info.innerHTML="你输入的密码的长度大于20,请重新输入！";
            MerJoin_Pwd_Flag==false;
            submitCheck();
            return;
        }
        MerJoin_Pwd_Info.innerHTML="密码输入正确！";
        MerJoin_Pwd_Flag=true;
        submitCheck();
        return;
   }
   
   MerJoin_Pwd2.onfocus=function()
   {
        if(MerJoin_Pwd_Flag==false){
            MerJoin_Pwd_Info2.innerHTML="请先输入正确的密码！";
            MerJoin_Pwd2_Flag=false;
            submitCheck();
            return;
        }
        else
            MerJoin_Pwd_Info2.innerHTML="请重新输入密码！";

        return;
   }
   
   MerJoin_Pwd2.onblur=function()
   {
        var Pwd2_Value=MerJoin_Pwd2.value;
        if(MerJoin_Pwd_Flag==false){
            MerJoin_Pwd_Info2.innerHTML="请先输入正确的密码！";
            MerJoin_Pwd2_Flag=false;
            submitCheck();
            return;
        }else if(Pwd2_Value!=MerJoin_Pwd.value)
        {
            MerJoin_Pwd_Info2.innerHTML="两次输入密码不一样！";
             MerJoin_Pwd2_Flag=false;
             submitCheck();
            return;
        }else
        {
            MerJoin_Pwd_Info2.innerHTML="输入一致！";
            MerJoin_Pwd2_Flag=true;
            submitCheck();
            return;
        }
   }
   
   
   var MerJoin_Address=document.getElementById("ctl00_ContentBar_MerJoin_Address");
   var MerJoin_Address_Info=document.getElementById("ctl00_ContentBar_MerJoin_Address_Info");
   
   MerJoin_Address.onfocus=function()
   {

            MerJoin_Address_Info.innerHTML="请输入6~50字数的地址！";
 
        
        return;
   }
   
   MerJoin_Address.onblur=function()
   {
        var MerJoin_Address_Value=MerJoin_Address.value;
        if(isOver(MerJoin_Address_Value,50))
        {
            MerJoin_Address_Info.innerHTML="字数超过50位，请重新输入！";
            MerJoin_Address_Flag==false;
            submitCheck();
            return;
        }else if(isLess(MerJoin_Address_Value,6))
        {
            MerJoin_Address_Info.innerHTML="字数少于6位，请重新输入！";
            MerJoin_Address_Flag=false;
            submitCheck();
            return;
        }
        
        MerJoin_Address_Info.innerHTML="输入正确";
        MerJoin_Address_Flag=true;
        submitCheck();
        return;
   }
   
   var MerJoin_Phone=document.getElementById("ctl00_ContentBar_MerJoin_Phone");
   var MerJoin_Phone_Info=document.getElementById("ctl00_ContentBar_MerJoin_Phone_Info");

   MerJoin_Phone.onfocus=function()
   {

            MerJoin_Phone_Info.innerHTML="请输入8位的电话号码！";
        
        return;
   }
   MerJoin_Phone.onblur=function()
   {
        if(!isTelephone(MerJoin_Phone.value))
        {
            MerJoin_Phone_Info.innerHTML="非法电话号码，请重新输入！";
            MerJoin_Phone_Flag=false;
            submitCheck();
            return;
        }else
        {
            MerJoin_Phone_Info.innerHTML="输入正确！";
            MerJoin_Phone_Flag=true;
            submitCheck();
            return;
        }
        
        
   }
   
   var MerJoin_RelaTelephone=document.getElementById("ctl00_ContentBar_MerJoin_RelaTelePhone");
   var MerJoin_RelaTelephone_Info=document.getElementById("ctl00_ContentBar_MerJoin_RelaTelephone_Info");

   MerJoin_RelaTelephone.onfocus=function()
   {
  
            MerJoin_RelaTelephone_Info.innerHTML="请输入11位的手机号码！";
            return;
       
   }
   MerJoin_RelaTelephone.onblur=function()
   {
        if(!isPhone(MerJoin_RelaTelephone.value))
        {
            MerJoin_RelaTelephone_Info.innerHTML="非法的手机号码,请重新输入！";
            MerJoin_RelaTelephone_Flag=false;
            submitCheck();
            return;
        }else
        {
            MerJoin_RelaTelephone_Info.innerHTML="输入正确！";
            MerJoin_RelaTelephone_Flag=true;
            submitCheck();
            return;
        }
   }
   
   var MerJoin_RelaPhone=document.getElementById("ctl00_ContentBar_MerJoin_RelaPhone");
   var MerJoin_RelaPhone_Info=document.getElementById("ctl00_ContentBar_MerJoin_RelaPhone_Info");

   MerJoin_RelaPhone.onfocus=function()
   {
     
            MerJoin_RelaPhone_Info.innerHTML="请输入8位的电话号码";
            return;
     
   }
   MerJoin_RelaPhone.onblur=function()
   {
        if(!isTelephone(MerJoin_RelaPhone.value))
        {
            MerJoin_RelaPhone_Info.innerHTML="非法的电话号码,请重新输入！";
            MerJoin_RelaPhone_Flag=false;
            submitCheck();
            return;
        }else
        {
            MerJoin_RelaPhone_Info.innerHTML="输入正确！";
            MerJoin_RelaPhone_Flag=true;
            submitCheck();
            return;
        }
   }
   
   var MerJoin_RelaEmail=document.getElementById("ctl00_ContentBar_MerJoin_RelaEmail");
   var MerJoin_RelaEmail_Info=document.getElementById("ctl00_ContentBar_MerJoin_RelaEmail_Info");

   MerJoin_RelaEmail.onfocus=function()
   {
   
            MerJoin_RelaEmail_Info.innerHTML="请输入邮箱地址！";
            return;
      
   }
   MerJoin_RelaEmail.onblur=function()
   {
        if(!isEmail(MerJoin_RelaEmail.value))
        {
            MerJoin_RelaEmail_Info.innerHTML="邮箱地址不合法，请重新输入！";
            MerJoin_RelaEmail_Flag=false;
            submitCheck();
            return;
        }else
        {
            MerJoin_RelaEmail_Info.innerHTML="地址合法！";
            MerJoin_RelaEmail_Flag=true;
            submitCheck();
            return;
        }
   }
   
   
   
  
  
}