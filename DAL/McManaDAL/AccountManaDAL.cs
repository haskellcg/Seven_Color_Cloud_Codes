using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace DAL.McManaDAL
{
    public class AccountManaDAL
    {
        string strSql;
        DBConnection dbc;
        /// <summary>
        /// 更改密码
        /// </summary>
        public bool UpdatePwdByTelephone(string telephone, string pwd)
        {

            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
   SET [mer_pwd] = @Pwd 
  WHERE [reg_telephone]=@TeleP";
            SqlParameter[] paras = { new SqlParameter("Pwd", pwd),
                                     new SqlParameter("TeleP", telephone)};
            return dbc.Execute(strSql, paras) > 0 ? true : false;
        }

        /// <summary>
        /// 更改商家信息
        /// </summary>
        public bool UpdateMerInfo(McBasicInfo mbi, string telephone)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
         SET [mer_type] = @MerType
      ,[mer_name] = @MerName
      ,[mer_address] = @MerAddr
      ,[mer_phone] = @MerPhone
      ,[mer_postcode] = @MerPostcode
      ,[mer_discount] = @MerDiscount
      ,[mer_pic] = @MerPic
      ,[mer_info] = @MerInfo
      WHERE [reg_telephone]=@TeleP";
            SqlParameter[] paras = {   new SqlParameter("MerType",mbi.MerType),
                                       new SqlParameter("MerName",mbi.MerName),
                                       new SqlParameter("MerAddr",mbi.MerAddr),
                                       new SqlParameter("MerPhone",mbi.MerPhone),
                                       new SqlParameter("MerPostcode",mbi.MerPostcode),
                                       new SqlParameter("MerDiscount",mbi.MerDiscount),
                                       new SqlParameter("MerPic",mbi.MerPic),
                                       new SqlParameter("MerInfo",mbi.MerInfo),
                                       new SqlParameter("TeleP",telephone)};
            if (dbc.Execute(strSql, paras) > 0)
                return true;
            else
                return false;
        }



        /// <summary>
        /// 商家查询密码
        /// </summary>
        public string GetPwdByTelephone(string telephone)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [mer_pwd]
      FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [reg_telephone]=@TeleP";
            SqlParameter[] para = { new SqlParameter("TeleP", telephone) };
            DataSet ds = dbc.GetDataSet(strSql, para);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0]["mer_pwd"].ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// 通过商家ID获取所有的商品信息数据集
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>返回会员金额的数据集</returns>
        public DataSet GetAllPdInfoByID(int merID)
        {
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
            dbc = new DBConnection();
            return (dbc.GetDataSet(strSql, para));
        }



        /// <summary>
        /// 通过商家ID获取所有的会员金额
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>返回会员金额的数据集</returns>
        public DataSet GetAllMemMoneyByID(int merID)
        {
            strSql = @"SELECT [mem_money]
                    FROM [shuaka].[dbo].[mb_BasicInfo]
                    WHERE [mer_id]=@MerID";
            SqlParameter[] para = { new SqlParameter("MerID", merID) };
            dbc = new DBConnection();
            return (dbc.GetDataSet(strSql, para));
        }


        /// <summary>
        /// 通过商家ID获取所有的会员全部信息
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>返回会员信息的数据集</returns>
        public DataSet GetAllMemInfoByID(int merID)
        {
            strSql = @"SELECT [mem_id]
      ,[mer_id]
      ,[card_type]
      ,[card_id]
      ,[mem_name]
      ,[mem_sex]
      ,[mem_telephone]
      ,[mem_addr]
      ,[mem_email]
      ,[mem_operator]
      ,[mem_op_time]
      ,[mem_psw]
      ,[mem_money]
       FROM [shuaka].[dbo].[mb_BasicInfo]
       WHERE [mer_id]=@MerID";
            SqlParameter[] para = { new SqlParameter("MerID", merID) };
            dbc = new DBConnection();
            return (dbc.GetDataSet(strSql, para));
        }

        /// <summary>
        /// 通过商家ID获得商家的营业额
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="merID"></param>
        /// <returns></returns>
        public string GetMerTotalMoney(DataSet ds, int merID)
        {
            int count = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                count += Convert.ToInt32(ds.Tables[0].Rows[i]["mem_money"].ToString());
            }
            return Convert.ToString(count);
        }
    }
}
