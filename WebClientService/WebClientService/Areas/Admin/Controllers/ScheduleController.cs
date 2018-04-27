using Model.DAO;
using Model.EF;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Admin/Schedule
        public ActionResult Index()
        {
            getKhoaThi();
            return View();
        }
        public void getKhoaThi(int id = -1)
        {
            ViewBag.ListSchedules = new SelectList(new KHOATHIDAO().DsKhoaThi(), "id", "TenKhoaThi", id);           
        }
        [HttpPost]
        public ActionResult Create(CATHI p)
        {
            bool idPHONG = false;
            if (ModelState.IsValid)
            {
                var dao = new CaThiDAO();
                idPHONG = dao.AddCATHI(p);
            }

            return Json(idPHONG, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(CATHI sub)
        {
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new CaThiDAO();

                if (dao.UpdateCATHI(sub))
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
            var PHONG = new CaThiDAO().getInfoCATHI(id);
            return Json(PHONG, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int idm)
        {
            var x = new CaThiDAO().DeleteCATHI(idm);
            return Json(new
            {
                result = x
            });
        }
        [HttpPost]
        public JsonResult showSchedule()
        {
            var x = new CaThiDAO().DsCATHI();
            return Json(new { result = x });
        }
    }
}