
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
    /// 文档实体类
    ///</summary>
    public partial class WeatherDocDAL : _WeatherDocDAL
    {
        public List<WeatherDoc> GetDocList(int id)
        {
            List<WeatherDoc> list = new List<WeatherDoc>();
            WeatherNodesDAL nodeDal = new WeatherNodesDAL();
            WeatherNodes node = nodeDal.GetModelByID(id);
            if (node != null && node.DataSourceType == "BaoShan")
            {
                return GetBaoShanDocList(node);
            }
            return list;
        }

        public List<WeatherDoc> GetBaoShanDocList(WeatherNodes node)
        {

            string url = node.DataApiUrl + "&pageSize=10";
            HttpHelper httpHelper = GetHttpHelper();
            string content = httpHelper.Get(url);
            JObject result = JsonConvert.DeserializeObject<JObject>(content);
            List<WeatherDoc> list = new List<WeatherDoc>();
            if (result["data"] != null)
            {
                DataTable dataList = JsonConvert.DeserializeObject<DataTable>(result["data"].ToString());
                foreach (DataRow row in dataList.Rows)
                {
                    WeatherDoc img = new WeatherDoc();
                    // string fileUrl = row["url"].ToString();
                    string fileUrl = DownLoadDocFile(httpHelper, row["url"].ToString());
                    img.InfoPath = fileUrl;
                    img.InfoTypeID = node.NodeID;
                    img.InfoTitle = row["name"].ToString();
                    img.DataTime = GetImageDataTime(row["name"].ToString());
                    //img.CreateTime = new DateTime(long.Parse((DataConverter.ToDouble(row["createTime"])).ToString()));
                    list.Add(img);
                }
            }

            return list;
        }


        public string DownLoadDocFile(HttpHelper httpHelper, string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string savePath = uri.AbsolutePath;
                FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + savePath);

                IOHelper.IsExistFolderAndCreate(file.DirectoryName);

                if (!File.Exists(file.FullName))
                {
                    httpHelper.Download(url, file.FullName);
                    WordHelper.SaveAs(file.FullName, file.FullName.Replace(".doc", ".jpg"), MySaveFormat.Jpg);
                }
                return savePath.Replace(".doc", ".jpg");
            }
            catch (Exception ex)
            {
                LogHelper.Error("下载文件失败：" + url, ex);
            }
            return url;
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
