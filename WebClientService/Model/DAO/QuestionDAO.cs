using Model.DTO;
using Model.EF;
using PagedList;
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
        public List<AllQuestionDTO> getAllQuestionDeTron(int iddetron)
        {
            List<AllQuestionDTO> o = (from a in db.DeTronQuestions
                                      join b in db.Questions on a.QuestionID equals b.QuestionID
                                      join c in db.DeTrons on a.IDDeTron equals c.ID
                                      where a.IDDeTron == iddetron
                                      orderby a.IDAuto
                                      select new AllQuestionDTO()
                                      {
                                          ID = c.ID,
                                          MaDeTron = c.MaDeTron,
                                          QuestionID = b.QuestionID,
                                          Question = b.Question1,
                                          Answer1 = b.Answer1,
                                          Answer2 = b.Answer2,
                                          Answer3 = b.Answer3,
                                          Answer4 = b.Answer4,
                                          TheAnswer = (int)b.TheAnswer,
                                          MaxAnswerLeng = (int)b.MaxAnswerLen,
                                          HV1 = a.Answer1,
                                          HV2 = a.Answer2,
                                          HV3 = a.Answer3,
                                          HV4 = a.Answer4,
                                          DapAn = a.DapAn
                                      }).ToList();
            return o;
        }
        public List<Question> getListQuestionIDModule(int idmodule)
        {
            Guid idclass = new QClassDAO().GetListAll().Where(i => i.IDQClass == idmodule).Select(p => p.ClassID).SingleOrDefault();
            List<Question> x = db.Questions.Where(o => o.ClassID == idclass).ToList();
            return x;
        }
        public IEnumerable<Question> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Question> x = db.Questions.OrderBy(m => m.QuestionID).ToPagedList(page, pageSize);
            return x;
        }
        public bool AddPQ(Question PQ)
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
                Question u = db.Questions.Where(p => p.QuestionID == PQ.QuestionID).SingleOrDefault();
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
                u.QID = PQ.QID;
                u.DateAdd = PQ.DateAdd;
                u.HostName = PQ.HostName;
                u.UserAccess = PQ.UserAccess;
                u.Active = PQ.Active;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteQuestion(Guid id)
        {
            try
            {
                Question u = db.Questions.Single(p => p.QuestionID == id);
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

    }
}
