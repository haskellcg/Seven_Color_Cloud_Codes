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
using BLL.OveralMana.IndMana;

public partial class OveralMana_IndMana_IndModify : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        IndManaBLL imbll = new IndManaBLL();

        if (imbll.IndModif(ddlInd.Text, tbModInd.Text) == true)
        {
            Response.Write("<script>alert('恭喜修改成功！');</script>");
        }
    }
}
