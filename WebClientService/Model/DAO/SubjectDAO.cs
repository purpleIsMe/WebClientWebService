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
        public List<Subject> GetListAll()
        {
            List<Subject> y = db.Subjects.ToList();
            return y;
        }
        public List<Subject> ListAllPaging(int page, int pageSize)
        {
            List<Subject> x = db.Subjects.OrderBy(m => m.SubjectID).ToPagedList(page, pageSize).ToList();
            return x;
        }
        public List<Subject> ShowAllSubID(Guid id)
        {
            return db.Subjects.Where(i => i.SubjectID == id).ToList();
        }
        public Guid AddSubject(Subject PQ)
        {
            try
            {
                db.Subjects.Add(PQ);
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
