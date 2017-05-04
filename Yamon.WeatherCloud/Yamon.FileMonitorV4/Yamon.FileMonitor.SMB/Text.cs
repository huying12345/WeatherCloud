using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.DBUtility;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using Yamon.Module.Weather.DAL;
using Yamon.Module.Weather.Entity;

namespace Yamon.FileMonitor.SMB
{
    public class Text : IFileExec
    {
        #region IFileExec 成员
        DateTime datatime = DateTime.Now;
        WeatherNodesDAL wNodesDAL = new WeatherNodesDAL();

        public string ExecFile(FileInfo file,out int nodeId)
        {

            string namePrefix = "";
            string savefilename = "";

            nodeId = 0;
            if (file.Exists)
            {
                foreach (string regString in GetFileNameRegxp())
                {
                    Regex regFileName = new Regex(regString.ToLower());
                    if (regFileName.Match(file.Name.ToLower()).Success)
                    {
                        StreamReader reader = new StreamReader(file.FullName, Encoding.GetEncoding("GB2312"));
                        string str = reader.ReadToEnd().Replace("\r\n", "\r");
                        reader.Close();
                        string fileName = file.Name.ToLower();

                        WeatherNodes wNodes = wNodesDAL.GetEntityModel("NameRule=?", new object[] { regString });

                        if (wNodes != null)
                        {
                            nodeId = DataConverter.ToInt(wNodes.NodeID);
                            namePrefix = wNodes.NamePrefix;

                            string[] fileNames = file.Name.Split(new char[] { '.' });
                            string ext = fileNames[fileNames.Length - 1];
                            if (namePrefix == "")
                            {
                                datatime = file.LastWriteTime;
                                savefilename = string.Format("{0}_{1}.{2}", file.Name.Substring(0, file.Name.Length - 4), datatime.ToString("yyyyMMddHHmm"), ext);
                            }
                            else
                            {
                                datatime = Common.GetDataTime(wNodes, file.Name.Replace(namePrefix, ""), file.LastWriteTime);
                                savefilename = string.Format("{0}_{1}.{2}", namePrefix, datatime.ToString("yyyyMMddHHmm"), ext);
                            }
                            //是否重命名
                            if (wNodes.IsRename == 0)
                            {
                                savefilename = file.Name;
                            }
                            string year = datatime.ToString("yyyy-MM-dd");
                            string path = "TxtBackFile/" + year.Replace("-", "/") + "/" + savefilename;
                            int isMonitor = 0;
                            
                            if (wNodes.IsTiming == 1 && wNodes.IsMonitor == 1)
                            {
                                isMonitor = 1;
                            }

                            int result = SaveText(str, wNodes.NodeName, nodeId.ToString(), fileName, path, datatime, isMonitor, DataConverter.ToInt(wNodes.Deley));
                            if (result > 0)
                            {
                                //执行Http任务
                                Common.RunHttpTask(wNodes.RunHttpTask.Replace("${NodeID}", nodeId.ToString()).Replace("${ID}", result.ToString()));
                                return savefilename;
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                }
            }
            return "";
        }

        public int SaveText(string dataStr, string type, string nodeId, string fileName, string path, DateTime dataTime, int isMonitor, int deley)
        {

            try
            {
                dataStr = dataStr.Replace("'", "''");

                WeatherTextDAL wTextDal = new WeatherTextDAL();
                WeatherText wText = wTextDal.GetEntityModel("DataTime=? AND InfoTypeID=?", new object[] { datatime.ToString("yyyy-MM-dd HH:mm:ss"), nodeId });
                int infoId = 0;

                if (wText == null)
                {
                    wText = new WeatherText();
                    wText.InfoTitle=type;
                    wText.InfoTypeID=DataConverter.ToInt(nodeId);
                    wText.InfoDetail=dataStr;
                    wText.DataTime=dataTime;
                    wTextDal.InsertByModel(wText);
                    infoId = wTextDal.GetMaxID();
                }
                else
                {
                    isMonitor = 0;
                    infoId = DataConverter.ToInt(wText.ID);
                    WeatherText wTextUpdate = new WeatherText();
                    wTextUpdate.UpdateTime = DateTime.Now;
                    wTextUpdate.InfoDetail = dataStr;
                    wTextUpdate.ID = infoId;
                    wTextDal.UpdateByModel(wTextUpdate);
                }
                string description = string.Format("{0} 抓取文件{1}成功", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), fileName);
                Log.AddLog(nodeId, path, description, 1, dataTime, isMonitor, deley);
                return infoId;
            }
            catch (Exception ex)
            {
                string description = string.Format("{0} 抓取文件{1}失败:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), fileName, ex.StackTrace);
                Log.AddLog(nodeId, fileName, description, 0, dataTime, 0, deley);
                return 0;
                //throw;
            }
        }

        public string GetBackupPath()
        {
            //return ConfigHelper.GetConfigString("TxtHistoryPath");
            string path = ConfigHelper.GetConfigString("TxtHistoryPath");
            string year = datatime.ToString("yyyy-MM-dd");
            path = path + "\\" + year.Replace("-", "\\");
            return path;
        }

        public string[] GetFileNameRegxp()
        {
            List<WeatherNodes> wNodesList = wNodesDAL.GetEntityList(" IsNull(RTRIM(NameRule), '') != '' AND NodeType=8 ");
            string[] strl = new string[wNodesList.Count];
            for (int i = 0; i < wNodesList.Count; i++)
            {
                strl[i] = wNodesList[i].NameRule;
            }
            return strl;
        }

        public string GetBackFileName(string fileName)
        {
            return "";
        }

        #endregion
    }
}
