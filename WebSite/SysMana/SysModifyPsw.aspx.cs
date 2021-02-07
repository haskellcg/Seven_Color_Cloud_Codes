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

public partial class SysMana_SysModifyPsw : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AssureBtn_Click(object sender, EventArgs e)
    {
        DAL.SysManaDAL.LoginManaDAL dm = new DAL.SysManaDAL.LoginManaDAL();
        string adminName = Session["adminUserName"].ToString();
        string oldPsw = dm.getAdminPswByID(adminName);
        if (oldPsw.Equals(OldPswBtn.Value)) {
            if (NewPassword1.Value.Equals(NewPassword2.Value))
            {
                dm.changeAdminPsw(adminName, NewPassword1.Value);
                alertMessage("修改密码成功", "../OveralMana/Main.aspx");
            }
            else {
                alertMessage("两次密码输入不一致");
            }
        }else{
            alertMessage("原始密码输入错误");
        }
    }
}
