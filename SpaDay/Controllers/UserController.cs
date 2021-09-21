using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("spa/user/add")]
        public IActionResult Add()
        {
            ViewBag.error = false;
            return View();
        }

        [HttpPost("/User")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            // Form submission handling code here
            ViewBag.user = newUser.Username;
            ViewBag.email = newUser.Email;
            ViewBag.date = newUser.Date.ToLongDateString();
            if (newUser.Password == verify)
            {
                ViewBag.error = false;
                return View("Index");
            }
            else
            {
                ViewBag.error = true;
                return View("Add");
            }
        }
    }
}