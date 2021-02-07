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
using DAL.McManaDAL;
using Entity;
public partial class MerchantManage_CommentMana_MerchantCommentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindMerList();
        }
    }


    protected void Reply_Command(object sender, CommandEventArgs e)
    {
        string mcID = e.CommandArgument.ToString();
        if (mcID != null)
        {
            Response.Redirect("MerReplyMana.aspx?" + "mc_id=" + mcID);
        }
    }
    public void BindMerList()
    {
        int count;
        CommentBLL cb = new CommentBLL();
        DataSet ds = cb.GetPageCommentListByMerID(Convert.ToInt32(Session["user_ID"]), MerReplyPager.CurrentPageIndex, MerReplyPager.PageSize, out count);
        MerReplyPager.RecordCount = count;
        CommentListGrd.DataSource = ds;
        CommentListGrd.DataBind();
    }
    protected void MerReplyPager_PageChanged(object sender, EventArgs e)
    {
        BindMerList();
    }
}
