using Model.DTO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class CaThiDAO
    {
        WebClientDbContext db = null;
        public CaThiDAO()
        {
            db = new WebClientDbContext();
        }
        public DetailSchedule getAllInfoCaThi(int idcathi)
        {
            DetailSchedule ca = (from a in db.CATHIs
                              join b in db.ChiTietCaThis on a.ID equals b.IDCa
                              join c in db.Subjects on b.SubjectID equals c.SubjectID
                              where a.ID == idcathi
                              select new DetailSchedule() {
                                  ID = a.ID,
                                  MaKhoaThi = a.MaKhoaThi,
                                  IDChiTietCa = b.ID,
                                  MaChiTietCa = b.MaChiTietCa,
                                  SubjectID = b.SubjectID,
                                  IDMon = c.idSub,
                                  NameSubject = c.Descr
                              }).SingleOrDefault();
            return ca;
        }
        public IEnumerable<CATHI> GetListCaThi()
        {
            IEnumerable<CATHI> x = db.CATHIs.ToList();
            return x;
        }
        public List<CATHI> DsCATHI()
        {
            return db.CATHIs.ToList();
        }
        public List<ChiTietCaThi> DsChiTietCaThi()
        {
            return db.ChiTietCaThis.ToList();
        }
        public CATHI getInfoCATHI(int id)
        {
            return db.CATHIs.Where(i => i.ID == id).SingleOrDefault();
        }
        public ChiTietCaThi getInfoChiTietCATHI(int idca)
        {
            return db.ChiTietCaThis.Where(i => i.IDCa == idca).SingleOrDefault();
        }
        public bool AddCATHI(CATHI CATHI)
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
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
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
        public bool AddChiTietCaThi(ChiTietCaThi ChiTietCaThi)
        {
            try
            {
                db.ChiTietCaThis.Add(ChiTietCaThi);
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
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public bool UpdateChiTietCaThi(ChiTietCaThi ChiTietCaThiDAO)
        {
            try
            {
                ChiTietCaThi u = db.ChiTietCaThis.Where(p => p.ID == ChiTietCaThiDAO.ID).SingleOrDefault();
                u.IDCa = ChiTietCaThiDAO.IDCa;
                u.MaChiTietCa = ChiTietCaThiDAO.MaChiTietCa;
                u.SubjectID = ChiTietCaThiDAO.SubjectID;
                u.TrangThai = ChiTietCaThiDAO.TrangThai;
                u.MaPhong = ChiTietCaThiDAO.MaPhong;
                u.MaGiamThi1 = ChiTietCaThiDAO.MaGiamThi1;
                u.MaGiamThi2 = ChiTietCaThiDAO.MaGiamThi2;
                u.IDDeChuan = ChiTietCaThiDAO.IDDeChuan;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteChiTietCaThi(int id)
        {
            try
            {
                ChiTietCaThi u = db.ChiTietCaThis.Single(p => p.ID == id);
                db.ChiTietCaThis.Remove(u);
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
