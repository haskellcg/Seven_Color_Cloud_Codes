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

public partial class NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void NewsPage_Command(object sender, CommandEventArgs e)
    {
        DBConnection dbc = new DBConnection();
        string temp = e.CommandArgument.ToString();
        Response.Redirect("NewsPage.aspx?id=" + temp);


    }
}
