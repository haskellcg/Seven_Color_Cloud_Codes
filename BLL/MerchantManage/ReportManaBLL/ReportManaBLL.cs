using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.McManaDAL;

namespace BLL.MerchantManage.ReportManaBLL
{
    public class ReportManaBLL
    {
        public DataSet GetReportByMerID(int merID, int pageSize, int pageIndex, out int count)
        {
            ReportManaDAL rmd = new ReportManaDAL();
            return rmd.GetPagerReportByMerID(merID,pageSize,pageIndex,out count);
        }

        public float GetReportMoney(int merID)
        {
            ReportManaDAL rmd = new ReportManaDAL();
            return rmd.GetReportMoney(merID);
        }
    }
}
