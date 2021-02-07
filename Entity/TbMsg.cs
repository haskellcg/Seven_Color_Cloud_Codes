using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class TbMsg
    {
        //站内信ID
        private int msgID;
        public int MsgID
        {
            get { return msgID; }
            set { msgID = value; }
        }

        //站内信标题
        private string msgTitle;
        public string MsgTitle
        {
            get { return msgTitle; }
            set { msgTitle = value; }
        }

        //站内信内容
        private string msgCont;
        public string MsgCont
        {
            get { return msgCont; }
            set { msgCont = value; }
        }

        //发件人
        private string msgPbs;
        public string MsgPbs
        {
            get { return msgPbs; }
            set { msgPbs = value; }
        }

        //发件时间
        private DateTime msgTime;
        public DateTime MsgTime
        {
            get { return msgTime; }
            set { msgTime = value; }
        }

        //收件人
        private string msgReplyer;
        public string MsgReplyer
        {
            get { return msgReplyer; }
            set { msgReplyer = value; }
        }

        //回复时间
        private DateTime msgReplyTime;
        public DateTime MsgReplyTime
        {
            get { return msgReplyTime; }
            set { msgReplyTime = value; }
        }

        //站内信状态
        private int msgState;
        public int MsgState
        {
            get { return msgState; }
            set { msgState = value; }
        }
    }
}
