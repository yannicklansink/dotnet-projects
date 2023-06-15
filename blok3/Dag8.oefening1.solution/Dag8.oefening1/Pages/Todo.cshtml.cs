using Dag8.oefening1.Repo;
using Dag8.oefening1.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dag8.oefening1.Pages
{
    public class TodoModel : PageModel
    {

        private readonly ITodoRepository _todoRepository;

        [BindProperty]
        public Todo NewTodo { get; set; }

        public TodoModel(ITodoRepository todoRepository) // dependency injection again?
        {
            _todoRepository = todoRepository;
        }

        public IActionResult OnGet(int id)
        {
            NewTodo = _todoRepository.Get(id);

            if (NewTodo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
