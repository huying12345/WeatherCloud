﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.Log4Net;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage;
using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;
using Yamon.Module.UCenter;
using Yamon.Module.UCenter.DAL;

namespace Yamon.WeatherCloud.WebSite.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {
        }

        public ActionResult Test()
        {

            return Content("");
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blank()
        {
            return View();
        }

        [NoCheckLogin]
        public ActionResult Login()
        {
            ViewBag.Title = "登录";
            return View();
        }

        //首页
        public ActionResult HomePage()
        {
            int userId = DataConverter.ToInt(CookieHelper.GetCookie("UserID"));
            string cityId = CookieHelper.GetCookie("CityID");
            return View();
        }


        public ActionResult LeftMenu(string parentId)
        {
            GetMenu();
            return View();
        }

        private void GetMenu()
        {
            MenuDAL menuDal = new MenuDAL();
            RolePurviewDAL rolePurviewDal = new RolePurviewDAL();
            string roleId = CookieHelper.GetCookie("RoleIDList");
            ArrayList purviewList = rolePurviewDal.GetPurviewListByRoleID(roleId);
            ViewBag.LeftMenuList = menuDal.GetMyTreeMenuList(roleId, purviewList);
        }

        /// <summary>
        /// 换肤功能
        /// </summary>
        /// <param name="skinName"></param>
        /// <returns></returns>
        [CheckPurview(0)]
        public ActionResult ChangeSkinAction(string skinName)
        {
            CookieHelper.WriteCookie("SkinName", skinName);
            return new EmptyResult();
        }

         [NoCheckLogin]
        public ActionResult WeiXinMenu()
        {
            return View();
        }
    }
}
