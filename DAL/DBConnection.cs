using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnection
    {
        SqlConnection conn;
        //string sqlInfo;
        public DBConnection()
        {
            // System.Configuration.AppSettingsReader asr = new System.Configuration.AppSettingsReader();
            //sqlInfo= asr.GetValue("StrConn", "".GetType()).ToString();
            conn = new SqlConnection("server=127.0.0.1;database=shuaka;uid=sa;pwd=111111");
        }

        #region     获得数据集的查询
        /// <summary>
        /// 获得查询的数据集
        /// </summary>
        /// <param name="strSql">需要执行的SQL语句</param>
        /// <returns>返回数据集</returns>
        public DataSet GetDataSet(string strSql)
        {
            return GetDataSet(strSql, null);

        }

        /// <summary>
        ///  通过参数获得查询的数据集
        /// </summary>
        /// <param name="strSql">需要执行的SQL语句</param>
        /// <param name="paras">参数</param>
        /// <returns>返回数据集</returns>
        public DataSet GetDataSet(string strSql, SqlParameter[] paras)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            if (paras != null && paras.Length > 0)
            {
                cmd.Parameters.Clear();
                for (int i = 0; i < paras.Length; i++)
                {
                    cmd.Parameters.Add(paras[i]);
                }

            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Dispose();
            conn.Close();
            return ds;

        }

        #endregion

        #region
        /// <summary>
        /// 获得商家获得的总收入
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public float GetTotalMoney(string strSql)
        {
            return GetTotalMoney(strSql,null);
        }
        /// <summary>
        /// 查询商家获得的总收入
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <param name="paras">参数</param>
        /// <returns>返回第一行第一列数据</returns>
        public float GetTotalMoney(string strSql, SqlParameter[] paras)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            if (paras != null && paras.Length > 0)
            {
                cmd.Parameters.Clear();
                for (int i = 0; i < paras.Length; i++)
                {
                    cmd.Parameters.Add(paras[i]);
                }

            }
            float j = float.Parse((cmd.ExecuteScalar().ToString()));
            conn.Close();
            return j;
        }
        #endregion

        #region   获得受影响的函数查询
        /// <summary>
        /// 获得查询所影响的行数
        /// </summary>
        /// <param name="strSql">需要执行的SQL语句</param>
        /// <returns>返回受影响的行数</returns>
        public int Execute(string strSql)
        {
            return Execute(strSql, null);

        }

        /// <summary>
        /// 通过参数获得查询所影响的行数
        /// </summary>
        /// <param name="strSql">需要执行的SQL语句</param>
        /// <param name="paras">参数</param>
        /// <returns>返回受影响的行数</returns>
        public int Execute(string strSql, SqlParameter[] paras)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            if (paras != null && paras.Length > 0)
            {
                cmd.Parameters.Clear();
                for (int i = 0; i < paras.Length; i++)
                {
                    cmd.Parameters.Add(paras[i]);
                }

            }
            int j = cmd.ExecuteNonQuery();
            conn.Close();
            return j;

        }
        #endregion

        #region   分页实现
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strsql">未分页的查询语句</param>
        /// <param name="key">数据库中的主键</param>
        /// <param name="pagesize">每一页的大小</param>
        /// <param name="pageindex">当前页的索引</param>
        /// <param name="count">总的记录条数</param>
        /// <param name="paras">查询所用的参数</param>
        /// <returns>返回数据集</returns>
        public DataSet GetDataSet(string strsql, string key, int pagesize, int pageindex, out int count, SqlParameter[] paras)
        {
            string sqlcount = "select count(*) from (" + strsql + ") as t";
            string sqlrtn = "select top " + pagesize + " * from (" + strsql + ") as t1 where " + key + @" not in (
                select top " + pagesize * (pageindex - 1) + " " + key + " from (" + strsql + ") as t2)";
            SqlCommand cmd1 = new SqlCommand(sqlcount, conn);
            SqlCommand cmd2 = new SqlCommand(sqlrtn, conn);
            DataSet ds = new DataSet();
            if (paras != null && paras.Length > 0)
            {
                cmd1.Parameters.Clear();
                cmd2.Parameters.Clear();
                for (int i = 0; i < paras.Length; i++)
                {
                    cmd1.Parameters.Add((SqlParameter)paras[i]);
                }
            }
            try
            {
                conn.Open();
                count = Convert.ToInt32(cmd1.ExecuteScalar());
                if (paras != null && paras.Length > 0)
                {
                    cmd1.Parameters.Clear();
                    cmd2.Parameters.Clear();
                    for (int i = 0; i < paras.Length; i++)
                    {
                        cmd2.Parameters.Add((SqlParameter)paras[i]);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return ds;

        }

        #region   分页实现
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strsql">未分页的查询语句</param>
        /// <param name="key">数据库中的主键</param>
        /// <param name="pagesize">每一页的大小</param>
        /// <param name="pageindex">当前页的索引</param>
        /// <param name="count">总的记录条数</param>
        /// <param name="paras">查询所用的参数</param>
        /// <returns>返回数据集</returns>
        public DataSet GetDataSet(string strsql, string key, int pagesize, int pageindex, out int count, SqlParameter[] paras,string orderKey)
        {
            string sqlcount = "select count(*) from (" + strsql + ") as t";
            string sqlrtn = "select top " + pagesize + " * from (" + strsql + ") as t1 where " + key + @" not in (
                select top " + pagesize * (pageindex - 1) + " " + key + " from (" + strsql + ") as t2) order by "+orderKey;
            SqlCommand cmd1 = new SqlCommand(sqlcount, conn);
            SqlCommand cmd2 = new SqlCommand(sqlrtn, conn);
            DataSet ds = new DataSet();
            if (paras != null && paras.Length > 0)
            {
                cmd1.Parameters.Clear();
                cmd2.Parameters.Clear();
                for (int i = 0; i < paras.Length; i++)
                {
                    cmd1.Parameters.Add((SqlParameter)paras[i]);
                }
            }
            try
            {
                conn.Open();
                count = Convert.ToInt32(cmd1.ExecuteScalar());
                if (paras != null && paras.Length > 0)
                {
                    cmd1.Parameters.Clear();
                    cmd2.Parameters.Clear();
                    for (int i = 0; i < paras.Length; i++)
                    {
                        cmd2.Parameters.Add((SqlParameter)paras[i]);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return ds;

        }
        #endregion
        ///// <summary>
        ///// 分页查询
        ///// </summary>
        ///// <param name="strsql">未分页的查询语句</param>
        ///// <param name="key">数据库中的主键</param>
        ///// <param name="pagesize">每一页的大小</param>
        ///// <param name="pageindex">当前页的索引</param>
        ///// <param name="count">总的记录条数</param>
        ///// <returns>返回数据集</returns>
        public DataSet GetDataSet(string strsql, string key, int pagesize, int pageindex, out int count)
        {
            return GetDataSet(strsql, key, pagesize, pageindex, out count, null);
        }
        #endregion
    }
}
