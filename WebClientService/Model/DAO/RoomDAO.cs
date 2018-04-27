using DevExpress.Office.Utils;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Model.DAO
{
    public class RoomDAO
    {
        WebClientDbContext dataContext = null;
        public RoomDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public bool AddRoom(PHONG PHONG)
        {
            try
            {
                dataContext.PHONGs.Add(PHONG);
                dataContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Debug.WriteLine(e.ToString());
                return false;
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
            return true;
        }
        public bool UpdateRoom(PHONG PHONGDAO)
        {
            try
            {
                PHONG u = dataContext.PHONGs.Where(p => p.id == PHONGDAO.id).SingleOrDefault();
                u.TenPhong = PHONGDAO.TenPhong;
                u.SoLuongMay = PHONGDAO.SoLuongMay;
                u.GhiChu = PHONGDAO.GhiChu;
                u.TrangThai = PHONGDAO.TrangThai;
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
        public bool DeleteRoom(int id)
        {
            try
            {
                PHONG u = dataContext.PHONGs.Single(p => p.id == id);
                dataContext.PHONGs.Remove(u);
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
        public List<PHONG> ListRoom()
        {
            return dataContext.PHONGs.ToList();
        }
        public PHONG getInfoRoom(int id)
        {
            return dataContext.PHONGs.Where(p => p.id == id).SingleOrDefault();
        }
    }
}
