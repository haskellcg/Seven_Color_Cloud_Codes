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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }

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
              ,@MerMemReg_MerID
              ,@MerMemReg_MemAddress
              ,@MerMemReg_Email
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
                                   new SqlParameter (@"MerMemReg_MerID",Convert.ToInt32(Session["user_ID"])),
                                   new SqlParameter (@"MerMemReg_Optor",MerMemReg_Optor.Value),
                                   new SqlParameter (@"MerMemReg_Time",DateTime.Now),
                                   new SqlParameter (@"MerMemReg_Money",MerMemReg_Money.Value),

                               };
        int rtn = dbc.Execute(strsql, paras);
        if (rtn > 0)
        {
            //Response.Write("<script>alert('登记会员成功');location.href='MemberList.aspx';</script>");
            alertMessage("登记会员成功", "MemberList.aspx");
        }
        else
        {
            alertMessage("登记会员失败");
        }

    }
}
