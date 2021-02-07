function IsLess(value,length)
{
    return value.length<length;
}
function IsMore(value,length)
{
    return value.length>length;
}
window.onload=function()
{
    var MerComRe_Submit=document.getElementById("MerComRe_Submit");
    MerComRe_Submit.disabled=true;
    
    var MerComRe_Reply_Flag=false;
    
    function submitCheck()
    {
        MerComRe_Submit.disabled=! MerComRe_Reply_Flag;
    }

    var MerComRe_Reply=document.getElementById("MerComRe_Reply");
    MerComRe_Reply.onfocusout=function()
    {
        if(IsLess(MerComRe_Reply.value,15))
        {
            alert("字数少于15字，请重新输入！");
             MerComRe_Reply_Flag=false;
        }else if(IsMore(MerComRe_Reply.value,200))
        {
            alert("字数大于200字，请重新输入！");
             MerComRe_Reply_Flag=false;
        }else
        {
             MerComRe_Reply_Flag=true;
        }
        
        submitCheck();
    }
}