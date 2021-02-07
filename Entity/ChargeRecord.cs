using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ChargeRecord
    {
        //充值ID
        private int chargeID;
        public int ChargeID
        {
            get { return chargeID; }
            set { chargeID = value; }
        }

        //会员ID
        private int memID;
        public int MemID
        {
            get { return memID; }
            set { memID = value; }
        }

        //充值时间
        private DateTime chargeTime;
        public DateTime ChargeTime
        {
            get { return chargeTime; }
            set { chargeTime = value; }
        }
    }
}
