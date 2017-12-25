using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class SubjectDAO
    {
        WebClientDbContext db = null;
        public SubjectDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<Subject> GetListAll()
        {
            IEnumerable<Subject> y = db.Subjects.ToList();
            CloseConnect();
            return y;
        }
        public IEnumerable<Subject> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Subject> x = db.Subjects.OrderBy(m => m.SubjectID).ToPagedList(page, pageSize);
            CloseConnect();
            return x;
        }
        public Guid AddSubject(Subject PQ)
        {
            try
            {
                db.Subjects.Add(PQ);
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
            return PQ.SubjectID;
        }
        public bool UpdateSubject(Subject PQ)
        {
            try
            {
                Subject u = db.Subjects.Where(p => p.SubjectID == PQ.SubjectID).SingleOrDefault();
                u.SubjectNbr = PQ.SubjectNbr;
                u.Descr = PQ.Descr;
                u.NoOfAnswers = PQ.NoOfAnswers;
                u.NoOfQuestions = PQ.NoOfQuestions;
                u.CreateDate = PQ.CreateDate;
                u.Locked = PQ.Locked;
                u.MaxPoint = PQ.MaxPoint;
                u.MinPoint = PQ.MinPoint;
                u.qBack = PQ.qBack;
                u.loop = PQ.loop;
                u.MaxUsed = PQ.MaxUsed;
                db.SaveChanges();
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteSubject(Guid id)
        {
            try
            {
                Subject u = db.Subjects.Single(p => p.SubjectID == id);
                db.Subjects.Remove(u);
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
