using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL.OveralManaDAL;

namespace DAL.DisplayDAL
{
    public class IndInfoDisDAL
    {
        private string strSql;
        DBConnection dbc;
        /// <summary>
        /// 通过城市名称获得商家信息数据集
        /// </summary>
        /// <param name="strCity">城市名称</param>
        /// <returns>商家信息数据集</returns>
        public DataSet GetMerInfoByCityName(string strCity)
        {
            CityManaDAL cmd = new CityManaDAL();
            int cityID = cmd.GetCityIDByCityName(strCity);

            strSql = @"SELECT [mer_id]
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
  FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [city_id]=@CityID";
            SqlParameter[] para = { new SqlParameter("CityID", cityID) };
            dbc = new DBConnection();
            return (dbc.GetDataSet(strSql, para));
        }

        /// <summary>
        /// 通过城市名称和城市类型获得商家信息数据集
        /// </summary>
        /// <param name="strCity">城市名称</param>
        /// <returns>商家信息数据集</returns>
        public DataSet GetMerInfoByCityName(string merType, string strCity)
        {
            if (merType == null)
            {
                return GetMerInfoByCityName(strCity);
            }
            else
            {
                CityManaDAL cmd = new CityManaDAL();
                int cityID = cmd.GetCityIDByCityName(strCity);
                strSql = @"SELECT [mer_id]
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
  FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [city_id]=@CityID AND [mer_type]=@MerType";
                SqlParameter[] paras = { new SqlParameter("CityID", cityID),
                                      new SqlParameter("MerType", merType)};
                dbc = new DBConnection();
                return (dbc.GetDataSet(strSql, paras));
            }
        }
    }
}

