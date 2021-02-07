using DAL.McManaDAL;

namespace BLL.MerchantManage.MerchantLogin
{
    public class MerchLogBLL
    {
        /// <summary>
        /// 商家登录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string McLog(string userID, string pwd)
        {
            LoginManaDAL logma = new LoginManaDAL();
            return (logma.McLogin(userID, pwd));
        }

    }
}
