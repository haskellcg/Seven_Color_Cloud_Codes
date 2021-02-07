using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL.OveralManaDAL
{
    public class IndManaDAL
    {
        /// <summary>
        /// 修改行业的类型
        /// </summary>
        /// <param name="ind_ID">行业ID</param>
        /// <param name="ind_Type">行业类型</param>
        /// <returns></returns>
        public bool IndModify(int ind_ID, string ind_Type)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"UPDATE [shuaka].[dbo].[ind_Classify]
               SET [ind_type] = @Ind_Type
             WHERE [ind_id]=@Ind_ID";
            SqlParameter[] paras = { new SqlParameter("Ind_Type", ind_Type),
                                     new SqlParameter("Ind_ID", ind_ID)};
            int ind = 0;
            ind = dbc.Execute(strSql, paras);
            if (ind != 0)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 增加行业
        /// </summary>
        /// <param name="indType"></param>
        /// <returns></returns>
        public int AddIndustry(string indType) {
            DBConnection dbc = new DBConnection();
            string strSql = @"
            INSERT INTO [shuaka].[dbo].[ind_Classify]
           ([ind_type]
           ,[ind_state])
     VALUES
           (@indType
           ,0)";
            SqlParameter[] para = { new SqlParameter(@"indType", indType) };
           return dbc.Execute(strSql, para);
        }
        /// <summary>
        /// 获取行业列表
        /// </summary>
        /// <returns></returns>
        public DataSet getIndList() {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [ind_id]
      ,[ind_type]
      ,[ind_state]
  FROM [shuaka].[dbo].[ind_Classify]";
            return dbc.GetDataSet(strSql);
        }
    }
}
