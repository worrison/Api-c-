using System.Collections.Generic;
using Todo.Models;

namespace Todo.utils
{
    public sealed class Store
    {
        private readonly static Store instance = new Store();
        public List<TodoItem> todos = new List<TodoItem>();
        public Store()
        {
            
        }
        public static Store Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
