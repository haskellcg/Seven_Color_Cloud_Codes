using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.McManaDAL;
using System.Data;
using Entity;


namespace BLL.MerchantManage.CommentManaBLL
{
    public class CommentBLL
    {
        public int Comment(McComm mc)
        {
            CommentDAL cd = new CommentDAL();
            return cd.Comment(mc);
        }

        public int CommentReply(McComm mc, int cmID)
        {
            CommentDAL cd = new CommentDAL();
            return cd.CommentReply(mc,cmID);
        }

        public DataSet GetAllCommentList()
        {
            CommentDAL cd = new CommentDAL();
            return cd.GetAllCommentList();
        }
        public DataSet GetPageCommentList(int pageSize,int pageIndex,out int count)
        {
            CommentDAL cd = new CommentDAL();

            return cd.GetPageCommentList(pageIndex,pageSize,out count);
        }

        public DataSet GetCommentListByMcID(int mcID)
        {
            CommentDAL cd = new CommentDAL();
            return cd.GetCommentListByMcID(mcID);
        }

        public DataSet GetPageCommentListByMerID(int merID, int pageIndex, int pageSize, out int count)
        {
            CommentDAL cd = new CommentDAL();
            return cd.GetPageCommentListByMerID(merID,pageIndex,pageSize,out count);
        }

        public DataSet GetPageCommentListByPdID(int pdID, int pageIndex, int pageSize, out int count)
        {
            CommentDAL cd = new CommentDAL();
            return cd.GetPageCommentListByPdID(pdID, pageIndex, pageSize, out count);
        }
    }
}
