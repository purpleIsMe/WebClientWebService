using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using Model.EF;
using PagedList;
//using WebClientService.Areas.Admin.Controllers;

namespace WebClientService.Controllers
{
    public class HomeController : Controller
    {
        // GET: Client/Home
        [HttpGet]
        public ActionResult Index()
        {
            GetContent();
            return View();
        }

        [HttpGet]
        public void GetContent()
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };

            //Load trang web, nạp html vào document
            HtmlDocument document = htmlWeb.Load("http://tgu.edu.vn/topics/?0.37.0.0");

            //Load các tag li trong tag ul
            var threadItems = document.DocumentNode.SelectNodes("//div[@id='box_catelogy']/ul[@class='cus-ul']/li").ToList();

            List<Post> items = new List<Post>();
            foreach (var item in threadItems)
            {
                //Extract các giá trị từ các tag con của tag li
                var Image = item.SelectSingleNode(".//div[contains(@class,'imgs')]/img");
                var linkImage = "http://tgu.edu.vn" + Image.Attributes["src"].Value;
                var linkNode = item.SelectSingleNode(".//div[contains(@class,'title_news')]/a");
                var link = "http://tgu.edu.vn" + linkNode.Attributes["href"].Value;
                var text = linkNode.InnerText;
                var datePost = item.SelectSingleNode(".//div[@class='date']").InnerText;
                DateTime date = DateTime.Parse(datePost.Remove(0, 11));
                var content = item.SelectSingleNode(".//div[@class='content']").InnerText;
                items.Add(new Post()
                {
                    Alias = link,
                    Name = text,
                    Image = linkImage,
                    Description = text,
                    Content = content,
                    CreatedDate = date,
                    CreateBy = "admin"
                });
            }
            ViewData["HotNews"] = items;
        }
    }
}