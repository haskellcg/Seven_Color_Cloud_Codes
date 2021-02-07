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

public partial class MerchantManage_MerchantLogin_Logout : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            if (Session["username"] != null && Session["user_ID"] != null) {
                Session.RemoveAll();
                string path = Request.ApplicationPath;
                if (!path.EndsWith("/"))
                {
                    path = path + "/";
                }
                Response.Write("<script>alert('注销成功');location.href='" + path + "MerchantManage/MerchantLogin/MerchantLogin.aspx';</script>");
            }
        }
    }
}
