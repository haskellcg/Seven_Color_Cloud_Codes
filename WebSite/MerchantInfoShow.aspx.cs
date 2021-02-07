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
using DAL.McManaDAL;
using Entity;

public partial class MerchantInfoShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Response.Write("<script>if(top.location!=self.location)top.location = self.location;</script>");
            InitPage();
        }

    }
    protected void InitPage()
    {
        DAL.McManaDAL.MerInfoMaintDAL func = new DAL.McManaDAL.MerInfoMaintDAL();
        int mer_id = int.Parse(Request.QueryString["mer_id"]);
        McBasicInfo mc = func.GetMerchantInfoByID(mer_id);
        MerBas_Name.Text = mc.MerName;
        MerBas_Intro.Text = mc.MerInfo;
        MerBas_Pic.ImageUrl = mc.MerPic;
        MerBas_Address.Text = mc.MerAddr;
        MerBas_Phone.Text = mc.MerPhone;
        MerBas_Web.Text = mc.MerWebsite;
        MerBas_Email.Text = mc.RegEmail;
        MerBas_Relat.Text = mc.RegName;
        MerBas_StarLevel.Text = mc.MerStarLever.ToString();
        string[] city_Pro = func.GetCityAndProvin(mc.CityID);
        MerBas_Province.Text = city_Pro[1];
        MerBas_City.Text = city_Pro[0];



        int count = 0;
        DataSet ds = func.GetAllProductByMerID(mer_id, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count);
        AspNetPager1.RecordCount = count;
        PrdRpt.DataSource = ds;
        PrdRpt.DataBind();
        


    }

    protected void MerchantBasicInfoModifyBtn_Click(object sender, EventArgs e)
    {
        int mer_id = int.Parse(Request.QueryString["mer_id"]);
        Response.Redirect("MerchantBasicInfoModify.aspx?mer_id=" + mer_id);
    }



    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        InitPage();


    }

    protected void MerProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "MerProductListCmd")
        {
            int prod_id = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("ProductInfoModify.aspx?pro_id=" + prod_id);
        }
    }
}
