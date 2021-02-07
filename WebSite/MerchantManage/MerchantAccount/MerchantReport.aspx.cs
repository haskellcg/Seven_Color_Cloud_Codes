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
using BLL.MerchantManage.ReportManaBLL;
using Entity;

public partial class MerchantManage_MerchantAccount_MerchantReport : MerchantManaBase
{
    public int merID;
    public float MoneyAccount;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            merID = Convert.ToInt32(Session["user_ID"]);
            BindReportMoney();
            BindReportList();

        }
    }

    public void BindReportList()
    {
        int count;
        ReportManaBLL rmb = new ReportManaBLL();
        DataSet ds = rmb.GetReportByMerID(merID, MerReportPager.PageSize,MerReportPager.CurrentPageIndex, out count);
        MerReportPager.RecordCount = count;
        ReportGrdList.DataSource = ds;
        ReportGrdList.DataBind();
    }

    public void MerReportPager_PageChanged(object sender, EventArgs e)
    {
        BindReportList();
    }

    public void BindReportMoney()
    {
        ReportManaBLL rmb = new ReportManaBLL();
        float str = rmb.GetReportMoney(merID);
        MoneyAccount = str;

    }
}

