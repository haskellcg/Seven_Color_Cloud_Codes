using System;
using System.Collections;
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

public partial class OveralMana_AdminMana_AddAdmin : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void EnsureBtn_Click(object sender, EventArgs e)
    {
        DAL.OveralManaDAL.AdminMana am = new DAL.OveralManaDAL.AdminMana();
        
        string a = AuthCbl.SelectedValue;
        List<int> authList = new List<int>();
        for (int i = 0; i < AuthCbl.Items.Count; i++)
            if (AuthCbl.Items[i].Selected)
                authList.Add(Convert.ToInt32(AuthCbl.Items[i].Value));
       int result = am.addNewAdmin(UserNameTb.Text,PswTb.Value,authList.ToArray());
       if (result != -1)
           Response.Write("<script>alert('添加成功');location.href='../Main.aspx';</script>");
       else
           Response.Write("<script>alert('添加失败')</script>");
    }
}
