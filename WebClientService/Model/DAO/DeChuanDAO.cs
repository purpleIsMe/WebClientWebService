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
        public IEnumerable<DECHUAN> GetListAll()
        {
            IEnumerable<DECHUAN> y = db.DECHUANs.ToList();
            return y;
        }
        public List<DECHUAN> GetListSingleDC(int maDC)
        {
            List<DECHUAN> x = db.DECHUANs.Where(i => i.MaDeChuan == maDC).ToList();
            return x;
        }
        public void CloseConnect()
        {
            db.Dispose();
        }
        public bool UpdateDECHUAN(DECHUAN DECHUANDAO)
        {
            try
            {
                DECHUAN u = db.DECHUANs.Where(p => p.MaDeChuan == DECHUANDAO.MaDeChuan).SingleOrDefault();
                u.TenDeChuan = DECHUANDAO.TenDeChuan;
                u.MaMon = DECHUANDAO.MaMon;
                u.SoDeHoanVi = DECHUANDAO.SoDeHoanVi;
                u.TrangThaiTron = DECHUANDAO.TrangThaiTron;
                u.ThoiGian = DECHUANDAO.ThoiGian;
                u.Lock = DECHUANDAO.Lock;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDECHUAN(int id)
        {
            try
            {
                DECHUAN u = db.DECHUANs.Single(p => p.MaDeChuan == id);
                db.DECHUANs.Remove(u);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
