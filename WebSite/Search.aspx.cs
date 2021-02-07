using System;
using System.Collections.Generic;
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
using System.Collections;
using System.Text;
using DAL;

public partial class Search : System.Web.UI.Page 
{
    string strSql;
    DBConnection dbc;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (Request.Form["search"] != null && Request.Form["ch"] != null)
        {
            Response.ContentType = "text/plain";
            Response.Write("Hello World^");//测试ajax用
            //接受客户端关键字并且解码
            //string searchStr = HttpUtility.UrlDecode(Request.QueryString["search"].ToString(), System.Text.Encoding.UTF8);
            //string checkStr = Request.QueryString["ch"].ToString();
            string searchStr = Request.Form["search"].ToString();
            string checkStr = Request.Form["ch"].ToString();
            List<string> result1 = new List<string>();
            dbc = new DBConnection();

            //产品搜索
            if (checkStr.Equals("prd"))
            {
                strSql = @"SELECT   [pd_name] as name     FROM [mc_PdMaintain]";
            }else{
                strSql = @"SELECT   [mer_name] as name     FROM [mc_BasicInfo]";
            }
            ds = dbc.GetDataSet(strSql);
            int i = ds.Tables[0].Rows.Count;
            string s;
            for (i--; i >= 0; i--)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                s = dr["name"].ToString();
                if (s.Contains(searchStr) && !result1.Contains(s))
                {
                    result1.Add(s);
                }
            }
            StringBuilder sb = new StringBuilder(100);
            foreach (string str in result1)
            {
                sb.AppendFormat("{0}^", str);
            }
            Response.Write(sb.ToString());
            Response.End();
 
        }
        if (!Page.IsPostBack)
        {
            InitPagePrd();
            InitPageMer();
            if (Request.QueryString["SearchContent"] != null)
            {
                txtSearch.Value = Request.QueryString["SearchContent"].ToString();
                SearchBtn_Click(SearchBtn, null);
            }
        }
        
    }

    public void InitPagePrd()
    {
        DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
        DataSet merDs = mc.GetAllMerList("");

        if (merDs.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < merDs.Tables[0].Rows.Count; i++)
            {
                MerDpl.Items.Add(new ListItem(merDs.Tables[0].Rows[i]["mer_name"].ToString(), merDs.Tables[0].Rows[i]["mer_id"].ToString()));
            }
        }
        DAL.OveralManaDAL.CityManaDAL cm = new DAL.OveralManaDAL.CityManaDAL();
        DataSet cityDs = cm.getAllCity();
        if (cityDs.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < cityDs.Tables[0].Rows.Count; i++)
            {
                CityDpl.Items.Add(new ListItem(cityDs.Tables[0].Rows[i]["city_name"].ToString(), cityDs.Tables[0].Rows[i]["city_id"].ToString()));
            }
        }
    }

    public void InitPageMer()
    {
        DAL.OveralManaDAL.CityManaDAL cm = new DAL.OveralManaDAL.CityManaDAL();
        DataSet ds = cm.getAllCity();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                CityDpl2.Items.Add(new ListItem(ds.Tables[0].Rows[i]["city_name"].ToString(), ds.Tables[0].Rows[i]["city_id"].ToString()));
        }
    }

    protected void LookPrdBtn_Command(object sender, CommandEventArgs e)
    {
        int prdID = Convert.ToInt32(e.CommandArgument);
        DAL.OveralManaDAL.PrdManaDAL pd = new DAL.OveralManaDAL.PrdManaDAL();
        if (pd.setPrdInvalid(prdID) > 0)
            Response.Write("alertMessage('设置成功！')");
        else
            Response.Write("alertMessage('设置失败！')");
    }

    public void BindDataMer()
    {
        
    }

    protected void SendMsgBtn_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("MerMessage.aspx?merID=" + e.CommandArgument);
    }
    protected void LookMerBtn_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("MerMainPage.aspx?merID=" + e.CommandArgument);
    }

    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        if (PrdRb.Checked)
        {
            int cityID, merID;
            DAL.OveralManaDAL.PrdManaDAL pd = new DAL.OveralManaDAL.PrdManaDAL();
            if (MerDpl.SelectedValue.Equals("AllMer"))
            {
                merID = -1;
            }
            else
            {
                merID = Convert.ToInt32(MerDpl.SelectedValue);
            }
            if (CityDpl.SelectedValue.Equals("AllCity"))
            {
                cityID = -1;
            }
            else
            {
                cityID = Convert.ToInt32(CityDpl.SelectedValue);
            }
            PrdGrd.DataSource = pd.GetAllPrdList(txtSearch.Value, merID, cityID);
            PrdGrd.DataBind();
            dvPrd.Style.Add("display", "block");
            dvMer.Style.Add("display", "none");
        }
        if (MerRb.Checked)
        {

            BLL.OveralMana.MerchantMana.MerchantManaBLL mc = new BLL.OveralMana.MerchantMana.MerchantManaBLL();
            int cityID, stateID;
            if (CityDpl.SelectedValue.Equals("AllCity"))
            {
                cityID = -1;
            }
            else
            {
                cityID = Convert.ToInt32(CityDpl.SelectedValue);
            }
            if (StateDpl.SelectedValue.Equals("-1"))
            {
                stateID = -1;
            }
            else
            {
                stateID = Convert.ToInt32(StateDpl.SelectedValue);
            }
            MerListGrd.DataSource = mc.GetAllMerList(txtSearch.Value, stateID, cityID);
            MerListGrd.DataBind();

            dvMer.Style.Add("display", "block");
            dvPrd.Style.Add("display", "none");
        }
    } 
}
