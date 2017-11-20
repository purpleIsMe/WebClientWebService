using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DeChuanQuestionDAO
    {
        WebClientDbContext db = null;
        public DeChuanQuestionDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<DeChuanQuestion> GetListAll()
        {
            IEnumerable<DeChuanQuestion> y = db.DeChuanQuestions.ToList();
            CloseConnect();
            return y;
        }
        public bool UpdateDeChuanQuestion(DeChuanQuestion PQ)
        {
            try
            {
                DeChuanQuestion u = db.DeChuanQuestions.Where(p => p.IDAuto == PQ.IDAuto).SingleOrDefault();
                u.MaDe = PQ.MaDe;
                u.QuesID = PQ.QuesID;
                u.QID = PQ.QID;
                db.SaveChanges();
                CloseConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDeChuanQuestion(int id)
        {
            try
            {
                DeChuanQuestion u = db.DeChuanQuestions.Single(p => p.IDAuto == id);
                db.DeChuanQuestions.Remove(u);
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
