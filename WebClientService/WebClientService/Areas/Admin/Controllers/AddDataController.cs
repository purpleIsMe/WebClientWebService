using Model.Content;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data.SQLite;

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
            listsubject(1);
            listmodule(1);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SubjectModel q, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && q.SelectedSubject != 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Doc"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    Guid subID = new SubjectDAO().ShowAllSubIDSingle(q.SelectedSubject).SubjectID;
                    Guid classID = new QClassDAO().singleIDQClass(q.SelectedModule).ClassID;

                    if (!SqLite2SqlServerQuestion(path, subID, classID))
                        ViewBag.Message = "Khong the luu cac cau hoi nay";
                    else
                        ViewBag.Message = "ok";

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            listmodule(q.SelectedSubject);
            listsubject(q.SelectedSubject);
            return View();
        }
        public static SQLiteDataReader SelectTable(string table, SQLiteConnection sqconn)
        {
            string sqlCmd;

            sqlCmd = "Select *  From " + table;

            SQLiteCommand cmd = new SQLiteCommand(sqlCmd, sqconn);
            SQLiteDataReader rs = cmd.ExecuteReader();
            return rs;
        }
        public static Boolean SqLite2SqlServerQuestion(string sqlitePath, Guid SubjectID, Guid classid)
        {
            try
            {
                string sql = "select * from sqlite_master where type = 'table'";
                string password = null;

                string sqliteConnString = CreateSQLiteConnectionString(sqlitePath, password);

                using (SQLiteConnection sqconn = new SQLiteConnection(sqliteConnString))
                {
                    sqconn.Open();
                    SQLiteCommand command = new SQLiteCommand(sql, sqconn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        SQLiteDataReader rs = SelectTable("Question", sqconn);
                        while (rs.Read())
                        {
                            if (!SaveQuestion(rs, SubjectID, classid))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            } // catch
        }
        public static bool SaveQuestion(SQLiteDataReader rs, Guid SubjectID, Guid classid)
        {
            string Campo;
            int i;
            Question q = new Question();

            for (i = 0; i < rs.FieldCount; i++)
            {
                Campo = rs.GetName(i);
                var valor = rs.GetValue(i);
                switch (Campo)
                {
                    case "QuestionID":
                        q.QuestionID = rs.GetGuid(i);
                        break;
                    case "SubjectID":
                        q.SubjectID = SubjectID;
                        break;
                    case "ClassID": q.ClassID = classid; break;
                    case "MentalityTypeID": break;
                    case "OSubjectID": break;
                    case "QuestionNbr":
                        q.QuestionNbr = rs.GetString(i);
                        break;
                    case "Content":
                        //q.Content = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Content = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "Question":
                        //q.Question1 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Question1 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "Answer1":
                        //q.Answer1 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer1 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "Answer2":
                        //q.Answer2 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer2 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "Answer3":
                        //q.Answer3 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer3 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "Answer4":
                        //q.Answer4 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer4 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "NoOfAnswers":
                        q.NoOfAnswers = rs.GetInt32(i);// (int)rs.GetValue(i);
                        break;
                    case "TheAnswer":
                        q.TheAnswer = rs.GetInt32(i);
                        break;
                    default:
                        q.Answer1SwapYN = true;
                        q.Answer2SwapYN = true;
                        q.Answer3SwapYN = true;
                        q.Answer4SwapYN = true;
                        break;
                }
            }
            q.Used = 0;
            q.Active = true;
            q.QID = (int)i;
            int maxlength = 0;
            int[] a;
            a = new int[4];

            a[0] = q.Answer1.Length;
            a[1] = q.Answer2.Length;
            a[2] = q.Answer3.Length;
            a[3] = q.Answer4.Length;

            for (int j = 0; j < a.Length; j++)
            {
                if (maxlength < a[j])
                    maxlength = a[j];
            }
            q.MaxAnswerLen = maxlength;
            if (!new QuestionDAO().AddPQ(q))
            {
                return false;
            }
            return true;
        }
        private static string CreateSQLiteConnectionString(string sqlitePath, string password)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = sqlitePath;
            if (password != null)
                builder.Password = password;
            builder.PageSize = 4096;
            builder.UseUTF16Encoding = true;
            string connstring = builder.ConnectionString;

            return connstring;
        }
        public void listsubject(int id = -1)
        {
            ViewBag.ListSubject = new SelectList(new SubjectDAO().GetListAll(), "ID", "Descr", id);
        }
        public void listmodule(int idsub = -1)
        {
            ViewBag.ListModule = new SelectList(new QClassDAO().listWithIDSub(idsub), "IDQClass", "Descr", idsub);
        }
    }
}