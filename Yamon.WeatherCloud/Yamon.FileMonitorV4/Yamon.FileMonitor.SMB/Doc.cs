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
using Yamon.Framework.Words;
using Yamon.Module.Weather.Entity;
using Yamon.Module.Weather.DAL;


namespace Yamon.FileMonitor.SMB
{
    public class Doc : IFileExec
    {
        #region IFileExec 成员
        DateTime datatime = DateTime.Now;
        WeatherNodesDAL wNodesDAL = new WeatherNodesDAL();
        WeatherDocDAL wDocDal = new WeatherDocDAL();

        public string ExecFile(FileInfo file, out int nodeId)
        {

            string namePrefix = "";
            string savefilename = "";
            int isTiming = 0;
            nodeId = 0;
            if (file.Exists)
            {
                try
                {
                    foreach (string regString in GetFileNameRegxp())
                    {
                        Regex regFileName = new Regex(regString.ToLower());
                        if (regFileName.Match(file.Name.ToLower()).Success)
                        {
                            string path = ConfigHelper.GetConfigString("DocDataSqlPath");

                            WeatherNodes wNodes = wNodesDAL.GetEntityModel("NameRule=?", new object[] { regString });
                            nodeId = DataConverter.ToInt(wNodes.NodeID);

                            isTiming = DataConverter.ToInt(wNodes.IsTiming);
                            namePrefix = wNodes.NamePrefix;
                            string fileName = file.Name.ToLower();
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
                            if (DataConverter.ToInt(wNodes.IsRename) == 0)
                            {
                                savefilename = file.Name;
                            }
                            string year = datatime.ToString("yyyy-MM-dd");
                            path = path + "/" + year.Replace("-", "/") + "/" + savefilename;
                            string htmlContent = "";
                            string textContent = "";

                            if (!fileNames[1].ToLower().Equals("pdf"))
                            {
                                htmlContent = WordHelper.GetWordHtml(file.FullName);
                                textContent = WordHelper.GetWordText(file.FullName);
                            }

                            WeatherDoc wDoc = wDocDal.GetEntityModel("DataTime=? AND InfoTypeID=?", new object[] { datatime.ToString("yyyy-MM-dd HH:mm:ss"), nodeId });

                            int infoId = 0;
                            int isMonitor = 0;
                            if (infoId == 0)
                            {
                                wDoc = new WeatherDoc();
                                wDoc.InfoTypeID = nodeId;
                                wDoc.InfoTitle = file.Name.Replace(file.Extension, "");
                                wDoc.InfoPath = path;
                                wDoc.DataTime = datatime;
                                wDoc.TextContent = textContent;
                                wDoc.HtmlContent = htmlContent;
                                wDocDal.InsertByModel(wDoc);
                                
                                infoId = wDocDal.GetMaxID();
                                if (DataConverter.ToInt(wNodes.IsTiming) == 1 && DataConverter.ToInt(wNodes.IsMonitor) == 1)
                                {
                                    isMonitor = 1;
                                }
                            }
                            else
                            {
                                infoId = DataConverter.ToInt(wDoc.ID);
                                WeatherDoc wDocUpdate = new WeatherDoc();
                                wDocUpdate.UpdateTime = DateTime.Now;
                                wDocUpdate.InfoPath = path;
                                wDocUpdate.TextContent = textContent;
                                wDocUpdate.HtmlContent = htmlContent;
                                wDocUpdate.ID = infoId;

                                wDocDal.UpdateByModel(wDocUpdate);
                            }
                            //执行Http任务
                            Common.RunHttpTask(wNodes.RunHttpTask.ToString().Replace("${NodeID}", nodeId.ToString()).Replace("${ID}", infoId.ToString()));
                            string description = string.Format("{0} 抓取文件{1}成功", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), file.Name);
                            Log.AddLog(nodeId.ToString(), path, description, 1, datatime, isMonitor, DataConverter.ToInt(wNodes.Deley));
                            break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    string description = string.Format("{0} 抓取文件{1}失败", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), file.Name);
                    Log.AddLog(nodeId.ToString(), file.Name, description, 0);
                    return "";
                }
            }
            return savefilename;
        }

        public string GetBackupPath()
        {
            string path = ConfigHelper.GetConfigString("DocHistoryPath");
            string year = datatime.ToString("yyyy-MM-dd");
            path = path + "\\" + year.Replace("-", "\\");
            return path;
        }

        public string[] GetFileNameRegxp()
        {

            List<WeatherNodes> wNodesList = wNodesDAL.GetEntityList(" IsNull(RTRIM(NameRule), '') != '' AND NodeType=2 ");
            string[] strl = new string[wNodesList.Count];
            for (int i = 0; i < wNodesList.Count; i++)
            {
                strl[i] = wNodesList[i].NameRule;
            }
            return strl;

        }
        #endregion


    }
}
