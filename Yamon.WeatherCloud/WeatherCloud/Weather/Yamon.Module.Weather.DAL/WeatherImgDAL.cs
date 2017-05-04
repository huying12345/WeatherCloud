
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
using Yamon.Module.Weather.Entity;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yamon.Framework.Log4Net;

namespace Yamon.Module.Weather.DAL
{
    /// <summary>
    /// 图片实体类
    ///</summary>
    public partial class WeatherImgDAL : _WeatherImgDAL
    {
        public string DownLoadFilelistImg(string filePath, int id, string dtime, string nodeid)
        {
            try
            {
                filePath = filePath.Replace("http://10.228.118.100/", "");
                string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);

                string fileDic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "UploadFiles\\IMG\\" + id + "\\" + nodeid + "\\",
                    filePath.Replace(fileName, "").Replace("/", "\\")).Replace("\\\\", "\\");
                IOHelper.IsExistFolderAndCreate(fileDic);

                if (!IOHelper.IsExist(fileDic + fileName, FsoMethod.File))
                {
                    //fileName = fileName.Substring(fileName.IndexOf("f="), fileName.LastIndexOf("=")).Replace("f=", "");
                    string[] filenames = fileName.Split('&');
                    if (filenames.Length > 0)
                    {
                        fileName = filenames[2].Substring(0, 10) + DataConverter.ToDate(dtime).ToString("yyyyMMddHHmmss");
                    }
                    else
                    {
                        fileName = fileName.Substring(fileName.IndexOf("f="), fileName.LastIndexOf("=")).Replace("f=", "") + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }

                    string url = "http://10.228.118.100/" + filePath;
                    HttpHelper httpHelper = GetHttpHelper();
                    httpHelper.Download(url, fileDic + fileName + ".gif");
                }

                string str = fileDic + fileName + ".gif";
                if (str != null)
                {
                    return "/UploadFiles/IMG/" + id + "/" + nodeid + "/" + fileName + ".gif";
                }
                else
                {
                    return "http://10.228.118.100/" + filePath;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("下载文件失败：" + filePath, ex);
            }
            return null;
        }

        public List<WeatherImg> GetPro(WeatherNodes node)
        {

            List<WeatherImg> list = new List<WeatherImg>();
            List<WeatherImg> listTemp = new List<WeatherImg>();
            try
            {
                //onclick=donghua('4cc3d8d9c64e0a054ed1253bee25a737',560,677)>地面</a><br 
                string url = node.DataApiUrl + "#";
                //if (id == 259)
                //{
                //    url = "http://10.228.118.100/index.php?controller=listpic&pid=" + id + "&DT1=2016092602#";
                //}
                //else
                //{
                //    url = "http://10.228.118.100/index.php?controller=listpic&pid=" + id + "#";
                //}

                HttpHelper http = GetHttpHelper();
                string content = http.Get(url);
                int indexStart = 0;
                int endIndex = 0;
                int id = 259;
                WeatherNodesDAL vp = new WeatherNodesDAL();
                //or ProductNo=? or OrderID=?
                WeatherNodes wNodes = vp.GetModelByID(node.NodeID);

                int nodeId = DataConverter.ToInt(wNodes.NodeID);
                if (nodeId == 179)
                {
                    indexStart = content.IndexOf("1小时累计降水");
                    endIndex = content.IndexOf("3小时累计降水");
                }
                else if (nodeId == 180)
                {
                    indexStart = content.IndexOf("地面风场");
                    endIndex = content.IndexOf("1小时累计降水");
                }
                else if (nodeId == 181)
                {
                    indexStart = content.IndexOf("能见度");
                    endIndex = content.IndexOf("闪电潜势指数");
                }
                else if (nodeId == 182)
                {
                    indexStart = content.IndexOf("K指数");
                    endIndex = content.IndexOf("位势高度和温度");
                }
                else if (nodeId == 183)
                {
                    indexStart = content.IndexOf("埃玛图");
                    endIndex = content.IndexOf("徐家汇软雹剖面图");
                }
                else if (nodeId == 175)
                {
                    indexStart = content.IndexOf("3小时累计降水");
                    endIndex = content.IndexOf("6小时累计降水");
                    id = 245;
                }
                else if (nodeId == 176)
                {
                    indexStart = content.IndexOf("地面风场");
                    endIndex = content.IndexOf("3小时累计降水");
                    id = 245;
                }
                else if (nodeId == 177)
                {
                    indexStart = content.IndexOf("能见度");
                    endIndex = content.IndexOf("边界层云底高度");
                    id = 245;
                }

                content = content.Substring(indexStart, endIndex - indexStart);
                if (nodeId == 183)
                {
                    content = content.Substring(content.IndexOf("南京"), content.IndexOf("宝山"));
                }
                content = content.Substring(content.IndexOf("('"), content.IndexOf("',") - content.IndexOf("('"));
                content = content.Replace("('", "");

                listTemp = GetIMG(content, id, http, nodeId, wNodes.NodeName);

                string idOrderDesc = ConfigHelper.GetConfigString("idOrderDesc");
                string nodIdOrder = "," + nodeId.ToString() + ",";
                if (idOrderDesc.IndexOf(nodIdOrder) != -1)
                {
                    for (int i = listTemp.Count - 1; i >= 0; i--)
                    {
                        list.Add(listTemp[i]);
                    }
                }
                else
                {
                    list = listTemp;
                }
            }
            catch (Exception ex)
            {

            }
            return list;

        }


