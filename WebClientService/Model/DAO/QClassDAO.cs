using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

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
        public List<QClass> listWithIDSubInt(int idsub)
        {
            Guid idSubject = db.Subjects.Where(p => p.idSub == idsub).Select(i=>i.SubjectID).SingleOrDefault();
            return db.QClasses.Where(l => l.SubjectID == idSubject).ToList();
        }
        public QClass singleIDQClassInt(int idqclass)
        {
            return db.QClasses.Where(p => p.idQClass == idqclass).SingleOrDefault();
        }
        public bool AddQClass(QClass PQ)
        {
            try
            {
                if(PQ.ChuThich == null)
                {
                    PQ.ChuThich = "Module mới";
                }
                object[] valparams = 
                {
                    new SqlParameter("@ClassID",PQ.ClassID),
                    new SqlParameter("@SubjectID",PQ.SubjectID),
                    new SqlParameter("@Descr",PQ.Descr),
                    new SqlParameter("@ClassNbr",PQ.ClassNbr),
                    new SqlParameter("@ChuThich",PQ.ChuThich),
                    new SqlParameter("@TrangThai",PQ.TrangThai)
                };
                int res = db.Database.ExecuteSqlCommand("Insert_module @ClassID, @SubjectID, @ClassNbr, @Descr, @ChuThich, @TrangThai", valparams);
                db.SaveChanges();
                if (res == 1)
                    return true;
                else
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
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public bool UpdateQClass(QClass PQ)
        {
            try
            {
                QClass u = db.QClasses.Where(p => p.idQClass == PQ.idQClass).SingleOrDefault();
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
        public bool DeleteQClass(int id)
        {
            try
            {
                QClass u = db.QClasses.Single(p => p.idQClass == id);
                db.QClasses.Remove(u);
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
