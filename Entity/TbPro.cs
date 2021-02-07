using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class TbPro
    {
        //省份ID
        private int proID;
        public int ProID
        {
            get { return proID; }
            set { proID = value; }
        }

        //省份名称
        private string proName;
        public string ProName
        {
            get { return proName; }
            set { proName = value; }
        }
    }
}
