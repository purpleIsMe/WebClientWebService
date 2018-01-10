using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class EmailController : Controller
    {
        // GET: Admin/Email
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            listuser();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FeedBack feed)
        {
            //if (ModelState.IsValid)
            //{
            //    Guid idclass = dao.AddQClass(sub);
            //    if (idclass != Guid.Empty)
            //    {
            //        return RedirectToAction("Index", "Module");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Thêm module thất bại");
            //    }
            //}
            return View("Create");
        }
        public void listuser(int id = -1)
        {
            ViewBag.ListUser = new SelectList(new UserDAO().ViewAll(), "ID", "Name", id);
        }
    }
}