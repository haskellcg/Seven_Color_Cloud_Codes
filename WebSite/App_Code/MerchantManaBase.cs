using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///OveralBaseMana 的摘要说明
/// </summary>
public class MerchantManaBase : System.Web.UI.Page
{
    public MerchantManaBase()
    {
        Load += Page_Load_Base;
    }
    protected void Page_Load_Base(object sender, EventArgs e)
    {
        TestIsLogin();
    }
    public void TestIsLogin()
    {
        if (Session["username"] == null)
        {
            string path = Request.ApplicationPath;
            if (!path.EndsWith("/"))
            {
                path = path + "/";
            }
            Response.Write("<script>alert('请先登录');location.href='" + path + "MerchantManage/MerchantLogin/MerchantLogin.aspx';</script>");
            //Response.Redirect("~/SysMana/SysLogin.aspx");
            return;
        }
    }
    public void alertMessage(string msg)
    {
        Response.Write("<script>alert('" + msg + "');</script>");
    }
    public void alertMessage(string msg, string url)
    {
        Response.Write("<script>alert('" + msg + "');location.href='" + url + "';</script>");
    }
}
