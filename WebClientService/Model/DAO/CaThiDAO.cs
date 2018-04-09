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
        public IEnumerable<CATHI> GetListCaThi()
        {
            IEnumerable<CATHI> x = db.CATHIs.ToList();
            return x;
        }
        public int AddCATHI(CATHI CATHI)
        {
            try
            {
                db.CATHIs.Add(CATHI);
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
            return CATHI.ID;
        }
        public bool UpdateCATHI(CATHI CATHIDAO)
        {
            try
            {
                CATHI u = db.CATHIs.Where(p => p.ID == CATHIDAO.ID).SingleOrDefault();
                u.GioBatDau = CATHIDAO.GioBatDau;
                u.GioKetThuc = CATHIDAO.GioKetThuc;
                u.Ngay = CATHIDAO.Ngay;
                u.TrangThai = CATHIDAO.TrangThai;
                u.Ngay = CATHIDAO.Ngay;
                u.Ca = CATHIDAO.Ca;
                u.DaHoanThanh = CATHIDAO.DaHoanThanh;
                u.MaKhoaThi = CATHIDAO.MaKhoaThi;
                u.Ngay = CATHIDAO.Ngay;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCATHI(int id)
        {
            try
            {
                CATHI u = db.CATHIs.Single(p => p.ID == id);
                db.CATHIs.Remove(u);
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
