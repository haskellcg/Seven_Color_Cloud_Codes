using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.OveralManaDAL
{
    public class MerchantManaDAL
    {
        DBConnection dbc;
        string strSql;
        ///<summary>
        ///获取所有的入盟的商家列表
        ///</summary>
        ///<rerturn>商家列表数据集</return>
        public DataSet GetAllMerList(string merName,int merState,int cityID)
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
      ,case when [mer_state]=0 then '未审核' when [mer_state]=1 then '通过' when [mer_state]=2 then '未通过' end as [mer_state]
      ,case [rec_mer_state] when 1 then '已推荐' else '未推荐' end as [rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo]
        WHERE 0=0";
           List<SqlParameter> para = new List<SqlParameter>();
            if (merName != null) {
                strSql += (@" and [mer_name] like "+@"@merName");
                para.Add(new SqlParameter(@"merName","%"+merName+"%"));
            }
            //strSql += " and [mer_name] like '%'" + "@merName" + "'%'";
            if(merState!=-1){
                strSql +=" and [mer_state]=@merState";
                para.Add(new SqlParameter(@"merState",merState));
            }
            if (cityID != -1) {
                strSql += " and [city_id]=@cityID";
                para.Add(new SqlParameter(@"cityID",cityID));
            }
             dbc = new DBConnection();
            if(para.Count==0){
                 return (dbc.GetDataSet(strSql));
            }else{
                 return dbc.GetDataSet(strSql,para.ToArray());
            }
            
        }
        /// <summary>
        /// 根据商家名称来查询商家列表
        /// </summary>
        /// <param name="merName"></param>
        /// <returns></returns>
        public DataSet GetAllMerList(string merName) {
            return GetAllMerList(merName, -1, -1);
        }
        /// <summary>
        /// 根据城市查询商家列表
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public DataSet GetAllMerList(int cityID)
        {
            return GetAllMerList(null, -1, cityID);
        }
        /// <summary>
        /// 根据商家状态和城市查询商家
        /// </summary>
        /// <param name="merState"></param>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public DataSet GetAllMerList(int merState, int cityID)
        {
            return GetAllMerList(null, merState, cityID);
        }
        ///<summary>
        ///获取所有的推荐的商家列表
        ///</summary>
        ///<rerturn>推荐商家列表数据集</return>
        public DataSet GetRecMerList()
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
  WHERE [rec_mer_state]=1";
            dbc = new DBConnection();
            return (dbc.GetDataSet(strSql));
        }

        /// <summary>
        /// 禁用商家
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>返回是否禁用成功</returns>
        public bool StopMer(int merID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
                      SET [mer_state] = 3 
                      WHERE [mer_id]=@merID";
            SqlParameter[] para = { new SqlParameter("merID", merID) };
            return (dbc.Execute(strSql, para) > 0);
        }

        public DataSet getMerDetailByID(int merID) {
            dbc = new DBConnection();
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
                  ,case [rec_mer_state] when 1 then '是' else '否' end as [rec_mer_state]
                  ,[mer_star_level]
              FROM [shuaka].[dbo].[mc_BasicInfo]
              where [mer_id]=@merID";
            SqlParameter[] para = { new SqlParameter("merID", merID) };
            return dbc.GetDataSet(strSql,para);
        }
        /// <summary>
        /// 设置推荐商家
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>返回是否成功设置推荐商家</returns>
        public bool SetRecMerchant(int merID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
                      SET [rec_mer_state] = 1 
                      WHERE [mer_id]=@merID";
            SqlParameter[] para = { new SqlParameter("merID", merID) };
            return (dbc.Execute(strSql, para) > 0);
        }

        /// <summary>
        /// 取消商家推荐
        /// </summary>
        /// <param name="merID"></param>
        /// <returns>返回是否成功，若是成功则返回1</returns>
        public bool CancelMerRec(int merID) {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
                      SET [rec_mer_state] = 0
                      WHERE [mer_id]=@merID";
            SqlParameter[] para = { new SqlParameter("merID", merID) };
            return (dbc.Execute(strSql, para) > 0);
        }

        public DataSet GetPagerMerList(string merName, int merState, int cityID,int PageSize,int PageIndex,out int count)
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
      ,case when [mer_state]=0 then '未审核' when [mer_state]=1 then '通过' when [mer_state]=2 then '未通过' end as [mer_state]
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo]
        WHERE 0=0";
            List<SqlParameter> para = new List<SqlParameter>();
            if (merName != null)
            {
                strSql += (@" and [mer_name] like " + @"@merName");
                para.Add(new SqlParameter(@"merName", "%" + merName + "%"));
            }
            //strSql += " and [mer_name] like '%'" + "@merName" + "'%'";
            if (merState != -1)
            {
                strSql += " and [mer_state]=@merState";
                para.Add(new SqlParameter(@"merState", merState));
            }
            if (cityID != -1)
            {
                strSql += " and [city_id]=@cityID";
                para.Add(new SqlParameter(@"cityID", cityID));
            }
            dbc = new DBConnection();
            if (para.Count == 0)
            {
                return (dbc.GetDataSet(strSql,"mer_id",PageSize,PageIndex,out count));
            }
            else
            {
                return dbc.GetDataSet(strSql,"mer_id",PageSize,PageIndex,out count, para.ToArray());
            }

        }
    }
}
