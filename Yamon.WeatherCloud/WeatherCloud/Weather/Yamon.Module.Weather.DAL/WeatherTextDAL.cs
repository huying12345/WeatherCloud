
using System;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yamon.Framework.DAL;
using Yamon.Framework.Log4Net;
using Yamon.Framework.Words;
using Yamon.Module.Weather.Entity;

namespace Yamon.Module.Weather.DAL
{
    /// <summary>
    /// 文本实体类
    ///</summary>
    public partial class WeatherTextDAL : _WeatherTextDAL
    {
        public List<WeatherText> GetTextList(int id)
        {
            List<WeatherText> list = new List<WeatherText>();
            WeatherNodesDAL nodeDal = new WeatherNodesDAL();
            WeatherNodes node = nodeDal.GetModelByID(id);
            if (node != null && node.DataSourceType == "BaoShan")
            {
                return GetBaoShanTextList(node);
            }
            return list;
        }

        public List<WeatherText> GetBaoShanTextList(WeatherNodes node)
        {

            string url = node.DataApiUrl + "&pageSize=1";
            HttpHelper httpHelper = GetHttpHelper();
            string content = httpHelper.Get(url);
            JObject result = JsonConvert.DeserializeObject<JObject>(content);
            List<WeatherText> list = new List<WeatherText>();
            if (result["data"] != null)
            {
                DataTable dataList = JsonConvert.DeserializeObject<DataTable>(result["data"].ToString());
                foreach (DataRow row in dataList.Rows)
                {
                    WeatherText img = new WeatherText();
                    // string fileUrl = row["url"].ToString();
                    httpHelper.SetEncoding(Encoding.Default);
                    string fileUrl = httpHelper.Get(row["url"].ToString());
                    img.InfoDetail = fileUrl;
                    img.InfoTypeID = node.NodeID;
                    img.InfoTitle = row["name"].ToString();
                    img.DataTime = GetImageDataTime(row["name"].ToString());
                    //img.CreateTime = new DateTime(long.Parse((DataConverter.ToDouble(row["createTime"])).ToString()));
                    list.Add(img);
                }
            }

            return list;
        }


        public DateTime GetImageDataTime(string name)
        {
            string[] arrName = name.Split(new char[] { '-' });
            for (int i = 0; i < arrName.Length; i++)
            {
                if (arrName[i].Length == 12)
                {
                    return DateTimeHelper.ToDateTime("yyyyMMddHHmm", arrName[i], DateTime.Now);
                }
            }
            return DateTime.Now;
        }

        private HttpHelper GetHttpHelper()
        {
            HttpHelper httpHelper = new HttpHelper();
            if (ConfigHelper.GetConfigBool("Shcma_Proxy"))
            {
                httpHelper.SetProxy("cm.yamon.cn", 5222, "yamon", "!QAZxsw2");
            }
            return httpHelper;
        }

    }
}
