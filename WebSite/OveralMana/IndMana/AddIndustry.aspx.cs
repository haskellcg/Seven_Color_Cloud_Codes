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

public partial class OveralMana_IndMana_AddIndustry : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IndTypeBox.Text.Length > 0) {
            DAL.OveralManaDAL.IndManaDAL im = new DAL.OveralManaDAL.IndManaDAL();
            if (im.AddIndustry(IndTypeBox.Text) > 0)
                alertMessage("添加成功", "../Main.aspx");
            else
                alertMessage("添加失败");
        }
    }
}
