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

public partial class OveralMana_MerchantMana_MerMessage : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            InitPage();        
        }
    }
    public void InitPage() {
        if (Request.QueryString["merID"] != null) {
            int merID = Convert.ToInt32(Request.QueryString["merID"]);
            DAL.OveralManaDAL.MsgManaDAL md = new DAL.OveralManaDAL.MsgManaDAL();
            DAL.OveralManaDAL.AuthMana at = new DAL.OveralManaDAL.AuthMana();
            int adminID = at.getAdminIDByName(Session["adminUserName"].ToString());
            MessageRpt.DataSource = md.getAdminMsgList(adminID,merID);
            MessageRpt.DataBind();
        }
    }
    /// <summary>
    /// 确认发送消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AssureBtn_Click(object sender, EventArgs e)
    {
        if (TitleBox.Text.Length > 0 && MsgContent.Value.Length > 0)
        {
            DAL.OveralManaDAL.AuthMana at = new DAL.OveralManaDAL.AuthMana();
            int adminID = at.getAdminIDByName(Session["adminUserName"].ToString());
            int merID = Convert.ToInt32(Request.QueryString["merID"]);
            DAL.OveralManaDAL.MsgManaDAL md = new DAL.OveralManaDAL.MsgManaDAL();
            int i = md.insertNewMsgA2M(adminID, merID, TitleBox.Text, MsgContent.Value);
            if (i > 0)
            {
                // Response.Write("<script>alert('消息发送成功');</script>");
                InitPage();
                MsgContent.Value = "";
                TitleBox.Text = "";
            }

        }else {
            alertMessage("消息的标题和内容不能为空！");
        }

    }
    protected void CancleBtn_Click(object sender, EventArgs e)
    {
        //MsgContent.Value = "";
        //TitleBox.Text = "";
      //  Response.Redirect("../Main.aspx");
        Response.Write("<script>alert('消息发送成功');</script>");
    }
}
