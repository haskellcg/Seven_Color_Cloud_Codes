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
using BLL.MerchantManage.MerchantLogin;

public partial class MerchantManage_MerchantLogin_MerchantLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MerLog_Submit_Click(object sender, EventArgs e)
    {
        MerchLogBLL mlb = new MerchLogBLL();
        string name = mlb.McLog(MerLog_Name.Text, MerLog_Pwd.Value);

        if (name!=null)
        {
            Session["username"] = MerLog_Name.Text;
            Session["user_ID"] = name;
            //Response.Write("<script>alert('登录成功！');location.href='../../MerchantShowInfoMaintain.aspx?mer_id=';</script>");
            Response.Redirect("../MerShowInfoMaintain.aspx?mer_id="+name);
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误，请重新登录！');</script>");
        }
    }
    protected void MerLog_Reg_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MerchantJoin/MerchantJoin.aspx");
    }
}
