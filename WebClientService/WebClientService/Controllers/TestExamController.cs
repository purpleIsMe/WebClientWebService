using Model.DAO;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RTE;
using System.Linq;

namespace WebClientService.Controllers
{
    public class TestExamController : Controller
    {
        // GET: TestExam
        public ActionResult Index()
        {

            //AllQuestionDTO xy = new QuestionDAO().getOneQuestion(78);

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
            var xy = new QuestionDAO().getAllQuestionDeTron(id);
            int sl = xy.Count;
            return Json(xy, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    result = xy,
            //    count = sl
            //});
        }
    }
}