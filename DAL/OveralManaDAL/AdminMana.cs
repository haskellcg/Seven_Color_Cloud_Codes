using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL.OveralManaDAL
{
    public class AdminMana
    {
        /// <summary>
        /// 增加新的管理员
        /// </summary>
        /// <param name="adminName">管理员账号</param>
        /// <param name="adminPsw">管理员密码</param>
        /// <param name="auth">权限合集</param>
        /// <returns>新增管理员id，若失败，则返回-1</returns>
        public int addNewAdmin(string adminName,string adminPsw,int[] auth)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"INSERT INTO [shuaka].[dbo].[tb_admin]
                         ([admin_name]
                        ,[admin_psw])
                         VALUES
	                    (@adminName
                          ,@adminPsw)
                         ;select distinct @@identity as [admin_id] from tb_admin";
            SqlParameter[] para = { new SqlParameter(@"adminName", adminName),new SqlParameter("@adminPsw",adminPsw)};
            
            DataSet ds = dbc.GetDataSet(strSql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int adminID = Convert.ToInt32(ds.Tables[0].Rows[0]["admin_id"]);
                if (auth.Length > 0)
                {
                    for (int i = 0; i < auth.Length; i++)
                    {
                        strSql = @"INSERT INTO [shuaka].[dbo].[auth_relation]
                                  ([auth_id]
                                 ,[admin_id])
                                 VALUES
                                 (@authID
                                 ,@adminID)";
                        SqlParameter[] tempPara = { new SqlParameter("adminID", adminID), new SqlParameter("authID", auth[i]) };
                        dbc.Execute(strSql, tempPara);
                    }
                }
                return adminID;
            }
            else
                return -1;
        }
    }
}
