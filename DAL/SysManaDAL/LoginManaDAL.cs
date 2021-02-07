using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL.SysManaDAL
{
    public class LoginManaDAL
    {
        public string authAdminAcount(Entity.TbAdmin admin){
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [admin_psw]
                            FROM [dbo].[tb_admin]
                            where [admin_name]=@UserName";
            SqlParameter[] para = { new SqlParameter(@"UserName", admin.AdminName) };
            DataSet ds = dbc.GetDataSet(strSql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["admin_psw"].ToString();
            }
            else
                return "";
            
        }
        /// <summary>
        /// 根据管理ID获取密码
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public string getAdminPswByID(string adminName) { 
           return authAdminAcount(new Entity.TbAdmin(adminName,null));
        }
        public int changeAdminPsw(string adminName,string adminPsw) {
            DBConnection dbc = new DBConnection();
            string strSql = @"UPDATE [shuaka].[dbo].[tb_admin]
                            SET [admin_psw] = @adminPsw
                            WHERE [admin_name]=@adminName";
           SqlParameter[] para = { new SqlParameter(@"adminName", adminName),new SqlParameter(@"adminPsw",adminPsw) };
           return dbc.Execute(strSql, para);
        }
    }
}
