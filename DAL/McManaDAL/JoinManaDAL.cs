using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class JoinManaDAL
    {
        /// <summary>
        /// 注册钱先判断是否存在该用户
        /// </summary>
        /// <param name="telephone">手机号</param>
        /// <returns>是否存在</returns>
        public bool IsExist(string telephone)
        {
            string strSql;
            int i;
            DBConnection dbc = new DBConnection();
            strSql = @"SELECT [mer_id]FROM [shuaka].[dbo].[mc_BasicInfo]
WHERE [reg_telephone]=@TeleP";
            SqlParameter[] para = { new SqlParameter("TeleP", telephone) };
            i = dbc.Execute(strSql, para);
            if (i != 0)
            {
                return true;
            }
            else
                return false;
        }

        DBConnection dbc = new DBConnection();
        DataSet ds;
        //入盟申请，插入记录
        public int AddMcDAL(McBasicInfo mcb)
        {
            string strSql = @"INSERT INTO [shuaka].[dbo].[mc_BasicInfo]
           ([ind_id]
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
           ,[mer_star_level])
     VALUES
           (@IndID
           ,@CityID
           ,@MerType
           ,@MerName
           ,@MerAddress
           ,@MerPhone
           ,@MerPostCode
           ,@MerDiscount
           ,@RegName
           ,@RegDuty
           ,@RegPhone
           ,@RegTelephone
           ,@RegEmail
           ,@MerPwd
           ,@MerPic
           ,@MerInfo
           ,@MerWebsite
           ,@MerState
           ,@RecMerState
           ,@MerStarLevel) SELECT @@IDENTITY AS 'mer_id'";

            SqlParameter[] paras ={new SqlParameter("IndID",mcb.IndID),
                                   new SqlParameter("CityID",mcb.CityID),
                                   new SqlParameter("MerType",mcb.MerType),
                                   new SqlParameter("MerName",mcb.MerName),
                                   new SqlParameter("MerAddress",mcb.MerAddr),
                                   new SqlParameter("MerPhone",mcb.MerPhone),
                                   new SqlParameter("MerPostCode",mcb.MerPostcode),
                                   new SqlParameter("MerDiscount",mcb.MerDiscount),
                                   new SqlParameter("RegName",mcb.RegName),
                                   new SqlParameter("RegDuty",mcb.RegDuty),
                                   new SqlParameter("RegPhone",mcb.RegPhone),
                                   new SqlParameter("RegTelephone",mcb.RegTelePhone),
                                   new SqlParameter("RegEmail",mcb.RegEmail),
                                   new SqlParameter("MerPwd",mcb.MerPwd),
                                   new SqlParameter("MerPic",mcb.MerPic),
                                   new SqlParameter("MerInfo",mcb.MerInfo),
                                   new SqlParameter("MerWebsite",mcb.MerWebsite),
                                   new SqlParameter("MerState",mcb.MerState),
                                   new SqlParameter("RecMerState",mcb.RecMerState),
                                   new SqlParameter("MerStarLevel",mcb.MerStarLever)};
            ds = dbc.GetDataSet(strSql, paras);
            string temp = ds.Tables[0].Rows[0]["mer_id"].ToString();
            return Convert.ToInt32(temp);

        }

        /// <summary>
        /// 通过行业类型获得行业ID
        /// </summary>
        /// <param name="name">行业类型名称</param>
        /// <returns>行业ID</returns>
        public int GetIndIDByName(string name)
        {
            string strSql = @"SELECT [ind_id]
        FROM [shuaka].[dbo].[ind_Classify]
	    WHERE [ind_type]=@Name";
            SqlParameter[] para = { new SqlParameter("Name", name) };
            DBConnection dbc = new DBConnection();
            DataSet ds = new DataSet();
            ds = dbc.GetDataSet(strSql, para);
            string a = ds.Tables[0].Rows[0]["ind_id"].ToString();
            return Convert.ToInt32(a);
        }

        /// <summary>
        /// 通过城市名称获得城市ID
        /// </summary>
        /// <param name="cityname">城市名称</param>
        /// <returns>城市ID</returns>
        public int GetCityIDByName(string cityname)
        {
            string strSql = @"SELECT [city_id]
             FROM [shuaka].[dbo].[tb_city]
             WHERE [city_name]=@CityName";
            SqlParameter[] para = { new SqlParameter("CityName", cityname) };
            DBConnection dbc = new DBConnection();
            DataSet ds = new DataSet();
            ds = dbc.GetDataSet(strSql, para);
            string a = ds.Tables[0].Rows[0]["city_id"].ToString();
            return Convert.ToInt32(a);
        }
    }
}
