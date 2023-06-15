using Dag8.oefening1.Shared.Models;

namespace Dag8.oefening1.Repo
{
    public interface ITodoRepository
    {
        Todo Add(Todo todo);
        Todo? Get(int id);
        IEnumerable<Todo> GetAll();
        public void Delete(int id);
        public Todo Update(Todo todoToUpdate);
        IEnumerable<Todo> SearchTodos(string searchTerm);


    }
}
