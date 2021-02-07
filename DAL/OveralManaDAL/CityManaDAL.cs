using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.OveralManaDAL
{
    public class CityManaDAL
    {
        public int GetCityIDByCityName(string cityName)
        {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [city_id]
      FROM [shuaka].[dbo].[tb_city]
      WHERE [city_name]=@CityName";
            SqlParameter[] para = { new SqlParameter("CityName", cityName) };
            DataSet ds = dbc.GetDataSet(strSql, para);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["city_id"].ToString());
        }
        public DataSet getAllCity() {
            DBConnection dbc = new DBConnection();
            string strSql = @"SELECT [city_id],[city_name]
      FROM [shuaka].[dbo].[tb_city]";
            return dbc.GetDataSet(strSql);
        }
    }
}
