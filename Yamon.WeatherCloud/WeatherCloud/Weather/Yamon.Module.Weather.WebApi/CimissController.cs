using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;

namespace Yamon.Module.Weather.WebApi
{
    public class CimissController : BaseController
    {

        string cimissUrl = ConfigHelper.GetConfigString("CIMISS");//网址
        string bs_StaIds = "A5151,A5145,A5155,A5142,A5153,A5143,A5154,A5104,A5152,A5148,A5101,A5150,A5156,A5141";

        //获取 HttpHelper；用于判断是否使用代理
        private HttpHelper GetHttpHelper()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.SetTimeOut(15000);
            if (ConfigHelper.GetConfigBool("Shcma_Proxy"))
            {
                httpHelper.SetProxy("cm.yamon.cn", 5222, "yamon", "!QAZxsw2");
            }
            return httpHelper;
        }

        //对Cimiss数据处理，返回datatable数据格式
        private DataTable GetDataByHttpString(string result)
        {
            DataTable dtDs = new DataTable();
            try
            {
                JObject job = JsonConvert.DeserializeObject<JObject>(result);
                dtDs = JsonConvert.DeserializeObject<DataTable>(job["DS"].ToString());
            }
            catch (Exception)
            {
            }
            return dtDs;
        }



        //根据区号返回站点数据
        [NoCheckLogin]
        public string GetSatationByAdminCodes(string adminCodes = "310113")
        {
            HttpHelper http = GetHttpHelper();
            string param = "&interfaceId=getStaInfoByRegionCode&dataCode=STA_INFO_SURF_GLB&elements=Station_Id_C,Station_Name&adminCodes=" + adminCodes + "&dataFormat=json";
            string result = http.Post(cimissUrl, param);
            DataTable dtDs = GetDataByHttpString(result);
            string Station_Id_CList = "";
            for (int i = 0; i < dtDs.Rows.Count; i++)
            {
                Station_Id_CList += dtDs.Rows[i]["Station_Id_C"] + ",";
            }
            return Station_Id_CList.TrimEnd(',');
        }


