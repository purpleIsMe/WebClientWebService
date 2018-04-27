using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;


namespace Model.DAO
{
    public class ClassDAO
    {
        WebClientDbContext dataContext = null;
        public ClassDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public bool AddClass(Class Class)
        {
            try
            {
                dataContext.Classes.Add(Class);
                dataContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Debug.Write(e.ToString());
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
        public List<Class> ClassesNoneLecturer()
        {
            return dataContext.Classes.ToList();
        }
        public Class getInfoClass(int id)
        {
            return dataContext.Classes.Where(p => p.IDClass == id).SingleOrDefault();
        }
    }
}
