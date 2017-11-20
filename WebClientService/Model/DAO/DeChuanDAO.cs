using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class DeChuanDAO
    {
        WebClientDbContext db = null;
        public DeChuanDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<DeChuan> GetListAll()
        {
            IEnumerable<DeChuan> y = db.DeChuans.ToList();
            CloseConnect();
            return y;
        }
        public List<DeChuan> GetListSingleDC(int maDC)
        {
            List<DeChuan> x = db.DeChuans.Where(i => i.MaDeChuan == maDC).ToList();
            CloseConnect();
            return x;
        }
        public void CloseConnect()
        {
            db.Dispose();
        }
        public bool UpdateDeChuan(DeChuan DeChuanDAO)
        {
            try
            {
                DeChuan u = db.DeChuans.Where(p => p.MaDeChuan == DeChuanDAO.MaDeChuan).SingleOrDefault();
                u.TenDeChuan = DeChuanDAO.TenDeChuan;
                u.MaMon = DeChuanDAO.MaMon;
                u.MaCaThi = DeChuanDAO.MaCaThi;
                u.SoDeHoanVi = DeChuanDAO.SoDeHoanVi;
                u.TrangThaiTron = DeChuanDAO.TrangThaiTron;
                u.ThoiGian = DeChuanDAO.ThoiGian;
                u.Lock = DeChuanDAO.Lock;
                db.SaveChanges();
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDeChuan(int id)
        {
            try
            {
                DeChuan u = db.DeChuans.Single(p => p.MaDeChuan == id);
                db.DeChuans.Remove(u);
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