        //获取最近12小时整点数据 气温、风向、雨量
        [NoCheckLogin]
        public ActionResult GetStationDataByHour12(string staIds = "58362")
        {
            try
            {
                //Station_Name,Station_Id_C,Station_Id_d,Datetime,TEM,TEM_Max_24h,TEM_Min_24h,PRE_1h,PRE_3h,PRE_6h,PRE_12h,PRE_24h
                string param = "&interfaceId=getSurfEleByTimeRangeAndStaID" /* 1.2 接口ID */ // //getSurfEleInRegionByTimeRange
                    + "&dataCode=SURF_CHN_MUL_HOR" /* 1.3 必选参数（按需加可选参数） */ //资料：中国地面逐小时
                    + "&elements=Station_Name,Station_Id_C,Station_Id_d,Datetime,TEM,PRE_1h,WIN_D_INST,WIN_S_INST,WIN_D_Avg_2mi,WIN_S_Avg_2mi"
                    + "&timeRange=(" + DateTime.Now.AddHours(-20).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]"
                    //检索时间段
                    + "&staIds=" + staIds //排序：按照站号从小到大 310113  
                    + "&orderby=Datetime:desc" //排序：按照站号从小到大
                    + "&dataFormat=json"; /* 1.4 序列化格式 */
                HttpHelper http = GetHttpHelper();
                string result = http.Post(cimissUrl, param);

                DataTable dtDs = GetDataByHttpString(result);

                dtDs.Columns["WIN_D_Avg_2mi"].DataType = typeof(string);
                dtDs.Columns["WIN_S_Avg_2mi"].DataType = typeof(string);

                for (int i = 0; i < dtDs.Rows.Count; i++)
                {
                    dtDs.Rows[i]["Datetime"] = DataConverter.ToDate(dtDs.Rows[i]["Datetime"]).AddHours(8);
                    dtDs.Rows[i]["WIN_D_Avg_2mi"] = GetWindDirectionString(dtDs.Rows[i]["WIN_D_Avg_2mi"].ToString());
                    dtDs.Rows[i]["WIN_S_Avg_2mi"] = GetWindLevelString(dtDs.Rows[i]["WIN_S_Avg_2mi"].ToString());
                }

                hash["data"] = dtDs;
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        //根据站号获取最新数据（雨量、气温、风向、风速、湿度、气压、能见度）
        [NoCheckLogin]
        public ActionResult GetStationDataNowByStaIds(string staIds="58362")
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            try
            {
                HttpHelper http = GetHttpHelper();
                string content = "";
                if (isCreate == 0)
                {
                    content = CacheReadFile.ReadFile(staIds);
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }
                string time1 = DateTime.Now.AddHours(-12).ToString("yyyyMMddHHmmss");
                string time2 = DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss");
                //雨量查询 最新雨量数据在整点时间上
                string param = "&interfaceId=getSurfEleByTimeRangeAndStaID&dataCode=SURF_CHN_PRE_MIN&elements=Station_Name,Datetime,Station_Id_C,PRE"
                    + "&timeRange=(" + time1 + "," + time2 + "]"
                    + "&staIds=" + staIds
                    + "&orderBy=Datetime:desc&limitCnt=1&dataFormat=json";

                string result = http.Post(cimissUrl, param);

                DataTable dtDs_Rain = GetDataByHttpString(result);

                //查询最新 气温，风向、风速、湿度、气压 //SURF_CHN_MAIN_MIN
                param = "&interfaceId=getSurfEleByTimeRangeAndStaID&dataCode=SURF_CHN_MAIN_MIN&elements=Station_Name,Station_Id_C,Datetime,TEM,RHU,WIN_D_Avg_1mi,WIN_S_Avg_1mi,PRS"
                    + "&timeRange=(" + time1 + "," + time2 + "]"
                    + "&staIds=" + staIds
                    + "&orderBy=Datetime:desc&limitCnt=1&dataFormat=json";

                result = http.Post(cimissUrl, param);
                DataTable dtDs_Tem = GetDataByHttpString(result);

                //查询最新 能见度 //SURF_CHN_OTHER_MIN
                param = "&interfaceId=getSurfEleByTimeRangeAndStaID&dataCode=SURF_CHN_OTHER_MIN&elements=Station_Name,Station_Id_C,Datetime,VIS_HOR_1MI"
                    + "&timeRange=(" + time1 + "," + time2 + "]"
                    + "&staIds=" + staIds
                    + "&orderBy=Datetime:desc&limitCnt=1&dataFormat=json";

                result = http.Post(cimissUrl, param);
                DataTable dtDs_VIS = GetDataByHttpString(result);

                //对返回数据进行处理
                dtDs_Tem.Columns.Add("PRE");
                dtDs_Tem.Columns.Add("Datetime2");
                
                if (dtDs_Rain.Rows.Count == 1)
                {
                    dtDs_Tem.Rows[0]["PRE"] = dtDs_Rain.Rows[0]["PRE"];
                }
                else
                {
                    dtDs_Tem.Rows[0]["PRE"] = 0;
                }
                //能见度
                dtDs_Tem.Columns.Add("VIS_HOR_1MI");
                if (dtDs_VIS.Rows.Count == 1)
                {
                    dtDs_Tem.Rows[0]["VIS_HOR_1MI"] = dtDs_VIS.Rows[0]["VIS_HOR_1MI"];
                }
                else
                {
                    dtDs_Tem.Rows[0]["VIS_HOR_1MI"] = 0;
                }

                //数据处理
                dtDs_Tem.Columns["WIN_D_Avg_1mi"].DataType = typeof(string);
                dtDs_Tem.Columns["WIN_S_Avg_1mi"].DataType = typeof(string);

                string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                for (int i = 0; i < dtDs_Tem.Rows.Count; i++)
                {
                    dtDs_Tem.Rows[i]["Datetime"] = DataConverter.ToDate(dtDs_Tem.Rows[i]["Datetime"]).AddHours(8);
                    dtDs_Tem.Rows[i]["WIN_D_Avg_1mi"] = GetWindDirectionString(dtDs_Tem.Rows[i]["WIN_D_Avg_1mi"].ToString());
                    dtDs_Tem.Rows[i]["WIN_S_Avg_1mi"] = GetWindLevelString(dtDs_Tem.Rows[i]["WIN_S_Avg_1mi"].ToString());
                    dtDs_Tem.Rows[i]["Datetime2"] = Day[Convert.ToInt32((DataConverter.ToDate(dtDs_Tem.Rows[i]["Datetime"])).DayOfWeek.ToString("d"))].ToString();
                }

                hash["data"] = dtDs_Tem.Rows[0].ToExpandoObject();
                hash["success"] = true;

                //写入缓存
                if (isCreate == 1)
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_" + staIds + ".txt");
                    IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }

            return Content(JsonConvert.SerializeObject(hash));
        }


