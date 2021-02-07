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
using DAL.OveralManaDAL;
public partial class MerchantManage_MessageMana_MessageBox : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            if (Session["user_ID"] != null) {
                BindMsg();
            }
        }
       
    }
    public void BindMsg()
    {
        int merID = Convert.ToInt32(Session["user_ID"]);
        UpdateMsgList(merID);
        MsgManaDAL mmd = new MsgManaDAL();
        DataSet ds = mmd.getMsgByMerID(merID);
        RepeaterMsg.DataSource = ds;
        RepeaterMsg.DataBind();
    }

    public int UpdateMsgList(int MerID)
    {
        MsgManaDAL mmd = new MsgManaDAL();
        return mmd.UpdateMsgList (MerID);
    }
}
