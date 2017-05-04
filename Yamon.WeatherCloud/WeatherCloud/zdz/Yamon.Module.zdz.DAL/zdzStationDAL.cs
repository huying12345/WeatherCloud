
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.zdz.Entity;
using System;

namespace Yamon.Module.zdz.DAL
{
    /// <summary>
    /// 自动站站点实体类
    ///</summary>
    public partial class zdzStationDAL : _zdzStationDAL
    {
        public string GetStationList()
        {
            string cacheKey = "GetAction_StationList";

            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            string content = "";

            if (objType == null)
            {
                try
                {
                    string url = "";

                    url = "http://app.bsqx.com/Home/GetStationAction/";


                    HttpHelper http = new HttpHelper();

                    content = http.Get(url);


                }
                catch (Exception ex)
                {

                }
                return content;

            }
            else
            {
                return content;
                //return objType.ToString();
            }
        }


        public string GetStationHour(string id)
        {
            string cacheKey = "GetAction_StationHour";

            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            string content = "";

            if (objType == null)
            {
                try
                {
                    string url = "";

                    url = "http://app.bsqx.com/Home/GetInfoListStationHour/"+id;


                    HttpHelper http = new HttpHelper();

                    content = http.Get(url);


                }
                catch (Exception ex)
                {

                }
                return content;

            }
            else
            {
                return content;
                //return objType.ToString();
            }
        }


        public string GetStationRainHour(string id)
        {
            string cacheKey = "GetAction_StationRainHour";

            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            string content = "";

            if (objType == null)
            {
                try
                {
                    string url = "";

                    url = "http://app.bsqx.com/Home/GetInfoListStationRain/" + id;


                    HttpHelper http = new HttpHelper();

                    content = http.Get(url);


                }
                catch (Exception ex)
                {

                }
                return content;

            }
            else
            {
                return content;
                //return objType.ToString();
            }
        }


        public string GetStaionIMG(string type)
        {
            string cacheKey = "GetAction_StationIMG";

            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            string content = "";

            if (objType == null)
            {
                try
                {
                    string url = "";

                    url = "http://bsqx.com/GetFoundIMG?createby=bs&type="+type+"&imgType=png";


                    HttpHelper http = new HttpHelper();

                    content = http.Get(url);


                }
                catch (Exception ex)
                {

                }
                return content;

            }
            else
            {
                return content;
                //return objType.ToString();
            }
        }


        public string GetStaionPM()
        {
            string cacheKey = "GetAction_StationPM";

            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            string content = "";

            if (objType == null)
            {
                try
                {
                    string url = "";

                    url = "http://bsqx.com/GetDustHourAction/24";


                    HttpHelper http = new HttpHelper();

                    content = http.Get(url);


                }
                catch (Exception ex)
                {

                }
                return content;

            }
            else
            {
                return content;
                //return objType.ToString();
            }
        }

    }
}
