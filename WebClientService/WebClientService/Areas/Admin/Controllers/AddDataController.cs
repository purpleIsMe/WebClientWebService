using Model.Content;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebClientService.Areas.Admin.Controllers
{
    public class AddDataController : Controller
    {
        // GET: Admin/AddData
        public ActionResult Index()
        {
            SubjectModel model = new SubjectModel()
            {
                Subjects = new SubjectDAO().GetListAll()
            };
            return View(model);
        }
        public ActionResult Module(int idsub)
        {
            var model = new ModuleModel()
            {
                Modules = new QClassDAO().listWithIDSub(idsub).ToList()
            };
            return PartialView("Partials/_ModulesDropDownList", model.Modules);
        }

        [HttpPost]
        public ActionResult GetModuleList(int idsub)
        {
            //Here I'll bind the list of cities corresponding to selected state's state id  

            var model = new ModuleModel()
            {
                Modules = new QClassDAO().listWithIDSub(idsub).ToList()
            };
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(model.Modules);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}