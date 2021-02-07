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
using DAL;
using System.Data.SqlClient;

public partial class MemberMana_AddMemberMana : MerchantManaBase
{
    private string merid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            merid = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                InitPage();
            }
        }

    }

    private void InitPage()
    {
    }

    protected void MerMemReg_Submit_onclick(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBConnection dbc = new DBConnection();

        string strsql = @"INSERT INTO [mb_BasicInfo]
           ([mem_name]
           ,[mem_psw]
           ,[mem_telephone]
           ,[card_type]
           ,[card_id]
           ,[mem_sex]
           ,[mer_id]
           ,[mem_addr]
           ,[mem_email]
           ,[mem_operator]
           ,[mem_op_time]
           ,[mem_money])
            VALUES
              (@MerMemReg_MemName
              ,@MerMemReg_Psw
              , @MerMemReg_Phone
              ,@MerMemReg_License
              ,@MerMemReg_LiID
              ,@MerMemReg_Male
              ,@MerMemReg_MemAddress
              ,@MerMemReg_Email
              ,@MerMemReg_MerID
              ,@MerMemReg_Optor
              ,@MerMemReg_Time
              ,@MerMemReg_Money)";
        SqlParameter[] paras = {

                                   new SqlParameter (@"MerMemReg_MemName",MerMemReg_MemName.Value),
                                   new SqlParameter (@"MerMemReg_Psw",MerMemReg_Psw.Value),
                                   new SqlParameter (@"MerMemReg_Phone",MerMemReg_Phone.Value),
                                   new SqlParameter (@"MerMemReg_License",MerMemReg_LicenseType.SelectedValue),
                                   new SqlParameter (@"MerMemReg_LiID",MerMemReg_LiID.Value),
                                   new SqlParameter (@"MerMemReg_Male",MerMemReg_Male.SelectedValue),
                                   new SqlParameter (@"MerMemReg_MemAddress",MerMemReg_MemAddress.Value),
                                   new SqlParameter (@"MerMemReg_Email",MerMemReg_Email.Value),
                                   new SqlParameter (@"MerMemReg_MerID",Session["username"].ToString()),
                                   new SqlParameter (@"MerMemReg_Optor",MerMemReg_Optor.Value),
                                   new SqlParameter (@"MerMemReg_Time",DateTime.Now),
                                   new SqlParameter (@"MerMemReg_Money",MerMemReg_Money.Value),

                               };
        
        int rtn = dbc.Execute(strsql, paras);

        string strsql1 = @"SELECT  [mer_id]
             FROM [mb_BasicInfo] where mer_id=@MerID ";

        SqlParameter[] para1 = { new SqlParameter("MerID", merid) };

        DataSet ds = dbc.GetDataSet(strsql1, para1);

        if (rtn > 0)
        {
            Response.Redirect("MemberList.aspx?mer_id=" + ds.Tables[0].Rows[0]["mer_id"].ToString());
        }
        else
        {
            Response.Write("<script>alert('登记会员失败');</script>");
        }

    }
}
