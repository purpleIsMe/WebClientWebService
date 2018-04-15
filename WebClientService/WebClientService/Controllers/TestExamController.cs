using Model.DAO;
using Model.DTO;
using Model.EF;
using System;
using System.Web.Mvc;
using WebClientService.Common;

namespace WebClientService.Controllers
{
    public class TestExamController : BaseController
    {
        // GET: TestExam
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult getQuestion()
        {
            var x1 = (ThiSinhLogin)Session[Constants.THISINH_SESSION];
            var ts = new ThiSinhDAO().ViewDetailTHISINH(x1.ThiSinhID);
            string imreBase64Data, imgDataURL;
            var xy = new QuestionDAO().getAllQuestionDeTron(ts.MaDeThi);
            foreach (var x in xy)
            {
                imreBase64Data = Convert.ToBase64String(x.PicQues);
                imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                x.sQues = imgDataURL;
                x.PicQues = null;

                imreBase64Data = Convert.ToBase64String(x.PicAns1);
                imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                x.sAns1 = imgDataURL;
                x.PicAns1 = null;

                imreBase64Data = Convert.ToBase64String(x.PicAns2);
                imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                x.sAns2 = imgDataURL;
                x.PicAns2 = null;

                imreBase64Data = Convert.ToBase64String(x.PicAns3);
                imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                x.sAns3 = imgDataURL;
                x.PicAns3 = null;

                imreBase64Data = Convert.ToBase64String(x.PicAns4);
                imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                x.sAns4 = imgDataURL;
                x.PicAns4 = null;
            }

            int sl = xy.Count;
            ViewBag.SL = sl;
            return Json(xy, JsonRequestBehavior.AllowGet);
        }
        int id;
        [HttpGet]
        public ActionResult getInfo()
        {
            var x = (ThiSinhLogin)Session[Constants.THISINH_SESSION];
            var ts = new ThiSinhDAO().ViewDetailTHISINH(x.ThiSinhID);
            id = ts.MaDeThi;
            return Json(ts, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult saveAns(AnswerSheetTS a)
        {
            AnswerDAO dao = new AnswerDAO();
            AnswerSheet ans = new AnswerSheet();
            Answer an = new Answer();
            var l = (ThiSinhLogin)Session[Constants.THISINH_SESSION];
            int ida = dao.FindIDAnswer(l.ThiSinhID);
            bool x = true, y = true;
            //request data from json save answer
            an.DiemThuc = a.DiemThuc;
            an.DiemSo = a.DiemSo;
            an.ID = ida;
            x = dao.UpdateAnswerScore(an);

            //request data from json save answersheet
            for (int i = 0; i < a.answerSheet.Count; i++)
            {
                ans.RemainTime = a.RemainTime;
                ans.IDAnswer = ida;
                ans.QuestionID = a.answerSheet[i].QuestionID;
                ans.ThuTuCauHoi = a.answerSheet[i].ThuTuCauHoi;
                ans.DapAn = a.answerSheet[i].DapAn;
                ans.Answer = a.answerSheet[i].Answer;
                y = dao.AddAnswerSheet(ans);
            }
            //request datada from json save sv
            ThiSinhDAO ts = new ThiSinhDAO();
            bool m = ts.UpdateActiveTimeThiSinh(ida, a.RemainTime, true, true, null);

            bool kq = false;
            if (x == true && y == true && m==true)
                kq = true;
            return Json(new { result = kq });
        }



    }
}