using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class McPdMaintain
    {
        //产品编号
        private int pdID;
        public int PdID
        {
            get { return pdID; }
            set { pdID = value; }
        }

        //商家ID
        private int merID;
        public int MerID
        {
            get { return merID; }
            set { merID = value; }
        }

        //商品名称
        private string pdName;
        public string PdName
        {
            get { return pdName; }
            set { pdName = value; }
        }

        //商品价格
        private float pdPrice;
        public float PdPrice
        {
            get { return pdPrice; }
            set { pdPrice = value; }
        }

        //商品会员价格
        private float pdMemPrice;
        public float PdMemPrice
        {
            get { return pdMemPrice; }
            set { pdMemPrice = value; }
        }

        //商品介绍
        private string pdInfo;
        public string PdInfo
        {
            get { return pdInfo; }
            set { pdInfo = value; }
        }

        //商品图片
        private string pdPic;
        public string PdPic
        {
            get { return pdPic; }
            set { pdPic = value; }
        }

        //商商品可用状态称
        private Boolean pdState;
        public Boolean PdState
        {
            get { return pdState; }
            set { pdState = value; }
        }

        //商品备注
        private string pdNote;
        public string PdNote
        {
            get { return pdNote; }
            set { pdNote = value; }
        }
    }
}
