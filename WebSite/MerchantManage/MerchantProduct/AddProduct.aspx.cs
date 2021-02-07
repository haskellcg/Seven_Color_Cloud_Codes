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

public partial class MerchantManage_MerchantProduct_AddProduct : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddPro_Submit_Click(object sender, EventArgs e)
    {
        int mer_id = int.Parse(Session["user_ID"].ToString());
        int pageSize = 6;
        DAL.McManaDAL.MerInfoMaintDAL func = new DAL.McManaDAL.MerInfoMaintDAL();
        McPdMaintain mcpd = new McPdMaintain();
        mcpd.MerID = mer_id;
        mcpd.PdName = AddPro_Name.Text;
        mcpd.PdPrice = float.Parse(AddPro_Price.Text);
        mcpd.PdMemPrice = float.Parse(AddPro_MemPrice.Text);
        mcpd.PdInfo = AddPro_Intro.Text;
        mcpd.PdState = AddPro_State.SelectedValue.Equals("1") == true ? true : false;
        mcpd.PdNote = AddPro_Note.Text;
        if (uploadF.Value == null || uploadF.Equals(""))
        {
            mcpd.PdPic = "";
        }
        else
        {
            string filename = uploadF.PostedFile.FileName;
            string fileExt = filename.Substring(filename.LastIndexOf('.') + 1);
            string newName = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileExt;
           
            string uploadFolder =Server.MapPath("../../")+"/UpFiles" + "/prd_pic/" + newName;
            uploadF.PostedFile.SaveAs(uploadFolder);

            string databasePath = "UpFiles/prd_pic/" + newName;
            mcpd.PdPic = databasePath;
        }

        int pro_id = func.AddProduct(mcpd);
        int pageIndex = (func.ProductCountInMerchant(mer_id) / pageSize) + 1;


        Response.Redirect("../MerShowInfoMaintain.aspx?mer_id=" + mer_id + "&pro_id=" + pro_id + "&page_index=" + pageIndex);

    }
}
