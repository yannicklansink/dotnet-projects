using Dag8.oefening1.Shared.Models;
using Dag8.oefening1.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Drawing.Drawing2D;

namespace Dag8.oefening1.Pages
{
    public class IndexModel : PageModel
    {

        public List<Todo> TodoList { get; set; }
        private readonly ITodoRepository _todoRepository;

        [BindProperty]
        public Todo NewTodo { get; set; }

        // The SupportsGet property of the[BindProperty] attribute is a boolean
        // that indicates whether or not the property should also be bound when
        // the HTTP request is of type GET.By default, [BindProperty] binds properties
        // only for POST requests, as it is commonly used for form submissions.
        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "asc";
        [BindProperty(SupportsGet = true)]
        public string SortColumn { get; set; } = "Id";

        public IndexModel(ITodoRepository todoRepository) // dependency injection again?
        {
            _todoRepository = todoRepository;
        }

        public void OnGet()
        {
            IEnumerable<Todo> todos = _todoRepository.GetAll();

            // Apply sorting
            switch (SortColumn)
            {
                case "Id":
                    todos = SortOrder == "asc" ? todos.OrderBy(t => t.Id) : todos.OrderByDescending(t => t.Id);
                    break;
                case "Description":
                    todos = SortOrder == "asc" ? todos.OrderBy(t => t.Description) : todos.OrderByDescending(t => t.Description);
                    break;
            }

            TodoList = todos.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TodoList = _todoRepository.GetAll().ToList();
                return Page();
            }

            _todoRepository.Add(NewTodo);
            return RedirectToPage(); // redirect naar GET-endpoint 
        }

        public IActionResult OnPostDelete(int id)
        {
            _todoRepository.Delete(id);
            return RedirectToPage();
        }

    }
}
