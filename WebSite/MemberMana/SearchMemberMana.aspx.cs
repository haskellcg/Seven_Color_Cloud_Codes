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

public partial class MemberMana_SearchMemberMana : MerchantManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }

    }
    protected void SearchMemRtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberListMana.aspx");
    }
    protected void SearchMemBtn_Click(object sender, EventArgs e)
    {

    }
}
