using Model.DAO;
using Model.EF;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class RoomsController : Controller
    {
        // GET: Admin/Rooms
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PHONG p)
        {
            bool idPHONG = false;
            if (ModelState.IsValid)
            {
                var dao = new RoomDAO();
                idPHONG = dao.AddRoom(p);
            }

            return Json(idPHONG, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(PHONG sub)
        {
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new RoomDAO();

                if (dao.UpdateRoom(sub))
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
            var PHONG = new RoomDAO().getInfoRoom(id);
            return Json(PHONG, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int idm)
        {
            var x = new RoomDAO().DeleteRoom(idm);
            return Json(new
            {
                result = x
            });
        }
        [HttpPost]
        public JsonResult showRoom()
        {
            var x = new RoomDAO().ListRoom();
            return Json(new { result = x });
        }

        
    }
}