using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class StudentDAO
    {
        WebClientDbContext dataContext = null;
        public StudentDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public bool AddStudent(Student Student)
        {
            try
            {
                dataContext.Students.Add(Student);
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
        public bool UpdateStudent(Student StudentDAO)
        {
            try
            {
                Student u = dataContext.Students.Where(p => p.ID == StudentDAO.ID).SingleOrDefault();
                u.Name = StudentDAO.Name;
                u.UserName = StudentDAO.UserName;
                u.Password = StudentDAO.Password;
                u.Mobile = StudentDAO.Mobile;
                u.Born = StudentDAO.Born;
                u.Address = StudentDAO.Address;
                u.Position = StudentDAO.Position;
                u.Mobile = StudentDAO.Mobile;
                u.Email = StudentDAO.Email;
                u.Active = StudentDAO.Active;
                u.IDClass = StudentDAO.IDClass;
                u.Status = StudentDAO.Status;
                u.Gender = StudentDAO.Gender;
                u.CMND = StudentDAO.CMND;
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
        public bool DeleteStudent(int id)
        {
            try
            {
                Student u = dataContext.Students.Single(p => p.ID == id);
                dataContext.Students.Remove(u);
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
        public List<Student> FiltStudent(int idlecturer)
        {
            List<Student> x = dataContext.Students.Where(i => i.IDLecturer == idlecturer).ToList();
            return x;
        }
        public List<Student> FiltStudentByClass(int idclass)
        {
            List<Student> x = dataContext.Students.Where(i => i.IDClass == idclass).ToList();
            return x;
        }
        public Student ViewDetailStudent(int id)
        {
            Student y = dataContext.Students.Where(i => i.ID == id).SingleOrDefault();
            return y;
        }
        public bool ConvertStudentToThiSinh(int idcathichitiet, int idclass)
        {
            try
            {
                object[] valparams =
                {
                    new SqlParameter("@IDClass",idclass),
                    new SqlParameter("@IDCaThiChiTiet",idcathichitiet)
                };
                int res = dataContext.Database.ExecuteSqlCommand("convertStudentToThiSinh @IDClass,@IDCaThiChiTiet", valparams);
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
        
    }
}
