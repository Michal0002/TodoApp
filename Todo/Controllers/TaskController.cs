using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
