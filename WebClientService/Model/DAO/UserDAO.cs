using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using PagedList.Mvc;
using PagedList;

namespace Model.DAO
{
    public class UserDAO
    {
        WebClientDbContext db = null;
        public UserDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<User> x =  db.Users.OrderBy(m=>m.ID).ToPagedList(page,pageSize);
            return x;
        }
        public List<User> ViewAll()
        {
            List<User> x = db.Users.ToList();
            return x;
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
                u.CreateDate = DateTime.Now;
                u.Status = userDAO.Status;
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
        public void CloseConnect()
        {
            db.Dispose();
        }
        
        //dang nhap bang usernam or mail
        public int LogIn(string UserName, string passWord, string loaiUser)
        {
            var result = db.Users.Where(x => x.UserName == UserName).SingleOrDefault();
            if (loaiUser == "Mail")
                result = db.Users.Where(x => x.Email == UserName).SingleOrDefault();                 
            if (result == null)
            {
                return 3;//tai khoan khong ton tai
            }
            if (result != null)
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
        public User getByUsername(string username, string loaiuser)
        {
            var res = db.Users.Where(x => x.UserName == username).SingleOrDefault();
            if (loaiuser == "Mail")
                res = db.Users.Where(x => x.Email == username).SingleOrDefault();
            return res;
        }
        public User getIDByUserName(string user)
        {
            User x = db.Users.SingleOrDefault(p => p.UserName == user);
            return x;
        }
        public User ViewDetailAll(int id)
        {
            User x= db.Users.Find(id);
            return x;
        }
        public User ViewDetailSingle(int id)
        {
            User x = db.Users.SingleOrDefault(p => p.ID == id);
            return x;
        }
        public List<User> ViewListForIDPQ(int idphanquyen)
        {
            List<User> x = db.Users.Where(p => p.IDPhanQuyen == idphanquyen).ToList();
            return x;
        }
        public bool UpdateActive(User dao)
        {
            User x = db.Users.Where(l => l.ID == dao.ID).SingleOrDefault();
            if(x!=null)
            {
                x.Active = dao.Active;
                x.Status = dao.Status;
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
