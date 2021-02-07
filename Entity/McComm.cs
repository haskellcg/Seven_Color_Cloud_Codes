using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class McComm
    {
        //点评编号
        private int mcID;
        public int McID
        {
            get { return mcID; }
            set { mcID = value; }
        }

        //产品编号
        private int pdID;
        public int PdID
        {
            get { return pdID; }
            set { pdID = value; }
        }

        //点评内容
        private string mcContent;
        public string McContent
        {
            get { return mcContent; }
            set { mcContent = value; }
        }

        //留言人IP
        private string mcIP;
        public string McIP
        {
            get { return mcIP; }
            set { mcIP = value; }
        }

        //留言人姓名
        private string mcName;
        public string McName
        {
            get { return mcName; }
            set { mcName = value; }
        }

        //留言时间
        private DateTime mcTime;
        public DateTime McTime
        {
            get { return mcTime; }
            set { mcTime = value; }
        }

        //是否有效
        private Boolean cmState;
        public Boolean CmState
        {
            get { return cmState; }
            set { cmState = value; }
        }

        //是否回复
        private Boolean cmReplyState;
        public Boolean CmReplyState
        {
            get { return cmReplyState; }
            set { cmReplyState = value; }
        }

        //回复人
        private string mcReplyer;
        public string McReplyer
        {
            get { return mcReplyer; }
            set { mcReplyer = value; }
        }

        //回复内容
        private string replyContent;
        public string ReplyContent
        {
            get { return replyContent; }
            set { replyContent = value; }
        }

        //回复时间
        private DateTime replyTime;
        public DateTime ReplyTime
        {
            get { return replyTime; }
            set { replyTime = value; }
        }
    }
}
