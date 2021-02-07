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

public partial class MerchantManage_MerInfoMaint_ProductInfoModify : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitPage();
        }
    }

    public void InitPage()
    {
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        int pro_id = int.Parse(Request.QueryString["pro_id"]);
        McPdMaintain mcpd = func.GetProductInfoByID(pro_id);
        ProdInfo_Name.Text = mcpd.PdName;
        ProdInfo_Price.Text = mcpd.PdPrice.ToString();
        ProdInfo_DiscountPrice.Text = mcpd.PdMemPrice.ToString();
        ProdMod_Introduce.Text = mcpd.PdInfo;
        ProdMod_Pic.ImageUrl = mcpd.PdPic;
        ProdMod_Able.SelectedValue = mcpd.PdState == true ? "1" : "0";
        ProdMod_Info.Text = mcpd.PdNote;


    }

    public void ProdMod_Submit_Click(object sender, EventArgs e)
    {
        McPdMaintain UPmcpd = new McPdMaintain();
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        int pro_id = int.Parse(Request.QueryString["pro_id"]);
        McPdMaintain mcpd = func.GetProductInfoByID(pro_id);
        UPmcpd.PdID = pro_id;
        UPmcpd.MerID = mcpd.MerID;
        UPmcpd.PdName = ProdInfo_Name.Text;
        UPmcpd.PdPrice = float.Parse(ProdInfo_Price.Text);
        UPmcpd.PdMemPrice = float.Parse(ProdInfo_DiscountPrice.Text);
        UPmcpd.PdInfo = ProdMod_Introduce.Text;
        UPmcpd.PdPic = ProdMod_PicFile.Value;
        UPmcpd.PdState = ProdMod_Able.SelectedValue.Equals("1") ? true : false;
        UPmcpd.PdNote = ProdMod_Info.Text;


        func.UpdateProduct(UPmcpd);
        Response.Redirect("MerchantShowInfoProtect.aspx?mer_id=" + mcpd.MerID);
    }
}
