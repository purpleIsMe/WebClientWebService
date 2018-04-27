using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using System.Data.OleDb;
using System.Data;
using WebClientService.Common;
using System.Data.Entity.Validation;
using Model.DAO;
using System.Linq;

namespace WebClientService.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Admin/Students
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetListUsers()
        {
            List<User> users = new UserDAO().ViewListForIDPQ(4);
            return Json(users.Select(x=>new {ID=x.ID,Name=x.Name }),JsonRequestBehavior.AllowGet);
        }       
        public ActionResult GetListClass(int userid=1)
        {
            List<Class> classes = new ClassDAO().ClassesOfLecturer(userid);
            return Json(classes.Select(i=>new { IDClass=i.IDClass,NameClass=i.NameClass,IDLecturer = i.IDLecturer,TrangThai=i.TrangThai}), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListStudentByClass(int classid = -1)
        {
            var dao1 = new StudentDAO();
            List<Student> x = dao1.FiltStudentByClass(classid);
            return Json(x.Select(i => new
            {
                ID = i.ID,
                Name = i.Name,
                Born = i.Born.ToShortDateString(),
                Address = i.Address,
                Position = i.Position,
                Mobile = i.Mobile,
                Email = i.Email,
                Active = i.Active,
                Password = i.Password,
                UserName = i.UserName,
                Status = i.Status,
                CreateDate = i.CreateDate,
                CreateBy = i.CreateBy,
                IDClass = i.IDClass,
                IDLecturer = i.IDLecturer,
                Gender = i.Gender,
                CMND = i.CMND
            }),
             JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListStudentByLecture(int useid = -1)
        {
            var dao1 = new StudentDAO();
            List<Student> x = dao1.FiltStudent(useid);
            return Json(x.Select(i => new {
                ID = i.ID,
                Name = i.Name, 
                Born = i.Born.ToShortDateString(),
                Address = i.Address,
                Position = i.Position,
                Mobile = i.Mobile,
                Email = i.Email,
                Active = i.Active,
                Password = i.Password,
                UserName = i.UserName,
                Status = i.Status,
                CreateDate = i.CreateDate,
                CreateBy = i.CreateBy,
                IDClass = i.IDClass,
                IDLecturer = i.IDLecturer,
                Gender = i.Gender,
                CMND = i.CMND}), 
                JsonRequestBehavior.AllowGet);
        }
        //get, create, edit, delete info student
        [HttpGet]
        public ActionResult Get(int id)
        {
            var student = new StudentDAO().ViewDetailStudent(id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int idm)
        {
            var x = new StudentDAO().DeleteStudent(idm);
            return Json(new
            {
                result = x
            });
        }
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            bool idstudent = false;
            if (ModelState.IsValid)
            {
                var dao = new StudentDAO();
                idstudent = dao.AddStudent(stu);
            }

            return Json(idstudent, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new StudentDAO();
                
                if (dao.UpdateStudent(stu))
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
        //upload file
        static int classid, lectid;
        public void getInfoLecClass(int idclass, int idlect)
        {
            classid = idclass;
            lectid = idlect;
        }
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase FileUpload)
        {
            StudentDAO stu = new StudentDAO();
            var x = (UserLogin)Session[Constants.USER_SESSION];
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();

                    adapter.Fill(ds, "ExcelTable");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (ds.Tables[0].Rows[i][1].ToString() != "" && ds.Tables[0].Rows[i][2].ToString() != "" && ds.Tables[0].Rows[i][7].ToString() != "")
                            {
                                Student TU = new Student();
                                TU.UserName = ds.Tables[0].Rows[i][1].ToString();
                                TU.Name = ds.Tables[0].Rows[i][2].ToString();
                                TU.Gender = Boolean.Parse(ds.Tables[0].Rows[i][3].ToString());
                                TU.Born = DateTime.Parse(ds.Tables[0].Rows[i][4].ToString());
                                TU.Address = ds.Tables[0].Rows[i][5].ToString();
                                TU.Mobile = ds.Tables[0].Rows[i][6].ToString();
                                TU.Email = ds.Tables[0].Rows[i][7].ToString();
                                TU.CMND = ds.Tables[0].Rows[i][8].ToString();
                                TU.Password = ds.Tables[0].Rows[i][9].ToString();
                                TU.IDClass = classid;
                                TU.Status = true;
                                TU.Position = "Student";
                                TU.Active = true;
                                TU.IDLecturer = lectid;
                                TU.CreateBy = x.UserID;
                                TU.CreateDate = DateTime.Now;
                                stu.AddStudent(TU);

                            }
                            else
                            {
                                ModelState.AddModelError("mess", "Xin điền đầy đủ các trường bắt buộc như tên, địa chỉ, năm sinh, mật khẩu, biệt danh");
                                return RedirectToAction("Upload", "Students");
                            }
                        }

                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {

                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {

                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);

                                }

                            }
                        }
                    }
                    //deleting excel file from folder  
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    ModelState.AddModelError("mess", "Import thành công tất cả sinh viên");
                    return RedirectToAction("Upload", "Students");
                }
                else
                {
                    ModelState.AddModelError("mess", "Chỉ cho phép import các loại file excel phiên bản từ 2013 -> 2017");
                    return RedirectToAction("Upload", "Students");
                }
            }
            else
            {
                if (FileUpload == null)
                    ModelState.AddModelError("mess", "Xin vui lòng chọn file Excel");
                return RedirectToAction("Upload", "Students");
            }
        }

        //convert student to thisinh
        [HttpGet]
        public ActionResult Convert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConvertStudentToThiSinh(int idcathi, int idclass)
        {
            var kq = new StudentDAO().ConvertStudentToThiSinh(idcathi, idclass);
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult PhanDeTS(int idcathi)
        {
            var kq = new DeChuanDAO().PhanDeChoThiSinh(idcathi);
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetListThiSinh(int id)
        {
            var student = new ThiSinhDAO().showListByIDCaChiTiet(id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
    }
}