using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL.OveralManaDAL
{
    public class PrdManaDAL
    {
        DBConnection dbc;
        string strSql;
        ///<summary>
        ///获取符合搜索所给的商品名，商家，城市的产品列表
        ///</summary>
        ///<rerturn>返回产品集</return>
        public DataSet GetAllPrdList(string prdName,int merID, int cityID)
        {
            strSql = @"SELECT [pd_id]
      ,[mc_PdMaintain].[mer_id]
	  ,[mc_BasicInfo].[mer_name]
	  ,[tb_city].[city_name]
      ,[pd_name]
      ,[pd_price]
      ,[pd_mem_price]
      ,[pd_info]
      ,[pd_pic]
      ,case [pd_state] when 1 then '可用' else '不可用' end as [pd_state]
      ,[pd_note]
      FROM [shuaka].[dbo].[mc_PdMaintain]
      inner join  [mc_BasicInfo]
      on [mc_PdMaintain].[mer_id]=[mc_BasicInfo].[mer_id]
      inner join [tb_city]
      on [mc_BasicInfo].[city_id]=[tb_city].[city_id]
      ";
            List<SqlParameter> para = new List<SqlParameter>();
            if (prdName != null)
            {
                strSql += (@" and [pd_name] like " + @"@prdName");
                para.Add(new SqlParameter(@"prdName", "%" + prdName + "%"));
            }
            //strSql += " and [mer_name] like '%'" + "@merName" + "'%'";
            if (merID != -1)
            {
                strSql += " and [mc_PdMaintain].[mer_id]=@merID";
                para.Add(new SqlParameter(@"merID", merID));
            }
            if (cityID != -1)
            {
                strSql += " and [tb_city].[city_id]=@cityID";
                para.Add(new SqlParameter(@"cityID", cityID));
            }
            dbc = new DBConnection();
            if (para.Count == 0)
            {
                return (dbc.GetDataSet(strSql));
            }
            else
            {
                return dbc.GetDataSet(strSql, para.ToArray());
            }

        }
        /// <summary>
        /// 根据商家ID返回商家的所有产品
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPrdList(int merID) {
            strSql = @"SELECT [pd_id]
              ,[pd_name]
              ,[pd_price]
              ,[pd_mem_price]
              ,[pd_info]
              ,case [pd_state] when 1 then '可用' else '不可用' end as [pd_state]
              FROM [shuaka].[dbo].[mc_PdMaintain]
              where mer_id=@merID
              ";
            SqlParameter[] para = { new SqlParameter("merID", merID) };
            DBConnection dbc = new DBConnection();
            return dbc.GetDataSet(strSql, para);
        }
        /// <summary>
        /// 设置商品为无效商品
        /// </summary>
        /// <param name="prdID"></param>
        /// <returns></returns>
        public int setPrdInvalid(int prdID) {
            strSql = @"UPDATE [shuaka].[dbo].[mc_PdMaintain]
                    SET [pd_state] = 0
                    WHERE [pd_id]=@prdID
                    ";
            SqlParameter[] para = { new SqlParameter("prdID", prdID) };
            DBConnection dbc = new DBConnection();
            return dbc.Execute(strSql, para);
            
        }
        
    }
}
