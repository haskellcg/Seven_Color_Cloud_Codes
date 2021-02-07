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

public partial class BuyWindow : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){
             if (Request.QueryString["pd_id"] != null) {
                 BntAssure.CommandArgument = Request.QueryString["pd_id"].ToString();
            }
        }
       
        
    }
    
    protected void BntAssure_Command(object sender, CommandEventArgs e)
    {
      
            int memID = Convert.ToInt32(TBMemID.Text);
            int pdID = Convert.ToInt32(e.CommandArgument);
            string memPwd = TBPwd.Text;
            PdInfoMaintain pdm = new PdInfoMaintain();
            float price = pdm.GetPriceByPdID(pdID);
            MemInfoMana mim = new MemInfoMana();
            float leftPrice = mim.QueryMemMoneyByMemID(memID);
            if (mim.IsExist(memID, memPwd))
            {
                if (leftPrice >= price)
                {
                    float left = leftPrice - price;
                    mim.ChangeMemMoneyByMemID(price, memID);
                    mim.RecordCost(memID, pdID, price);
                    Response.Write("<script>alert('购买成功！" + "您的余额为" + left.ToString() + "');window.close();</script>");

                }
                else
                {
                    Response.Write("<script>alert('您的余额已不足，请充值！');</script>");
                }
            }
            else
            { Response.Write("<script>alert('该会员不存在！');</script>"); }
    
    }
}
