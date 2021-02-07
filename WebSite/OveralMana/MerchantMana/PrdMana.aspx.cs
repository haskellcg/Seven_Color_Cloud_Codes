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

public partial class OveralMana_MerchantMana_PrdMana : OveralManaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            InitPage();
        }
    }
    public void InitPage() {
        DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
        DataSet merDs = mc.GetAllMerList("");
        MerDpl.DataSource = merDs;
        if (merDs.Tables[0].Rows.Count > 0) {
            for (int i = 0; i < merDs.Tables[0].Rows.Count; i++) { 
                MerDpl.Items.Add(new ListItem(merDs.Tables[0].Rows[i]["mer_name"].ToString(),merDs.Tables[0].Rows[i]["mer_id"].ToString()));
            }
        }
        DAL.OveralManaDAL.CityManaDAL cm = new DAL.OveralManaDAL.CityManaDAL();
        DataSet cityDs= cm.getAllCity();
        if (cityDs.Tables[0].Rows.Count > 0) {
            for (int i = 0; i < cityDs.Tables[0].Rows.Count; i++) {
                CityDpl.Items.Add(new ListItem(cityDs.Tables[0].Rows[i]["city_name"].ToString(), cityDs.Tables[0].Rows[i]["city_id"].ToString()));
            }
        }
    }
    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        int cityID,merID;
        DAL.OveralManaDAL.PrdManaDAL pd = new DAL.OveralManaDAL.PrdManaDAL();
        if(MerDpl.SelectedValue.Equals("AllMer")){
            merID=-1;
        }else{
            merID =Convert.ToInt32(MerDpl.SelectedValue);
        }
        if(CityDpl.SelectedValue.Equals("AllCity")){
            cityID = -1;
        }else{
            cityID = Convert.ToInt32(CityDpl.SelectedValue);
        }
        PrdGrd.DataSource = pd.GetAllPrdList(SrchTextbox.Text, merID, cityID);
        PrdGrd.DataBind();
    }
    protected void LookPrdBtn_Command(object sender, CommandEventArgs e)
    {
        int prdID = Convert.ToInt32(e.CommandArgument);
        DAL.OveralManaDAL.PrdManaDAL pd = new DAL.OveralManaDAL.PrdManaDAL();
        if (pd.setPrdInvalid(prdID) > 0)
            alertMessage("设置成功！");
        else
            alertMessage("设置失败！");
    }
}
