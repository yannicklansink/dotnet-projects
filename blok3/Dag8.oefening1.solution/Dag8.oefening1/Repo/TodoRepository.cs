using Dag8.oefening1.Dal;
using Dag8.oefening1.Models;

namespace Dag8.oefening1.Repo
{
    public class TodoRepository : ITodoRepository
    {

        private readonly TodoContext _context;

        public TodoRepository(TodoContext context) 
        {
            _context = context;
        }

        public Todo Add(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges(); // genereert Id
            return todo; // why return?
        }

        public Todo? Get(int id)
        {
            return _context.Todos.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }
    }
}
