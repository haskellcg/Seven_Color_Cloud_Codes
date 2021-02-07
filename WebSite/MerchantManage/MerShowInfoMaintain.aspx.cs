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

public partial class Default2 : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["user_ID"] != null) {
                InitPage();
            }           
        }
    }

    protected void InitPage()
    {
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        int mer_id = int.Parse(Session["user_ID"].ToString());
        McBasicInfo mc = func.GetMerchantInfoByID(mer_id);
        MerBas_Name.Text = mc.MerName;
        MerBas_Intro.Text = mc.MerInfo;
        MerBas_Pic.ImageUrl = Request.ApplicationPath+"/"+mc.MerPic;
        MerBas_Address.Text = mc.MerAddr;
        MerBas_Phone.Text = mc.MerPhone;
        MerBas_Web.Text = mc.MerWebsite;
        MerBas_Email.Text = mc.RegEmail;
        MerBas_Relat.Text = mc.RegName;
        MerBas_StarLevel.Text = "";
        for (int i = 0; i < int.Parse(mc.MerStarLever.ToString()); i++)
        {
            MerBas_StarLevel.Text += " ★ ";
        }
        string[] city_Pro = func.GetCityAndProvin(mc.CityID);
        MerBas_Province.Text = city_Pro[1];
        MerBas_City.Text = city_Pro[0];
        string state = "";
        switch (mc.MerState)
        {
            case 0:
                state = "未审核";
                break;
            case 1:
                state = "已通过";
                    break;
            case 2:
                    state = "未通过";
                    break;

        }
        MerBas_State.Text = state;


        int count = 0;
        DataSet ds = func.GetAllProductByMerID(mer_id, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count);
        AspNetPager1.RecordCount = count;
        MerProductList.DataSource = ds;
        MerProductList.DataBind();

    }

    protected void MerchantBasicInfoModifyBtn_Click(object sender, EventArgs e)
    {
        int mer_id = int.Parse(Session["user_ID"].ToString());
        Response.Redirect("../MerBasicInfoModify.aspx?mer_id=" + mer_id);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int mer_id = int.Parse(Session["user_ID"].ToString());
        Response.Redirect("MerchantPwdModify/MerPwdModify.aspx?mer_id=" + mer_id);
    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
        int mer_id = int.Parse(Session["user_ID"].ToString());
        Response.Redirect("~/MemberMana/AddMemberMana.aspx?mer_id=" + mer_id);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int mer_id = int.Parse(Session["user_ID"].ToString());
        Response.Redirect("~/MemberMana/MemberList.aspx?mer_id=" + mer_id);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("CommentMana/MerchantCommentList.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("MerchantAccount/MerchantReport.aspx");
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("MerchantProduct/AddProduct.aspx");
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
            Response.Redirect("MerchantProduct/ProductInfoModify.aspx?pro_id=" + prod_id);
        }
    }
}
