using DevExpress.Office.Utils;
using Model.DTO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
        public DECHUAN singleDeChuan(int iddechuan)
        {
            return db.DECHUANs.Where(i => i.MaDeChuan == iddechuan).SingleOrDefault();
        }
        public int luuDeChuan(DECHUAN de)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@tende",de.TenDeChuan),
                    new SqlParameter("@VARsubjectID",de.MaMon),
                    new SqlParameter("@macathi",de.MaCaThi),
                    new SqlParameter("@sodehoanvi",de.SoDeHoanVi),
                    new SqlParameter("@thoigianthi",de.ThoiGian),
                };
                int res = db.Database.ExecuteSqlCommand("setDECHUAN2 @tende, @VARsubjectID, @macathi, @sodehoanvi, @thoigianthi", valparams);
                db.SaveChanges();
                return res;
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
                return -1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return -1;
            }
        }
        public IEnumerable<DECHUAN> GetListAll()
        {
            IEnumerable<DECHUAN> y = db.DECHUANs.ToList();
            return y;
        }
        public List<dechuan> GetListSingleDC(int idcathi)
        {
            List<dechuan> lide= new List<dechuan>();
            List<DECHUAN> dcn = new List<DECHUAN>();
            if (idcathi == -1)
                dcn = db.DECHUANs.OrderByDescending(p => p.MaDeChuan).ToList();
            else
                dcn = db.DECHUANs.Where(i => i.MaCaThi == idcathi).ToList();
            foreach (var x in dcn)
            {
                dechuan dc = new dechuan();
                dc.MaDeChuan = x.MaDeChuan;
                dc.Lock = x.Lock;
                dc.MaCaThi = x.MaCaThi;
                dc.MaMon = x.MaMon;
                dc.SoDeHoanVi = x.SoDeHoanVi;
                dc.TenDeChuan = x.TenDeChuan;
                dc.ThoiGian = x.ThoiGian;
                dc.TrangThaiTron = x.TrangThaiTron;
                lide.Add(dc);
            }
            return lide;
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
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public int tronDeThi(int iddechuan)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@madechuan",iddechuan)
                };
                int res = db.Database.ExecuteSqlCommand("setDETRON @madechuan", valparams);
                db.SaveChanges();
                return res;
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
                return -1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return -1;
            }
        }
        public int khoaDeChuan(bool locked, int iddechuan)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@IDDeChuan",iddechuan),
                    new SqlParameter("@lock",locked)
                };
                int res = db.Database.ExecuteSqlCommand("khoadechuan @IDDeChuan, @lock", valparams);
                db.SaveChanges();
                return res;
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
                return -1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return -1;
            }
        }
        public List<detron> getListDeTron(int iddechuan)
        {
            List<detron> ldt = new List<detron>();
            var x = db.DETRONs.Where(i => i.MaDeChuan == iddechuan).ToList();
            foreach(var y in x)
            {
                detron dt = new detron();
                dt.ID = y.ID;
                dt.MaDeChuan = y.MaDeChuan;
                dt.MaDeTron = y.MaDeTron;
                dt.TenDeTron = y.TenDeTron;
                ldt.Add(dt);
            }
            return ldt;
        }
        public bool PhanDeChoThiSinh(int idcathichitiet)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@macathi",idcathichitiet)
                };
                int res = db.Database.ExecuteSqlCommand("PhanDeThiChoThiSinh @macathi", valparams);
                db.SaveChanges();
                return true;
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
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    } 
}
