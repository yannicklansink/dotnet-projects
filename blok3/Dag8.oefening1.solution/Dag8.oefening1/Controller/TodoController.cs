using Dag8.oefening1.Models;
using Dag8.oefening1.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Dag8.oefening1.Controller
{

    [Route("api/todos")]
    [ApiController] // magic binding of modelstate :O
    public class TodoController : ControllerBase
    {

        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet("")]
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
            _todoRepository.Add(newTodo);
            return StatusCode(201, newTodo); // statuscode 201 - created

        }



    }
}
