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
using BLL.MerchantManage.CommentManaBLL;
using Entity;

public partial class MerchantManage_CommentMana_MerReplyMana : MerchantManaBase
{
    public int mcID;
    int merID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            mcID = Convert.ToInt32(Request.QueryString["mc_id"]);
            merID = Convert.ToInt32(Session["user_ID"]);
            init();
        }      
    }
    public void init()
    {
        CommentBLL cb = new CommentBLL();
        DataSet ds = cb.GetCommentListByMcID(mcID);
        MerComRe_Content.Text = ds.Tables[0].Rows[0]["mc_content"].ToString();
        TBip.Text = ds.Tables[0].Rows[0]["mc_ip"].ToString();
        TBname.Text = ds.Tables[0].Rows[0]["mc_name"].ToString();
        TBtime.Text = ds.Tables[0].Rows[0]["mc_time"].ToString();
        Button1.CommandArgument = mcID.ToString();
    }
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        CommentBLL cb = new CommentBLL();
        McComm mc = new McComm();
        mc.ReplyContent = MerComRe_Reply.Text;
        mc.ReplyTime = DateTime.Now;
        mc.McID = mcID;
        mc.McReplyer = Session["username"].ToString();
        int i = cb.CommentReply(mc, Convert.ToInt32(e.CommandArgument));
        if (i > 0)
        {
            Response.Redirect("MerchantCommentList.aspx");
        }
    }
}
