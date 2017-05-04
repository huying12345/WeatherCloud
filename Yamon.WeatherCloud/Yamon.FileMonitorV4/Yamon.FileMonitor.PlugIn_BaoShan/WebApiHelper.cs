using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.Framework.Common;

namespace Yamon.FileMonitor.PlugIn_BaoShan
{
    public class WebApiHelper
    {
        private static string baseUrl = ConfigHelper.GetConfigString("WebApiUrl").TrimEnd('/');
        private static string secretKey = "21232f297a57a5a743894a0e4a801fc3";
        private static string apiKey = "1001";
        public static string token = "";
        private static HttpHelper _httpHelper;

        static WebApiHelper()
        {
            _httpHelper = new HttpHelper();
        }

        public static string Get(string actionUrl, Dictionary<string, object> paramDictionary)
        {
            if (paramDictionary == null)
            {
                paramDictionary = new Dictionary<string, object>();
            }
            ParamOptions param = new ParamOptions();
            param.Timestamp = SignHelper.GetUnixTime();
            param.Apikey = apiKey;
            param.Properties = paramDictionary;
            if (!string.IsNullOrEmpty(token))
            {
                param.Properties.Add("Token", token);
            }
            string url = baseUrl + actionUrl;
            param.Sign = SignHelper.CreateSign("GET", param, url, secretKey);
            var postStr = SignHelper.CreateParamString(param, "&");
            string postParam = "sign=" + param.Sign + postStr;
            return _httpHelper.Get(url + postParam);
        }

        public static string Post(string actionUrl, Dictionary<string, object> paramDictionary, string postString)
        {
            if (paramDictionary == null)
            {
                paramDictionary = new Dictionary<string, object>();
            }
            ParamOptions param = new ParamOptions();
            param.Timestamp = SignHelper.GetUnixTime();
            param.Apikey = apiKey;
            param.Properties = paramDictionary;
            if (!string.IsNullOrEmpty(token))
            {
                param.Properties.Add("Token", token);
            }
            string url = baseUrl + actionUrl;
            param.Sign = SignHelper.CreateSign("POST", param, url, secretKey);
            var postStr = SignHelper.CreateParamString(param, "&");
            string postParam = "sign=" + param.Sign + postStr + postString;
            return _httpHelper.Post(url, postParam);
        }
    }
}
