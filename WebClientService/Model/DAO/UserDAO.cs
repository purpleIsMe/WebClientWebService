using Model.EF;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Model.DAO
{
    public class UserDAO
    {
        WebClientDbContext db = null;
        public UserDAO()
        {
            db = new WebClientDbContext();
        }

        public int AddUser(User user)
        {
            try
            {
                db.Users.Add(user);
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
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return user.ID;
        }
        public bool UpdateUser(User userDAO)
        {
            try
            {
                User u = db.Users.Where(p => p.ID == userDAO.ID).SingleOrDefault();
                u.Name = userDAO.Name;
                u.UserName = userDAO.UserName;
                u.Password = userDAO.Password;
                u.PhanQuyen = userDAO.PhanQuyen;
                u.Mobile = userDAO.Mobile;
                u.Born = userDAO.Born;
                u.Address = userDAO.Address;
                u.Position = userDAO.Position;
                u.Mobile = userDAO.Mobile;
                u.Skype = userDAO.Skype;
                u.Email = userDAO.Email;
                u.Facebook = userDAO.Facebook;
                u.Active = userDAO.Active;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                User u = db.Users.Single(p => p.ID == id);
                db.Users.Remove(u);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //dang nhap bang usernam or mail
        public int LogIn(string UserName, string passWord, string loaiUser)
        {
            var result = db.Users.Where(x => x.UserName == UserName).SingleOrDefault();
            if(result == null)
            {
                return 3;//tai khoan khong ton tai
            }
            if(loaiUser == "Mail")
                  result = db.Users.Where(x => x.Email == UserName).SingleOrDefault();

            if(result != null)
            {
                if (result.Status == false)
                    return 4;//tai khoan dang bi khoa
                if (result.Password == passWord)
                {
                    if (result.Active)
                        return 1; //Login successful
                    else
                        return 2; //user dang su dung o mot thiet bi khac
                }
                else
                    return 5; // mat khau khong dung
            }
            return 0;
        }
        public User getByUsername(string username)
        {
            var res = db.Users.Where(x => x.UserName == username).SingleOrDefault();
            return res;
        }
        public User getIDByUserName(string user)
        {
            return db.Users.SingleOrDefault(p => p.UserName == user);
        }
    }
}
