using Model.DAO;
using Model.DTO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class MakeTestController : Controller
    {
        // GET: Admin/MakeTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DeTron()
        {
            return View();
        }
        public ActionResult getKhoaThi()
        {
            var kq = new KHOATHIDAO().DsKhoaThi();
            return Json(kq.Select(x => new { TenKhoaThi = x.TenKhoaThi, MaKhoaThi = x.MaKhoaThi }), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getCaThi(string id)
        {
            var kq = new CaThiDAO().DsCATHI().Where(i=>i.MaKhoaThi == id);
            return Json(kq.Select(x => new { ID = x.ID, Ca = x.Ca }), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getMonThi(int id)
        {
            DetailSchedule result = new CaThiDAO().getAllInfoCaThi(id);
            if (result == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            else
            {
                var k = new { IDMon = result.IDMon, NameSubject = result.NameSubject, MaChiTietCa = result.MaChiTietCa };
                return Json(k, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SaveTest(DECHUAN de)
        {
            Guid idsub = new SubjectDAO().ShowAllSubIDSingle(de.MaDeChuan).SubjectID;
            de.MaMon = idsub;
            de.MaDeChuan = -1;
            int id = new DeChuanDAO().luuDeChuan(de);
            
            return Json(id, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult showAllTest(int id = -1)
        {
            var kq = new DeChuanDAO().GetListSingleDC(id);
            if (kq == null)
                kq = null;
            
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult deleteTest(int id)
        {
            bool x = new DeChuanDAO().DeleteDECHUAN(id);
            return Json(x,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult taoDeTron(int id)
        {
            int x = new DeChuanDAO().tronDeThi(id);
            string kq;
            if (x == -1)
                kq = "Lỗi trộn đề";
            else
                kq = "Trộn đề thành công";
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult khoaDeChuan(int idde)
        {
            int x = new DeChuanDAO().khoaDeChuan(true, idde);
            string kq;
            if (x == -1)
                kq = "Không thể khóa đề chuẩn";
            else
                kq = "Khóa đề chuẩn thành công";
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult moKhoaDeChuan(int idde)
        {
            int x = new DeChuanDAO().khoaDeChuan(false, idde);
            string kq;
            if (x == -1)
                kq = "Không thể mở khóa đề chuẩn";
            else
                kq = "Mở khóa đề chuẩn thành công";
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getListDeTron(int idde)
        {
            List<detron> dt = new DeChuanDAO().getListDeTron(idde);
            return Json(dt, JsonRequestBehavior.AllowGet);
        }
    }
}