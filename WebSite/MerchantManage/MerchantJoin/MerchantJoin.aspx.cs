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
using Entity;
using BLL.MerchantManage.MerchantJoin;
using System.Data.SqlClient;
using DAL;

public partial class MerchantManage_MerchantJoin_MerchantJoin : System.Web.UI.Page
{
    string proName;
    string cityName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindProvince();
            proName = Provinceddl.Text;
            BindCity(proName);
        }
    }
    protected void MerJoin_Submit_Click(object sender, EventArgs e)
    {
        DAL.McManaDAL.JoinManaDAL jm = new DAL.McManaDAL.JoinManaDAL();
        if (!jm.IsExist(MerJoin_RelaTelePhone.Text))
        {
            JoinManaBLL jmb = new JoinManaBLL();
            McBasicInfo mcb = new McBasicInfo();
            string indType = MerJoin_Type.SelectedValue.ToString();

            mcb.IndID = Convert.ToInt32(indType);
            mcb.CityID = jmb.GetCityIDByName(Cityddl.SelectedValue.ToString());
            mcb.MerType = MerJoin_Type.SelectedValue.ToString();
            mcb.MerName = MerJoin_Name.Text;
            mcb.MerAddr = MerJoin_Address.Text;
            mcb.MerPhone = MerJoin_Phone.Text;
            mcb.MerPostcode = MerJoin_PostCode.Text;
            mcb.MerDiscount = MerJoin_MemberDiscountRate.SelectedValue.ToString();
            mcb.RegName = MerJoin_RelaName.Text;
            mcb.RegDuty = MerJoin_RelaDuty.Text;
            mcb.RegPhone = MerJoin_RelaPhone.Text;
            mcb.RegTelePhone = MerJoin_RelaTelePhone.Text;
            mcb.RegEmail = MerJoin_RelaEmail.Text;
            mcb.MerPwd = MerJoin_Pwd.Value;
            mcb.MerPic = "";
            mcb.MerInfo = MerJoin_Info.Value;
            mcb.MerWebsite = MerJoin_WebSite.Text;
            mcb.MerState = 0;
            mcb.RecMerState = false;
            mcb.MerStarLever = 0;


            jmb.JoinManage(mcb);

            Response.Write("<script>alert('恭喜注册成功！');location.href='../MerchantLogin/MerchantLogin.aspx'</script>");
        }
        else {
            Response.Write("<script>alert('手机号已经被注册，请更换手机号！');</script>");
        }
        
    }

    public void BindProvince()
    {
        ListItem lt=new ListItem("","空");
        string strSql = @"SELECT [pro_name]
  FROM [shuaka].[dbo].[tb_pro]";
        DBConnection dbc = new DBConnection();
        DataSet ds = dbc.GetDataSet(strSql);
        Provinceddl.DataSource = ds;
        Provinceddl.DataTextField=("pro_name");
        Provinceddl.DataValueField = ("pro_name");
        Provinceddl.DataBind();
        
    }

    public void BindCity(string proName)
    {
        string strSql = @"SELECT [city_name]
  FROM [shuaka].[dbo].[tb_city] inner join [shuaka].[dbo].[tb_pro]
  ON [shuaka].[dbo].[tb_city].[pro_id]=[shuaka].[dbo].[tb_pro].[pro_id]
  WHERE [pro_name]=@ProName";
        DBConnection dbc = new DBConnection();
        SqlParameter[] paras = { new SqlParameter("ProName", proName) };
        DataSet ds = dbc.GetDataSet(strSql, paras);
        Cityddl.DataSource = ds;
        Cityddl.DataTextField = ("city_name");
        Cityddl.DataValueField = ("city_name");
        Cityddl.DataBind();
        
    }



    protected void Provinceddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        proName = Provinceddl.Text;
        BindCity(proName);
    }
}
