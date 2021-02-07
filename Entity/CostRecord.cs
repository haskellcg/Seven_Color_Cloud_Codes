using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CostRecord
    {
        //消费ID
        private int costID;
        public int CostID
        {
            get { return costID; }
            set { costID = value; }
        }


        //会员ID
        private int memID;
        public int MemID
        {
            get { return memID; }
            set { memID = value; }
        }

        //商家ID
        private int merID;
        public int MerID
        {
            get { return merID; }
            set { merID = value; }
        }

        //消费时间
        private DateTime costTime;
        public DateTime CostTime
        {
            get { return costTime; }
            set { costTime = value; }
        }

        //消费金额
        private float costMoney;
        public float CostMoney
        {
            get { return costMoney; }
            set { costMoney = value; }
        }

        //产品ID
        private int pdID;
        public int PdID
        {
            get { return pdID; }
            set { pdID = value; }
        }

        //产品名称
        private string pdName;
        public string PdName
        {
            get { return pdName; }
            set { pdName = value; }
        }
    }
}
