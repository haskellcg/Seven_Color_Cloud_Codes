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


public partial class UnionNewsMana_NewsPage : System.Web.UI.Page
{
    private string newsid = "";
    public string newstitle = "";
    public string newspub = "";
    public string newstime = "";
    public string newstext = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            newsid = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                InitPage();

            }
        }
    }
    private void InitPage()
    {

        DBConnection dbc = new DBConnection();
        
        string strsql = @"SELECT [news_title]
             ,[news_text]
              ,[news_pub]
             ,[news_time]
             FROM [tb_News] where news_id=@NewsID ";

        SqlParameter[] para = { new SqlParameter("NewsID", newsid) };



        DataSet ds = dbc.GetDataSet(strsql, para);

        if (ds.Tables[0].Rows.Count > 0)
        {
            newstitle = ds.Tables[0].Rows[0]["news_title"].ToString();
            newstext= ds.Tables[0].Rows[0]["news_text"].ToString();
            newspub = ds.Tables[0].Rows[0]["news_pub"].ToString();
            newstime = ds.Tables[0].Rows[0]["news_time"].ToString();
        }



    }

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void NewsTime_TextChanged(object sender, EventArgs e)
    {

    }
}
