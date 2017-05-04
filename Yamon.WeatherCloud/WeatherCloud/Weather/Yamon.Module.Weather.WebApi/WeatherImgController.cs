
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using Yamon.Framework.DAL;
using Yamon.Module.Weather.Entity;
using Yamon.Module.Weather.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;
using System.Web.Caching;
using Yamon.Framework.Common.IO;



namespace Yamon.Module.Weather.WebApi
{
    /// <summary>
    /// 图片
    /// </summary>
    public partial class WeatherImgController : _WeatherImgController
    {

        //根据资源编号获取图片数据
        [NoCheckLogin]
        public ActionResult GetImageList(int id=0)
        {
            List<WeatherImg> dt = dal.GetImageList(id);
            hash["data"] = dt;
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }

        //根据资源编号获取所有类型数据
        [NoCheckLogin]
        public ActionResult GetDataList(int id = 0)
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            try
            {
                string content = "";
                if (isCreate == 0)
                {
                    content=CacheReadFile.ReadFile(id);
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }
                WeatherNodesDAL nodeDal = new WeatherNodesDAL();
                WeatherNodes node = nodeDal.GetModelByID(id);
                switch (node.NodeType)
                {
                    case 1://图片栏目
                        {
                            WeatherImgDAL weather = new WeatherImgDAL();
                            List<WeatherImg> dt = weather.GetImageList(id);
                            hash["data"] = dt;
                            hash["success"] = true;

                            break;
                        }
                    case 2://文档栏目
                        {
                            WeatherDocDAL weather = new WeatherDocDAL();
                            List<WeatherDoc> dt = weather.GetDocList(id);
                            hash["data"] = dt;
                            hash["success"] = true;
                            break;
                        }
                    case 8: //文本栏目
                        {
                            WeatherTextDAL weather = new WeatherTextDAL();
                            List<WeatherText> dt = weather.GetTextList(id);
                            hash["data"] = dt;
                            hash["success"] = true;
                            break;
                        }
                    default: break;
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            if (isCreate == 1)
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_" + id + ".txt");
                IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
            }
            return Content(JsonConvert.SerializeObject(hash));
        }
        
       
    }
}
