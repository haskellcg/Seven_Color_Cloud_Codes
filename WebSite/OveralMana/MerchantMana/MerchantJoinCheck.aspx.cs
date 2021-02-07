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

public partial class MerchantMana_MerchantJoinCheck : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            BindMerList();
        }
    }
    public void initPage() {
        BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL mc = new BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL();
        JionMerListGrd.DataSource = mc.GetJionMerList();
        JionMerListGrd.DataBind();
    }
    protected void CheckNo_Command(object sender, CommandEventArgs e)
    {
       string merID = e.CommandArgument.ToString();
       if (merID != null)
       {
           BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL mj = new BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL();
           if (mj.DisagreeMerApply(merID)) {
               BindMerList();
               Response.Write("<script>alert('拒绝成功');</script>");
           }
              
       }
    }
    protected void CheckYes_Command(object sender, CommandEventArgs e)
    {
        string merID = e.CommandArgument.ToString();
        if (merID != null)
        {
            BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL mj = new BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL();
            if (mj.AgreeMerApply(merID)) {
                BindMerList();
                Response.Write("<script>alert('审核成功');</script>");
            }
                
        }
    }
    public void BindMerList() {
        int count;
        BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL mc = new BLL.OveralMana.MerchantMana.MerchantJoinCheckBLL();
        DataSet ds = mc.getPageMerList(MerJionCheckPager.PageSize, MerJionCheckPager.CurrentPageIndex,out count);
        MerJionCheckPager.RecordCount = count;
        JionMerListGrd.DataSource = ds;
        JionMerListGrd.DataBind();
    }
    protected void MerJionCheckPager_PageChanged(object sender, EventArgs e)
    {
        BindMerList();
    }
}
