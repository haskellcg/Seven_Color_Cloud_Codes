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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }


    protected void Add_News_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUnionNews.aspx");
    }
    protected void Search_News_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchUnionNews.aspx");

    }

    protected void BtnDeleteNews_Command(object sender, CommandEventArgs e)
    {
        DBConnection dbc = new DBConnection();
        string sql = "delete from tb_news where news_id = @NewsID";
        string temp = e.CommandArgument.ToString();

        SqlParameter[] para = { new SqlParameter("NewsID", temp) };
        dbc.Execute(sql, para);

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditNews")
        {
            string strnewsid = e.CommandArgument.ToString();
            Response.Redirect("EditUnionNews.aspx?id=" + strnewsid);
        }
    }
}
