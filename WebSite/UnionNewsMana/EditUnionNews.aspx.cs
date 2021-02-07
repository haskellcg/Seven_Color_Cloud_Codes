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

public partial class UnionNewsMana_EditUnionNews : System.Web.UI.Page
{
    private string newsid = "";
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
            NewsTitle.Text = ds.Tables[0].Rows[0]["news_title"].ToString();
            NewsFCKeditor1.Value = ds.Tables[0].Rows[0]["news_text"].ToString();
            NewsPublisher.Text = ds.Tables[0].Rows[0]["news_pub"].ToString();
        }



    }

    protected void NewsEditRtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("UnionNewsMana.aspx");
    }
    protected void NewsEditSave_Click(object sender, EventArgs e)
    {
        DBConnection dbc = new DBConnection();
        string strsql = @"update[tb_news]set [news_title]=@NewsTitle 
             ,[news_text]=@NewsText
              ,[news_pub]=@NewsPub
             ,[news_time]=@NewsTime where news_id=@NewsID";
        
        SqlParameter[] paras = {
                                   new SqlParameter (@"NewsTitle",NewsTitle.Text),
                                   new SqlParameter (@"NewsText",NewsFCKeditor1.Value),
                                   new SqlParameter (@"NewsPub",NewsPublisher.Text),
                                   new SqlParameter (@"NewsTime",DateTime.Now),
                                   new SqlParameter (@"NewsID",newsid),
                               };

        int rtn = dbc.Execute(strsql, paras);


        if (rtn > 0)
        {
            Response.Write("<script>alert('保存新闻成功');location.href='UnionNewsMana.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('保存新闻失败');</script>");
        }

    }
}
