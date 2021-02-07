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
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
        this.Load += new System.EventHandler(this.Page_Load);
    }

    private void Page_Load(Object sender, System.EventArgs e)
    {
        //BLL.Sys.UserInfo ui = new BLL.Sys.UserInfo();
        //ui.UserID = -1;
        //Session["UserInfo"] = ui;
        if (Session["UserInfo"] == null)
        {
            // Alert("登录状态丢失，或者未登录。\r\n请登录后再使用！");
            Response.Redirect("~/login.aspx");
            // Response.Write("<script>window.location.href='~login.aspx';</script>");
        }
    }




    /// <summary>
    /// 弹出对话框
    /// </summary>
    /// <param name="msg"></param>
    protected void Alert(string msg)
    {
        Response.Write("<script>alert('" + msg + "');</script>");
    }
    /// <summary>
    /// 弹出对话框并返回指定页面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="url"></param>
    protected void Alert(string msg, string url)
    {
        Response.Write("<script>alert('" + msg + "');window.location.href='" + url + "'</script>");
    }
    /// <summary>
    /// 截断字符串，只显示一部分
    /// </summary>
    /// <param name="str">原字符串</param>
    /// <param name="len">长度</param>
    /// <returns>截断后的字符串</returns>
    protected string SubString(string str, int len)
    {
        if (str.Length > len)
        {
            str = str.Substring(0, len) + "...";
        }
        return str;
    }


}
