using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DisplayDAL
{
    public class MerInfoDisplay
    {
        private string strSql;
        DBConnection dbc;
        /// <summary>
        /// 通过商家ID获取所有产品信息
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>产品信息数据集</returns>
        public DataSet GetPdInfoByMerID(int merID)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [pd_id]
      ,[mer_id]
      ,[pd_name]
      ,[pd_price]
      ,[pd_mem_price]
      ,[pd_info]
      ,[pd_pic]
      ,[pd_state]
      ,[pd_note]
  FROM [shuaka].[dbo].[mc_PdMaintain]
  WHERE [mer_id]=@MerID";
            SqlParameter[] para = { new SqlParameter("MerID", merID) };
            return dbc.GetDataSet(strSql, para);
        }
    }
}
