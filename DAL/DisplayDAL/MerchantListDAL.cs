using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DisplayDAL
{
   public  class MerchantListDAL
    {
        public DataSet GetMerchantListForPage(int pageSize,int pageIndex,out int count)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"SELECT [mer_id]
      ,[ind_id]
      ,[city_id]
      ,[mer_type]
      ,[mer_name]
      ,[mer_address]
      ,[mer_phone]
      ,[mer_postcode]
      ,[mer_discount]
      ,[reg_name]
      ,[reg_duty]
      ,[reg_phone]
      ,[reg_telephone]
      ,[reg_email]
      ,[mer_pwd]
      ,[mer_pic]
      ,[mer_info]
      ,[mer_website]
      ,[mer_state]
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo] where mer_state=1";
           return  dbc.GetDataSet(sqlString,"mer_id",pageSize,pageIndex,out count);
        }

        public DataSet GetMerchantListByIndID(int indID,int pageSize, int pageIndex, out int count)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"SELECT [mer_id]
      ,[ind_id]
      ,[city_id]
      ,[mer_type]
      ,[mer_name]
      ,[mer_address]
      ,[mer_phone]
      ,[mer_postcode]
      ,[mer_discount]
      ,[reg_name]
      ,[reg_duty]
      ,[reg_phone]
      ,[reg_telephone]
      ,[reg_email]
      ,[mer_pwd]
      ,[mer_pic]
      ,[mer_info]
      ,[mer_website]
      ,[mer_state]
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo] where mer_state=1 and ind_id=@indID";
            SqlParameter[] para = { new SqlParameter(@"indID", indID) };
            return dbc.GetDataSet(sqlString, "mer_id", pageSize, pageIndex, out count,para);
        }

    }
}
