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
            ViewBag.descr = new SubjectDAO().DescrSub(1);
            return View();
        }
        [HttpPost]
        public ActionResult Create(QClass sub)
        {
            bool idclass = false;
            if (ModelState.IsValid)
            {
                var dao = new QClassDAO();
                Guid id = new SubjectDAO().GetListAll().Where(i => i.idSub == sub.idQClass).Select(l => l.SubjectID).SingleOrDefault();
                sub.SubjectID = id;
                sub.ClassID = Guid.NewGuid();
                idclass = dao.AddQClass(sub);
            }

            return Json(idclass, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(QClass sub)
        {
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new QClassDAO();

                if (dao.UpdateQClass(sub))
                {
                    kq = true;
                }
                else
                {
                    kq = false;
                }
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            var qclass = new QClassDAO().singleIDQClassInt(id);
            listsubject();
            return Json(qclass, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int idm)
        {
            var x = new QClassDAO().DeleteQClass(idm);
            return Json(new
            {
                result = x
            });
        }

        public void listsubject(int id = -1)
        {
            ViewBag.ListSubject = new SelectList(new SubjectDAO().GetListAll(), "idSub", "Descr", id);
        }
        [HttpPost]
        public JsonResult ChangeSubject(int idsub)
        {
            var kq = new QClassDAO().listWithIDSubInt(idsub);
            return Json(new
            {
                result = kq
            });
        }
    }
}