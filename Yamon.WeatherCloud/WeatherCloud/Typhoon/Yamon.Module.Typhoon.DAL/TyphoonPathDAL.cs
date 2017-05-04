
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
using Yamon.Module.Typhoon.Entity;
using System;

namespace Yamon.Module.Typhoon.DAL
{
    /// <summary>
    /// 台风路径实体类
    ///</summary>
    public partial class TyphoonPathDAL : _TyphoonPathDAL
    {
        /// <summary>
        /// 查询台风路径信息
        /// </summary>
        /// <param name="typhoonID">台风编号</param>
        /// <param name="rCenter">发报中心(参数可选)</param>
        /// <returns></returns>
        public DataTable GetTyphoonPathDetailByID(int typhoonID,string rCenter)
        {
            string where = "";
            object[] obj;
            if (rCenter == null || rCenter.Length == 0)
            {
                where = "TyphoonID =? ";
                obj=new object[] { typhoonID };
            }
            else
            {
                where = "TyphoonID = ? and ReportCenter = ? ";
                obj=new object[]{typhoonID,rCenter};
            }
            string fields ="TyphoonID,PathTime,Longitude,Latitude,Hours,CenterAirPressure,MaxWindSpeed,MoveHeading,MoveSpeeding,CenterSevenRadius,CenterTenRadius,ReportCenter";
            DataTable dt = GetEntityTable(where, obj, "", 0, fields);
            return FormatDataTableTime(dt);
        }

        private DataTable FormatDataTableTime(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("PathDateTime",typeof(string)));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["PathDateTime"] = (DataConverter.ToDate(dt.Rows[i]["PathTime"].ToString())).ToString("yyyy-MM-dd HH:mm:ss");
            }
            dt.Columns.Remove("PathTime");
            dt.Columns["PathDateTime"].SetOrdinal(1);
            return dt;
        }


        public static string DatatableToCSV(System.Data.DataTable dt, bool showHeader)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (showHeader)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(dt.Columns[i].ColumnName);
                        if (i != dt.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                        else
                        {
                            sb.AppendLine();
                        }
                    }
                }

                foreach (DataRow dr in dt.Rows)
                {

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(dr[i].ToString().Trim().Replace(",", " "));

                        if (i != dt.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                        else
                        {
                            sb.AppendLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return sb.ToString();
        }

    }
}
