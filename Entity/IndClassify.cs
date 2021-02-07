using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class IndClassify
    {
        //行业ID
        private int indID;
        public int IndID
        {
            get { return indID; }
            set { indID = value; }
        }
        //行业类型
        private string indType;
        public string IndType
        {
            get { return indType; }
            set { indType = value; }
        }

        //行业描述
        private string indInfo;
        public string IndInfo
        {
            get { return indInfo; }
            set { indInfo = value; }
        }
    }
}
