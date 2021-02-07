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
using DAL.McManaDAL;

public partial class MemberMana_ChargeForMem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Charge_Submit_Click(object sender, EventArgs e)
    {
        DAL.McManaDAL.MerInfoMaintDAL func = new DAL.McManaDAL.MerInfoMaintDAL();
        int mem_id = int.Parse(Charge_MemID.Text);
        float money = float.Parse(Charge_Money.Text);

        int result = func.ChargeMoneyForMem(mem_id, money);


        Response.Write("<script>alert('充值成功')</script>");
        Response.Write("<script>window.opener=null;window.close();</script>");
    }

}
