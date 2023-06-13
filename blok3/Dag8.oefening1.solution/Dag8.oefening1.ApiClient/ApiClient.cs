using Dag8.oefening1.Shared.Models;
using Flurl;
using Flurl.Http;




var todos = await "https://localhost:7185/api/todos".GetJsonAsync<IEnumerable<Todo>>();
foreach (var todo in todos)
{
    Console.WriteLine($"{todo.Title} moet af zijn voor: {todo.UitersteDatum}");
}
