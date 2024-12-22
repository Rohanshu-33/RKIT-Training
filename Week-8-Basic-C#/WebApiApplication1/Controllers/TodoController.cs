using Microsoft.AspNetCore.Mvc;
using WebApiApplication1.Data;
using WebApiApplication1.Models;

namespace WebApiApplication1.Controllers
{
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoRepository _repository = new TodoRepository();

        [HttpGet("todos")]
        public IActionResult Get()
        {
            var items = _repository.GetAllItems();
            return Ok(items);
        }

        [HttpPost("addtodo")]
        public IActionResult Add(TodoItem itm)
        {
            if (itm == null || string.IsNullOrEmpty(itm.Title))
            {
                return BadRequest("Invalid Todo Item.");
            }
            TodoItem addedItem = _repository.AddItem(itm);
            return Ok(addedItem);
        }

        [HttpDelete("deletetodo/{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _repository.DeleteItem(id);
            if (!success)
            {
                return NotFound($"Todo item with id {id} don't exist.");
            }
            return NoContent();
        }
    }
}
