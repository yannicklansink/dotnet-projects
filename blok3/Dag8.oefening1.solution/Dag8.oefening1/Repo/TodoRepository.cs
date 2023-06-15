using Dag8.oefening1.Dal;
using Dag8.oefening1.Shared.Models;

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
            return todo; 
        }

        public Todo? Get(int id)
        {
            return _context.Todos.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }

        public void Delete(int id)
        {
            var todo = _context.Todos.SingleOrDefault(x => x.Id == id);

            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
        }

        public Todo Update(Todo todoToUpdate)
        {
            var existingTodo = _context.Todos.SingleOrDefault(x => x.Id == todoToUpdate.Id);

            if (existingTodo != null)
            {
                existingTodo.Title = todoToUpdate.Title;
                existingTodo.UitersteDatum = todoToUpdate.UitersteDatum;
                existingTodo.Description = todoToUpdate.Description;
                existingTodo.IsDone = todoToUpdate.IsDone;

                _context.SaveChanges();

                return existingTodo;
            }

            return null;
        }

        public IEnumerable<Todo> SearchTodos(string searchTerm)
        {
            return _context.Todos
                .Where(todo => todo.Title.Contains(searchTerm) || todo.Description.Contains(searchTerm))
                .ToList();
        }


    }
}
