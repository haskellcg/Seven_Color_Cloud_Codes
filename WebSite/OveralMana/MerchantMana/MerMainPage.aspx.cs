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

public partial class OveralMana_MerchantMana_MerMainPage : OveralManaBase
{
    public string merPicPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            InitPage();
        }    
    }
    /// <summary>
    /// 初始化界面
    /// </summary>
    public void InitPage() {
       
        if(Request.QueryString["merID"]!=null){
            DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
            int merID = Convert.ToInt32(Request.QueryString["merID"]);
            DataSet merDs = mc.getMerDetailByID(merID);
            MerDetailRpt.DataSource = merDs;
            MerDetailRpt.DataBind();
            if (merDs.Tables[0].Rows.Count > 0) { 
                string recState = merDs.Tables[0].Rows[0]["rec_mer_state"].ToString();
                RcmBtn.CommandArgument = merDs.Tables[0].Rows[0]["mer_id"].ToString();
                SendMsgBtn.CommandArgument = merDs.Tables[0].Rows[0]["mer_id"].ToString();
                merPicPath = merDs.Tables[0].Rows[0]["mer_pic"].ToString();
                if (recState.Equals("是"))
                {
                    RcmBtn.CommandName = "CancelMerRcm";
                    RcmBtn.Text = "取消商家推荐";
                }
                else {
                    RcmBtn.CommandName = "SetMerRcm";
                    RcmBtn.Text = "推荐该商家";
                }
            }
            DAL.OveralManaDAL.PrdManaDAL pd = new DAL.OveralManaDAL.PrdManaDAL();
           PrdRpt.DataSource = pd.GetAllPrdList("",merID,-1);
           PrdRpt.DataBind();
        }
       
    }
    /// <summary>
    /// 推荐商家设置与取消按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RcmBtn_OnCommand(object sender, CommandEventArgs e)
    {
        DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
        int merID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("CancelMerRcm"))
        {
            if (mc.CancelMerRec(merID))
                Response.Write("");//"<script>alert('取消成功')</script>"
        }else { 
            if(mc.SetRecMerchant(merID))
                Response.Write("");//"<script>alert('设置成功')</script>"
        }
        InitPage();
    }

    protected void SendMsgBtn_Command(object sender, CommandEventArgs e)
    {  
        Response.Redirect("MerMessage.aspx?merID=" + e.CommandArgument);
    }
}
