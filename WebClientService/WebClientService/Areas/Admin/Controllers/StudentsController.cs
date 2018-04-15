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

namespace WebClientService.Areas.Admin.Controllers
{
    public class StudentsController : BaseController
    {
        // GET: Admin/Students
        [HttpGet]
        public ActionResult Index()
        {
            if (!GetListPQ())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GetListClass();
            var model = new StudentDAO().ViewDetailStudent(id);
            ViewBag.editstu = model;
            return View(model);
        }

        public bool GetListPQ(int idclasschoose = -1)
        {
            var x = (UserLogin)Session[Constants.USER_SESSION];

            if (x != null)
            {
                var dao = new ClassDAO();

                ViewBag.ID = new SelectList(dao.ClassesOfLecturer(x.UserID), "IDClass", "NameClass", idclasschoose);
                var dao1 = new StudentDAO();
                ViewBag.ListStu = new List<Student>(dao1.FiltStudent(x.UserID));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetListClass(int idclass = -1)
        {
            var session = (UserLogin)Session[Constants.USER_SESSION];
            var dao = new ClassDAO();
            ViewBag.IDClass = new SelectList(dao.ClassesOfLecturer(session.UserID), "IDClass", "NameClass", idclass);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase FileUpload, Class cl)
        {
            StudentDAO stu = new StudentDAO();

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
                            if (ds.Tables[0].Rows[i][1].ToString() != "" && ds.Tables[0].Rows[i][2].ToString() != "" && ds.Tables[0].Rows[i][2].ToString() != null && ds.Tables[0].Rows[i][10].ToString() != null
   && ds.Tables[0].Rows[i][7].ToString() != "")
                            {
                                Student TU = new Student();
                                TU.Name = ds.Tables[0].Rows[i][1].ToString();
                                TU.Address = ds.Tables[0].Rows[i][2].ToString();
                                TU.Born = DateTime.Parse(ds.Tables[0].Rows[i][3].ToString());
                                TU.Email = ds.Tables[0].Rows[i][4].ToString();
                                TU.Mobile = ds.Tables[0].Rows[i][5].ToString();
                                TU.Facebook = ds.Tables[0].Rows[i][6].ToString();
                                TU.Zalo = ds.Tables[0].Rows[i][7].ToString();
                                TU.Skype = ds.Tables[0].Rows[i][8].ToString();
                                TU.UserName = ds.Tables[0].Rows[i][9].ToString();
                                if (!String.IsNullOrEmpty(ds.Tables[0].Rows[i][10].ToString()))
                                {
                                    var encrypted = Encryptor.MD5Hash(ds.Tables[0].Rows[i][10].ToString());
                                    TU.Password = encrypted;
                                }
                                TU.IDClass = cl.IDClass;
                                TU.Status = true;
                                TU.Status = false;
                                TU.Position = "Student";
                                TU.Active = true;
                                stu.AddStudent(TU);

                            }
                            else
                            {
                                ModelState.AddModelError("", "Xin điền đầy đủ các trường bắt buộc như tên, địa chỉ, năm sinh, mật khẩu, biệt danh");
                                return RedirectToAction("Index", "Students");
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
                    ModelState.AddModelError("", "Import thành công tất cả sinh viên");
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉ cho phép import các loại file excel phiên bản từ 2013 -> 2017");
                    return RedirectToAction("Index", "Students");
                }
            }
            else
            {
                if (FileUpload == null)
                    ModelState.AddModelError("", "Xin vui lòng chọn file Excel");
                return RedirectToAction("Index", "Students");
            }
        }

        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            if (ModelState.IsValid)
            {
                var dao = new StudentDAO();
                //if (!String.IsNullOrEmpty(stu.Password))
                //{
                //    var encrypted = Encryptor.MD5Hash(stu.Password);
                //    stu.Password = encrypted;
                //}
                //stu.Password = pass;
                //stu.idlecturer = 1;
                stu.CreateDate = DateTime.Now;
                stu.Active = true;
                stu.Status = true;
                var result = dao.UpdateStudent(stu);
                if (result)
                {
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sinh viên thất bại");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (new StudentDAO().DeleteStudent(id))
                {
                    return RedirectToAction("Index", "Students");
                }
            }
            return View("Index");
        }

        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }


    }
}