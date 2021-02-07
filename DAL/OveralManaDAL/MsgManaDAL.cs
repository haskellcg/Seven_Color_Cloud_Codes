using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.OveralManaDAL
{
    public class MsgManaDAL
    {
        /// <summary>
        /// 管理员向商家发送消息
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="merID"></param>
        /// <param name="msgTitle"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int insertNewMsgA2M(int adminID, int merID, string msgTitle, string content)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"INSERT INTO [shuaka].[dbo].[tb_msg]
           ([msg_title]
           ,[msg_cont]
           ,[msg_mer_id]
           ,[msg_time]
           ,[msg_admin_id]
           ,[msg_dir]
           ,[msg_state])
     VALUES
           (@msgTitle
           ,@msgContent
           ,@merID
           ,@Now
           ,@adminID
           ,0
           ,0)";
            SqlParameter[] para = { new SqlParameter(@"msgTitle", msgTitle), new SqlParameter(@"msgContent", content), new SqlParameter(@"merID", merID), new SqlParameter("Now", DateTime.Now), new SqlParameter("adminID", adminID) };
            return dbc.Execute(strSql, para);
        }

        /// <summary>
        /// 通过商家ID获取商家消息
        /// </summary>
        /// <param name="merID"></param>
        /// <returns></returns>
        public DataSet getMsgByMerID(int merID) {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [msg_id]
      ,[msg_title]
      ,[msg_cont]
      ,[msg_mer_id]
      ,[msg_time]
      ,[msg_admin_id]
      ,[msg_dir]
      ,[msg_state]
	  ,[admin_name]
	  ,[mer_name]
  FROM [shuaka].[dbo].[tb_msg]
  inner join [tb_admin]
  on [tb_admin].[admin_id]=[tb_msg].[msg_admin_id]
  inner join [mc_BasicInfo]
  on [mc_BasicInfo].[mer_id]=[tb_msg].[msg_mer_id]
  and [mc_BasicInfo].[mer_id]=@merID
  order by [msg_time] desc";
            SqlParameter[] para = { new SqlParameter(@"merID", merID) };
            return dbc.GetDataSet(strSql, para);
        }

        /// <summary>
        /// 通过商家ID获得商家未读消息列表
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <returns>返回未读消息数目</returns>
        public int QueryNewMsg(int merID)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [msg_id]
      ,[msg_title]
      ,[msg_cont]
      ,[msg_mer_id]
      ,[msg_time]
      ,[msg_admin_id]
      ,[msg_dir]
      ,[msg_state]
  FROM [shuaka].[dbo].[tb_msg]
  WHERE [msg_dir]=0 AND [msg_state]=0 AND [msg_mer_id]=@MerID";
            SqlParameter[] paras = { new SqlParameter("MerID", merID) };
            DataSet ds = dbc.GetDataSet(strSql, paras);

            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 向所有商家发送通知
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public int informToMer(int adminID, string msgTitle, string content)
        {
            DBConnection dbc = new DBConnection();
            string strSql1 = @"INSERT INTO [shuaka].[dbo].[tb_msg]
           ([msg_title]
           ,[msg_cont]
           ,[msg_time]
           ,[msg_admin_id]
           ,[msg_dir]
           ,[msg_state])
     VALUES
           (@msgTitle
           ,@msgContent
           ,@msgTime
           ,@adminID
           ,0
           ,2)";
            SqlParameter[] para = { new SqlParameter(@"msgTitle", msgTitle), new SqlParameter(@"msgContent", content), new SqlParameter("msgTime", DateTime.Now), new SqlParameter("adminID", adminID) };
            return dbc.Execute(strSql1, para);
        }

        /// <summary>
        /// 商家向管理员发送消息
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="merID"></param>
        /// <param name="msgTitle"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int insertNewMsgM2A(int adminID, int merID, string msgTitle, string content)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"INSERT INTO [shuaka].[dbo].[tb_msg]
           ([msg_title]
           ,[msg_cont]
           ,[msg_mer_id]
           ,[msg_time]
           ,[msg_admin_id]
           ,[msg_dir]
           ,[msg_state])
     VALUES
           (@msgTitle
           ,@msgContent
           ,@merID
           ,@Now
           ,@adminID
           ,1
           ,0)";
            SqlParameter[] para = { new SqlParameter(@"msgTitle", msgTitle), new SqlParameter(@"msgContent", content), new SqlParameter(@"merID", merID), new SqlParameter("Now", DateTime.Now), new SqlParameter("adminID", adminID) };
            return dbc.Execute(strSql, para);
        }
        /// <summary>
        /// 通过管理员和商家ID获取他们之间的消息
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="merID"></param>
        /// <returns></returns>
        public DataSet getAdminMsgList(int adminID, int merID)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [msg_id]
      ,[msg_title]
      ,[msg_cont]
      ,[msg_mer_id]
      ,[msg_time]
      ,[msg_admin_id]
      ,[msg_dir]
      ,[msg_state]
	  ,[admin_name]
	  ,[mer_name]
  FROM [shuaka].[dbo].[tb_msg]
  inner join [tb_admin]
  on [tb_admin].[admin_id]=[tb_msg].[msg_admin_id]
  inner join [mc_BasicInfo]
  on [mc_BasicInfo].[mer_id]=[tb_msg].[msg_mer_id]
  and [mc_BasicInfo].[mer_id]=@merID
  and [tb_admin].[admin_id]=@adminID
  order by [msg_time] desc";
            SqlParameter[] para = { new SqlParameter(@"merID", merID), new SqlParameter(@"adminID", adminID) };
            return dbc.GetDataSet(strSql, para);
        }

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <returns></returns>
        public DataSet getInformList()
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [msg_id]
      ,[msg_title]
      ,[msg_cont]
      ,[msg_time]
      ,[msg_admin_id]
      ,[msg_state]
	  ,[admin_name]
  FROM [shuaka].[dbo].[tb_msg]
  inner join [tb_admin]
  on [tb_admin].[admin_id]=[tb_msg].[msg_admin_id]
  and [msg_state]=2 order by [msg_time] desc
  ";
            return dbc.GetDataSet(strSql);
        }

        /// <summary>
        /// 通过商家ID和管理员ID更新消息状态
        /// </summary>
        /// <param name="adminID">管理员ID</param>
        /// <param name="merID">商家ID</param>
        /// <returns>受影响行数</returns>
        public int UpdateMsgList(int merID)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"UPDATE [shuaka].[dbo].[tb_msg]
            SET [msg_state] = 1
            WHERE [msg_mer_id]=@MerID AND [msg_state]=0 AND [msg_dir]=0";
            SqlParameter[] paras ={new SqlParameter("MerID",merID)};
            return dbc.Execute(strSql, paras);
        }
    }
}
