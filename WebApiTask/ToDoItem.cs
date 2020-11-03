using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiTask
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
