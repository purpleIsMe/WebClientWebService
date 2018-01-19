using Model.DAO;
using Model.DTO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientService.Areas.Admin.Controllers
{
    public class TestExamController:Controller
    {
        // GET: Admin/TestExam
        public ActionResult Index(int id)
        {
            getQuestion(id);
            return View();
        }
        public void getQuestion(int iddetron)
        {
            List<AllQuestionDTO> xy = new QuestionDAO().getAllQuestionDeTron(iddetron);
            foreach (var item in xy)
            {
                byte[] k = item.Question;

                System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
                string s_unicode2 = System.Text.Encoding.UTF8.GetString(k);
                item.quesex = s_unicode2;
            }
            //ViewBag.ListQues = xy.Select(p => p.Question);
            //ViewBag.ListAns1 = xy.Select(l => l.Answer1);
            //ViewBag.ListAns2 = xy.Select(u => u.Answer2);
            //ViewBag.ListAns3 = xy.Select(k => k.Answer3);
            //ViewBag.ListAns4 = xy.Select(o => o.Answer4);
            ViewBag.ListQues = xy;
        }

    }
}