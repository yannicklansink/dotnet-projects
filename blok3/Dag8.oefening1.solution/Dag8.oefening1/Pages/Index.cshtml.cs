using Dag8.oefening1.Models;
using Dag8.oefening1.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dag8.oefening1.Pages
{
    public class IndexModel : PageModel
    {

        public List<Todo> TodoList { get; set; }
        private readonly ITodoRepository _todoRepository;

        public IndexModel(ITodoRepository todoRepository) // dependency injection again?
        {
            _todoRepository = todoRepository;
        }




        //public static List<Todo> Todoos { get; set; } = new List<Todo>()
        //{
        //    new Todo
        //    {
        //        Id = 4,
        //        Title = "afwas",
        //        UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52),
        //        Description = "Doe de afwas",
        //        IsDone = false,
        //    },
        //    new Todo
        //    {
        //        Id = 6,
        //        Title = "afwas",
        //        UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52),
        //        Description = "Doe de afwas2",
        //        IsDone = false,
        //    },
        //    new Todo
        //    {
        //        Id = 8,
        //        Title = "afwas",
        //        UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52),
        //        Description = "Doe de afwas3",
        //        IsDone = false,
        //    },
        //};

        [BindProperty]
        public Todo NewTodo { get; set; }

        public void OnGet(string? action, int? id)
        {
            TodoList = _todoRepository.GetAll().ToList();

            if (id.HasValue)
            {
                var todo = TodoList.SingleOrDefault(x => x.Id == id);
                if (todo != null)
                {
                    TodoList.Remove(todo);
                }

            }
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


        public void OnPostAdd()
        {
            Console.WriteLine("Methode OnPostAdd() uitgevoerd");
        }

    }
}
