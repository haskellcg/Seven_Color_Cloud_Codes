using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;

namespace BLL.SysManaBLL
{
    public class LoginManaBLL
    {
        public bool authAccount(string userName,string password) {
            DAL.SysManaDAL.LoginManaDAL loginDal = new DAL.SysManaDAL.LoginManaDAL();
            string tempPsw = loginDal.authAdminAcount(new TbAdmin(userName,password));
            if (tempPsw.Equals(""))
                return false;
            else
                return tempPsw.Equals(password);
        }
    }
}
