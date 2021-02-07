
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL.OveralManaDAL
{
    public class AuthMana
    {
        /// <summary>
        /// 通过userName查询admin_id
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>若存在，则返回admin_id，否则返回-1</returns>
        public int getAdminIDByName(string userName)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [admin_id]
                             FROM [shuaka].[dbo].[tb_admin]
                             WHERE [admin_name]=@userName";
            SqlParameter[] para = { new SqlParameter(@"userName",userName) };
            DataSet ds = dbc.GetDataSet(strSql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["admin_id"]);
            }
            else
                return -1;

        }
        /// <summary>
        /// 通过adminID查询权限关系表，返回admin所对应的权限集合
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns>若有权限，则返回DataSet集合，否则返回null</returns>
        public DataSet getAdminAuthByID(int adminID)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT t1.[auth_id],t2.[auth_name]
                              FROM [shuaka].[dbo].[auth_relation] as t1
                              inner join 
                              [shuaka].[dbo].[mana_auth] as t2
                              on t1.[auth_id]=t2.[auth_id] and t1.[admin_id]=@adminID";
            SqlParameter[] para = { new SqlParameter(@"adminID", adminID) };
            DataSet ds = dbc.GetDataSet(strSql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;

        }

        /// <summary>
        /// 通过权限id查询子权限记录表，获取子权限集合
        /// </summary>
        /// <param name="authID"></param>
        /// <returns>若存在子权限，则返回DataSet集合，否则返回null</returns>
        public DataSet getChildAuthByAuthID(int authID)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [ch_auth_name],[ch_auth_url]
                            FROM [shuaka].[dbo].[ch_auth]
                            WHERE [auth_id]=@authID";
            SqlParameter[] para = { new SqlParameter(@"authID", authID) };
            DataSet ds = dbc.GetDataSet(strSql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }        
    }
}
