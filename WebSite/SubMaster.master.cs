using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
public partial class SubMaster : System.Web.UI.MasterPage
{
    string strSql;
    DBConnection dbc;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["search"] != null )
        {
            Response.ContentType = "text/plain";
            Response.Write("Hello World^");//测试ajax用
            //接受客户端关键字并且解码
            //string searchStr = HttpUtility.UrlDecode(Request.QueryString["search"].ToString(), System.Text.Encoding.UTF8);
            //string checkStr = Request.QueryString["ch"].ToString();
            string searchStr = Request.Form["search"].ToString();
            //string checkStr = Request.Form["ch"].ToString();
            List<string> result1 = new List<string>();
            dbc = new DBConnection();

            //产品搜索
            //if (checkStr.Equals("prd"))
            //{
                strSql = @"SELECT   [pd_name] as name     FROM [mc_PdMaintain]";
            //}
            //else
            //{
            //    strSql = @"SELECT   [mer_name] as name     FROM [mc_BasicInfo]";
            //}
            ds = dbc.GetDataSet(strSql);
            int i = ds.Tables[0].Rows.Count;
            string s;
            for (i--; i >= 0; i--)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                s = dr["name"].ToString();
                if (s.Contains(searchStr) && !result1.Contains(s))
                {
                    result1.Add(s);
                }
            }
            StringBuilder sb = new StringBuilder(100);
            foreach (string str in result1)
            {
                sb.AppendFormat("{0}^", str);
            }
            Response.Write(sb.ToString());
            Response.End();

        }

    }
   
}
