using Model.DAO;
using Model.EF;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class KhoaThiController : Controller
    {
        // GET: Admin/KHOATHI
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KHOATHI p)
        {
            bool idPHONG = false;
            if (ModelState.IsValid)
            {
                var dao = new KHOATHIDAO();
                idPHONG = dao.AddKHOATHI(p);
            }

            return Json(idPHONG, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(KHOATHI sub)
        {
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new KHOATHIDAO();

                if (dao.UpdateKHOATHI(sub))
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
            var PHONG = new KHOATHIDAO().getInfoKHOATHI(id);
            return Json(PHONG, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int idm)
        {
            var x = new KHOATHIDAO().DeleteKHOATHI(idm);
            return Json(new
            {
                result = x
            });
        }
        [HttpPost]
        public JsonResult showKHOATHI()
        {
            var x = new KHOATHIDAO().DsKhoaThi();
            return Json(new { result = x });
        }

    }
}