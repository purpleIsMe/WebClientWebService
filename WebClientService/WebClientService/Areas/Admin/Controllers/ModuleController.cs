using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class ModuleController : Controller
    {
        // GET: Admin/Module
        public ActionResult Index()
        {  
           listsubject(1);
            var qclassDAO = new QClassDAO();
            ViewBag.ListQC = new List<QClass>(qclassDAO.listWithIDSub(1));
            ViewBag.descr = new SubjectDAO().DescrSub(1);
            return View();
        }
        [HttpPost]
        public ActionResult Index(QClass q)
        {
            listsubject(q.idsu);
            var qclassDAO = new QClassDAO();
            ViewBag.ListQC = new List<QClass>(qclassDAO.listWithIDSub(q.idsu));
            ViewBag.descr = new SubjectDAO().DescrSub(q.idsu);
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            listsubject();
            return View();
        }
        [HttpPost]
        public ActionResult Create(QClass sub)
        {
            if (ModelState.IsValid)
            {
                var dao = new QClassDAO();
                Guid id = new SubjectDAO().GetListAll().Where(i => i.ID == sub.idsu).Select(l => l.SubjectID).SingleOrDefault();
                sub.SubjectID = id;
                sub.ClassID = Guid.NewGuid();
                Guid idclass = dao.AddQClass(sub);
                if (idclass != Guid.Empty)
                {
                    return RedirectToAction("Index", "Module");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm module thất bại");
                }
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            listsubject(id);
            var model = new QClassDAO().singleIDQClass(id);
            return View(model);
        }
        [HttpPost]
        // GET: Admin/Users/Edit
        public ActionResult Edit(QClass sub)
        {
            if (ModelState.IsValid)
            {
                var dao = new QClassDAO();
                Guid id = new SubjectDAO().GetListAll().Where(i => i.ID == sub.idsu).Select(l => l.SubjectID).SingleOrDefault();
                sub.SubjectID = id;

                if (dao.UpdateQClass(sub))
                {
                    return RedirectToAction("Index", "Module");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa module thất bại");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (new QClassDAO().DeleteQClassID(id))
                {
                    return RedirectToAction("Index", "Module");
                }
            }
            return View("Index");
        }


        public void listsubject(int id = -1)
        {
            ViewBag.ListSubject = new SelectList(new SubjectDAO().GetListAll(), "ID", "Descr", id);
        }

    }
}