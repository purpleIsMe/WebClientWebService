using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class DeChuanQuestionDAO
    {
        WebClientDbContext db = null;
        public DeChuanQuestionDAO()
        {
            db = new WebClientDbContext();
        }
        public IEnumerable<DECHUAN_QUESTION> GetListAll()
        {
            IEnumerable<DECHUAN_QUESTION> y = db.DECHUAN_QUESTION.ToList();
            return y;
        }
        public bool UpdateDeChuanQuestion(DECHUAN_QUESTION PQ)
        {
            try
            {
                DECHUAN_QUESTION u = db.DECHUAN_QUESTION.Where(p => p.IDAuto == PQ.IDAuto).SingleOrDefault();
                u.MaDe = PQ.MaDe;
                u.QuestionID = PQ.QuestionID;
                u.QID = PQ.QID;
                db.SaveChanges();
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
                DECHUAN_QUESTION u = db.DECHUAN_QUESTION.Single(p => p.IDAuto == id);
                db.DECHUAN_QUESTION.Remove(u);
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
