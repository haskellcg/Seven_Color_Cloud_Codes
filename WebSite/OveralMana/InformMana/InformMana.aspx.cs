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

public partial class OveralMana_InformMana_InformMana : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            InitPage();
        }  
    }
    public void InitPage() {
        DAL.OveralManaDAL.MsgManaDAL ms = new DAL.OveralManaDAL.MsgManaDAL();
        MessageRpt.DataSource = ms.getInformList();
        MessageRpt.DataBind();
    }
    protected void AssureBtn_Click(object sender, EventArgs e)
    {
        if (TitleBox.Text.Length > 0 && MsgContent.Value.Length > 0)
        {
            DAL.OveralManaDAL.MsgManaDAL ms = new DAL.OveralManaDAL.MsgManaDAL();
            DAL.OveralManaDAL.AuthMana at = new DAL.OveralManaDAL.AuthMana();
            int adminID = at.getAdminIDByName(Session["adminUserName"].ToString());
            if (ms.informToMer(adminID, TitleBox.Text, MsgContent.Value) > 0)
            {
                InitPage();
            }
        }else {
            alertMessage("通知的标题和内容不能为空！");
        }
       
    }
    protected void CancleBtn_Click(object sender, EventArgs e)
    {
        //MsgContent.Value = "";
        //TitleBox.Text = "";
        //  Response.Redirect("../Main.aspx");
       
    }
}
