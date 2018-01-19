using Model.EF;
using PagedList;
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
    public class StudentDAO
    {
        WebClientDbContext dataContext = null;
        public StudentDAO()
        {
            dataContext = new WebClientDbContext();
        }
        public IEnumerable<Student> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<Student> x = dataContext.Students.OrderBy(m => m.ID).ToPagedList(page, pageSize);
            CloseConnect();
            return x;
        }
        public int AddStudent(Student Student)
        {
            try
            {
                dataContext.Students.Add(Student);
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
            return Student.ID;
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
                u.Skype = StudentDAO.Skype;
                u.Email = StudentDAO.Email;
                u.Facebook = StudentDAO.Facebook;
                u.Active = StudentDAO.Active;
                u.CreateDate = DateTime.Now;
                u.IDClass = StudentDAO.IDClass;
                u.Status = StudentDAO.Status;
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
        public Student ViewDetailStudent(int id)
        {
            Student y = dataContext.Students.Where(i => i.ID == id).SingleOrDefault();
            return y;
        }
    }
}
