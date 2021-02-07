using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class AuthRelation
    {
        //权限关系ID
        private int authRelationID;
        public int AuthRelationID
        {
            get { return authRelationID; }
            set { authRelationID = value; }
        }
        //权限ID
        private int authID;
        public int AuthID
        {
            get { return authID; }
            set { authID = value; }
        }
        //管理员ID
        private int adminID;
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }
    }
}
