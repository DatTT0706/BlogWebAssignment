using Microsoft.AspNetCore.Mvc;

namespace BlogWebAssignmentClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("UserProfile");
        }
        
        public IActionResult GetUserById(int id)
        {
            return View("UserProfile");
        }
    }
}
