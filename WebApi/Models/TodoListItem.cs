using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class TodoListItem
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Done { get; set; } = false;
    }
}