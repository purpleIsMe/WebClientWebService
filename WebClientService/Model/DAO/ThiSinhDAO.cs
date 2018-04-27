using DevExpress.Office.Utils;
using Model.DTO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using WebClientService.Common;

namespace Model.DAO
{
    public class ThiSinhDAO
    {
        WebClientDbContext dataContext = null;
        public ThiSinhDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public int AddTHISINH(THISINH THISINH)
        {
            try
            {
                dataContext.THISINHs.Add(THISINH);
                dataContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Debug.WriteLine(e.ToString());
                throw;
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
            return THISINH.ID;
        }
        public bool UpdateTHISINH(THISINH THISINHDAO)
        {
            try
            {
                THISINH u = dataContext.THISINHs.Where(p => p.ID == THISINHDAO.ID).SingleOrDefault();
                u.MaDuThi = THISINHDAO.MaDuThi;
                u.HoTen = THISINHDAO.HoTen;
                u.Password = THISINHDAO.Password;
                u.SDT = THISINHDAO.SDT;
                u.NgaySinh = THISINHDAO.NgaySinh;
                u.DiaChi = THISINHDAO.DiaChi;
                u.GioiTinh = THISINHDAO.GioiTinh;
                u.CMND = THISINHDAO.CMND;
                u.Email = THISINHDAO.Email;
                u.MaCaThi = THISINHDAO.MaCaThi;
                u.MaDeThi = THISINHDAO.MaDeThi;
                u.TrangThai = THISINHDAO.TrangThai;
                u.SoMay = THISINHDAO.SoMay;
                u.DaHoanThanh = THISINHDAO.DaHoanThanh;
                u.ThoiGian = THISINHDAO.ThoiGian;
                dataContext.SaveChanges();
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
        public bool DeleteTHISINH(int id)
        {
            try
            {
                THISINH u = dataContext.THISINHs.Single(p => p.ID == id);
                dataContext.THISINHs.Remove(u);
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
        public void CloseConnect()
        {
            dataContext.Dispose();
        }
        public int FindThiSinh(string maduthi, string password)
        {
            int x = -1;
            x = dataContext.THISINHs.Where(i => i.MaDuThi == maduthi && i.Password == password).Select(p => p.ID).SingleOrDefault();
            return x;
        }
        public InfoStudent ViewDetailTHISINH(int id)
        {
            InfoStudent y =
                            (from a in dataContext.THISINHs
                             join b in dataContext.DETRONs on a.MaDeThi equals b.ID
                             join c in dataContext.DECHUANs on b.MaDeChuan equals c.MaDeChuan
                             join d in dataContext.Subjects on c.MaMon equals d.SubjectID
                             where a.ID == id
                             select new InfoStudent()
                             {
                                 ID = a.ID,
                                 MaDuThi = a.MaDuThi,
                                 HoTen = a.HoTen,
                                 GioiTinh = a.GioiTinh,
                                 MaCaThi = a.MaCaThi,
                                 MaDeThi = a.MaDeThi,
                                 TrangThai = a.TrangThai,
                                 SoMay = a.SoMay,
                                 DaHoanThanh = a.DaHoanThanh,
                                 ThoiGian = a.ThoiGian,
                                 TGThi = c.ThoiGian,
                                 NgayThi = DateTime.Now,
                                 MonThi = d.Descr
                             }).SingleOrDefault();
            return y;
        }

        public bool UpdateActive(THISINH ts)
        {
            THISINH x = dataContext.THISINHs.Where(l => l.ID == ts.ID).SingleOrDefault();
            if (x != null)
            {
                x.DaHoanThanh = true;
                dataContext.SaveChanges();
                return true;
            }
            return false;
        }
        public int LogIn(string UserName, string passWord)
        {
            var result = dataContext.THISINHs.Where(x => x.MaDuThi == UserName).SingleOrDefault();

            if (result == null)
            {
                return 3;//tai khoan khong ton tai
            }
            if (result != null)
            {
                if (result.DaHoanThanh == true)
                    return 4;//tai khoan da hoan tat khoa thi
                if (Encryptor.MD5Hash(result.Password) == passWord)
                {
                    return 1;
                }
                if (result.TrangThai == false)
                    return 5;//tai khoan da bi khoa
                else
                    return 2; // mat khau khong dung
            }
            return 0;
        }
        public THISINH getIDByUserName(string user)
        {
            THISINH x = dataContext.THISINHs.SingleOrDefault(p => p.MaDuThi == user);
            return x;
        }
        public List<THISINH> showListAll()
        {
            return dataContext.THISINHs.ToList();
        }
        public List<THISINH> showListByIDCaChiTiet(int idcachitiet)
        {
            return dataContext.THISINHs.Where(i=>i.MaCaThi == idcachitiet).ToList();
        }
        public bool UpdateActiveTimeThiSinh(int idts, int tg, bool hoanthanh, bool trangthai, string somay)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@IDThiSinh",idts),
                    new SqlParameter("@TrangThai",trangthai),
                    new SqlParameter("@SoMay",somay),
                    new SqlParameter("@DaHoanThanh",hoanthanh),
                    new SqlParameter("@ThoiGian",tg)
                };
                dataContext.Database.ExecuteSqlCommand("update_thisinh @IDThiSinh, @TrangThai, @SoMay, @DaHoanThanh, @ThoiGian", valparams);
                dataContext.SaveChanges();
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
    }
}
