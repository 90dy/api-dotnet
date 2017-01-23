using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class TodoListController : ApiController
    {
        Todo[] todoList = new Todo[]
        {
            new Todo { Id = 1, Description = "I'm the first todo so don't delete me please." },
            new Todo { Id = 2, Description = "I'm second, wtf ?!" },
            new Todo { Id = 3, Description = "Third is a place, I don't give a sh** of the first !" },
            new Todo { Id = 4, Description = "One day, fourth will have a cup too." }
        };

        public IEnumerable<Todo> GetAllTodo()
        {
            return todoList;
        }

        public IHttpActionResult GetTodo(int id)
        {
            var todo = todoList.FirstOrDefault((t) => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
    }
}
