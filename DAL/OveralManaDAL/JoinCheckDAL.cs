using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.OveralManaDAL
{
    public class JoinCheckDAL
    {
        /// <summary>
        /// 通过手机号来查询并修改商家状态
        /// </summary>
        string strSql;
        public int OpenMcState(string telephone)
        {
            DBConnection dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
   SET [mer_state] = 1 
  WHERE [reg_phone]=@TeleP";
            SqlParameter []para = {new SqlParameter("TeleP",telephone)};
            return (dbc.Execute(strSql, para));
        }

        /// <summary>
        /// 通过手机号获得数据集
        /// </summary>
        /// <param name="telephone"></param>
        /// <returns></returns>
        public DataSet FindMcByTelephone(string telephone)
        {
            strSql = @"SELECT [mer_id]
      ,[ind_id]
      ,[city_id]
      ,[mer_type]
      ,[mer_name]
      ,[mer_address]
      ,[mer_phone]
      ,[mer_postcode]
      ,[mer_discount]
      ,[reg_name]
      ,[reg_duty]
      ,[reg_phone]
      ,[reg_telephone]
      ,[reg_email]
      ,[mer_pwd]
      ,[mer_pic]
      ,[mer_info]
      ,[mer_website]
      ,[mer_state]
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [reg_telephone]=@TeleP";
            SqlParameter []para = {new SqlParameter("TeleP", telephone)};
            DBConnection dbc = new DBConnection();
            return (dbc.GetDataSet(strSql, para));

        }
        ///<summary>
        ///获取未被审核的商家列表
        ///</summary>
        ///<rerturn>DataSet ApplyMerList</return>
       public DataSet GetApplyMerList(){
           strSql = @"SELECT [mer_id]
      ,[ind_id]
      ,[city_id]
      ,[mer_type]
      ,[mer_name]
      ,[mer_address]
      ,[mer_phone]
      ,[mer_postcode]
      ,[mer_discount]
      ,[reg_name]
      ,[reg_duty]
      ,[reg_phone]
      ,[reg_telephone]
      ,[reg_email]
      ,[mer_pwd]
      ,[mer_pic]
      ,[mer_info]
      ,[mer_website]
      ,[mer_state]
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [mer_state]=0";
           DBConnection dbc = new DBConnection();
           return (dbc.GetDataSet(strSql));
       }

        ///<summary>
        ///同意商家的入盟申请
        ///</summary>
        ///<rerturn>bool isSuccess</return>
       public bool agreeMerApply(string merID) {
           DBConnection dbc = new DBConnection();
           strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
   SET [mer_state] = 1 
  WHERE [mer_id]=@merID";
           SqlParameter[] para = { new SqlParameter("merID", merID) };
           return (dbc.Execute(strSql, para)>0);
       }

       ///<summary>
       ///拒绝商家的入盟申请
       ///</summary>
       ///<rerturn>bool isSuccess</return>
       public bool disagreeMerApply(string merID)
       {
           DBConnection dbc = new DBConnection();
           strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
   SET [mer_state] = 2 
  WHERE [mer_id]=@merID";
           SqlParameter[] para = { new SqlParameter("merID", merID) };
           return (dbc.Execute(strSql, para) > 0);
       }
        ///<summary>
        ///获取分页商家列表
        ///</summary>
        ///<rerturn>bool isSuccess</return>
       public DataSet getPageMerList(int pageIndex,int pageSize,out int count) {
           DBConnection db = new DBConnection();
           strSql = @"SELECT [mer_id]
      ,[ind_id]
      ,[city_id]
      ,[mer_type]
      ,[mer_name]
      ,[mer_address]
      ,[mer_phone]
      ,[mer_postcode]
      ,[mer_discount]
      ,[reg_name]
      ,[reg_duty]
      ,[reg_phone]
      ,[reg_telephone]
      ,[reg_email]
      ,[mer_pwd]
      ,[mer_pic]
      ,[mer_info]
      ,[mer_website]
      ,(case when [mer_state]=0 then '未审核' when [mer_state]=1 then '已审核' else '已拒绝' end) as mer_state
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo] 
      WHERE [mer_state]=0 "; //
           return db.GetDataSet(strSql, "mer_id", pageSize, pageIndex, out count);
       }
    }
}
