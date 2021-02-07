using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL.McManaDAL
{
    public class MemInfoMana
    {
        string strSql;
        DBConnection dbc;
        DataSet ds;

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="mbi">会员实体类</param>
        /// <returns>返回会员ID</returns>
        public int AddMember(MbBasicInfo mbi)
        {
            dbc = new DBConnection();
            strSql = @"INSERT INTO [shuaka].[dbo].[mb_BasicInfo]
           ([mer_id]
           ,[card_type]
           ,[card_id]
           ,[mem_name]
           ,[mem_sex]
           ,[mem_telephone]
           ,[mem_addr]
           ,[mem_email]
           ,[mem_operator]
           ,[mem_op_time]
           ,[mem_psw]
           ,[mem_money])
     VALUES
           (@MerID
           ,@CardType
           ,@CardID
           ,@MemName
           ,@MemSex
           ,@MemTelp
           ,@MemAddr
           ,@MemEmail
           ,@MemOperator
           ,@MemOpTime
           ,@MemPwd
           ,@MemMoney) SELECT @@IDENTITY AS 'mem_id'";
            SqlParameter[] paras = { new SqlParameter("MerID",mbi.MerID),
                                     new SqlParameter("CardType",mbi.CardType),
                                     new SqlParameter("CardID",mbi.CardID),
                                     new SqlParameter("MemName",mbi.MemName),
                                     new SqlParameter("MemSex",mbi.MemSex),
                                     new SqlParameter("MemTelp",mbi.MemTelephone),
                                     new SqlParameter("MemAddr",mbi.MemAddr),
                                     new SqlParameter("MemEmail",mbi.MemEmail),
                                     new SqlParameter("MemOperator",mbi.MemOperator),
                                     new SqlParameter("MemOpTime",mbi.MemOpTime),
                                     new SqlParameter("MemPwd",mbi.MemPwd),
                                     new SqlParameter("MemMoney",mbi.MemMoney)};
            ds = dbc.GetDataSet(strSql, paras);
            string temp = ds.Tables[0].Rows[0]["mem_id"].ToString();
            return Convert.ToInt32(temp);
        }

        /// <summary>
        /// 通过会员ID修改会员密码
        /// </summary>
        /// <param name="strPwd">需要输入的新密码</param>
        /// <param name="memID">会员ID</param>
        /// <returns>返回受影响的行数</returns>
        public int ChangeMemPwdByMemID(string strPwd, int memID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mb_BasicInfo]
                    SET [mem_psw] = @MemPwd
                    WHERE [mem_id]=@MemID";
            SqlParameter[] paras = { new SqlParameter("MemPwd",strPwd),
                                     new SqlParameter("MemID",memID)};
            return dbc.Execute(strSql, paras);
        }


        /// <summary>
        /// 通过会员ID修改会员手机号
        /// </summary>
        /// <param name="strPwd">需要输入的新密码</param>
        /// <param name="memID">会员ID</param>
        /// <returns>返回受影响的行数</returns>
        public int ChangeMemTelByMemID(string memTele, int memID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mb_BasicInfo]
                    SET [mem_telephone] = @MemTele
                    WHERE [mem_id]=@MemID";
            SqlParameter[] paras = { new SqlParameter("MemTele",memTele),
                                     new SqlParameter("MemID",memID)};
            return dbc.Execute(strSql, paras);
        }

        /// <summary>
        /// 通过会员ID修改会员余额，即模拟会员消费
        /// </summary>
        /// <param name="money">消费的金额</param>
        /// <param name="memID">会员ID</param>
        /// <returns>返回受影响行数</returns>
        public int ChangeMemMoneyByMemID(float money, int memID)
        {
            dbc = new DBConnection();
            strSql = @"UPDATE [shuaka].[dbo].[mb_BasicInfo]
                    SET [mem_money] = [mem_money]-@Money
                    WHERE [mem_id]=@MemID";
            SqlParameter[] paras = { new SqlParameter("Money",money),
                                     new SqlParameter("MemID",memID)};
            return dbc.Execute(strSql, paras);
        }

        /// <summary>
        /// 通过会员ID查询会员余额
        /// </summary>
        /// <param name="money">剩余金额</param>
        /// <param name="memID">会员ID</param>
        /// <returns>返回受影响行数</returns>
        public float QueryMemMoneyByMemID(int memID)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [mem_money]
                    FROM [shuaka].[dbo].[mb_BasicInfo]
                    WHERE [mem_id]=@MemID";
            SqlParameter[] paras = { new SqlParameter("MemID", memID) };
            DataSet ds = dbc.GetDataSet(strSql, paras);
            float price = float.Parse(ds.Tables[0].Rows[0]["mem_money"].ToString());
            return price;
        }

        /// <summary>
        /// 购买商品的时候判断用户是否存在
        /// </summary>
        /// <param name="memID">会员ID</param>
        /// <param name="pwd">会员密码</param>
        /// <returns></returns>
        public bool IsExist(int memID, string pwd)
        {
            dbc = new DBConnection();
            strSql = @"SELECT [mem_id]
                FROM [shuaka].[dbo].[mb_BasicInfo]
                WHERE [mem_id]=@MerID AND [mem_psw]=@Pwd";
            SqlParameter[] paras ={new SqlParameter("MerId",memID),
                                  new SqlParameter("Pwd",pwd)};
            DataSet ds = dbc.GetDataSet(strSql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// 通过会员ID，产品ID和金额修改消费记录
        /// </summary>
        /// <param name="memID">会员ID</param>
        /// <param name="pdID">产品ID</param>
        /// <param name="money">金额</param>
        /// <returns></returns>
        public int RecordCost(int memID, int pdID, float money)
        {
            PdInfoMaintain pim = new PdInfoMaintain();
            DataSet ds = pim.GetPdInfoByPdID(pdID);
            CostRecord cr = new CostRecord();
            cr.CostTime = DateTime.Now;
            cr.MemID = memID;
            cr.MerID = Convert.ToInt32(ds.Tables[0].Rows[0]["mer_id"].ToString());
            cr.CostMoney = money;
            cr.PdID = pdID;
            cr.PdName = ds.Tables[0].Rows[0]["pd_name"].ToString();

            dbc = new DBConnection();
            strSql = @"INSERT INTO [shuaka].[dbo].[cost_record]
           ([mem_id]
           ,[mer_id]
           ,[cost_time]
           ,[cost_money]
           ,[pd_id]
           ,[pd_name])
     VALUES
           (@MemID,
           @MerID,
           @CostTime,
           @CostMoney,
           @PdID,
           @PdName)";
            SqlParameter[] paras = { new SqlParameter("MemID",cr.MemID),
                                     new SqlParameter("MerID",cr.MerID),
                                     new SqlParameter("CostTime",DateTime.Now),
                                     new SqlParameter("CostMoney",cr.CostMoney),
                                     new SqlParameter("PdID",cr.PdID),
                                     new SqlParameter("PdName",cr.PdName),};
            return dbc.Execute(strSql, paras);


        }
    }
}
