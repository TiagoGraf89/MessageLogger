using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About(ApplicationModel model)
        {
            return View(model);
        }

        [Authorize]
        public ActionResult Message()
        {
            var levelList = new List<SelectListItem>();
            levelList.Add(new SelectListItem() { Text = "Error", Value = "Error" });
            levelList.Add(new SelectListItem() { Text = "Information", Value = "Information" });
            levelList.Add(new SelectListItem() { Text = "Warning", Value = "Warning" });
            levelList.Add(new SelectListItem() { Text = "Critical", Value = "Critical" });

            ViewBag.LevelList = levelList;

            return View();
        }

        [Authorize]
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Message(MessageViewModel model)
        {
            var ctx = HttpContext.GetOwinContext();
            ClaimsPrincipal user = ctx.Authentication.User;
            IEnumerable<Claim> claims = user.Claims;
            var token = claims.Where(c => c.Type == "token").Select(c=> c.Value).First();
            model.Application_Id = User.Identity.Name;

            var helper = new Helper.WebApiHelper();
            try
            {
                var response = await helper.PostMessageLog(model, token);
                if (response != null && response.Success)
                    ViewBag.Message = "Message logged successfully!";
                else
                    ViewBag.Message = "Message couldn't be logged!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return Message();
        }

    }
}