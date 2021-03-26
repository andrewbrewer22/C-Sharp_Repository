using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ToDoSQL
{
    /*A ToDoItem class. This is your "POCO" class that represents 
        the item we want to track in our to do app. a. The items should 
        have at a minimum: a description, an id, and done flag or status. b. 
        The user should be able to set the description and the done flag, but 
        the id will be automatically set for us*/
    public class TodoItem
    {
        //Auto set
        public int ID { get; private set; }
        //User set
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public TodoItem()
        {

        }
        public TodoItem(string title, string desc, string stat)
        {
            this.Title = title;
            this.Description = desc;
            this.Status = stat;
        }
    }
}
