using System.Web.Mvc;
using WebClientService.Areas.Admin.Models;
using Model.DAO;
using WebClientService.Common;

namespace WebClientService.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                string loaiUser;
                int test = -1;
                test = model.UserName.IndexOf('@');
                if (test == -1)
                    loaiUser = "UserName";
                else
                    loaiUser = "Mail";
                int result = dao.LogIn(model.UserName, Encryptor.MD5Hash(model.Password), loaiUser);
                if (result == 1)
                {
                    var user = dao.getByUsername(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(Constants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                if(result == 4)
                {
                    ModelState.AddModelError("Fail","Tài khoản này đã bị khóa");
                }
                if(result == 3)
                {
                    ModelState.AddModelError("Fail", "Tài khoản này không tồn tại");
                }
                if(result == 2)
                {
                    ModelState.AddModelError("Fail", "Tài khoản này đang sử dụng ở một thiết bị khác");
                }
                if(result == 5)
                {
                    ModelState.AddModelError("Fail", "Mật khẩu không đúng. Xin vui lòng nhập lại");
                }
                else
                {
                    ModelState.AddModelError("Fail", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}