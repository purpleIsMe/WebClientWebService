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
using System.Drawing;

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
            q.nameModule = new QClassDAO().singleIDQClassInt(q.SelectedModule).Descr;
            if (file != null && file.ContentLength > 0 && q.SelectedSubject != 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Doc/"+q.nameModule),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    Guid subID = new SubjectDAO().ShowAllSubIDSingle(q.SelectedSubject).SubjectID;
                    Guid classID = new QClassDAO().singleIDQClassInt(q.SelectedModule).ClassID;

                    if (!SqLite2SqlServerQuestion(path, subID, classID))
                        ViewBag.Message = "Không thể lưu các câu hỏi này";
                    else
                    { ViewBag.Message = "Import danh sách câu hỏi thành công!!!"; }

                   // ViewBag.Message = "Import danh sách câu h?i thành công!!!";
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
                        SQLiteDataReader rs = SelectTable("[Question]", sqconn);
                        while (rs.Read())
                        {
                            if (!SaveQuestion(rs, SubjectID, classid))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else return false;
                }
                return false;
            }
            catch (Exception e)
            {
                //ViewBag.Message = "ERROR:" + e.Message.ToString();
                return false;
            } // catch
        }
        public static bool SaveQuestion(SQLiteDataReader rs, Guid SubjectID, Guid classid)
        {
            string Campo;
            int i;
            QuestionTemp q = new QuestionTemp();

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
                        q.Content = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                        break;
                    case "Question":
                        q.Question = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                      //  q.PicQuestion = imageToByteArray(byteArrayToImage((byte[])rs.GetValue(i)));
                        //q.PicQuestion = System.IO.File.ReadAllBytes(((byte[])rs.GetValue(i));
                        break;
                    case "Answer1":
                        q.Answer1 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                     //   q.PicAnswer1 = imageToByteArray(byteArrayToImage((byte[])rs.GetValue(i)));
                        break;
                    case "Answer2":
                        //q.Answer2 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer2 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                       // q.PicAnswer2 = imageToByteArray(byteArrayToImage((byte[])rs.GetValue(i)));
                        break;
                    case "Answer3":
                        //q.Answer3 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer3 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                       // q.PicAnswer3 = imageToByteArray(byteArrayToImage((byte[])rs.GetValue(i)));
                        break;
                    case "Answer4":
                        //q.Answer4 = ReadMsWordHavePic((Byte[])rs.GetValue(i));
                        q.Answer4 = (Byte[])rs.GetValue(i);// != DBNull.Value ? (Byte[])rs.GetValue(i) : null;
                       // q.PicAnswer4 = imageToByteArray(byteArrayToImage((byte[])rs.GetValue(i)));
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
            if (!new QuestionDAO().AddQuestionTemp(q))
            {
                return false;
            }
            return true;
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            //Image returnImage = Image.FromStream(ms);
            Image returnImage = (Bitmap)((new ImageConverter()).ConvertFrom(byteArrayIn));
            return returnImage;

        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
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
            ViewBag.ListSubject = new SelectList(new SubjectDAO().GetListAll(), "idSub", "Descr", id);
        }
        public void listmodule(int idsub = -1)
        {
            ViewBag.ListModule = new SelectList(new QClassDAO().listWithIDSubInt(idsub), "idQClass", "Descr", idsub);
        }
    }
}