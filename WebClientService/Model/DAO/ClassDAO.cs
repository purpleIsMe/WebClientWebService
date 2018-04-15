using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
    public class ClassDAO
    {
        WebClientDbContext dataContext = null;
        public ClassDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public int AddClass(Class Class)
        {
            try
            {
                dataContext.Classes.Add(Class);
                dataContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Debug.Write(e.ToString());
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
            return Class.IDClass;
        }
        public bool UpdateClass(Class ClassDAO)
        {
            try
            {
                Class u = dataContext.Classes.Where(p => p.IDClass == ClassDAO.IDClass).SingleOrDefault();
                u.IDLecturer = ClassDAO.IDLecturer;
                u.NameClass = ClassDAO.NameClass;
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
        public bool DeleteClass(int id)
        {
            try
            {
                Class u = dataContext.Classes.Single(p => p.IDClass == id);
                dataContext.Classes.Remove(u);
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
        public List<Class> ClassesOfLecturer(int id)
        {
            return dataContext.Classes.Where(i => i.IDLecturer == id).ToList();
        }
    }
}
