using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL.OveralMana
{
    public class AuthManaBLL
    {
        /// <summary>
        /// 通过userName查询一级权限节点
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataSet getAuthIDByName(string userName){
            DAL.OveralManaDAL.AuthMana am = new DAL.OveralManaDAL.AuthMana();
            int adminID = am.getAdminIDByName(userName);
            return am.getAdminAuthByID(adminID);
        }

        /// <summary>
        /// 通过权限id查询子权限记录表，获取子权限集合
        /// </summary>
        /// <param name="authID"></param>
        /// <returns>若存在子权限，则返回DataSet集合，否则返回null</returns>
        public DataSet getChildAuthByAuthID(int authID)
        {
            DAL.OveralManaDAL.AuthMana am = new DAL.OveralManaDAL.AuthMana();
            return am.getChildAuthByAuthID(authID);
        }        
    }
}
