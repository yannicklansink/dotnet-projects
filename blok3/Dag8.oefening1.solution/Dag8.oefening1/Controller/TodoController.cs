using Dag8.oefening1.Shared.Models;
using Dag8.oefening1.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Dag8.oefening1.Controller
{

    [Route("api/todos")]
    [ApiController] // magic binding of modelstate :O -> geeft ook foutmelding terug
    public class TodoController : ControllerBase
    {

        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetById(int id)
        {
            if (id == null)
            {
                return NotFound(); // statuscode 404 - not found
            }
            return _todoRepository.Get(id);
        }

        [HttpPost]
        public IActionResult Post(Todo newTodo)
        {
            if (newTodo == null)
            {
                return BadRequest("Todo item is null"); // status code 400 - Bad Request
            }
            _todoRepository.Add(newTodo);
            return StatusCode(201, newTodo); // statuscode 201 - created
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null)
            {
                return NotFound(); // status code 404 - not found
            }

            _todoRepository.Delete(id);
            return NoContent(); // status code 204 - no content
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, Todo updatedTodo)
        {
            if (id != updatedTodo.Id)
            {
                return BadRequest(); // status code 400 - Bad Request
            }

            var existingTodo = _todoRepository.Get(id);
            if (existingTodo == null)
            {
                return NotFound(); // status code 404 - Not Found
            }

            var result = _todoRepository.Update(updatedTodo);

            if (result == null)
            {
                return NotFound(); // status code 404 - Not Found, if the item was not found to update.
            }
            else
            {
                return Ok(result); // status code 200 - OK
            }
        }



    }
}
