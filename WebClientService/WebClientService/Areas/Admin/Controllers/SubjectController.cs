using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClientService.Common;

namespace WebClientService.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Admin/Subject
        public ActionResult Index()
        {
            var subDAO = new SubjectDAO();
            ViewBag.LisSub = new List<Subject>(subDAO.GetListAll());
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // GET: Admin/Users/Create
        public ActionResult Create(Subject sub)
        {
            if (ModelState.IsValid)
            {
                var dao = new SubjectDAO();
                sub.CreateDate = DateTime.Now;
                sub.SkipSwap = false;
                sub.clogic = false;
                sub.AnswerOption = false;
                sub.NoOfAnswers = 4;
                sub.roundToZero = false;
                sub.skipMinus = false;
                Guid id = dao.AddSubject(sub);
                if (id != null)
                {
                    return RedirectToAction("Index", "Subject");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm môn thi thất bại");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(Guid SubID)
        {
            var sub = new SubjectDAO().ShowAllSubID(SubID);
            return View(sub);
        }
        [HttpPost]
        // GET: Admin/Users/Edit
        public ActionResult Edit(Subject sub)
        {
            if (ModelState.IsValid)
            {
                var dao = new SubjectDAO();
                sub.CreateDate = DateTime.Now;
                sub.SkipSwap = false;
                sub.clogic = false;
                sub.AnswerOption = false;
                sub.NoOfAnswers = 4;
                sub.roundToZero = false;
                sub.skipMinus = false;
                if (dao.UpdateSubject(sub))
                {
                    return RedirectToAction("Index", "Subject");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa môn thi thất bại");
                }
            }
            return View("Index");
        }
    }
}