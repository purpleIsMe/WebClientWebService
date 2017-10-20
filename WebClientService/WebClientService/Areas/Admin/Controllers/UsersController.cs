using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using WebClientService.Common;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebClientService.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // GET: Admin/Users/Create
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encrypted = Encryptor.MD5Hash(user.Password);
                user.Password = encrypted;
                long id = dao.AddUser(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thất bại");
                }
            }
            return View("Index");
        }

    }
}
