﻿using InsBook.Areas.Client.Models;
using InsBook.Areas.Client.code;
using InsBook.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Model.EF;

namespace InsBook.Areas.Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Client/Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null && Request.Cookies[CommonConstants.USER_COOKIE] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid) // kiểm tra lại hàm
            {

                var dao = new UserDao();

                var result = dao.Login(model.EmailLogin, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    //Tìm email trong db
                    var user = dao.GetbyEmail(model.EmailLogin);

                    //Tạo các thông tin để lưu session, cokie
                    var userSC = new UserLogin();
                    userSC.Email = user.email;
                    userSC.UserID = user.id;

                    //thêm session
                    Session.Add(CommonConstants.USER_SESSION, userSC);
                    Session.Timeout = 1800;

                    //CommonConstants.USER_ONLINE.Add(user.id);
                    //thêm cookie khi bấm nút ghi nhớ đăng nhập
                    if (model.RememberMe)
                    {
                        Response.Cookies[CommonConstants.USER_COOKIE]["1"] = user.id.ToString();
                        Response.Cookies[CommonConstants.USER_COOKIE]["2"] = user.email;
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                //var user = (UserLogin)Session[CommonConstants.USER_SESSION];
                //CommonConstants.USER_ONLINE.Remove(user.UserID);

                Session.Remove(CommonConstants.USER_SESSION);

                Response.Cookies[CommonConstants.USER_COOKIE].Expires = DateTime.Now.AddDays(-1);
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}