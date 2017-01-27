using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Diagnostics;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TodoListController : ApiController
    {
        static IEnumerable<TodoListItem> todoList = new TodoListItem[]
        {
            new TodoListItem { Id = 1, Description = "I'm the first TodoListItem so don't delete me please.", Done = true },
            new TodoListItem { Id = 2, Description = "I'm second, wtf ?!" },
            new TodoListItem { Id = 3, Description = "Third is a place, I don't give a sh** of the first !" },
            new TodoListItem { Id = 4, Description = "One day, fourth will have a cup too." }
        };

        [HttpGet]
        public IEnumerable<TodoListItem> GetTodoList()
        {
            return todoList;
        }

        [HttpGet]
        public IHttpActionResult GetTodoListItem(int id)
        {
            var todo = todoList.FirstOrDefault((t) => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public IHttpActionResult PostTodoListItem(TodoListItem item)
        {
            todoList = todoList.Concat(
                new TodoListItem[]
                {
                    new TodoListItem
                    {
                        Id = todoList.Last().Id + 1,
                        Description = item.Description,
                        Done = item.Done
                    }
                }
            );
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PutTodoListItem(TodoListItem item)
        {

            TodoListItem todo = todoList.FirstOrDefault((t) => t.Id == item.Id);
            Trace.WriteLine("Item: " + item.Id);

            if (todo == null)
                return (NotFound());
            todoList = todoList.Select(t =>
            {
                if (t.Id == item.Id)
                    return (item);
                return (t);
            });
            return Ok();
        }
    }
}
