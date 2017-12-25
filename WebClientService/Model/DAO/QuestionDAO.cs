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
        public IEnumerable<Question> GetListAll()
        {
            IEnumerable<Question> y = db.Questions.ToList();
            CloseConnect();
            return y;
        }
        public IEnumerable<Question> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Question> x = db.Questions.OrderBy(m => m.QuestionID).ToPagedList(page, pageSize);
            CloseConnect();
            return x;
        }
        public Guid AddPQ(Question PQ)
        {
            try
            {
                db.Questions.Add(PQ);
                db.SaveChanges();
                CloseConnect();
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
            return PQ.QuestionID;
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
                CloseConnect();
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
                CloseConnect();
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
