using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL.McManaDAL;
using Entity;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
           
            McBasicInfo mbi = new McBasicInfo();
            mbi.IndID = 12304;
            mbi.CityID = 23566;
            mbi.MerType = "tt";
            mbi.MerName = "bingbing";
            mbi.MerAddr = "dfkjsfsdfjsd";
            mbi.MerPhone = "1238651561";
            mbi.MerPostcode = "0074";
            mbi.MerDiscount = "15";
            mbi.RegName = "nimei";
            mbi.RegDuty = "jingli";
            mbi.RegEmail = "dfdsf";
            mbi.RegPhone = "12345678911";
            mbi.RegTelePhone = "12345698712";
            mbi.MerPwd = "dsfdfds";
            mbi.MerPic="C:\\";
            mbi.MerInfo = "sdfsd";
            mbi.MerWebsite = "www.baidu.com";
            mbi.MerState = 0;
            mbi.MerStarLever = 1;
            mbi.RecMerState = true;
            mbi.MerID = 123255;
            mbi.MerAddr = "xianjiaoda";
            JoinManaDAL jmd = new JoinManaDAL();
            int j = jmd.AddMcDAL(mbi);
            System.Console.Write(j);
            LoginManaDAL lmd=new LoginManaDAL();
             DBConnection dbc = new DBConnection();
             System.Console.Write(lmd.McLogin("12345698712", "dsfdfds"));
        }

    }
}
