using Model.DAO;
using Model.DTO;
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
            //AllQuestionDTO xy = new QuestionDAO().getOneQuestion(8);

            //byte[] Ans4 = xy.PicAns4;
            //byte[] Ans3 = xy.PicAns3;
            //byte[] Ans2 = xy.PicAns2;
            //byte[] Ans1 = xy.PicAns1;
            //byte[] Ques = xy.PicQues;

            //string imreBase64Data = Convert.ToBase64String(Ans4);
            //string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            ////Passing image data in viewbag to view  
            //ViewBag.PicAns4 = imgDataURL;


            //imreBase64Data = Convert.ToBase64String(Ans3);
            //imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            ////Passing image data in viewbag to view  
            //ViewBag.PicAns3 = imgDataURL;

            //imreBase64Data = Convert.ToBase64String(Ans2);
            //imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            ////Passing image data in viewbag to view  
            //ViewBag.PicAns2 = imgDataURL;

            //imreBase64Data = Convert.ToBase64String(Ans1);
            //imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            ////Passing image data in viewbag to view  
            //ViewBag.PicAns1 = imgDataURL;

            //imreBase64Data = Convert.ToBase64String(Ques);
            //imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            ////Passing image data in viewbag to view  
            //ViewBag.PicQues = imgDataURL;


            return View();
        }
        [HttpGet]
        public ActionResult getQuestion(int id)
        {
            string imreBase64Data, imgDataURL;
            var xy = new QuestionDAO().getAllQuestionDeTron(id);
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
        [HttpGet]
        public ActionResult getInfo()
        {
            var x = (ThiSinhLogin)Session[Constants.THISINH_SESSION];
            var ts = new ThiSinhDAO().ViewDetailTHISINH(x.ThiSinhID);
            
            return Json(ts, JsonRequestBehavior.AllowGet);
        }
    }
}