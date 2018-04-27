using Model.DAO;
using Model.EF;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class ClassesController : BaseController
    {
        // GET: Admin/Class
        public ActionResult Index()
        {
            listLecturer(1);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Class sub)
        {
            bool idclass = false;
            if (ModelState.IsValid)
            {
                var dao = new ClassDAO();
                idclass = dao.AddClass(sub);
            }

            return Json(idclass, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Class sub)
        {
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new ClassDAO();

                if (dao.UpdateClass(sub))
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
            var Class = new ClassDAO().getInfoClass(id);
            listLecturer(Class.IDLecturer);
            return Json(Class, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int idm)
        {
            var x = new ClassDAO().DeleteClass(idm);
            return Json(new
            {
                result = x
            });
        }

        public void listLecturer(int id = -1)
        {
            ViewBag.ListLecturers = new SelectList(new UserDAO().ViewListForIDPQ(4), "ID", "Name", id);
        }
        [HttpPost]
        public JsonResult ChangeClass(int idsub)
        {
            var kq = new ClassDAO().ClassesOfLecturer(idsub);
            if (kq == null)
                kq = null;
            return Json(new
            {
                result = kq
            });
        }
    }
}