using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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
                int id = dao.AddSubject(sub);
                if (id != 0)
                {
                    return RedirectToAction("Index", "Subject");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm môn thi thất bại");
                }
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(int SubID)
        {
            var sub = new SubjectDAO().ShowAllSubID(SubID);
            //return View(sub);
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
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (new SubjectDAO().DeleteSubjectInt(id))
                {
                    return RedirectToAction("Index", "Subject");
                }
            }
            return View("Index");
        }
    }
}