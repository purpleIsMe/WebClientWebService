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

namespace WebClientService.Areas.Client.Controllers
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
        ////ham lay link tu url bat ki
        //public string GetWebContent(string strLink)
        //{
        //    string strContent = "";
        //    try
        //    {
        //        WebRequest objWebRequest = WebRequest.Create(strLink);
        //        objWebRequest.Credentials = CredentialCache.DefaultCredentials;
        //        WebResponse objWebResponse = objWebRequest.GetResponse();
        //        Stream receiveStream = objWebResponse.GetResponseStream();
        //        StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
        //        strContent = readStream.ReadToEnd();
        //        objWebResponse.Close();
        //        readStream.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    return strContent;
        //}
        ////phan tich lay phan tieu de
        //public string LayTieuDe(string Content)
        //{
        //    string pattern = "<H1 class=Title>[^<]+";
        //    Regex Title = new Regex(pattern);
        //    Match m = Title.Match(Content);
        //    if (m.Success)
        //        return m.Value.Substring(16, m.Value.Length - 16);
        //    return "";
        //}
        ////lay phan mo ta
        //public string LayMoTa(string Content)
        //{
        //    string pattern = "<H2 class=Lead>[^<]+";
        //    Regex Title = new Regex(pattern);
        //    Match m = Title.Match(Content);
        //    if (m.Success)
        //        return m.Value.Substring(15, m.Value.Length - 15);
        //    return "";
        //}
        ////lay phan noi dung
        //public string LayNoiDung(string Content)
        //{
        //    string pattern = "<P class=Normal>[^~]+";
        //    Regex Title = new Regex(pattern);
        //    Match m = Title.Match(Content);
        //    if (m.Success)
        //        return m.Value.Substring(16, m.Value.Length - 16).Replace("/Files", "http://vnexpress.net/Files").Replace("/gl", "http://vnexpress.net/gl");
        //    return "";
        //}
      
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
                var linkImage = "http://tgu.edu.vn"+Image.Attributes["src"].Value;
                var linkNode = item.SelectSingleNode(".//div[contains(@class,'title_news')]/a");
                var link = "http://tgu.edu.vn"+linkNode.Attributes["href"].Value;
                var text = linkNode.InnerText;
                var datePost = item.SelectSingleNode(".//div[@class='date']").InnerText;
                DateTime date = DateTime.Parse(datePost.Remove(0,11));
                var content = item.SelectSingleNode(".//div[@class='content']").InnerText;
                items.Add(new Post() { Alias = link,
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