using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ToDoSQL
{
    /*A ItemContext class that extends Microsoft.EntityFrameworkCore.DbContext.
     */
    public class ItemContext : DbContext
    {
        public DbSet<TodoItem> toDo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "ToDoItemsDataBase.db");

            // to check what the path of the file is, uncomment the file below
            Console.WriteLine("using database file :" + DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}