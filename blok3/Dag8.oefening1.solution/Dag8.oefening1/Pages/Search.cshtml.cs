using Dag8.oefening1.Repo;
using Dag8.oefening1.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dag8.oefening1.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        public SearchModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [BindProperty]
        public string SearchTerm { get; set; }

        public List<Todo> SearchResults { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                SearchResults = (List<Todo>)_todoRepository.SearchTodos(SearchTerm);
            }
        }
    }
}
