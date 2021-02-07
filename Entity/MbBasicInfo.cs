using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MbBasicInfo
    {
        //会员ID
        private int memID;
        public int MemID
        {
            get { return memID; }
            set { memID = value; }
        }

        //会员密码
        private string memPwd;
        public string MemPwd
        {
            get { return memPwd; }
            set { memPwd = value; }
        }

        //会员姓名
        private string memName;
        public string MemName
        {
            get { return memName; }
            set { memName = value; }
        }

        //证件类型
        private string cardType;
        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        //证件号
        private string cardID;
        public string CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }

        //会员性别
        private int memSex;
        public int MemSex
        {
            get { return memSex; }
            set { memSex = value; }
        }

        //会员手机号码
        private string memTelephone;
        public string MemTelephone
        {
            get { return memTelephone; }
            set { memTelephone = value; }
        }

        //会员地址
        private string memAddr;
        public string MemAddr
        {
            get { return memAddr; }
            set { memAddr = value; }
        }

        //会员Email
        private string memEmail;
        public string MemEmail
        {
            get { return memEmail; }
            set { memEmail = value; }
        }

        //操作人
        private string memOperator;
        public string MemOperator
        {
            get { return memOperator; }
            set { memOperator = value; }
        }

        //操作时间
        private DateTime memOpTime;
        public DateTime MemOpTime
        {
            get { return memOpTime; }
            set { memOpTime = value; }
        }

         //会员余额
        private float memMoney;
        public float MemMoney
        {
            get { return memMoney; }
            set { memMoney = value; }
        }

        //商家ID
        private int merID;
        public int MerID
        {
            get { return merID; }
            set { merID = value; }
        }
    }
}
