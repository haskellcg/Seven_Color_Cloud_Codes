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
using DAL;

public partial class MerchantManage_MerInfoMaint_MerchantBasicInfoModify : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitPage();
        }
    }

    protected void InitPage()
    {
        int mer_id = int.Parse(Request.QueryString["mer_id"]);
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        McBasicInfo mc = func.GetMerchantInfoByID(mer_id);
        MerInfoMod_Name.Text = mc.MerName;
        MerInfoMod_Introduction.Text = mc.MerInfo;
        MerInfoMod_Pic.ImageUrl = mc.MerPic;
        MerInfoMod_Address.Text = mc.MerAddr;
        MerInfoMod_Telephone.Text = mc.MerPhone;
        MerInfoMod_Website.Text = mc.MerWebsite;
        MerInfoMod_Email.Text = mc.RegEmail;
        MerInfoMod_Relat.Text = mc.RegName;
        MerInfoMod_StarLevel.SelectedValue = mc.MerStarLever.ToString();
        MerInfoMod_Province.SelectedValue = "0";
        MerInfoMod_City.SelectedValue = "0";


    }

    protected void MerInfoMod_Submit_Click(object sender, EventArgs e)
    {
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        McBasicInfo mc = new McBasicInfo();
        int mer_id = int.Parse(Request.QueryString["mer_id"]);
        mc.MerID = mer_id;
        mc.MerName = MerInfoMod_Name.Text;
        mc.MerInfo = MerInfoMod_Introduction.Text;
        mc.MerPic = MerInfoMod_Pic.ImageUrl;
        mc.MerAddr = MerInfoMod_Address.Text;
        mc.MerPhone = MerInfoMod_Telephone.Text;
        mc.MerWebsite = MerInfoMod_Website.Text;
        mc.RegEmail = MerInfoMod_Email.Text;
        mc.RegName = MerInfoMod_Relat.Text;
        mc.MerStarLever = int.Parse(MerInfoMod_StarLevel.SelectedValue);
        mc.CityID = 2;


        func.UpdateMerchant(mc);
        Response.Redirect("MerchantShowInfoProtect.aspx?mer_id=" + mer_id);
    }
}
