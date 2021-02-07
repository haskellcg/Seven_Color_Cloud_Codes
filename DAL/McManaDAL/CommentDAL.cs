using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class CommentDAL
    {
        string strSql;
        DBConnection dbc;
        DataSet ds;

        /// <summary>
        /// 会员点评商品
        /// </summary>
        /// <param name="mc">商品实体</param>
        /// <returns>返回点评ID</returns>
        public int Comment(McComm mc)
        {
            strSql = @"INSERT INTO [shuaka].[dbo].[mc_comm]
           ([pd_id]
           ,[mc_content]
           ,[mc_ip]
           ,[mc_name]
           ,[mc_time]
           ,[mc_state])
      VALUES
           (@PdID
           ,@McCon
           ,@McIP
           ,@McName
           ,@McTime
           ,@McState) SELECT @@IDENTITY AS 'pd_id'";
            SqlParameter[] paras = { new SqlParameter("PdID",mc.PdID),
                                     new SqlParameter("McCon",mc.McContent),
                                     new SqlParameter("McIP",mc.McIP),
                                     new SqlParameter("McName",mc.McName),
                                     new SqlParameter("McTime",mc.McTime),
                                     new SqlParameter("McState",mc.CmState=true)
                                    };
            dbc = new DBConnection();
            ds = dbc.GetDataSet(strSql, paras);
            string temp = ds.Tables[0].Rows[0]["pd_id"].ToString();
            return Convert.ToInt32(temp);
        }
        #region      未回复列表
        /// <summary>
        /// 获得会员评论但是商家未回复的点评列表数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetCommentListByMerID(int merID)
        {
            strSql = @"SELECT [shuaka].[dbo].[mc_PdMaintain].[pd_id]
      ,[pd_name]
      ,[mc_id]
      ,[mc_content]
      ,[mc_ip]
      ,[mc_name]
      ,[mc_time]
  FROM [shuaka].[dbo].[mc_PdMaintain]inner join [shuaka].[dbo].[mc_comm]
  on [shuaka].[dbo].[mc_PdMaintain].[pd_id]=[shuaka].[dbo].[mc_comm].[pd_id]
  WHERE [mer_id]=@MerID ORDER BY [mc_time] DESC";
            dbc = new DBConnection();
            SqlParameter[] paras = { new SqlParameter("MerID",merID)};
            return dbc.GetDataSet(strSql,paras);
        }
        #endregion
        #region  商家回复商品点评
        /// <summary>
        /// 商家回复商品点评
        /// </summary>
        /// <param name="cmID">点评ID</param>
        /// <returns>返回受影响行数</returns>
        public int CommentReply(McComm mc, int cmID)
        {
            strSql = @"UPDATE [shuaka].[dbo].[mc_comm]
         SET [mc_reply_state] = @ReplyState
      ,[mc_replyer] = @CmReplyer
      ,[reply_content] = @ReplyContent
      ,[reply_time] = @ReplyTime
         WHERE [mc_id]=@McID";
            SqlParameter[] paras = { new SqlParameter("CmReplyer",mc.McReplyer),
                                     new SqlParameter("ReplyContent",mc.ReplyContent),
                                     new SqlParameter("ReplyTime",mc.ReplyTime),
                                     new SqlParameter("ReplyState",mc.CmReplyState=true),
                                     new SqlParameter("McID",cmID)
                                    };
            dbc = new DBConnection();
            return dbc.Execute(strSql, paras);
        }
        #endregion
        #region
        /// <summary>
        /// 获得商家点评的所有评论
        /// </summary>
        /// <returns>评论列表数据集</returns>
        public DataSet GetAllCommentList()
        {
            strSql = @"SELECT [mc_id]
      ,[pd_id]
      ,[mc_content]
      ,[mc_ip]
      ,[mc_name]
      ,[mc_time]
      ,[mc_state]
      ,[mc_reply_state]
      ,[mc_replyer]
      ,[reply_content]
      ,[reply_time]
  FROM [shuaka].[dbo].[mc_comm]
  WHERE [mc_state]=1";
            dbc = new DBConnection();
            return dbc.GetDataSet(strSql);
        }
        #endregion

        /// <summary>
        /// 通过产品ID获取分页点评列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">页总数</param>
        /// <returns>分页数据集</returns>
        public DataSet GetPageCommentListByPdID(int pdID,int pageIndex, int pageSize, out int count)
        {
            dbc = new DBConnection();
            strSql = @"SELECT TOP 100 PERCENT [mc_id]
      ,[pd_id]
      ,[mc_content]
      ,[mc_ip]
      ,[mc_name]
      ,[mc_time]
      ,[mc_state]
      ,[mc_reply_state]
      ,[mc_replyer]
      ,[reply_content]
      ,[reply_time]
  FROM [shuaka].[dbo].[mc_comm]
  WHERE [pd_id]=@PdID ORDER BY [mc_time] DESC";
            SqlParameter[] paras = { new SqlParameter("PdID",pdID)};
            return dbc.GetDataSet(strSql, "mc_id", pageSize, pageIndex, out count,paras);
        }

        /// <summary>
        /// 获取所有分页点评列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">页总数</param>
        /// <returns>分页数据集</returns>
        public DataSet GetPageCommentList(int pageIndex, int pageSize, out int count)
        {
            dbc = new DBConnection();
            strSql = @"SELECT TOP 100 PERCENT [mc_id]
      ,[pd_id]
      ,[mc_content]
      ,[mc_ip]
      ,[mc_name]
      ,[mc_time]
      ,[mc_state]
      ,[mc_reply_state]
      ,[mc_replyer]
      ,[reply_content]
      ,[reply_time]
  FROM [shuaka].[dbo].[mc_comm]
  WHERE [mc_state]=1 ORDER BY [mc_time] DESC";
            return dbc.GetDataSet(strSql, "mc_id", pageSize, pageIndex, out count);
        }

        /// <summary>
        /// 通过商家ID获得所有产品点评列表页
        /// </summary>
        /// <param name="merID">商家ID</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">记录数</param>
        /// <returns>点评页表</returns>
        public DataSet GetPageCommentListByMerID(int merID, int pageIndex, int pageSize, out int count)
        {
            dbc = new DBConnection();
            strSql = @"SELECT TOP 100 PERCENT [shuaka].[dbo].[mc_comm].[pd_id]
      ,[mer_id]
      ,[pd_name]
      ,[mc_content]
      ,[mc_ip]
      ,[mc_name]
      ,[mc_time]
      ,[mc_id]
    FROM [shuaka].[dbo].[mc_comm] INNER JOIN
        [shuaka].[dbo].[mc_PdMaintain]
    ON [shuaka].[dbo].[mc_comm].[pd_id]=[shuaka].[dbo].[mc_PdMaintain].[pd_id]
    WHERE [mer_id]=@MerID AND [mc_reply_state] IS NULL
    ORDER BY [mc_time] DESC";
            SqlParameter[] paras = { new SqlParameter("MerID", merID) };
            return dbc.GetDataSet(strSql, "[mc_id]", pageSize, pageIndex, out count, paras);
        }


        #region   通过产品ID获得商品点评列表
        /// <summary>
        /// 通过点评ID获得商品点评列表
        /// </summary>
        /// <param name="mcID">点评编号</param>
        /// <returns>返回列表数据集</returns>
        public DataSet GetCommentListByMcID(int mcID)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [mc_id]
      ,[pd_id]
      ,[mc_content]
      ,[mc_ip]
      ,[mc_name]
      ,[mc_time]
      ,[mc_state]
      ,[mc_reply_state]
      ,[mc_replyer]
      ,[reply_content]
      ,[reply_time]
  FROM [shuaka].[dbo].[mc_comm]
  WHERE [mc_id]=@McID";
            SqlParameter[] paras = { new SqlParameter("McID",mcID)};
            return dbc.GetDataSet(strSql,paras);
        }
        #endregion
    }
}
