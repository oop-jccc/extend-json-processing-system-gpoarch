using dynamic_json.Models;
using Newtonsoft.Json.Linq;

namespace dynamic_json.JsonProcessors;

public class TodoItemProcessor : IJsonProcessor
{
    // "{\"Title\":\"Buy groceries\",\"IsCompleted\":false}"
    public bool CanProcess(JObject json)
    {
        return json.ContainsKey(nameof(TodoItem.Title)) && json.ContainsKey(nameof(TodoItem.IsCompleted));
    }

    public object? Process(JObject json)
    
    {
        if (!CanProcess(json)) return null;

        var todoItem = json.ToObject<TodoItem>();
    
        return todoItem with { IsCompleted = true};
    }
     
}


