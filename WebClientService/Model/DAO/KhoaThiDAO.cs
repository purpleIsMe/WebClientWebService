using DevExpress.Office.Utils;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class KHOATHIDAO
    {
        WebClientDbContext dataContext = null;
        public KHOATHIDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public bool AddKHOATHI(KHOATHI KHOATHI)
        {
            try
            {
                dataContext.KHOATHIs.Add(KHOATHI);
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
        public bool UpdateKHOATHI(KHOATHI KHOATHIDAO)
        {
            try
            {
                KHOATHI u = dataContext.KHOATHIs.Where(p => p.id == KHOATHIDAO.id).SingleOrDefault();
                u.MaKhoaThi = KHOATHIDAO.MaKhoaThi;
                u.TenKhoaThi = KHOATHIDAO.TenKhoaThi;
                u.TrangThai = KHOATHIDAO.TrangThai;
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
        public bool DeleteKHOATHI(int id)
        {
            try
            {
                KHOATHI u = dataContext.KHOATHIs.Single(p => p.id == id);
                dataContext.KHOATHIs.Remove(u);
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
        public List<KHOATHI> DsKhoaThi()
        {
            return dataContext.KHOATHIs.ToList();
        }
        public KHOATHI getInfoKHOATHI(int id)
        {
            return dataContext.KHOATHIs.Where(p => p.id == id).SingleOrDefault();
        }
    }
}
