using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class TbCity
    {
        //市区ID
        private int cityID;
        public int CityID
        {
            get { return cityID; }
            set { cityID = value; }
        }

        //省ID
        private int proID;
        public int ProID
        {
            get { return proID; }
            set { proID = value; }
        }

        //市区名称
        private string cityName;
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }
    }
}
