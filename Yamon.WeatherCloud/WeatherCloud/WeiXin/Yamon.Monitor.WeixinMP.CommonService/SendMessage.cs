using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;
using Yamon.Framework.Common;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common.Mail;
using Yamon.Framework.Common.Mail.Plugin;
using Yamon.Framework.DBUtility;
using Yamon.Framework.Log4Net;
using Yamon.Module.OnePublish;
using Yamon.Module.OnePublish.DAL;

namespace Yamon.Monitor.WeixinMP.CommonService
{
    public class SendMessage
    {
        public static readonly string CorpId = ConfigHelper.GetConfigString("QY_CorpId");//与微信企业账号后台的CorpId设置保持一致，区分大小写。
        public static readonly string CorpSecrets = ConfigHelper.GetConfigString("QY_CorpSecrets");

        /// <summary>
        /// 微信发送方法
        /// </summary>
        public static void SendWeiXinMsg()
        {
            SendListDAL sendDal = new SendListDAL();
            var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
            object obj = new object();
            using (NullableDataReader sms = sendDal.Db.ExecuteReaderSql("select * from OnePublish_SendList where SendStatus <2 and SendNumber<5 AND Channel='WEIXIN'AND (IsTiming=0 OR (IsTiming=1 AND TimingSendTime<'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')) order by CreateTime"))
            {
                while (sms.Read())
                {
                    lock (obj)
                    {
                        try
                        {
                            string content = sms["InfoContent"].ToString();
                            string wx = "";
                            try
                            {
                                MassResult result = MassApi.SendText(accessToken,
                                    sms["ServiceUserInfo"].ToString(), "", "", "4",
                                     content);
                            }
                            catch (Exception ex1)
                            {
                                wx = ex1.Message;
                            }
                            InsertLog("发送成功！" + wx, DataConverter.ToInt(sms["ID"].ToString()), 2);

                        }
                        catch (Exception ex)
                        {
                            InsertLog("微信发送失败！" + ex.Message, DataConverter.ToInt(sms["ID"].ToString()), 3);

                        }
                    }
                }
            }
        }

        public static int InsertLog(string msg, int id, int sendStatus)
        {
            try
            {
                SendListDAL sendDal = new SendListDAL();
                return sendDal.Db.ExecuteNonQuerySql("update OnePublish_SendList set SendStatus=" + sendStatus + ",SendTime=getdate(),SendNumber=SendNumber+1,Message=Message+convert(nvarchar(50),GETDATE(),121)+' " + msg.ToString().Replace("'", "’") + "<br/>' where ID=" + id);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
