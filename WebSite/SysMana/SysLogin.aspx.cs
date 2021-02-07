using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;

public partial class ManaLogin_ManaLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Sys_Login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        BLL.SysManaBLL.LoginManaBLL loginMana = new BLL.SysManaBLL.LoginManaBLL();
        e.Authenticated = loginMana.authAccount(Sys_Login.UserName,Sys_Login.Password);
    }
    protected void Sys_Login_LoginError(object sender, EventArgs e)
    {
       //Response.Write("<script>alert('登录失败');</script>");
    }
    protected void Sys_Login_LoggedIn(object sender, EventArgs e)
    {
        Session.Add("adminUserName", Sys_Login.UserName);
    }
}
