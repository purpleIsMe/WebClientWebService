using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class ErrorDAO
    {
        WebClientDbContext db = null;
        public ErrorDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<Error> GetListAll()
        {
            IEnumerable<Error> y = db.Errors.ToList();
            return y;
        }
        public IEnumerable<Error> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Error> x = db.Errors.OrderBy(m => m.ID).ToPagedList(page, pageSize);
            return x;
        }
        public int AddPQ(Error PQ)
        {
            try
            {
                db.Errors.Add(PQ);
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
            return PQ.ID;
        }
        public bool UpdateError(Error PQ)
        {
            try
            {
                Error u = db.Errors.Where(p => p.ID == PQ.ID).SingleOrDefault();
                u.Messages = PQ.Messages;
                u.StackTrace = PQ.StackTrace;
                u.CreateDate = PQ.CreateDate;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteError(int id)
        {
            try
            {
                Error u = db.Errors.Single(p => p.ID == id);
                db.Errors.Remove(u);
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
