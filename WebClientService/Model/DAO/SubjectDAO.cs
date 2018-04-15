using Model.EF;
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
       
        public List<Subject> ShowAllSubID(int id)
        {
            return db.Subjects.Where(i => i.idSub == id).ToList();
        }
        public Subject ShowAllSubIDSingle(int id)
        {
            return db.Subjects.Where(i => i.idSub == id).SingleOrDefault();
        }
        public List<Subject> showWithGuidID(Guid id)
        {
            return db.Subjects.Where(o => o.SubjectID == id).ToList();
        }
        public string DescrSub(int id)
        {
            return db.Subjects.Where(k => k.idSub == id).Select(m => m.Descr).SingleOrDefault();
        }
        public int AddSubject(Subject PQ)
        {
            try
            {
                PQ.SubjectID = Guid.NewGuid();
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
            return PQ.idSub;
        }
        public bool UpdateSubject(Subject PQ)
        {
            try
            {
                Subject u = db.Subjects.Where(p => p.idSub == PQ.idSub).SingleOrDefault();
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
        public bool DeleteSubjectInt(int id)
        {
            try
            {
                Subject u = db.Subjects.Single(p => p.idSub == id);
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
