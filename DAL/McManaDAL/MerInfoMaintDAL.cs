using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class MerInfoMaintDAL
    {
        /// <summary>
        /// 根据商家ID获得商家信息
        /// </summary>
        /// <param name="mer_id">商家ID</param>
        /// <returns></returns>
        public McBasicInfo GetMerchantInfoByID(int mer_id)
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
      ,case [mer_state] when 1 then '可用' else '不可用' end as mer_state
      ,[rec_mer_state]
      ,[mer_star_level]
  FROM [shuaka].[dbo].[mc_BasicInfo]
  WHERE [mer_id]= @mer_id";
            SqlParameter[] paras = {
                                       new SqlParameter("mer_id",mer_id)
                                 };
            DataSet ds = dbc.GetDataSet(sqlString, paras);
            object[] mc_Array = ds.Tables[0].Rows[0].ItemArray;
            McBasicInfo mc = new McBasicInfo();
            mc.MerID = int.Parse((mc_Array[0]).ToString());
            mc.IndID = int.Parse(mc_Array[1].ToString());
            mc.CityID = int.Parse(mc_Array[2].ToString());
            mc.MerType = mc_Array[3].ToString();
            mc.MerName = mc_Array[4].ToString();
            mc.MerAddr = mc_Array[5].ToString();
            mc.MerPhone = mc_Array[6].ToString();
            mc.MerPostcode = mc_Array[7].ToString();
            mc.MerDiscount = mc_Array[8].ToString();
            mc.RegName = mc_Array[9].ToString();
            mc.RegDuty = mc_Array[10].ToString();
            mc.RegPhone = mc_Array[11].ToString();
            mc.RegTelePhone = mc_Array[12].ToString();
            mc.RegEmail = mc_Array[13].ToString();
            mc.MerPwd = mc_Array[14].ToString();
            mc.MerPic = mc_Array[15].ToString();
            mc.MerInfo = mc_Array[16].ToString();
            mc.MerWebsite = mc_Array[17].ToString();
            mc.MerState = (mc_Array[18].ToString().Equals("可用") == true ? 1 : 0);
            mc.RecMerState = mc_Array[19].ToString().Equals("1") ? true : false;
            mc.MerStarLever = int.Parse(mc_Array[20].ToString());


            return mc;
        }


        /// <summary>
        /// 根据城市ID获得城市名称以及省名称
        /// </summary>
        /// <param name="city_id">城市ID</param>
        /// <returns></returns>
        public string[] GetCityAndProvin(int city_id)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"SELECT [city_id]
      ,[pro_id]
      ,[city_name]
  FROM [shuaka].[dbo].[tb_city]
  WHERE [city_id]=@city_id";
            SqlParameter[] paras ={
                                      new SqlParameter("city_id",city_id)
                                 };
            object[] item = dbc.GetDataSet(sqlString, paras).Tables[0].Rows[0].ItemArray;
            string cityName = item[2].ToString();


            string sqlString2 = @"SELECT [pro_id]
      ,[pro_name]
  FROM [shuaka].[dbo].[tb_pro]
  WHERE [pro_id]= @pro_id";
            SqlParameter[] paras2 = {
                                        new SqlParameter("pro_id",int.Parse(item[1].ToString()))
                                    };
            object[] item2 = dbc.GetDataSet(sqlString2, paras2).Tables[0].Rows[0].ItemArray;
            string proName = item2[1].ToString();


            string[] result = {
                                  cityName,proName
                              };

            return result;
        }


        /// <summary>
        /// 根据商家ID获得所有商家的商品
        /// </summary>
        /// <param name="mer_id">商家ID</param>
        /// <returns></returns>
        public DataSet GetAllProductByMerID(int mer_id)
        {
            DBConnection dbc = new DBConnection();
            String sqlString = @"SELECT [pd_id]
      ,[mer_id]
      ,[pd_name]
      ,[pd_price]
      ,[pd_mem_price]
      ,[pd_info]
      ,[pd_pic]
      ,case [pd_state] when 1 then '可用' else '不可用' end as pd_state
      ,[pd_note]
  FROM [shuaka].[dbo].[mc_PdMaintain]
  WHERE [mer_id]= @mer_id";
            SqlParameter[] paras = {
                                       new SqlParameter("mer_id",mer_id)
                                   };
            DataSet ds = dbc.GetDataSet(sqlString, paras);
            return ds;
        }

        /// <summary>
        /// 商品分页查询
        /// </summary>
        /// <param name="mer_id">商家ID</param>
        /// <param name="pageSize">分页控件的大小</param>
        /// <param name="pageIndex">分页控件目前索引</param>
        /// <param name="count">字段数目</param>
        /// <returns></returns>
        public DataSet GetAllProductByMerID(int mer_id, int pageSize, int pageIndex, out int count)
        {
            DBConnection dbc = new DBConnection();
            String sqlString = @"SELECT [pd_id]
      ,[mer_id]
      ,[pd_name]
      ,[pd_price]
      ,[pd_mem_price]
      ,[pd_info]
      ,[pd_pic]
      ,case [pd_state] when 1 then '可用' else '不可用' end as pd_state
      ,[pd_note]
  FROM [shuaka].[dbo].[mc_PdMaintain]
  WHERE [mer_id]= @mer_id";
            SqlParameter[] paras ={
                                    new  SqlParameter("mer_id",mer_id)
                                 };
            return dbc.GetDataSet(sqlString, "pd_id", pageSize, pageIndex, out count, paras);
        }

        /// <summary>
        /// 根据商品ID获得商品详细信息
        /// </summary>
        /// <param name="pro_id">商品ID</param>
        /// <returns>商品实体类</returns>
        public McPdMaintain GetProductInfoByID(int pro_id)
        {
            DBConnection dbc = new DBConnection();
            String strString = @"SELECT [pd_id]
      ,[mer_id]
      ,[pd_name]
      ,[pd_price]
      ,[pd_mem_price]
      ,[pd_info]
      ,[pd_pic]
      ,case [pd_state] when 1 then '可用' else '不可用' end as pd_state
      ,[pd_note]
  FROM [shuaka].[dbo].[mc_PdMaintain]
  WHERE [pd_id]=@pro_id";
            SqlParameter[] paras = {
                                       new SqlParameter("pro_id",pro_id)
                                   };

            DataSet ds = dbc.GetDataSet(strString, paras);
            McPdMaintain mcpd = new McPdMaintain();
            object[] itemArray = ds.Tables[0].Rows[0].ItemArray;
            mcpd.PdID = int.Parse(itemArray[0].ToString());
            mcpd.MerID = int.Parse(itemArray[1].ToString());
            mcpd.PdName = itemArray[2].ToString();
            mcpd.PdPrice = float.Parse(itemArray[3].ToString());
            mcpd.PdMemPrice = float.Parse(itemArray[4].ToString());
            mcpd.PdInfo = itemArray[5].ToString();
            mcpd.PdPic = itemArray[6].ToString();
            mcpd.PdState = (itemArray[7].ToString().Equals("可用") == true);
            mcpd.PdNote = itemArray[8].ToString();


            return mcpd;
        }


        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="mcpd">商品实体类</param>
        /// <returns>数据库中受影响的行数</returns>
        public int UpdateProduct(McPdMaintain mcpd)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"UPDATE [shuaka].[dbo].[mc_PdMaintain]
   SET [mer_id] = @mer_id
      ,[pd_name] = @pd_name
      ,[pd_price] = @pd_price
      ,[pd_mem_price] = @pd_mem_price
      ,[pd_info] = @pd_info
      ,[pd_pic] = @pd_pic
      ,[pd_state] = @pd_state
      ,[pd_note] = @pd_note
 WHERE [pd_id]=@pd_id";
            SqlParameter[] paras ={
                                     new SqlParameter("mer_id",mcpd.MerID),
                                     new SqlParameter("pd_name",mcpd.PdName),
                                     new SqlParameter("pd_price",mcpd.PdPrice),
                                     new SqlParameter("pd_mem_price",mcpd.PdMemPrice),
                                     new SqlParameter("pd_info",mcpd.PdInfo),
                                     new SqlParameter("pd_pic",mcpd.PdPic),
                                     new SqlParameter("pd_state",mcpd.PdState),
                                     new SqlParameter("pd_note",mcpd.PdNote),
                                     new SqlParameter("pd_id",mcpd.PdID)
                                 };

            return dbc.Execute(sqlString, paras);
        }

        /// <summary>
        /// 修改商家信息
        /// </summary>
        /// <param name="mc">商家实体类</param>
        /// <returns></returns>
        public int UpdateMerchant(McBasicInfo mc)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"UPDATE [shuaka].[dbo].[mc_BasicInfo]
   SET [city_id] = @city_id
      ,[mer_name] = @mer_name
      ,[mer_address] = @mer_address
      ,[mer_phone] = @mer_phone
	  ,[mer_info]= @mer_info
      ,[reg_name] = @reg_name
      ,[reg_email] = @reg_email
      ,[mer_pic] = @mer_pic
      ,[mer_website] = @mer_website
      ,[mer_star_level] = @mer_star_level
 WHERE [mer_id]=@mer_id";

            SqlParameter[] paras = {
                                       new SqlParameter("city_id",mc.CityID),
                                       new SqlParameter("mer_name",mc.MerName),
                                       new SqlParameter("mer_address",mc.MerAddr),
                                       new SqlParameter("mer_phone",mc.MerPhone),
                                       new SqlParameter("mer_info",mc.MerInfo),
                                       new SqlParameter("reg_name",mc.RegName),
                                       new SqlParameter("reg_email",mc.RegEmail),
                                       new SqlParameter("mer_pic",mc.MerPic),
                                       new SqlParameter("mer_website",mc.MerWebsite),
                                       new SqlParameter("mer_star_level",mc.MerStarLever),
                                       new SqlParameter("mer_id",mc.MerID)
                                   };



            return dbc.Execute(sqlString, paras);
        }

        /// <summary>
        /// 获得所有省的数据
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet GetAllProvince()
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"SELECT [pro_id]
      ,[pro_name]
  FROM [shuaka].[dbo].[tb_pro]";

            return dbc.GetDataSet(sqlString);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provin_id"></param>
        /// <returns></returns>
        public DataSet GetAllCityByProvin(int provin_id)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"SELECT [city_id]
      ,[pro_id]
      ,[city_name]
  FROM [shuaka].[dbo].[tb_city]
  WHERE [pro_id]=@pro_id";
            SqlParameter[] paras = {
                                       new SqlParameter("pro_id",provin_id)
                                   };
            return dbc.GetDataSet(sqlString, paras);

        }


        /// <summary>
        /// 添加产品，返回产品的ID
        /// </summary>
        /// <param name="mcpd"></param>
        /// <returns></returns>
        public int AddProduct(McPdMaintain mcpd)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"INSERT INTO [shuaka].[dbo].[mc_PdMaintain]
           ([mer_id]
           ,[pd_name]
           ,[pd_price]
           ,[pd_mem_price]
           ,[pd_info]
           ,[pd_pic]
           ,[pd_state]
           ,[pd_note])
     VALUES
           (@mer_id
           ,@pd_name
           ,@pd_price
           ,@pd_memprice
           ,@pd_info
           ,@pd_pic
           ,@pd_state
           ,@pd_note)
     SELECT @@IDENTITY as 'identity'";

            SqlParameter[] paras = {
                                       new SqlParameter("mer_id",mcpd.MerID),
                                       new SqlParameter("pd_name",mcpd.PdName),
                                       new SqlParameter("pd_price",mcpd.PdPrice),
                                       new SqlParameter("pd_memprice",mcpd.PdMemPrice),
                                       new SqlParameter("pd_info",mcpd.PdInfo),
                                       new SqlParameter("pd_pic",mcpd.PdPic),
                                       new SqlParameter("pd_state",mcpd.PdState),
                                       new SqlParameter("pd_note",mcpd.PdNote)
                                   };
            DataSet ds = dbc.GetDataSet(sqlString, paras);
            return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());

        }

        /// <summary>
        /// 返回制定商家的商品的数量
        /// </summary>
        /// <param name="mer_id"></param>
        /// <returns></returns>
        public int ProductCountInMerchant(int mer_id)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"SELECT count(*)
  FROM [shuaka].[dbo].[mc_PdMaintain]
  WHERE [mer_id]=@mer_id";
            SqlParameter[] paras ={
                                     new SqlParameter("mer_id",mer_id)
                                 };
            DataSet ds = dbc.GetDataSet(sqlString, paras);
            return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }

        /// <summary>
        /// 为会员充值，并且添加充值记录
        /// </summary>
        /// <param name="mem_id"></param>
        /// <param name="money"></param>
        public int ChargeMoneyForMem(int mem_id, float money)
        {
            DBConnection dbc = new DBConnection();
            string sqlString = @"UPDATE [shuaka].[dbo].[mb_BasicInfo]
                    SET [mem_money] = [mem_money]+@Money
                    WHERE [mem_id]=@mem_id";
            string sqlString2 = @"INSERT INTO [shuaka].[dbo].[charge_record]
           ([mem_id]
           ,[charge_time]
           ,[charge_money])
     VALUES
           (@mem_id
           ,@charge_time
           ,@charge_money)";


            SqlParameter[] paras = {
                                       new SqlParameter("mem_id",mem_id),
                                       new SqlParameter("Money",money)
                                   };
            SqlParameter[] paras2 = {
                                       new SqlParameter("mem_id",mem_id),
                                       new SqlParameter("charge_time",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                       new SqlParameter("charge_money",money)
                                   };
            int result = 0;
            result += dbc.Execute(sqlString, paras);
            result += dbc.Execute(sqlString2, paras2);

            return result;
        }
    }
}
