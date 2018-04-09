using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class PhanQuyenDAO
    {
        WebClientDbContext db = null;
        public PhanQuyenDAO()
        {
            db = new WebClientDbContext();
        }
        public List<PhanQuyen> GetListAll()
        {
            List<PhanQuyen> y = db.PhanQuyens.ToList();
            return y;
        }
        public IEnumerable<PhanQuyen> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<PhanQuyen> x = db.PhanQuyens.OrderBy(m => m.ID).ToPagedList(page, pageSize); 
            return x;
        }
        public int AddPQ(PhanQuyen PQ)
        {
            try
            {
                db.PhanQuyens.Add(PQ);
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
        public bool UpdatePhanQuyen(PhanQuyen PQ)
        {
            try
            {
                PhanQuyen u = db.PhanQuyens.Where(p => p.ID == PQ.ID).SingleOrDefault();
                u.MaPQ = PQ.MaPQ;
                u.TenPQ = PQ.TenPQ;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePhanQuyen(int id)
        {
            try
            {
                PhanQuyen u = db.PhanQuyens.Single(p => p.ID == id);
                db.PhanQuyens.Remove(u);
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
