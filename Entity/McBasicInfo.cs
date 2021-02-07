using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class McBasicInfo
    {
        //商家ID
        private int merID;
        public int MerID
        {
            get { return merID; }
            set { merID = value; }
        }

        //行业ID
        private int indID;
        public int IndID
        {
            get { return indID; }
            set { indID = value; }
        }

        //市区ID
        private int cityID;
        public int CityID
        {
            get { return cityID; }
            set { cityID = value; }
        }

        //商家密码
        private string merPwd;
        public string MerPwd
        {
            get { return merPwd; }
            set { merPwd = value; }
        }

        //商家类型
        private string merType;
        public string MerType
        {
            get { return merType; }
            set { merType = value; }
        }

        //商家名称
        private string merName;
        public string MerName
        {
            get { return merName; }
            set { merName = value; }
        }

        //商家图片
        private string merPic;
        public string MerPic
        {
            get { return merPic; }
            set { merPic = value; }
        }

        //商家介绍
        private string merInfo;
        public string MerInfo
        {
            get { return merInfo; }
            set { merInfo = value; }
        }

        //商家联系地址
        private string merAddr;
        public string MerAddr
        {
            get { return merAddr; }
            set { merAddr = value; }
        }
       
        //商家联系电话
        private string merPhone;
        public string MerPhone
        {
            get { return merPhone; }
            set { merPhone = value; }
        }

        //商家邮编
        private string merPostcode;
        public string MerPostcode
        {
            get { return merPostcode; }
            set { merPostcode = value; }
        }

        //商家网址
        private string merWebsite;
        public string MerWebsite
        {
            get { return merWebsite; }
            set { merWebsite = value; }
        }

        //商家账号状态
        private int merState;
        public int MerState
        {
            get { return merState; }
            set { merState = value; }
        }

        //是否为推荐商家
        private Boolean recMerState;
        public Boolean RecMerState
        {
            get { return recMerState; }
            set { recMerState = value; }
        }

        //会员折扣比例
        private string merDiscount;
        public string MerDiscount
        {
            get { return merDiscount; }
            set { merDiscount = value; }
        }

        //注册人姓名
        private string regName;
        public string RegName
        {
            get { return regName; }
            set { regName = value; }
        }

        //注册人职务
        private string regDuty;
        public string RegDuty
        {
            get { return regDuty; }
            set { regDuty = value; }
        }
        
        //注册人电话
        private string regPhone;
        public string RegPhone
        {
            get { return regPhone; }
            set { regPhone = value; }
        }

        //注册人手机号
        private string regTelePhone;
        public string RegTelePhone
        {
            get { return regTelePhone; }
            set { regTelePhone = value; }
        }

        //注册人电子邮箱
        private string regEmail;
        public string RegEmail
        {
            get { return regEmail; }
            set { regEmail = value; }
        }

        //商家星级
        private int merStarLever;
        public int MerStarLever
        {
            get { return merStarLever; }
            set { merStarLever = value; }
        }
    }
}
