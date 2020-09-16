using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.DataAccess
{
    public class TodoItemDAOImpl: ITodoItemDAO
    {
        private readonly PostgreSqlContext _context;

        public TodoItemDAOImpl(PostgreSqlContext context) 
        {
            _context = context;
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            _context.items.Add(todoItem);
            _context.SaveChanges();
        }

        public void DeleteTodoItem(string id)
        {
            var entity = _context.items.FirstOrDefault(x => x.id == id);
            _context.items.Remove(entity);
            _context.SaveChanges();
        }

        public List<TodoItem> GetTodoItems()
        {
            return _context.items.ToList();
        }

        public TodoItem GetTodoItem(string id)
        {
            return _context.items.FirstOrDefault(x => x.id == id);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            _context.items.Update(todoItem);
            _context.SaveChanges();
        }
    }
}