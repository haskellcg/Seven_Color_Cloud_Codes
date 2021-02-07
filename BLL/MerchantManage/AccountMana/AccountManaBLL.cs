using DAL.McManaDAL;

namespace BLL.MerchantManage
{
    public class AccountManaBLL
    {
        AccountManaDAL amd = new AccountManaDAL();
        /// <summary>
        /// 商家密码修改
        /// </summary>
        /// <param name="telephone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool MerPwdMod(string telephone, string pwd)
        {
            return amd.UpdatePwdByTelephone(telephone,pwd);
        }
    }
}
