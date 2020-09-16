using TodoApi.Models;
using System.Collections.Generic;

namespace TodoApi.DataAccess
{
    public interface ITodoItemDAO
    {
        void AddTodoItem(TodoItem todoItem);
        void UpdateTodoItem(TodoItem todoItem);
        void DeleteTodoItem(string id);
        TodoItem GetTodoItem(string id);
        List<TodoItem> GetTodoItems();
    }
}