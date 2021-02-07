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
using DAL.DisplayDAL;

public partial class MerchantList : System.Web.UI.Page
{
    public DataSet IndList;
    protected void Page_Load(object sender, EventArgs e)
    {
       // DAL.OveralManaDAL.MerchantManaDAL md = new DAL.OveralManaDAL.MerchantManaDAL();
       //Repeater1.DataSource =  md.GetAllMerList("", -1, -1);
       //Repeater1.DataBind();
        if (!Page.IsPostBack)
        {
            InitPage();
        }
    }

    protected void InitPage()
    {
        MerchantListDAL func = new MerchantListDAL();
        DataSet ds = new DataSet();
        DAL.OveralManaDAL.IndManaDAL idm = new DAL.OveralManaDAL.IndManaDAL();
        IndList = idm.getIndList();
        //int count=0;
        //ds = func.GetMerchantListForPage(AspNetPager1.PageSize,AspNetPager1.CurrentPageIndex,out count);
        //AspNetPager1.RecordCount = count;
        //Repeater1.DataSource = ds ;
        //Repeater1.DataBind();
    }
}
