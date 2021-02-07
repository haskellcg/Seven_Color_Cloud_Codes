using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL.OveralMana.MerchantMana
{
    public class MerchantManaBLL
    {
        /// <summary>
        /// 根据商家名称来查询商家列表
        /// </summary>
        /// <param name="merName"></param>
        /// <returns></returns>
      public DataSet GetAllMerList(string merName) {
            DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
            return mc.GetAllMerList(merName);
      }   
        /// <summary>
        /// 根据城市查询商家列表
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public DataSet GetAllMerList(int cityID)
        {
            DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
            return mc.GetAllMerList(cityID);
        }

         /// <summary>
        /// 根据商家状态和城市查询商家
        /// </summary>
        /// <param name="merState"></param>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public DataSet GetAllMerList(int merState, int cityID)
        {
            DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
            return mc.GetAllMerList(merState, cityID);
        }
        ///<summary>
        ///获取所有的入盟的商家列表
        ///</summary>
        ///<rerturn>商家列表数据集</return>
        public DataSet GetAllMerList(string merName,int merState,int cityID)
        {
            DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
            return mc.GetAllMerList(merName,merState,cityID);
        }
        public DataSet GetPageMerList(string merName, int merState, int cityID, int pageSize, int pageIndex, out int count) {
           DAL.OveralManaDAL.MerchantManaDAL mc = new DAL.OveralManaDAL.MerchantManaDAL();
           return mc.GetPagerMerList(merName, merState, cityID, pageSize, pageIndex, out count);
        }
    }
}