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
        public List<QClass> GetListAll()
        {
            List<QClass> y = db.QClasses.ToList();
            return y;
        }
        public List<QClass> ShowAllClassNbr(int classnbr)
        {
            return db.QClasses.Where(i => i.ClassNbr == classnbr).ToList();
        }
        public List<QClass> listWithIDSub(int idsub)
        {
            return db.QClasses.Where(l => l.idsu == idsub).ToList();
        }
        public QClass singleIDQClass(int idqclass)
        {
            return db.QClasses.Where(p => p.IDQClass == idqclass).SingleOrDefault();
        }
        public IEnumerable<QClass> ListAllPaging(int page, int pageSize)
        {
            IEnumerable<QClass> x = db.QClasses.OrderBy(m => m.ClassID).ToPagedList(page, pageSize);
            return x;
        }
        public Guid AddQClass(QClass PQ)
        {
            try
            {
                db.QClasses.Add(PQ);
                db.SaveChanges();
                CloseConnect();
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
                QClass u = db.QClasses.Where(p => p.ClassID == PQ.ClassID || p.IDQClass == PQ.IDQClass).SingleOrDefault();
                u.SubjectID = PQ.SubjectID;
                u.ClassNbr = PQ.ClassNbr;
                u.Descr = PQ.Descr;
                u.ChuThich = PQ.ChuThich;
                u.TrangThai = PQ.TrangThai;
                db.SaveChanges();
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
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteQClassID(int id)
        {
            try
            {
                QClass u = db.QClasses.Single(p => p.IDQClass == id);
                db.QClasses.Remove(u);
                db.SaveChanges();
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
