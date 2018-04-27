using Model.DTO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class QuestionDAO
    {
        WebClientDbContext db = null;
        public QuestionDAO()
        {
            db = new WebClientDbContext();
        }
        public List<Question> GetListAll()
        {
            List<Question> y = db.Questions.ToList();
            return y;
        }
        public AllQuestionDTO getOneQuestion(int QID)
        {
            AllQuestionDTO x = (from a in db.Questions
                               where a.QID == QID
                               select new AllQuestionDTO()
                               {
                                   QuestionID = a.QuestionID,
                                   PicQues = a.PicQuestion,
                                   PicAns1 = a.PicAnswer1,
                                   PicAns2 = a.PicAnswer2,
                                   PicAns3 = a.PicAnswer3,
                                   PicAns4 = a.PicAnswer4,
                                   DapAn = (int) a.TheAnswer
                               }).SingleOrDefault();
            return x;
        }
        public List<AllQuestionDTO> getAllQuestionDeTron(int iddetron)
        {
            List<AllQuestionDTO> o = (from a in db.DETRON_QUESTION
                                      join b in db.Questions on a.QuestionID equals b.QuestionID
                                      join c in db.DETRONs on a.IDDeTron equals c.ID
                                      where a.IDDeTron == iddetron
                                      orderby a.IDAuto
                                      select new AllQuestionDTO()
                                      {
                                          ID = b.QID,
                                          MaDeTron = c.MaDeTron,
                                          QuestionID = b.QuestionID,
                                          DapAn = a.DapAn,
                                          PicQues = b.PicQuestion,
                                          PicAns1 = b.PicAnswer1,
                                          PicAns2 = b.PicAnswer2,
                                          PicAns3 = b.PicAnswer3,
                                          PicAns4 = b.PicAnswer4
                                      }).ToList();
            return o;
        }
        //public List<Question> getListQuestionIDModule(int idmodule)
        //{
        //    Guid idclass = new QClassDAO().GetListAll().Where(i => i.ClassID == idmodule).Select(p => p.ClassID).SingleOrDefault();
        //    List<Question> x = db.Questions.Where(o => o.ClassID == idclass).ToList();
        //    return x;
        //}
        public bool AddQuestion(Question PQ)
        {
            try
            {
                db.Questions.Add(PQ);
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
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public bool UpdateQuestion(Question PQ)
        {
            try
            {
                Question u = db.Questions.Where(p => p.QID == PQ.QID).SingleOrDefault();
                u.QuestionNbr = PQ.QuestionNbr;
                u.ClassID = PQ.ClassID;
                u.SubjectID = PQ.SubjectID;
                u.Content = PQ.Content;
                u.Question1 = PQ.Question1;
                u.NoOfAnswers = PQ.NoOfAnswers;
                u.TheAnswer = PQ.TheAnswer;
                u.Answer1 = PQ.Answer1;
                u.Answer2 = PQ.Answer2;
                u.Answer3 = PQ.Answer3;
                u.Answer4 = PQ.Answer4;
                u.Answer5 = PQ.Answer5;
                u.MaxAnswerLen = PQ.MaxAnswerLen;
                u.Used = PQ.Used;
                u.DateAdd = PQ.DateAdd;
                u.HostName = PQ.HostName;
                u.UserAccess = PQ.UserAccess;
                u.Active = PQ.Active;
                u.PicQuestion = PQ.PicQuestion;
                u.PicAnswer1 = PQ.PicAnswer1;
                u.PicAnswer2 = PQ.PicAnswer2;
                u.PicAnswer3 = PQ.PicAnswer3;
                u.PicAnswer4 = PQ.PicAnswer4;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteQuestion(int id)
        {
            try
            {
                Question u = db.Questions.Single(p => p.QID == id);
                db.Questions.Remove(u);
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
        public bool AddQuestionTemp(QuestionTemp PQ)
        {
            try
            {
                db.QuestionTemps.Add(PQ);
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
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
