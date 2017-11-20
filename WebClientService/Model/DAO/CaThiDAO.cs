using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CaThiDAO
    {
        WebClientDbContext db = null;
        public CaThiDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<Cathi> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Cathi> x = db.Cathis.OrderBy(m => m.ID).ToPagedList(page, pageSize);
            CloseConnect();
            return x;
        }
        public IEnumerable<Cathi> GetListCathi()
        {
            IEnumerable<Cathi> x = db.Cathis.ToList();
            CloseConnect();
            return x;
        }
        public int AddCathi(Cathi Cathi)
        {
            try
            {
                db.Cathis.Add(Cathi);
                CloseConnect();
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
            return Cathi.ID;
        }
        public bool UpdateCathi(Cathi CathiDAO)
        {
            try
            {
                Cathi u = db.Cathis.Where(p => p.ID == CathiDAO.ID).SingleOrDefault();
                u.GioBD = CathiDAO.GioBD;
                u.GioKT = CathiDAO.GioKT;
                u.Ngay = CathiDAO.Ngay;
                u.TrangThai = CathiDAO.TrangThai;
                db.SaveChanges();
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCathi(int id)
        {
            try
            {
                Cathi u = db.Cathis.Single(p => p.ID == id);
                db.Cathis.Remove(u);
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
