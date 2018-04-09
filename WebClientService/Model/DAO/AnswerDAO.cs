using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        public IEnumerable<Answer> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Answer> x = db.Answers.OrderBy(m => m.ID).ToPagedList(page, pageSize);
            return x;
        }
        public IEnumerable<Answer> GetListAnswer()
        {
            IEnumerable<Answer> x = db.Answers.ToList();
            return x;
        }
        public int AddAnswer(Answer Answer)
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
    }
}
