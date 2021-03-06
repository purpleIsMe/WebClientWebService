﻿using Model.EF;
using Model.DAO;
using System.Web.Mvc;
using WebClientService.Common;
using WebClientService.Models;

namespace WebClientService.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            THISINH us = new THISINH();
            var dao = new ThiSinhDAO();
            ThiSinhLogin THISINH = (ThiSinhLogin)Session[Constants.THISINH_SESSION];
            us.ID = THISINH.ThiSinhID;

            if (!dao.UpdateActive(us))
                ModelState.AddModelError("", "Không thể update dữ liệu");
            Session[Constants.THISINH_SESSION] = null;
            return View("Index");
        }
        public ActionResult Login(LoginTSModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThiSinhDAO();

                int result = dao.LogIn(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var THISINH = dao.getIDByUserName(model.UserName);

                    var TSSession = new ThiSinhLogin();
                    TSSession.ThiSinhName = THISINH.MaDuThi;
                    TSSession.ThiSinhID = THISINH.ID;
                    Session.Add(Constants.THISINH_SESSION, TSSession);

                    //save answer
                    Answer an = new Answer();
                    an.IDThiSinh = THISINH.ID;
                    an.DiemSo = 0;
                    an.DiemThuc = 0;
                    var kq = new AnswerDAO().AddAnswer(an);
                    if (kq < 1)
                        ModelState.AddModelError("", "Tài khoản không thể tạo answer");
                    else
                        return RedirectToAction("Index", "TestExam");
                }
                if (result == 4)
                {
                    ModelState.AddModelError("", "Tài khoản đã hoàn thành bài thi");
                }
                if (result == 3)
                {
                    ModelState.AddModelError("", "Tài khoản này không tồn tại");
                }
                if (result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng. Xin vui lòng kiểm tra lại!");
                }
                if (result == 5)
                {
                    ModelState.AddModelError("", "Tài khoản này đã bị khóa. Xin vui lòng kiểm tra lại!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }

    }
}