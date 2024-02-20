using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    public class TaskController : Controller
    {
        TaskDAO taskDAO = new TaskDAO();

        public IActionResult Index()
        {
            return View(taskDAO.GetAllTasks());
        }

        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    taskDAO.Create(task);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Wystąpił błąd podczas tworzenia zadania.");
                }
            }
            return View(task);
        }
    }
}
