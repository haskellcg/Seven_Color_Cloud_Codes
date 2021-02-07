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

public partial class Default2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void AddMemBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMemberMana.aspx");
    }
    protected void SearchMemBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchMember.aspx");
    }

    protected void MemberDeleteBtn_Command(object sender, CommandEventArgs e)
    {
        DBConnection dbc = new DBConnection();
        string sql = "delete from mb_BasicInfo where mem_id = @MemID";
        string temp = e.CommandArgument.ToString();

        SqlParameter[] para = { new SqlParameter("MemID", temp) };
        dbc.Execute(sql, para);

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditMember")
        {
            string strmemid = e.CommandArgument.ToString();
            Response.Redirect("EditMember.aspx?id=" + strmemid);
        }

    }

}
