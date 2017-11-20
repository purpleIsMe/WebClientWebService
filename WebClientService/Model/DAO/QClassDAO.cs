using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class QClassDAO
    {
        WebClientDbContext db = null;
        public QClassDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<QClass> GetListAll()
        {
            IEnumerable<QClass> y = db.QClasses.ToList();
            CloseConnect();
            return y;
        }
        public IEnumerable<QClass> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<QClass> x = db.QClasses.OrderBy(m => m.ClassID).ToPagedList(page, pageSize);
            CloseConnect();
            return x;
        }
        public Guid AddQClass(QClass PQ)
        {
            try
            {
                db.QClasses.Add(PQ);
                CloseConnect();
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
            return PQ.ClassID;
        }
        public bool UpdateQClass(QClass PQ)
        {
            try
            {
                QClass u = db.QClasses.Where(p => p.ClassID == PQ.ClassID).SingleOrDefault();
                u.SubjectID = PQ.SubjectID;
                u.ClassNbr = PQ.ClassNbr;
                u.Descr = PQ.Descr;
                u.ChuThich = PQ.ChuThich;
                u.TrangThai = PQ.TrangThai;
                db.SaveChanges();
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteQClass(Guid id)
        {
            try
            {
                QClass u = db.QClasses.Single(p => p.ClassID == id);
                db.QClasses.Remove(u);
                CloseConnect();
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
