using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using WebClientService.Common;
using System;

namespace WebClientService.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Admin/Users
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(page, pageSize);
           
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            GetListPQ();
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
                user.CreateDate = DateTime.Now;

                long id = dao.AddUser(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thất bại");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = new UserDAO().ViewDetailAll(id);
            return View(result);
        }
        [HttpPost]
        // GET: Admin/Users/Edit
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!String.IsNullOrEmpty(user.Password))
                {
                    var encrypted = Encryptor.MD5Hash(user.Password);
                    user.Password = encrypted;
                }
                user.CreateDate = DateTime.Now;

                var result = dao.UpdateUser(user);
                if (result)
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thất bại");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public void GetListPQ(int idpqchoose = -1)
        {
            var dao = new PhanQuyenDAO();
            ViewBag.IDPhanQuyen = new SelectList(dao.GetListAll(),"ID","TenPQ", idpqchoose);
        }
    }
}
