using Microsoft.AspNetCore.Mvc;

namespace BlogWebAssignmentClient.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}