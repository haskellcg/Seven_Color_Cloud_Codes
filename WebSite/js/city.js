// JavaScript Document
window.onload=function(){
var cityBut=document.getElementById("selectedcity");
var cityList=document.getElementById("citylist");
cityBut.onclick=function(){
    cityList.className="display";
}
cityBut.onblur=function(){
    cityList.className="nodisplay";
}
var beiJing=document.getElementById("beijing");
beiJing.onclick=function(){
	cityList.className="nodisplay";
	}
}