        //根据区域查询 1h、3h、6h、24h 的 雨量
        [NoCheckLogin]
        public ActionResult GetStationDataHourPRE(string adminCodes = "310113", string staLevels = "")
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            string fileName = "PRE_" + (adminCodes + "_" + staLevels).Replace(",", "-");
            try
            {
                string content = "";
                if (isCreate == 0)
                {
                    content = CacheReadFile.ReadFile(fileName);
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }

                HttpHelper http = GetHttpHelper();

                string param = "&interfaceId=statSurfEleInRegion&dataCode=SURF_CHN_MUL_HOR&elements=Station_Name,Station_Id_C&statEles=SUM_PRE_1h"
                    + "&adminCodes=" + adminCodes
                    + "&orderBy=Station_Id_C&dataFormat=json";
                if (staLevels != "")
                {
                    param = param + "&staLevels=" + staLevels;
                }
                //1h
                string timeRange = "&timeRange=(" + DateTime.Now.AddHours(-9).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                string result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour1 = GetDataByHttpString(result);

                //3h
                timeRange = "&timeRange=(" + DateTime.Now.AddHours(-8 - 3).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour3 = GetDataByHttpString(result);

                //6h
                timeRange = "&timeRange=(" + DateTime.Now.AddHours(-8 - 6).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour6 = GetDataByHttpString(result);

                //24h
                timeRange = "&timeRange=(" + DateTime.Now.AddDays(-1).AddHours(-8).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour24 = GetDataByHttpString(result);


                //数据处理

                //添加数据字段
                dtDs_Hour1.Columns.Add("SUM_PRE_3h");
                dtDs_Hour1.Columns.Add("SUM_PRE_6h");
                dtDs_Hour1.Columns.Add("SUM_PRE_24h");
                
                for (int i = 0; i < dtDs_Hour1.Rows.Count; i++)
                {
                    DataRow[] dr3 = dtDs_Hour3.Select("Station_Id_C=" + dtDs_Hour3.Rows[i]["Station_Id_C"]);
                    if (dr3.Length > 0)
                    {
                        dtDs_Hour1.Rows[i]["SUM_PRE_3h"] = dr3[0]["SUM_PRE_1h"];
                    }
                    else
                    {
                        dtDs_Hour1.Rows[i]["SUM_PRE_3h"] = "";
                    }
                    DataRow[] dr6 = dtDs_Hour6.Select("Station_Id_C=" + dtDs_Hour3.Rows[i]["Station_Id_C"]);
                    if (dr3.Length > 0)
                    {
                        dtDs_Hour1.Rows[i]["SUM_PRE_6h"] = dr3[0]["SUM_PRE_1h"];
                    }
                    else
                    {
                        dtDs_Hour1.Rows[i]["SUM_PRE_6h"] = "";
                    }
                    DataRow[] dr24 = dtDs_Hour24.Select("Station_Id_C=" + dtDs_Hour3.Rows[i]["Station_Id_C"]);
                    if (dr3.Length > 0)
                    {
                        dtDs_Hour1.Rows[i]["SUM_PRE_24h"] = dr3[0]["SUM_PRE_1h"];
                    }
                    else
                    {
                        dtDs_Hour1.Rows[i]["SUM_PRE_24h"] = "";
                    }
                }
                
                hash["data"] = dtDs_Hour1;
                hash["success"] = true;

                if (isCreate == 1)
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_" + fileName + ".txt");
                    IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            
            return Content(JsonConvert.SerializeObject(hash));
        }


