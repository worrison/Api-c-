using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.utils;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class toDoController : ControllerBase
    {
        private Store store = Store.Instance;
        [HttpGet]
        public List<TodoItem> getTodos()
        {
            return this.store.todos;
        }
        [HttpGet("{id}")]
        public TodoItem getTodoItem(long id)
        {
            return this.store.todos.Find(todo => todo.Id == id);
        }

        [HttpGet("busqueda/{name}")]
        public List<TodoItem> getTodoItemName(string name)
        {
            return this.store.todos.FindAll(todo => todo.Name.Contains(name));
        }

        [HttpGet("done")]
        public List<TodoItem> getTodoComplete()
        {
            return this.store.todos.FindAll(todo => todo.IsComplete);
        }

        [HttpPost]
        public TodoItem PostTodo(TodoItem item)
        {
            item.Id = store.todos.Count;
            this.store.todos.Add(item);
            return item;
        }
        [HttpDelete("{id}")]
        public void delete(long id ){
            this.store.todos.Remove(this.store.todos.Find(todo => todo.Id == id));
            
        }


    }

}