        public List<WeatherImg> GetIMG(string content, int id, HttpHelper http, int nodeID, string name)
        {
            List<WeatherImg> list = new List<WeatherImg>();
            try
            {
                string url1 = "http://10.228.118.100/index.php?controller=listpic&action=xml&j=" + content + "&pid=" + id + "";
                string PhpContent = StringHelper.HtmlDecode(http.Get(url1));
                PhpContent = PhpContent.Substring(PhpContent.IndexOf("<pictureList>"), PhpContent.IndexOf("</pictureList>") - PhpContent.IndexOf("<pictureList>"));
                PhpContent = PhpContent.Replace("\"", "").Replace("\r\n\t", ",");
                string[] PhpList = PhpContent.Split(',');
                string bsszyb = ConfigHelper.GetConfigString("bsszyb");
                for (int i = 1; i < 11; i++)
                {
                    int indexstart = PhpList[i].IndexOf("path=");
                    int endstart = PhpList[i].IndexOf("name");
                    string path = PhpList[i].Substring(indexstart, endstart - indexstart).Replace("path=", "");
                    string datatime = PhpList[i].Substring(PhpList[i].IndexOf("datetime="), PhpList[i].IndexOf("/>") - PhpList[i].IndexOf("datetime=")).Replace("datetime=", "");

                    WeatherImg img = new WeatherImg();
                    //img.InfoPath = DownLoadFilelistImg(path, id, datatime, nodeID.ToString());
                    img.InfoPath = path.Replace("http://10.228.118.100/", bsszyb);
                    img.InfoTypeID = nodeID;
                    img.InfoTitle = name;
                    img.DataTime = DataConverter.ToDate(datatime);
                    list.Add(img);
                }
            }
            catch
            {

            }
            return list;
        }


        public List<WeatherImg> GetImageList(int id)
        {
            List<WeatherImg> list = new List<WeatherImg>();
            WeatherNodesDAL nodeDal = new WeatherNodesDAL();
            WeatherNodes node = nodeDal.GetModelByID(id);
            if (node != null && node.DataSourceType == "BaoShan")//宝山
            {
                return GetBaoShanImageList(node);
            }
            if (node != null && node.DataSourceType == "NumForecast")//数值预报
            {
                return GetPro(node);
            }
            if (node != null && node.DataSourceType == "BaoShanShared")//宝山共享图片
            {
                return GetSharedPicture(node);
            }
            return list;
        }

        /// <summary>
        /// 数据来源-宝山
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<WeatherImg> GetBaoShanImageList(WeatherNodes node)
        {

            string url = node.DataApiUrl + "&pageSize=10";
            HttpHelper httpHelper = GetHttpHelper();

            string bsdata = ConfigHelper.GetConfigString("bsdata");
            string content = httpHelper.Get(url);
            JObject result = JsonConvert.DeserializeObject<JObject>(content);
            List<WeatherImg> list = new List<WeatherImg>();
            if (result["data"] != null)
            {
                DataTable dataList = JsonConvert.DeserializeObject<DataTable>(result["data"].ToString());
                foreach (DataRow row in dataList.Rows)
                {
                    WeatherImg img = new WeatherImg();
                    string fileUrl = row["url"].ToString();
                    //string fileUrl = DownLoadFilelistImg(httpHelper, row["url"].ToString());
                    img.InfoPath = fileUrl.Replace("http://10.228.136.227/", bsdata);
                    img.InfoTypeID = node.NodeID;
                    img.InfoTitle = row["name"].ToString();
                    img.DataTime = GetImageDataTime(row["name"].ToString());
                    //img.CreateTime = new DateTime(long.Parse((DataConverter.ToDouble(row["createTime"])).ToString()));
                    list.Add(img);
                }
            }

            return list;
        }


