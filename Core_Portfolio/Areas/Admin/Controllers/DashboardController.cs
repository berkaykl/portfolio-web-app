using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EfToDoListDal());
        public IActionResult Index()
        {
            ViewData["WebTitle"] = "Yönetim Paneli - Admin";
            return View();
        }

        [HttpPost]
        public IActionResult AddToDoItem(ToDoList p)
        {
            toDoListManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        [HttpPost]
        public IActionResult DeleteToDoItem(int id)
        {
            var deletedValue = toDoListManager.TGetById(id);

            if (deletedValue != null)
            {
                toDoListManager.TDelete(deletedValue);
            }
            
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateToDoStatus([FromBody] ToDoList updatedItem)
        {
            var todo = toDoListManager.TGetById(updatedItem.ToDoListID);
            if (todo != null)
            {
                todo.Status = updatedItem.Status;
                toDoListManager.TUpdate(todo);
                return Ok();
            }

            return NotFound();
        }

    }
}
