using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class TbNews
    {
        //新闻ID
        private int newsID;
        public int NewsID
        {
            get { return newsID; }
            set { newsID = value; }
        }

        //新闻标题
        private string newsTitle;
        public string NewsTitle
        {
            get { return newsTitle; }
            set { newsTitle = value; }
        }

        //新闻正文
        private string newsText;
        public string NewstText
        {
            get { return newsText; }
            set { newsText = value; }
        }

        //新闻的发布人
        private string newsPub;
        public string NewsPub
        {
            get { return newsPub; }
            set { newsPub = value; }
        }

        //新闻的发布时间
        private String newsTime;
        public String NewsTime
        {
            get { return newsTime; }
            set { newsTime = value; }
        }

        //新闻状态
        private int newsState;
        public int NewsState
        {
            get { return newsState; }
            set { newsState = value; }
        }

        //新闻图片
        private string newsPic;
        public string NewsPic
        {
            get { return newsPic; }
            set { newsPic = value; }
        }
    }
}
