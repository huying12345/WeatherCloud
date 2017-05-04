
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
    /// 台风信息实体类
    ///</summary>
    public partial class TyphoonInfoDAL : _TyphoonInfoDAL
    {
        /// <summary>
        /// 根据年份查询,
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetTyphoonInfoListByTYear(int year)
        {
            year = year == 0 ? DateTime.Now.Year : year;
            string fields = "TyphoonID,EnName,CnName,DataInfo,ReportCenter,TYear,LastReportTime";
            string where = "TYear = ? ";
            return GetEntityTable(where, new object[] { year }, "LastReportTime desc", 0, fields);
        }

        /// <summary>
        /// 查询最近信息
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetNewTyphoonInfoList(int rows)
        {
            string fields = "TyphoonID,EnName,CnName,DataInfo,ReportCenter,TYear,LastReportTime";
            return GetEntityTable("1=1",new object[]{}, "LastReportTime desc", rows, fields);
        }
    }
}
