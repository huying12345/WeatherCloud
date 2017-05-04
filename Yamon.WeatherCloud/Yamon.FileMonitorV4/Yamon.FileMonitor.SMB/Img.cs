using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.FileMonitor.Component;
using System.IO;
using Yamon.Framework.Common;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using Yamon.Module.Weather.Entity;
using Yamon.Module.Weather.DAL;

namespace Yamon.FileMonitor.SMB
{
    public class Img : IFileExec
    {
        #region IFileExec 成员
        DateTime _datatime = DateTime.Now;
        WeatherNodesDAL wNodesDAL = new WeatherNodesDAL();
        WeatherImgDAL wImgDAL = new WeatherImgDAL();

        public string ExecFile(FileInfo file, out int nodeId)
        {
            string savefilename = "";
            int isMonitor = 0;
            nodeId = 0;

            if (file.Exists)
            {
                try
                {
                    foreach (string regString in GetFileNameRegxps())
                    {
                        Regex regFileName = new Regex(regString.ToLower());
                        if (regFileName.Match(file.Name.ToLower()).Success)
                        {

                            WeatherNodes wNodes = wNodesDAL.GetEntityModel("NameRule=?", new object[] { regString });

                            nodeId = DataConverter.ToInt(wNodes.NodeID);

                            var namePrefix = wNodes.NamePrefix;

                            string[] fileNames = file.Name.Split(new char[] { '.' });
                            string ext = fileNames[fileNames.Length - 1];
                            if (namePrefix == "")
                            {
                                _datatime = file.LastWriteTime;
                                savefilename = string.Format("{0}_{1}.{2}", file.Name.Substring(0, file.Name.Length - 4), _datatime.ToString("yyyyMMddHHmm"), ext);
                            }
                            else
                            {
                                _datatime = Common.GetDataTime(wNodes, file.Name.Replace(namePrefix, ""), file.LastWriteTime);
                                savefilename = string.Format("{0}_{1}.{2}", namePrefix, _datatime.ToString("yyyyMMddHHmm"), ext);
                            }
                            //是否重命名
                            if (wNodes.IsRename == 0)
                            {
                                savefilename = file.Name;
                            }

                            string path = ConfigHelper.GetConfigString("ImgDataSqlPath");
                            string year = _datatime.ToString("yyyy-MM-dd");
                            path = path + "/" + year.Replace("-", "/") + "/" + savefilename;

                            WeatherImg wImg = wImgDAL.GetEntityModel("DataTime=? AND InfoTypeID=?", new object[] { _datatime.ToString("yyyy-MM-dd HH:mm:ss"), nodeId });

                            int infoId = 0;
                            if (wImg == null)
                            {

                                wImg = new WeatherImg();
                                wImg.InfoTypeID = nodeId;
                                wImg.InfoTitle = wNodes.NodeName;
                                wImg.InfoPath = path;
                                wImg.DataTime = _datatime;
                                wImgDAL.InsertByModel(wImg);

                                infoId = wImgDAL.GetMaxID();
                                if (DataConverter.ToInt(wNodes.IsTiming) == 1 && DataConverter.ToInt(wNodes.IsMonitor) == 1)
                                {
                                    isMonitor = 1;
                                }
                            }

                            //执行Http任务
                            Common.RunHttpTask( wNodes.RunHttpTask.Replace("${NodeID}", nodeId.ToString()).Replace("${ID}", infoId.ToString()));
                            //压缩图片
                            if (("," + ConfigHelper.GetConfigString("RunCompressImageID") + ",").Contains("," + nodeId + ","))
                            {
                                CompressImages(file);
                            }
                            string description = string.Format("{0} 抓取文件{1}成功", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), file.Name);
                            Log.AddLog(nodeId.ToString(), path, description, 1, _datatime, isMonitor, DataConverter.ToInt(wNodes.Deley));
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string description = string.Format("{0} 抓取文件{1}失败:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), file.Name, ex.Message);
                    Log.AddLog(nodeId.ToString(), file.Name, description, 0);
                    return "";
                }

                //GetDateLogWDR(dt, file.Name);
            }

            return savefilename;
        }

        public void CompressImages(FileInfo file)
        {
            if (!Common.ValidatePath(GetBackupPath()))
            {
                throw new Exception("备份文件夹不存在!");
            }
            string newFileName = Path.Combine(GetBackupPath(), file.Name.Replace(".gif", ".jpg"));
            if (file.Extension.ToString() == ".jpg")
            {
                SetCompressImage(newFileName.Replace(".jpg","_s.jpg" ), file.FullName, 30);
            }
            else
            {
                Image original = Image.FromFile(file.FullName);
                Size _newSize = new Size(original.Width, original.Height);
                Image displayImage = new Bitmap(original, _newSize);
                try
                {
                    
                    displayImage.Save(newFileName, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    original.Dispose();
                }
            }
        }


        public void SetCompressImage(string newfileName, string oldfileName, long quality)
        {
            try
            {
                if (quality == 0)
                {
                    quality = 80;
                }
                using (Bitmap bitmp = new Bitmap(oldfileName))
                {
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                    ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                    bitmp.Save(newfileName, myImageCodecInfo, ep);
                    bitmp.Dispose();
                }
            }
            catch { }
        }

        //获取MimeType
        private System.Drawing.Imaging.ImageCodecInfo
            GetEncoderInfo(string mineType)
        {

            System.Drawing.Imaging.ImageCodecInfo[] myEncoders =
                System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();

            foreach (System.Drawing.Imaging.ImageCodecInfo myEncoder in myEncoders)
                if (myEncoder.MimeType == mineType)
                    return myEncoder;
            return null;
        }

        public string GetBackupPath()
        {
            string path = ConfigHelper.GetConfigString("ImgHistoryPath");
            string year = _datatime.ToString("yyyy-MM-dd");
            path = path + "\\" + year.Replace("-", "\\");
            return path;
        }

        public string[] GetFileNameRegxp()
        {
            List<WeatherNodes> wNodesList = wNodesDAL.GetEntityList(" IsNull(RTRIM(NameRule), '') != '' AND NodeType=1  ");
            string[] strl = new string[wNodesList.Count];
            for (int i = 0; i < wNodesList.Count; i++)
            {
                strl[i] = wNodesList[i].NameRule;
            }
            return strl;

        }

        public string[] GetFileNameRegxps()
        {

            List<WeatherNodes> wNodesList = wNodesDAL.GetEntityList(" IsNull(RTRIM(NameRule), '') != ''  and IsImportToDB=1 AND NodeType=1 ");
            string[] strl = new string[wNodesList.Count];
            for (int i = 0; i < wNodesList.Count; i++)
            {
                strl[i] = wNodesList[i].NameRule;
            }
            return strl;
        }

        public string GetBackFileName(string fileName)
        {
            return fileName;
        }

        #endregion
    }
}
