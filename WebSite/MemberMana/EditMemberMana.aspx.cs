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
using System.Data.SqlClient;
using DAL;

public partial class MemberMana_EditMemberMana : MerchantManaBase
{
    private string memid = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            memid = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                InitPage();

            }
        }

    }

    private void InitPage()
    {

        DBConnection dbc = new DBConnection();

        string strsql = @"SELECT  [mem_name]
           ,[mem_psw]
           ,[mem_telephone]
           ,[card_type]
           ,[card_id]
           ,[mem_sex]
           ,[mem_addr]
           ,[mem_email]
           ,[mer_id]
           ,[mem_operator]
           ,[mem_op_time]
           ,[mem_money]
             FROM [mb_BasicInfo] where mem_id=@MemID ";



        SqlParameter[] para = { new SqlParameter("MemID", memid) };



        DataSet ds = dbc.GetDataSet(strsql, para);

        if (ds.Tables[0].Rows.Count > 0)
        {

            MerMemReg_Phone.Text = ds.Tables[0].Rows[0]["mem_telephone"].ToString();
            MerMemReg_Psw.Text = ds.Tables[0].Rows[0]["mem_psw"].ToString();
            MerMemReg_LicenseType.SelectedValue = ds.Tables[0].Rows[0]["card_type"].ToString();
            MerMemReg_LiID.Text = ds.Tables[0].Rows[0]["card_id"].ToString();
            MerMemReg_MemName.Text = ds.Tables[0].Rows[0]["mem_name"].ToString();
            MerMemReg_Male.SelectedValue = ds.Tables[0].Rows[0]["mem_sex"].ToString();
            MerMemReg_MemAddress.Text = ds.Tables[0].Rows[0]["mem_addr"].ToString();
            MerMemReg_Email.Text = ds.Tables[0].Rows[0]["mem_email"].ToString();
            MerMemReg_MerID.Text = ds.Tables[0].Rows[0]["mer_id"].ToString();
            MerMemReg_Optor.Text = ds.Tables[0].Rows[0]["mem_operator"].ToString();
            MerMemReg_Time.Value = ds.Tables[0].Rows[0]["mem_op_time"].ToString();
            MerMemReg_Money.Text = ds.Tables[0].Rows[0]["mem_money"].ToString();

        }



    }



    protected void EditMemRtnBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberListMana.aspx");
    }
    protected void EditMemSaveBtn_Click(object sender, EventArgs e)
    {
        DBConnection dbc = new DBConnection();

        string strsql = @"update[mb_BasicInfo]set 
           [mem_name]=@MemName
            ,[mem_psw]=@MemPsw
            ,[mem_telephone]=@MemTelephone 
            ,[card_type]=@CardType
           ,[card_id]=@CardID
           ,[mem_sex]=@MemSex
           ,[mem_addr]=@MemAddr
           ,[mem_email]=@MemEmail
           ,[mer_id]=@MerID
           ,[mem_operator]=@MemOperator
           ,[mem_op_time]=@MemOpTime
           ,[mem_money]=@MemMoney where mem_id=@MemID";

        SqlParameter[] paras = {
                                   
                                   new SqlParameter (@"MemTelephone",MerMemReg_Phone.Text ),
                                   new SqlParameter (@"MemPsw",MerMemReg_Psw.Text),
                                   new SqlParameter (@"CardType", MerMemReg_LicenseType.SelectedValue),
                                   new SqlParameter (@"CardID", MerMemReg_LiID.Text),
                                   new SqlParameter (@"MemName",MerMemReg_MemName.Text),
                                   new SqlParameter (@"MemSex", MerMemReg_Male.SelectedValue),
                                   new SqlParameter (@"MemAddr", MerMemReg_MemAddress.Text),
                                   new SqlParameter (@"MemEmail",MerMemReg_Email.Text),
                                   new SqlParameter (@"MerID",MerMemReg_MerID.Text),
                                   new SqlParameter (@"MemOperator",MerMemReg_Optor.Text ),
                                   new SqlParameter (@"MemOpTime",MerMemReg_Time.Value),
                                   new SqlParameter (@"MemMoney",MerMemReg_Money.Text),
                                   new SqlParameter (@"MemID",memid)
                               };



        int rtn = dbc.Execute(strsql, paras);


        if (rtn > 0)
        {
            Response.Write("<script>alert('修改会员成功');location.href='MemberList.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('修改会员失败');</script>");
        }
    }
}
