using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebAssignmentClient.Controllers
{
    public class PostContentController : Controller
    {
        public User User { get; set; }

        public IActionResult Index()
        {
            return View(User);
        }
    }
}