using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class AnswerDAO
    {
        WebClientDbContext db = null;
        public AnswerDAO()
        {
            db = new WebClientDbContext();
        }
        public List<Answer> GetListAnswer()
        {
            List<Answer> x = db.Answers.ToList();
            return x;
        }
        public int FindIDAnswer(int IDThiSinh)
        {
            return db.Answers.Where(i => i.IDThiSinh == IDThiSinh).Select(p => p.ID).SingleOrDefault();
        }
        public int AddAnswerNotQuery(Answer Answer)
        {
            try
            {
                db.Answers.Add(Answer);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("- Entity of type \"{0}\", in state \"{1}\" has the following validation errors: ", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return Answer.ID;
        }
        public int AddAnswer(Answer Answer)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@IDThiSinh",Answer.IDThiSinh),
                    new SqlParameter("@DiemSo",Answer.DiemSo),
                    new SqlParameter("@DiemThuc",Answer.DiemThuc)
                };
                int res = db.Database.ExecuteSqlCommand("Insert_answer @IDThiSinh, @DiemSo, @DiemThuc", valparams);
                db.SaveChanges();
                if (res < 1)
                    return -1;
                else
                    return res;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("- Entity of type \"{0}\", in state \"{1}\" has the following validation errors: ", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return 0;
            }
        }
        public bool UpdateAnswer(Answer AnswerDAO)
        {
            try
            {
                Answer u = db.Answers.Where(p => p.ID == AnswerDAO.ID).SingleOrDefault();
                u.IDThiSinh = AnswerDAO.IDThiSinh;
                u.DiemSo = AnswerDAO.DiemSo;
                u.DiemThuc = AnswerDAO.DiemThuc;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateAnswerScore(Answer AnswerDAO)
        {
            try
            {
                Answer u = db.Answers.Where(p => p.ID == AnswerDAO.ID).SingleOrDefault();
                u.DiemSo = AnswerDAO.DiemSo;
                u.DiemThuc = AnswerDAO.DiemThuc;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAnswer(int id)
        {
            try
            {
                Answer u = db.Answers.Single(p => p.ID == id);
                db.Answers.Remove(u);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void CloseConnect()
        {
            db.Dispose();
        }


        public List<AnswerSheet> GetListAnswerSheet()
        {
            List<AnswerSheet> x = db.AnswerSheets.ToList();
            return x;
        }
        public bool AddAnswerSheet(AnswerSheet an)
        {
            try
            {
                object[] valparams =
               {
                    new SqlParameter("@IDAnswer",an.IDAnswer),
                    new SqlParameter("@QuestionID",an.QuestionID),
                    new SqlParameter("@ThuTuCauHoi",an.ThuTuCauHoi),
                    new SqlParameter("@Answer",an.Answer),
                    new SqlParameter("@DapAn",an.DapAn),
                    new SqlParameter("@RemainTime",an.RemainTime)
                };
                int res = db.Database.ExecuteSqlCommand("Insert_answersheet @IDAnswer, @QuestionID, @ThuTuCauHoi, @Answer, @DapAn, @RemainTime", valparams);
                db.SaveChanges();
                if (res == 1)
                    return true;
                else
                    return false;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("- Entity of type \"{0}\", in state \"{1}\" has the following validation errors: ", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
     
        public bool UpdateAnswerSheet(AnswerSheet AnswerSheetDAO)
        {
            try
            {
                AnswerSheet u = db.AnswerSheets.Where(p => p.IDAnswer == AnswerSheetDAO.IDAnswer).SingleOrDefault();
                u.ThuTuCauHoi = AnswerSheetDAO.ThuTuCauHoi;
                u.Answer = AnswerSheetDAO.Answer;
                u.QuestionID = AnswerSheetDAO.QuestionID;
                u.DapAn = AnswerSheetDAO.DapAn;
                u.RemainTime = AnswerSheetDAO.RemainTime;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAnswerSheet(int id)
        {
            try
            {
                AnswerSheet u = db.AnswerSheets.Single(p => p.IDAnswer == id);
                db.AnswerSheets.Remove(u);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