        public string DownLoadFilelistImg(HttpHelper httpHelper, string url)
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
                }
                return savePath;
            }
            catch (Exception ex)
            {
                LogHelper.Error("下载文件失败：" + url, ex);
            }
            return url;
        }

        public DateTime GetImageDataTime(string name)
        {

            string[] arrName = name.Split(new char[] { '-', '_' });
            for (int i = 0; i < arrName.Length; i++)
            {
                if (Regex(arrName[i]).Length == 12)
                {
                    return DateTimeHelper.ToDateTime("yyyyMMddHHmm", arrName[i], DateTime.Now);
                }
            }
            return DateTime.Now;
        }

        public string Regex(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
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


        /// <summary>
        /// 获取远程文件图片
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<WeatherImg> GetSharedPicture(WeatherNodes node)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Log\\Shared_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";//详细日志
            HttpHelper httpHelper = GetHttpHelper();
            List<WeatherImg> list = new List<WeatherImg>();
            string bsdata1 = ConfigHelper.GetConfigString("bsdata1");
            string idOrderDesc = ConfigHelper.GetConfigString("idOrderDesc");
            string namePrefix = node.NamePrefix;//命令前缀
            string apiUrl = node.DataApiUrl;//路径
            string dateTimeFormat = node.DateTimeFormat;//日期格式
            try
            {
                //判断是否需要修改数据排序
                bool idOrderDescs=false;
                string nodIdOrder = "," + node.NodeID.ToString() + ",";
                if (idOrderDesc.IndexOf(nodIdOrder) != -1)
                {
                    idOrderDescs = true;
                }

                string result = httpHelper.Get(apiUrl);
                ArrayList aList = StringHelper.GetAHrefArray(result);

                List<WeatherImg> listTemp = new List<WeatherImg>();
                int kk = 0;
                string item = "";
                string fiInfo = "";
                string dateTime = "";
                string dateTimeStart = "";
                DateTime imgDataTime=DateTime.Now;
                for (int i = aList.Count - 1; i >= 0; i--)
                {
                    item = aList[i].ToString();
                    if (item.ToString().IndexOf(namePrefix) != -1)
                    {
                        WeatherImg img = new WeatherImg();

                        //--读取数据时间
                        //fiInfo = item.Substring(item.LastIndexOf("/") + 1);
                        //string fileName = fiInfo.Substring(0, fiInfo.LastIndexOf("."));
                        //string[] fileNames = fileName.Replace(namePrefix, "").Replace(".", "").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        //dateTime = fileNames[fileNames.Length - 1].Replace(namePrefix, "").Replace(".", "");
                        //imgDataTime = DateTimeHelper.ToDateTime(dateTimeFormat, dateTime, DateTime.Now);

                        //if (idOrderDescs) //需要排序读取对离现在最近的时间
                        //{
                        //    if (kk == 0) { dateTimeStart = fileNames[0]; }//获取发布时间
                        //    if (dateTimeStart != fileNames[0]) break; //只查询此发布时间发布的数据
                        //    if (DateTime.Compare(DateTime.Now, imgDataTime) >= 0) break;
                        //}

                        //读取预报时间
                        fiInfo = item.Substring(item.LastIndexOf("/") + 1);
                        string fileName = fiInfo.Substring(0, fiInfo.LastIndexOf("."));

                        
                        img.DataTime = GetImageDataTime(fiInfo);
                        if (idOrderDescs) //需要排序读取对离现在最近的时间
                        {
                            if (kk == 0) { dateTimeStart = DataConverter.ToDate(img.DataTime).ToString("yyyyMMddHHmm"); }//获取发布时间
                            if (dateTimeStart != DataConverter.ToDate(img.DataTime).ToString("yyyyMMddHHmm")) break; //只查询此发布时间发布的数据
                            //if (DateTime.Compare(DateTime.Now, imgDataTime) >= 0) break;
                        }
                        
                        img.InfoPath = bsdata1 + item.Replace("\\", "/").TrimStart('/');
                        img.InfoTypeID = node.NodeID;
                        img.InfoTitle = fileName;
                        
                        listTemp.Add(img);
                        kk++;
                        

                        if (kk >= 10 && idOrderDescs == false) break; //读取10条数据
                    }
                }

                if (idOrderDescs)
                {

                    List<WeatherImg> listTempNew = new List<WeatherImg>();
                    int count = 0;
                    if (listTemp.Count - 10 > 0) { count = listTemp.Count - 10; }
                    for (int i = listTemp.Count - 1; i >= count; i--)
                    {
                        listTempNew.Add(listTemp[i]);
                    }

                    list.Add(listTempNew[0]);
                    for (int i = listTempNew.Count - 1; i >= 1; i--)
                    {
                        list.Add(listTempNew[i]);
                    }
                    //list = listTemps;
                }
                else
                {
                    list = listTemp;
                }
            }
            catch (Exception ex)
            {
                IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "读取远程图片失败！" + ex.Message + "\r\n");
                LogHelper.Error("读取远程图片失败！" + ex.Message);
            }
            return list;
        }

         
    }
}
