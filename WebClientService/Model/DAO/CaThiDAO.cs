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
        public IEnumerable<CaThi> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<CaThi> x = db.CaThis.OrderBy(m => m.ID).ToPagedList(page, pageSize);
            CloseConnect();
            return x;
        }
        public IEnumerable<CaThi> GetListCaThi()
        {
            IEnumerable<CaThi> x = db.CaThis.ToList();
            CloseConnect();
            return x;
        }
        public int AddCaThi(CaThi CaThi)
        {
            try
            {
                db.CaThis.Add(CaThi);
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
            return CaThi.ID;
        }
        public bool UpdateCaThi(CaThi CaThiDAO)
        {
            try
            {
                CaThi u = db.CaThis.Where(p => p.ID == CaThiDAO.ID).SingleOrDefault();
                u.GioBD = CaThiDAO.GioBD;
                u.GioKT = CaThiDAO.GioKT;
                u.Ngay = CaThiDAO.Ngay;
                u.TrangThai = CaThiDAO.TrangThai;
                u.IDDeChuan = CaThiDAO.IDDeChuan;
                u.MaGiamThi1 = CaThiDAO.MaGiamThi1;
                u.MaGiamThi2 = CaThiDAO.MaGiamThi2;
                u.SubjectID = CaThiDAO.SubjectID;
                u.TenCaThi = CaThiDAO.TenCaThi;
                db.SaveChanges();
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCaThi(int id)
        {
            try
            {
                CaThi u = db.CaThis.Single(p => p.ID == id);
                db.CaThis.Remove(u);
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
