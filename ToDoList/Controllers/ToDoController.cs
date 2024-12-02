using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        // Constructor with Dependency Injection
        public ToDoController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // POST: api/ToDo
        [HttpPost]
        public IActionResult AddToDoItem([FromBody] ToDoItem toDoItem)
        {
            if (string.IsNullOrEmpty(toDoItem.Title))
            {
                return BadRequest("Title cannot be empty.");
            }

            _databaseService.AddTask(toDoItem.Title, toDoItem.Status);

            return CreatedAtAction(nameof(AddToDoItem), new { id = toDoItem.Id }, toDoItem);
        }

        // GET: api/ToDo
        [HttpGet]
        public IActionResult GetAllToDoItems()
        {
            var tasks = _databaseService.GetTasks();
            return Ok(tasks);
        }

        // GET: api/ToDo/{id}
        [HttpGet("{id}")]
        public IActionResult GetToDoItemById(int id)
        {
            var task = _databaseService.GetTaskById(id);
            if (task == null)
            {
                return NotFound($"No task found with ID {id}.");
            }

            return Ok(task);
        }

        // PUT: api/ToDo/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateToDoItem(int id, [FromBody] ToDoItem toDoItem)
        {
            var existingTask = _databaseService.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound($"No task found with ID {id}.");
            }

            _databaseService.UpdateTask(id, toDoItem.Title, toDoItem.Status);
            return Ok($"Task with ID {id} updated successfully.");
        }

        // DELETE: api/ToDo/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoItem(int id)
        {
            var existingTask = _databaseService.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound($"No task found with ID {id}.");
            }

            _databaseService.DeleteTask(id);
            return Ok($"Task with ID {id} deleted successfully.");
        }
    }
}
