using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class TbAdmin
    {
        //管理员ID
        public TbAdmin(string username,string psw) {
            this.adminName = username;
            this.adminPsw = psw;
        }
        private int adminID;
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        //管理员名称
        private string adminName;
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        //管理员密码
        private string adminPsw;
        public string AdminPsw
        {
            get { return adminPsw; }
            set { adminPsw = value; }
        }
    }
}
