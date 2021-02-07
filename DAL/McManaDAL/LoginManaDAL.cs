using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class LoginManaDAL
    {
        /// <summary>
        /// 通过手机号和密码登录
        /// </summary>
        private string strSql;
        public string McLogin(string userID,string pwd)
        {
            DBConnection dbc = new DBConnection();
            strSql = @"SELECT [mer_id]
  FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [reg_telephone]=@Telep AND [mer_pwd]=@Pwd";
            SqlParameter[] para = { new SqlParameter(@"Telep", userID),
                                  new SqlParameter(@"Pwd", pwd)};
            DataSet ds = dbc.GetDataSet(strSql, para);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
                return null;
        }

    }
}
