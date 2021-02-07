using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ManaAuth
    {
        //权限ID
        private int authID;
        public int AuthID
        {
            get { return authID; }
            set { authID = value; }
        }
        //权限名称
        private string authName;
        public string AuthName
        {
            get { return authName; }
            set { authName = value; }
        }
    }
}
