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

public partial class OveralMana_Default : OveralManaBase
{
    public string userName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["adminUserName"] != null)
            {
                initAuthTree();
                userName = Session["adminUserName"].ToString();
            }
        }

    }
    public void initAuthTree()
    {
        //if (Session["adminUserName"] == null)
        //{
        //    Response.Write("<script>alert('请先登录');location.href='../SysMana/SysLogin.aspx';</script>");
        //    //Response.Redirect("~/SysMana/SysLogin.aspx");
        //    return;
        //}
        BLL.OveralMana.AuthManaBLL am = new BLL.OveralMana.AuthManaBLL();
        string userName = Session["adminUserName"].ToString();
        DataSet authSet = am.getAuthIDByName(userName);
        if (authSet != null)
        {
            for (int i = 0; i < authSet.Tables[0].Rows.Count; i++)
            {

                ManaTree.Nodes[0].ChildNodes.Add(new TreeNode(authSet.Tables[0].Rows[i]["auth_name"].ToString(), ""));
                ManaTree.Nodes[0].ChildNodes[i].Selected = false;
                ManaTree.Nodes[0].ChildNodes[i].SelectAction = TreeNodeSelectAction.None;
                DataSet chAuthSet = am.getChildAuthByAuthID(Convert.ToInt32(authSet.Tables[0].Rows[i]["auth_id"]));
                if (chAuthSet != null)
                {
                    for (int j = 0; j < chAuthSet.Tables[0].Rows.Count; j++)
                    {
                        ManaTree.Nodes[0].ChildNodes[i].ChildNodes.Add(new TreeNode(chAuthSet.Tables[0].Rows[j]["ch_auth_name"].ToString(), null, null, chAuthSet.Tables[0].Rows[j]["ch_auth_url"].ToString(), "frmMain"));

                    }
                }
            }
        }

    }
    //protected void ManaTree_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if (((TreeView)sender).SelectedNode.Value!=null&&!((TreeView)sender).SelectedNode.Value.Equals("")) {
    //        string url = ((TreeView)sender).SelectedNode.Value;
    //        Response.Write("<script>window.onload=function(){document.getElementById('frmMain').src='" + url + "';}</script>");
    //    }
    //}
}
