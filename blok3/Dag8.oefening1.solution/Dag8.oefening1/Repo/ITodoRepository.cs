using Dag8.oefening1.Models;

namespace Dag8.oefening1.Repo
{
    public interface ITodoRepository
    {
        Todo Add(Todo todo);
        Todo? Get(int id);
        IEnumerable<Todo> GetAll();

    }
}
