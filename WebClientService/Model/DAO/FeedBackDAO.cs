using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Model.DAO
{
    public class FeedBackDAO
    {
        WebClientDbContext db = null;
        public FeedBackDAO()
        {
            db = new WebClientDbContext();
        }
        public List<FeedBack> showAll()
        {
            return db.FeedBacks.ToList();
        }
        public int AddFeedBack(FeedBack PQ)
        {
            try
            {
                db.FeedBacks.Add(PQ);
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
        public bool UpdateFeedBack(FeedBack PQ)
        {
            try
            {
                FeedBack u = db.FeedBacks.Where(p => p.ID == PQ.ID).SingleOrDefault();
                u.Name = PQ.Name;
                u.Email = PQ.Email;
                u.Messages = PQ.Messages;
                u.CreateDate = PQ.CreateDate;
                u.Status = PQ.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteFeedBack(int id)
        {
            try
            {
                FeedBack u = db.FeedBacks.Single(p => p.ID == id);
                db.FeedBacks.Remove(u);
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
