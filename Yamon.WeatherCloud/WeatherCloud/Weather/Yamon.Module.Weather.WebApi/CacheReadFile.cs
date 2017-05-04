using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;

namespace Yamon.Module.Weather.WebApi
{
    public static class CacheReadFile
    {
        public static string ReadFile(object id)
        {
            string cacheKey = "show_" + id.ToString();
            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            if (objType == null)
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + cacheKey + ".txt");
                CacheDependency cdy = new CacheDependency(filePath);

                objType = IOHelper.ReadFile(filePath);
                CacheHelper.Insert(cacheKey, objType, cdy);// 写入缓存
            }
            if (objType == null)
            {
                return "";
            }
            return objType.ToString();
        }
    }
}
