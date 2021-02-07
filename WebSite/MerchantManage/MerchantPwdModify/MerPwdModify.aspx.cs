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
using BLL.MerchantManage;

public partial class MerchantManage_MerchantPwdModify_MerPwdModify : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //先用Ajax验证原密码是否正确，js中此处简单处理了
    protected void MerPwdMod_Submit_Click(object sender, EventArgs e)
    {
        AccountManaBLL amb = new AccountManaBLL();

        if (amb.MerPwdMod(Session["username"].ToString(), MerPwdMod_NewPwd.Value))
        {
            Response.Write("<script>alert('修改密码成功！');</script>");
        }
        else
        {
            Response.Write("<script>alert('抱歉！修改密码失败！');</script>");
        }
    }
}
