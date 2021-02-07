using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.McManaDAL;
using DAL.OveralManaDAL;

namespace BLL.OveralMana.IndMana
{
    public class IndManaBLL
    {
        IndManaDAL imdal = new IndManaDAL();
        JoinManaDAL jmdal = new JoinManaDAL();
        /// <summary>
        /// 行业修改
        /// </summary>
        /// <param name="ind_ID"></param>
        /// <param name="ind_Type"></param>
        /// <returns></returns>
        public bool IndModif(string ind_ID, string ind_Type)
        {
            int ind = jmdal.GetIndIDByName(ind_ID);
            return (imdal.IndModify(ind, ind_Type));
        }
    }
}
