using Microsoft.AspNetCore.Mvc;  
using TodoApi.DataAccess;  
using TodoApi.Models;  
using System;  
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemDAO _dataAccessProvider;

        public TodoItemsController(ITodoItemDAO dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _dataAccessProvider.GetTodoItems();
        }

        [HttpPost]
        public IActionResult Create([FromBody]TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                todoItem.id = obj.ToString();
                _dataAccessProvider.AddTodoItem(todoItem);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]  
        public TodoItem Details(string id)  
        {  
            return _dataAccessProvider.GetTodoItem(id);  
        }  
  
        [HttpPut]  
        public IActionResult Edit([FromBody]TodoItem todoItem)  
        {  
            if (ModelState.IsValid)  
            {  
                _dataAccessProvider.UpdateTodoItem(todoItem);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpDelete("{id}")]  
        public IActionResult DeleteConfirmed(string id)  
        {  
            var data = _dataAccessProvider.GetTodoItem(id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
            _dataAccessProvider.DeleteTodoItem(id);  
            return Ok();  
        }
    }
}