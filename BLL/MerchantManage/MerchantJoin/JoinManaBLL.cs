using DAL.McManaDAL;
using Entity;

namespace BLL.MerchantManage.MerchantJoin
{
    public class JoinManaBLL
    {
        /// <summary>
        /// 商家加盟
        /// </summary>
        /// <param name="mcb"></param>
        /// <returns></returns>
        public bool JoinManage(McBasicInfo mcb)
        {
            JoinManaDAL jom = new JoinManaDAL();

            jom.AddMcDAL(mcb);
            return true;

        }
        /// <summary>
        /// 通过名字获得行业ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetIndIDByName(string name)
        {
            JoinManaDAL jom = new JoinManaDAL();
            return jom.GetIndIDByName(name);
        }
        /// <summary>
        /// 通过名字获得城市ID
        /// </summary>
        /// <param name="cityname"></param>
        /// <returns></returns>
        public int GetCityIDByName(string cityname)
        {
            JoinManaDAL jom = new JoinManaDAL();
            return jom.GetCityIDByName(cityname);
        }

    }
}
