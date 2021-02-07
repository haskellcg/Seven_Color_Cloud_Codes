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

public partial class Default2 : System.Web.UI.Page
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
        MerInfoMod_Pic.Src = mc.MerPic;
        MerInfoMod_Address.Text = mc.MerAddr;
        MerInfoMod_Telephone.Text = mc.MerPhone;
        MerInfoMod_Website.Text = mc.MerWebsite;
        MerInfoMod_Email.Text = mc.RegEmail;
        MerInfoMod_Relat.Text = mc.RegName;




        string[] city_Pro = func.GetCityAndProvin(mc.CityID);
        MerInfoMod_Province.DataSource = func.GetAllProvince();
        MerInfoMod_Province.DataValueField = "pro_id";
        MerInfoMod_Province.DataTextField = "pro_name";
        MerInfoMod_Province.DataBind();
        MerInfoMod_Province.Text = city_Pro[1];

        MerInfoMod_City.DataSource = func.GetAllCityByProvin(int.Parse(MerInfoMod_Province.SelectedValue));
        MerInfoMod_City.DataValueField = "city_id";
        MerInfoMod_City.DataTextField = "city_name";
        MerInfoMod_City.DataBind();
        MerInfoMod_City.Text = city_Pro[0];


    }

    protected void MerInfoMod_Submit_Click(object sender, EventArgs e)
    {
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        McBasicInfo mc = new McBasicInfo();
        int mer_id = int.Parse(Request.QueryString["mer_id"]);
        McBasicInfo mc_old = func.GetMerchantInfoByID(mer_id);
        mc.MerID = mer_id;
        mc.MerName = MerInfoMod_Name.Text;
        mc.MerInfo = MerInfoMod_Introduction.Text;
        mc.MerAddr = MerInfoMod_Address.Text;
        mc.MerPic = mc_old.MerPic;
        mc.MerPhone = MerInfoMod_Telephone.Text;
        mc.MerWebsite = MerInfoMod_Website.Text;
        mc.RegEmail = MerInfoMod_Email.Text;
        mc.RegName = MerInfoMod_Relat.Text;

        mc.CityID = int.Parse(MerInfoMod_City.SelectedValue);


        func.UpdateMerchant(mc);
        Response.Redirect("MerchantManage/MerShowInfoMaintain.aspx?mer_id=" + mer_id);
    }

    protected void UploadBtn_Click(object sender, EventArgs e)
    {
        if (!(uploadF.Value == null || uploadF.Value.Equals("")))
        {
            string path = uploadF.PostedFile.FileName;
            string fileExt = path.Substring(path.LastIndexOf('.') + 1);
            if (fileExt.ToLower().Equals("jpg") || fileExt.ToLower().Equals("png") || fileExt.ToLower().Equals("gif"))
            {
                string filePath = Server.MapPath("UpFiles") + "/mer_pic";


                string serverName = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileExt;
                uploadF.PostedFile.SaveAs(filePath + "/" + serverName);

                MerInfoMaintDAL func = new MerInfoMaintDAL();
                McBasicInfo mc = new McBasicInfo();
                int mer_id = int.Parse(Request.QueryString["mer_id"]);
                mc.MerID = mer_id;
                mc.MerName = MerInfoMod_Name.Text;
                mc.MerInfo = MerInfoMod_Introduction.Text;
                mc.MerAddr = MerInfoMod_Address.Text;
                mc.MerPic = "UpFiles/mer_pic/" + serverName;
                mc.MerPhone = MerInfoMod_Telephone.Text;
                mc.MerWebsite = MerInfoMod_Website.Text;
                mc.RegEmail = MerInfoMod_Email.Text;
                mc.RegName = MerInfoMod_Relat.Text;

                mc.CityID = int.Parse(MerInfoMod_City.SelectedValue);


                func.UpdateMerchant(mc);
                MerInfoMod_Pic.Src = "UpFiles/mer_pic/" + serverName;
            }
            else
            {
                Response.Write("<script>alert('不被允许的文件格式');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('没有文件');</script>");
        }
    }

    protected void MerInfoMod_Province_TextChanged(object sender, EventArgs e)
    {
        MerInfoMaintDAL func = new MerInfoMaintDAL();
        MerInfoMod_City.DataSource = func.GetAllCityByProvin(int.Parse(MerInfoMod_Province.SelectedValue));
        MerInfoMod_City.DataValueField = "city_id";
        MerInfoMod_City.DataTextField = "city_name";
        MerInfoMod_City.DataBind();
    }
}
