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

public partial class OveralMana_MerchantMana_MerchantMana : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){
            InitPage();    
        }
         
    }
    public void InitPage(){
        DAL.OveralManaDAL.CityManaDAL cm = new DAL.OveralManaDAL.CityManaDAL();
        DataSet ds = cm.getAllCity();
        if (ds.Tables[0].Rows.Count > 0) { 
            for(int i = 0;i< ds.Tables[0].Rows.Count;i++)
                CityDpl.Items.Add(new ListItem(ds.Tables[0].Rows[i]["city_name"].ToString(),ds.Tables[0].Rows[i]["city_id"].ToString()));
        }
    }
    public void BindData() { 
        BLL.OveralMana.MerchantMana.MerchantManaBLL mc = new BLL.OveralMana.MerchantMana.MerchantManaBLL();
        int cityID, stateID;
        if (CityDpl.SelectedValue.Equals("AllCity"))
        {
            cityID = -1;
        }
        else {
            cityID = Convert.ToInt32(CityDpl.SelectedValue);
        }   
        if (StateDpl.SelectedValue.Equals("-1"))
        {
            stateID = -1;
        }
        else {
            stateID = Convert.ToInt32(StateDpl.SelectedValue);
        }
       MerListGrd.DataSource = mc.GetAllMerList(SrchTextbox.Text, stateID, cityID);
       MerListGrd.DataBind();
    }
    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void SendMsgBtn_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("MerMessage.aspx?merID=" + e.CommandArgument);
    }
    protected void LookMerBtn_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("MerMainPage.aspx?merID=" + e.CommandArgument);
    }
}
