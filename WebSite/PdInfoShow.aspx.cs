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
using BLL.MerchantManage.CommentManaBLL;
using DAL.McManaDAL;
using Entity;

public partial class PdInfoShow : System.Web.UI.Page
{
    public int pdID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pdID"] != null)
            pdID = Convert.ToInt32(Request.QueryString["pdID"]);
         if (!Page.IsPostBack)
        {
            InitPage();
            BindPdInfo(pdID);
            BindCommentList();
        }
    }
    protected void InitPage()
    {
        DAL.McManaDAL.PdInfoMaintain pim = new PdInfoMaintain();
        string tem = pim.GetPdInfoByPdID(pdID).Tables[0].Rows[0]["mer_id"].ToString();
        DAL.McManaDAL.MerInfoMaintDAL func = new DAL.McManaDAL.MerInfoMaintDAL();
        int mer_id = int.Parse(tem);
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


    }
    public void BindPdInfo(int pdId)
    {
        PdInfoMaintain pim = new PdInfoMaintain();
        DataSet ds = pim.GetPdInfoByPdID(pdId);
        PdInfoShowRep.DataSource = ds;
        PdInfoShowRep.DataBind();
    }
    public void SubmitComment(object sender, EventArgs e)
    {
        string userip = Page.Request.UserHostAddress;
        McComm mc = new McComm();
        if (TBComment.Text == "")
        {
            return;
        }
        mc.McContent = TBComment.Text;
        mc.McIP = userip;
        mc.McName = TBName.Text;
        mc.McTime = DateTime.Now;
        mc.PdID = pdID;
        CommentDAL cd = new CommentDAL();
        cd.Comment(mc);
        TBComment.Text = "";
        TBName.Text = "";
        BindCommentList();

    }

    public void BindCommentList()
    {
        int count;
        CommentBLL cb = new CommentBLL();
        DataSet ds = cb.GetPageCommentListByPdID(pdID, CommentManaPager.CurrentPageIndex, CommentManaPager.PageSize, out count);
        CommentManaPager.RecordCount = count;
        RepeaterComList.DataSource = ds;
        RepeaterComList.DataBind();
    }
    protected void CommentManaPager_PageChanged(object sender, EventArgs e)
    {
        BindCommentList();
    }


}
