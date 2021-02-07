using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class ReportManaDAL
    {
        DBConnection dbc;

        /// <summary>
        /// 通过商家ID获得所有会员的消费记录
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">当前索引</param>
        /// <param name="count">页总数</param>
        /// <returns></returns>
        public DataSet GetPagerReportByMerID(int merID, int pageSize, int pageIndex, out int count)
        {
            string strSql = @"SELECT TOP 100 PERCENT [shuaka].[dbo].[cost_record].[cost_id]
      ,[shuaka].[dbo].[cost_record].[pd_name]
      ,[cost_money]
      ,[shuaka].[dbo].[mb_BasicInfo].[mem_id]
      ,[mem_name]
      ,[cost_time]
FROM [shuaka].[dbo].[cost_record] INNER JOIN [shuaka].[dbo].[mb_BasicInfo]
ON  [shuaka].[dbo].[cost_record].[mem_id]=[shuaka].[dbo].[mb_BasicInfo].[mem_id]
INNER JOIN [shuaka].[dbo].[mc_PdMaintain] ON [shuaka].[dbo].[mc_PdMaintain].[pd_id]=[shuaka].[dbo].[cost_record].[pd_id]
WHERE [shuaka].[dbo].[cost_record].[mer_id]=@MerID ORDER BY [cost_time] DESC";
            dbc = new DBConnection();
            SqlParameter[] paras = { new SqlParameter("MerID", merID) };
            return dbc.GetDataSet(strSql, "cost_id", pageSize, pageIndex, out count, paras, "[cost_time] DESC");
        }

        /// <summary>
        /// 通过商家ID获得总营业额
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns></returns>
        public float GetReportMoney(int merID)
        {
            string strSql = @"SELECT SUM([cost_money])AS sum_money
  FROM [shuaka].[dbo].[cost_record] WHERE [mer_id]=@MerID";
            SqlParameter[] paras = { new SqlParameter("MerID", merID) };
            dbc = new DBConnection();
            return dbc.GetTotalMoney(strSql, paras);
        }
    }
}
