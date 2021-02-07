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
using BLL;

public partial class UnionNewsMana_AddUnionNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void NewsAddReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("UnionNewsMana.aspx");
    }
    protected void NewsAddSave_Click(object sender, EventArgs e)
    {

        DBConnection dbc = new DBConnection();

        string strsql = @"INSERT INTO [tb_News]
               ([news_title]
             ,[news_text]
              ,[news_pub]
             ,[news_time])
            VALUES
               (@NewsTitle
               ,@NewsText
              ,@NewsPub
               ,@NewsTime)";
        SqlParameter[] paras = {
                                   new SqlParameter (@"NewsTitle",NewsTitle.Text),
                                   new SqlParameter (@"NewsText",FCKeditor1.Value),
                                   new SqlParameter (@"NewsPub",NewsPublisher.Text),
                                   new SqlParameter (@"NewsTime",DateTime.Now),
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
