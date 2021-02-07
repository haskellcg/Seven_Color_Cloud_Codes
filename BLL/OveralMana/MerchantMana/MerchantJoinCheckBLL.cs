using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL.OveralMana.MerchantMana
{
    public class MerchantJoinCheckBLL
    {
        public DataSet GetJionMerList() {
            DAL.OveralManaDAL.JoinCheckDAL jc = new DAL.OveralManaDAL.JoinCheckDAL();
            return jc.GetApplyMerList();
        }
        public bool AgreeMerApply(string merID) {
            DAL.OveralManaDAL.JoinCheckDAL jc = new DAL.OveralManaDAL.JoinCheckDAL();
            return jc.agreeMerApply(merID);
        }
        public bool DisagreeMerApply(string merID) {
            DAL.OveralManaDAL.JoinCheckDAL jc = new DAL.OveralManaDAL.JoinCheckDAL();
            return jc.disagreeMerApply(merID);
        }
        public DataSet getPageMerList(int pageSize,int pageIndex,out int count) {
            DAL.OveralManaDAL.JoinCheckDAL jc = new DAL.OveralManaDAL.JoinCheckDAL();
            return jc.getPageMerList(pageIndex, pageSize,out count);
        }
    }
}
