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

public partial class UnionNewsSearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        DBConnection dbc = new DBConnection();
        string sql = "delete from tb_news where news_id = @NewsID";
        string temp = e.CommandArgument.ToString();

        SqlParameter[] para = { new SqlParameter("NewsID", temp) };
        dbc.Execute(sql, para);

        //SqlCommand cmd = new SqlCommand(sql);
        //cmd.ExecuteNonQuery();
    }

    protected void BtnEditNews_Command(object sender, CommandEventArgs e)
    {
        string strnewsid = e.CommandArgument.ToString();
        Response.Redirect("EditUnionNews.aspx?id=" + strnewsid);
    }


    
    protected void SearchNews_Click(object sender, EventArgs e)
    {

    }
    protected void SearchNewsReturn_Click1(object sender, EventArgs e)
    {
        Response.Redirect("UnionNewsMana.aspx");
    }
}
