using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebAssignmentClient.Controllers
{
    public class PostContentController : Controller
    {
        public User Author { get; set; }

        public IActionResult Index()
        {
            return View(Author);
        }
    }
}