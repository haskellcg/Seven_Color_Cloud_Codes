using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class PdInfoMaintain
    {
        string strSql;
        DBConnection dbc;
        DataSet ds;
        /// <summary>
        /// 商家添加商品信息，返回商品ID
        /// </summary>
        /// <param name="mc">商品信息实体</param>
        /// <returns>商品ID</returns>
        public int AddPd(McPdMaintain mpm)
        {
            dbc = new DBConnection();
            strSql = @"INSERT INTO [shuaka].[dbo].[mc_PdMaintain]
           ([mer_id]
           ,[pd_name]
           ,[pd_price]
           ,[pd_mem_price]
           ,[pd_info]
           ,[pd_pic]
           ,[pd_state]
           ,[pd_note])
     VALUES
           (@MerID
           ,@PdName
           ,@PdPrice
           ,@PdMemPrice
           ,@PdInfo
           ,@PdPic
           ,@PdState
           ,@PdNote) SELECT @@IDENTITY AS 'pd_id'";
            SqlParameter[] paras = { new SqlParameter("MerID",mpm.MerID),
                                     new SqlParameter("PdName",mpm.PdName),
                                     new SqlParameter("PdPrice",mpm.PdPrice),
                                     new SqlParameter("PdMemPrice",mpm.PdMemPrice),
                                     new SqlParameter("PdInfo",mpm.PdInfo),
                                     new SqlParameter("PdPic",mpm.PdPic),
                                     new SqlParameter("PdState",mpm.PdState),
                                     new SqlParameter("PdNote",mpm.PdNote)};
            ds = dbc.GetDataSet(strSql, paras);
            string temp = ds.Tables[0].Rows[0]["pd_id"].ToString();
            return Convert.ToInt32(temp);
        }

        /// <summary>
        /// 获得商品状态
        /// </summary>
        /// <param name="pdID">商品ID</param>
        /// <returns></returns>
        public bool GetPdStateByPdID(int pdID)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [pd_state]
                FROM [shuaka].[dbo].[mc_PdMaintain]
                WHERE [pd_id]=@PdID";
            SqlParameter[] paras = { new SqlParameter("PdID", Convert.ToString(pdID)) };
            ds = dbc.GetDataSet(strSql, paras);
            string str = Convert.ToString(ds.Tables[0].Rows[0]["pd_state"]);
            if (str == "True")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 商家启用商品的状态
        /// </summary>
        /// <param name="pdID">商品ID</param>
        /// <returns>返回受影响行数</returns>
        public int OpenPdStateByPdID(int pdID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_PdMaintain]
                 SET [pd_state]='1'
                 WHERE [pd_id]=@PdID";
            SqlParameter[] paras = { new SqlParameter("PdID", Convert.ToString(pdID)) };
            return dbc.Execute(strSql, paras);
        }

        /// <summary>
        /// 商家启禁用商品的状态
        /// </summary>
        /// <param name="pdID">商品ID</param>
        /// <returns>返回受影响行数</returns>
        public int ClosePdStateByPdID(int pdID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_PdMaintain]
                 SET [pd_state]='0'
                 WHERE [pd_id]=@PdID";
            SqlParameter[] paras = { new SqlParameter("PdID", pdID) };
            return dbc.Execute(strSql, paras);
        }

        /// <summary>
        /// 通过商品ID获得商品信息
        /// </summary>
        /// <param name="pdID">商品ID</param>
        /// <returns>返回商品信息集</returns>
        public DataSet GetPdInfoByPdID(int pdID)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [pd_name]
      ,[mer_id]
      ,[pd_price]
      ,[pd_mem_price]
      ,[pd_info]
      ,[pd_pic]
      ,[pd_state]
      ,[pd_note]
  FROM [shuaka].[dbo].[mc_PdMaintain]
  WHERE [pd_id]=@PdID";
            SqlParameter[] paras = { new SqlParameter("PdID", pdID) };
            return dbc.GetDataSet(strSql, paras);
        }

        /// <summary>
        /// 通过产品ID获得产品价格
        /// </summary>
        /// <param name="pdID">产品ID</param>
        /// <returns>返回价格</returns>
        public float GetPriceByPdID(int pdID)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [pd_mem_price]
                FROM [shuaka].[dbo].[mc_PdMaintain]
                WHERE [pd_id]=@PdID";
            SqlParameter[] paras = { new SqlParameter("PdID", pdID) };
            DataSet ds = dbc.GetDataSet(strSql, paras);
            int count = ds.Tables[0].Rows.Count;
            string a = ds.Tables[0].Rows[0]["pd_mem_price"].ToString();
            float price = float.Parse(a);
            return price;
        }
    }
}