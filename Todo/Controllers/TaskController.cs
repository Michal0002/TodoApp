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

        public IActionResult Edit(int id)
        {
            TaskModel foundItem = taskDAO.GetElementById(id);
            return View("ShowEdit", foundItem);
        }

        public IActionResult ShowEdit(TaskModel task)
        {
            taskDAO.Update(task);
            return View("Index", taskDAO.GetAllTasks());
        }

        public IActionResult Details(int id)
        {
            TaskModel foundItem = taskDAO.GetElementById(id);
            return View(foundItem);
        }
        public IActionResult Delete(int id)
        {
            taskDAO.Delete(id);
            return View("Index", taskDAO.GetAllTasks());
        }
    }
}