        //根据区域查询 1h、3h、6h、24h 的 风向风速
        [NoCheckLogin]
        public ActionResult GetStationDataHourDS(string adminCodes = "310113", string staLevels = "")
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            string fileName = "DS_" + (adminCodes + "_" + staLevels).Replace(",", "-");
            try
            {
                string content = "";
                if (isCreate == 0)
                {
                    content = CacheReadFile.ReadFile(fileName);
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }

                HttpHelper http = GetHttpHelper();
                string param = "&interfaceId=statSurfEleInRegion&dataCode=SURF_CHN_MUL_HOR&elements=Station_Name,Station_Id_C&statEles=MAX_WIN_D_Avg_2mi,MAX_WIN_S_Avg_2mi"
                    + "&adminCodes=" + adminCodes
                    + "&orderBy=Station_Id_C&dataFormat=json";
                if (staLevels != "")
                {
                    param = param + "&staLevels=" + staLevels;
                }
                //1h
                string timeRange = "&timeRange=(" + DateTime.Now.AddHours(-9).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                string result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour1 = GetDataByHttpString(result);

                //3h
                timeRange = "&timeRange=(" + DateTime.Now.AddHours(-8 - 3).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour3 = GetDataByHttpString(result);

                //6h
                timeRange = "&timeRange=(" + DateTime.Now.AddHours(-8 - 6).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour6 = GetDataByHttpString(result);

                //24h
                timeRange = "&timeRange=(" + DateTime.Now.AddDays(-1).AddHours(-8).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_Hour24 = GetDataByHttpString(result);


                //数据处理
                //更改数据类型
                dtDs_Hour1.Columns["MAX_WIN_D_Avg_2mi"].DataType = typeof(string);
                dtDs_Hour1.Columns["MAX_WIN_S_Avg_2mi"].DataType = typeof(string);

                //添加数据字段 
                dtDs_Hour1.Columns.Add("MAX_WIN_D_Avg_2mi_3h");
                dtDs_Hour1.Columns.Add("MAX_WIN_S_Avg_2mi_3h");

                dtDs_Hour1.Columns.Add("MAX_WIN_D_Avg_2mi_6h");
                dtDs_Hour1.Columns.Add("MAX_WIN_S_Avg_2mi_6h");


                dtDs_Hour1.Columns.Add("MAX_WIN_D_Avg_2mi_24h");
                dtDs_Hour1.Columns.Add("MAX_WIN_S_Avg_2mi_24h");
                for (int i = 0; i < dtDs_Hour1.Rows.Count; i++)
                {
                    dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi"] = GetWindDirectionString(dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi"].ToString());
                    dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi"] = GetWindLevelString(dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi"].ToString());
                }

                for (int i = 0; i < dtDs_Hour1.Rows.Count; i++)
                {
                    DataRow[] dr3 = dtDs_Hour3.Select("Station_Id_C=" + dtDs_Hour3.Rows[i]["Station_Id_C"]);
                    if (dr3.Length > 0)
                    {
                        dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi_3h"] = GetWindDirectionString(dr3[0]["MAX_WIN_D_Avg_2mi"].ToString());
                        dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi_3h"] = GetWindLevelString(dr3[0]["MAX_WIN_S_Avg_2mi"].ToString());
                    }
                    else
                    {
                        dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi_3h"] = "";
                        dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi_3h"] = "";
                    }

                    DataRow[] dr6 = dtDs_Hour6.Select("Station_Id_C=" + dtDs_Hour3.Rows[i]["Station_Id_C"]);
                    if (dr3.Length > 0)
                    {
                        dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi_6h"] = GetWindDirectionString(dr6[0]["MAX_WIN_D_Avg_2mi"].ToString());
                        dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi_6h"] = GetWindLevelString(dr6[0]["MAX_WIN_S_Avg_2mi"].ToString());
                    }
                    else
                    {
                        dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi_6h"] = "";
                        dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi_6h"] = "";
                    }


                    DataRow[] dr24 = dtDs_Hour24.Select("Station_Id_C=" + dtDs_Hour3.Rows[i]["Station_Id_C"]);
                    if (dr3.Length > 0)
                    {
                        dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi_24h"] = GetWindDirectionString(dr24[0]["MAX_WIN_D_Avg_2mi"].ToString());
                        dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi_24h"] = GetWindLevelString(dr24[0]["MAX_WIN_S_Avg_2mi"].ToString());
                    }
                    else
                    {
                        dtDs_Hour1.Rows[i]["MAX_WIN_D_Avg_2mi_24h"] = "";
                        dtDs_Hour1.Rows[i]["MAX_WIN_S_Avg_2mi_24h"] = "";
                    }
                }

                hash["data"] = dtDs_Hour1;
                hash["success"] = true;

                if (isCreate == 1)
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_" + fileName + ".txt");
                    IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }

            return Content(JsonConvert.SerializeObject(hash));
        }

        //根据区域查询今天 瞬时、最高、最低气温
        [NoCheckLogin]
        public ActionResult GetStationDataHourTem(string adminCodes = "310113", string staLevels="")
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            string fileName = "Tem_" + (adminCodes + "_" + staLevels).Replace(",", "-");

            try
            {
                string content = "";
                if (isCreate == 0)
                {
                    content = CacheReadFile.ReadFile(fileName);
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }

                HttpHelper http = GetHttpHelper();
                string timeRange = "";
                //今天最高最低气温
                string param = "&interfaceId=statSurfEleInRegion&dataCode=SURF_CHN_MUL_HOR&elements=Station_Name,Station_Id_C&statEles=MAX_TEM_Max,MIN_TEM_Min"
                    + "&adminCodes=" + adminCodes
                    + "&orderBy=Station_Id_C&dataFormat=json";
                if (staLevels != "")
                {
                    param = param + "&staLevels=" + staLevels;
                }
                if (DateTime.Now.Hour >= 20)
                {
                    timeRange = "&timeRange=(" + DateTime.Now.ToString("yyyyMMdd200000") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                }
                else
                {
                    timeRange = "&timeRange=(" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd200000") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]";
                }

                string result = http.Post(cimissUrl, param + timeRange);
                DataTable dtDs_TemCount = GetDataByHttpString(result);

                //获取最新时次气温 查询最近一段时间的数据，在通过站号查询此站号最新的数据赋值
                param = "&interfaceId=getSurfEleInRegionByTimeRange&dataCode=SURF_CHN_MAIN_MIN&elements=Station_Name,Datetime,Station_Id_C,TEM"
                    + "&timeRange=(" + DateTime.Now.AddHours(-8).AddMinutes(-20).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.AddHours(-8).ToString("yyyyMMddHHmmss") + "]"
                    + "&adminCodes=" + adminCodes
                    + "&orderBy=Datetime:desc&dataFormat=json";
                if (staLevels != "")
                {
                    param = param + "&staLevels=" + staLevels;
                }
                result = http.Post(cimissUrl, param);
                DataTable dtDs_TemNow = GetDataByHttpString(result);

                dtDs_TemCount.Columns.Add("TEM");
                string where="";
                for (int i = 0; i < dtDs_TemCount.Rows.Count; i++)
                {
                    where="";
                    where=string.Format("Station_Id_C='{0}'", dtDs_TemCount.Rows[i]["Station_Id_C"]);
                    DataRow[] drs12 = dtDs_TemNow.Select(where, " Datetime desc");

                    if (drs12.Length > 0)
                    {
                        dtDs_TemCount.Rows[i]["TEM"] = drs12[0]["TEM"];
                    }
                    else
                    {
                        dtDs_TemCount.Rows[i]["TEM"] = "";
                    }
                }

                hash["data"] = dtDs_TemCount;
                hash["success"] = true;

                if (isCreate == 1)
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_" + fileName + ".txt");
                    IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }



        #region 业务处理

        private string GetWindLevelString(string Level)
        {
            if (Level == "")
            {
                Level = "0";
            }
            double wind = Convert.ToDouble(Level);
            if (wind == 0.0) { return "无风"; }
            if (wind == 0) { return "无风"; }
            if (0.0 < wind && wind <= 0.2) { return "0级"; }
            if (0.3 <= wind && wind <= 1.5) { return "1级"; }
            if (1.6 <= wind && wind <= 3.3) { return "2级"; }
            if (3.4 <= wind && wind <= 5.4) { return "3级"; }
            if (5.5 <= wind && wind <= 7.9) { return "4级"; }
            if (8.0 <= wind && wind <= 10.7) { return "5级"; }
            if (10.8 <= wind && wind <= 13.8) { return "6级"; }
            if (13.9 <= wind && wind <= 17.1) { return "7级"; }
            if (17.2 <= wind && wind <= 20.7) { return "8级"; }
            if (20.8 <= wind && wind <= 24.4) { return "9级"; }
            if (24.5 <= wind && wind <= 28.4) { return "10级"; }
            if (28.5 <= wind && wind <= 32.6) { return "11级"; }
            if (32.7 <= wind && wind <= 36.9) { return "12级"; }
            if (37.0 <= wind && wind <= 41.4) { return "13级"; }
            if (41.5 <= wind && wind <= 46.1) { return "14级"; }
            if (46.2 <= wind && wind <= 50.9) { return "15级"; }
            if (51.0 <= wind && wind <= 56.0) { return "16级"; }
            if (56.1 <= wind && wind <= 61.2) { return "17级"; }
            return "暂无数据";
        }

        private string GetWindLevelStringTwo(string Level)
        {
            if (Level == "")
            {
                Level = "0";
            }
            double wind = Convert.ToDouble(Level);
            if (wind == 0.0) { return "0"; }
            if (wind == 0) { return "0"; }
            if (0.0 < wind && wind <= 0.2) { return "0"; }
            if (0.3 <= wind && wind <= 1.5) { return "1"; }
            if (1.6 <= wind && wind <= 3.3) { return "2"; }
            if (3.4 <= wind && wind <= 5.4) { return "3"; }
            if (5.5 <= wind && wind <= 7.9) { return "4"; }
            if (8.0 <= wind && wind <= 10.7) { return "5"; }
            if (10.8 <= wind && wind <= 13.8) { return "6"; }
            if (13.9 <= wind && wind <= 17.1) { return "7"; }
            if (17.2 <= wind && wind <= 20.7) { return "8"; }
            if (20.8 <= wind && wind <= 24.4) { return "9"; }
            if (24.5 <= wind && wind <= 28.4) { return "10"; }
            if (28.5 <= wind && wind <= 32.6) { return "11"; }
            if (32.7 <= wind && wind <= 36.9) { return "12"; }
            if (37.0 <= wind && wind <= 41.4) { return "13"; }
            if (41.5 <= wind && wind <= 46.1) { return "14"; }
            if (46.2 <= wind && wind <= 50.9) { return "15"; }
            if (51.0 <= wind && wind <= 56.0) { return "16"; }
            if (56.1 <= wind && wind <= 61.2) { return "17"; }
            return "0";
        }

        private string GetWindDirectionString(string direction)
        {
            direction = direction.Replace(".00", "").Replace(".0", "");
            if (direction == "")
            {
                direction = "0";
            }
            int[] d = new int[] { 0, 0x2d, 90, 0x87, 180, 0xe1, 270, 0x13b, 360 };
            string[] s = new string[] { "北风", "东北风", "东风", "东南风", "南风", "西南风", "西风", "西北风", "北风" };
            for (int i = 0; i < 9; i++)
            {
                if (Math.Abs((int)(DataConverter.ToInt(direction) - d[i])) <= 22.5)
                {
                    return s[i];
                }
            }
            return "无风";
        }
        #endregion
    }
}
