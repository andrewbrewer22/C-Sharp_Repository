using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

#region Points
/*5pts - TodoItem Class
10pts - ItemRepository Class
5pts - ItemContext Class
10pts - ConsoleUtils Class
10pts - App Class
10pts - Create an item
10pts - Delete an item
10pts - Mark an item as done
5pts - List All items
5pts - List Done items
5pts - List Pending items
5pts - Handling bad input on action selection
5pts - Handling bad input on item selection
5pts - Implementation satisfies separation of concerns*/
#endregion
#region Functionality
/*The user should be able to:
1. Create a new item
2. Delete an existing item
3. Mark an item as done
4. List all done items
5. List all pending items
6. List all items (both pending and done items)
7. The program should handle saving automatically 
so quitting and restarting the app should not result in data loss*/
#endregion
#region Instructions
/*1. An App class that is the brains the manages all the rules
and coordinates the user interactions and the database interactions.

2. An ItemRepository class that acts as the interface between 
your application and the database that store the TodoItems. 
This class is responsible for managing the list of items and how 
it is saved and fetched from the database.

3. A ItemContext class that extends Microsoft.EntityFrameworkCore.DbContext.

4. A ConsoleUtils class to handle printing to the console, and reading 
from the console. Yes, this could be done in the App class, but we 
want to contain all code that handles user input and display to the ConsoleUtils class.

5. A ToDoItem class. This is your "POCO" class that represents 
the item we want to track in our to do app. a. The items should 
have at a minimum: a description, an id, and done flag or status. b. 
The user should be able to set the description and the done flag, but 
the id will be automatically set for us*/
#endregion
#region Seperation Concern
/*Your implementation should split up the code such that different 
classes are responsible for certain aspects of the overall functionality.
If you follow the suggestion given above, then

1. The ItemRepository class should not be involved in displaying 
or accepting any info to/from the user, and should not directly 
call any code that interacts with the user.

2. The ConsoleUtils class should not directly interact with the 
ItemRepository class or edit the database. (ie this is the only class 
that should have Console.WriteLine() and Console.ReadLine())

3. The App class should not directly update the database, but should go 
through the ItemRepository class.*/
#endregion
namespace ToDoSQL
{
    //Just hanging out with the other classes :)
    class Program
    {
        static App friend;

        //Say Hi to App Class and than hide in a corner
        static void Main()
        {
            friend = new App();
        }
    }

    /*A ToDoItem class. This is your "POCO" class that represents 
    the item we want to track in our to do app. a. The items should 
    have at a minimum: a description, an id, and done flag or status. b. 
    The user should be able to set the description and the done flag, but 
    the id will be automatically set for us*/
    class TodoItem
    {
        //Auto set
        public int ID { get; private set; }
        //User set
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }


        public TodoItem(string title, string desc, string stat)
        {
            this.Title = title;
            this.Description = desc;
            this.Status = stat;
        }
    }

    /*An ItemRepository class that acts as the interface between 
    your application and the database that store the TodoItems. 
    This class is responsible for managing the list of items and how 
    it is saved and fetched from the database.*/
    class ItemRepository
    {
        ItemContext contextItem = new ItemContext();

        public List<string> ListInfo()
        {
            
            contextItem.Database.EnsureCreated();

            List<string> toDoList = new List<string>();

            foreach(TodoItem i in contextItem.toDo)
            {
                toDoList.Add(i.ID + i.Status + i.Title + i.Description);
            }

            // contextItem.Database.
            return toDoList;
        }
    }

    /*A ItemContext class that extends Microsoft.EntityFrameworkCore.DbContext.
     */
    class ItemContext : DbContext
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

    /*A ConsoleUtils class to handle printing to the console, and reading 
    from the console. Yes, this could be done in the App class, but we 
    want to contain all code that handles user input and display to the ConsoleUtils class.*/
    class ConsoleUI
    {
        public int currentPrompt;
        public void UserInputPrompt()
        {
            Console.WriteLine("Main User Prompt");
            Console.WriteLine("________________________________");

            //Basic Commands
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "help":
                    Console.WriteLine("_______________________");
                    Console.WriteLine("quit : Exit the console");
                    Console.WriteLine("additem : Add a todo item");
                    Console.WriteLine("removeitem : Remove a todo item");
                    Console.WriteLine("edititem : Edit an existing todo item");
                    Console.WriteLine("return : Return to last section");
                    Console.WriteLine("list : List todo items");
                    Console.WriteLine("help \"additem, removeitem, edititem\" : action help");
                    Console.WriteLine("_______________________________");
                    break;

                case "help additem":
                    Console.WriteLine("Type \'additem\' to get to Add Item section first :)");
                    break;

                case "help removeitem":
                    Console.WriteLine("Type \'removeitem\' to get to Remove Item section first :)");
                    break;

                case "help edititem":
                    Console.WriteLine("Type \'edititem\' to get to Edit Item section first :)");
                    break;

                case "additem":
                    AddItemPrompt();
                    currentPrompt = 1;
                    break;

                case "removeitem":
                    RemoveItemPrompt();
                    currentPrompt = 2;
                    break;

                case "edititem":
                    EditItemPrompt();
                    currentPrompt = 3;
                    break;

                case "list":
                    currentPrompt = 4;
                    break;

                case "return":
                    Console.WriteLine("Nothing to Return to");
                    break;

                case "quit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Input. Type \'help\' for a list of commands");
                    break;
            }
        }

        public void AddItemPrompt()
        {
            Console.WriteLine("Add Item");
            Console.WriteLine("________________________________");
            //Basic Commands
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "help":
                    Console.WriteLine("_______________________");
                    Console.WriteLine("quit : Exit the console");
                    Console.WriteLine("return : Return to last section");
                    Console.WriteLine("help additem : action help");
                    Console.WriteLine("list : List todo items");
                    Console.WriteLine("_______________________________");
                    break;

                case "help additem":
                    Console.WriteLine("Put additem help here");
                    Console.WriteLine("Put additem help here");
                    Console.WriteLine("Put additem help here");
                    Console.WriteLine("Put additem help here");
                    Console.WriteLine("Put additem help here");
                    break;

                case "return":
                    currentPrompt = 0;
                    break;

                case "quit":
                    Environment.Exit(0);
                    break;

                case "list":
                    currentPrompt = 4;
                    break;

                default:
                    Console.WriteLine("Invalid Input. Type \'help\' for a list of commands");
                    break;
            }
        }

        public void RemoveItemPrompt()
        {
            Console.WriteLine("Remove Item");
            Console.WriteLine("________________________________");
            //Basic Commands
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "help":
                    Console.WriteLine("_______________________");
                    Console.WriteLine("quit : Exit the console");
                    Console.WriteLine("return : Return to last section");
                    Console.WriteLine("help removeitem : action help");
                    Console.WriteLine("list : List todo items");
                    Console.WriteLine("_______________________________");
                    break;

                case "help removeitem":
                    Console.WriteLine("Put removeitem help here");
                    Console.WriteLine("Put removeitem help here");
                    Console.WriteLine("Put removeitem help here");
                    Console.WriteLine("Put removeitem help here");
                    Console.WriteLine("Put removeitem help here");
                    break;

                case "return":
                    currentPrompt = 0;
                    break;

                case "quit":
                    Environment.Exit(0);
                    break;

                case "list":
                    currentPrompt = 4;
                    break;

                default:
                    Console.WriteLine("Invalid Input. Type \'help\' for a list of commands");
                    break;
            }
        }

        public void EditItemPrompt()
        {
            Console.WriteLine("Edit Item");
            Console.WriteLine("________________________________");
            //Basic Commands
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "help":
                    Console.WriteLine("_______________________");
                    Console.WriteLine("quit : Exit the console");
                    Console.WriteLine("return : Return to last section");
                    Console.WriteLine("help edititem : action help");
                    Console.WriteLine("list : List todo items");
                    Console.WriteLine("_______________________________");
                    break;

                case "help edititem":
                    Console.WriteLine("Put edititem help here");
                    Console.WriteLine("Put edititem help here");
                    Console.WriteLine("Put edititem help here");
                    Console.WriteLine("Put edititem help here");
                    Console.WriteLine("Put edititem help here");
                    break;

                case "return":
                    currentPrompt = 0;
                    break;

                case "quit":
                    Environment.Exit(0);
                    break;

                case "list":
                    currentPrompt = 4;
                    break;

                default:
                    Console.WriteLine("Invalid Input. Type \'help\' for a list of commands");
                    break;
            }
        }

        public void ResetMethod()
        {
            currentPrompt = 0;
        }

        public void ListToDo(List<string> todo)
        {
            for(int i = 0; i < todo.Count; i++)
            {
                Console.WriteLine(todo[i]);
            }
        }
    }

    /*An App class that is the brains the manages all the rules
    and coordinates the user interactions and the database interactions.*/
    class App
    {
        //Class Refs
        ConsoleUI console = new ConsoleUI();
        ItemRepository itemRepo = new ItemRepository();

        public int currentPrompt = 0;

        //Booleans
        bool Working = true;

        public App()
        {
            Console.WriteLine("Welcome to your ToDo list");
            Console.WriteLine("Type \'help\' for a list of commands");

            do
            {
                Master();
                currentPrompt = console.currentPrompt;
            }
            while (Working);
        }

        void Master()
        {
            switch (currentPrompt)
            {
                //Main input
                case 0:
                    console.UserInputPrompt();
                    break;

                //Add Item
                case 1:
                    console.AddItemPrompt();
                    break;

                //Remove Item
                case 2:
                    console.RemoveItemPrompt();
                    break;

                //Edit Item
                case 3:
                    console.EditItemPrompt();
                    break;

                case 4:
                    //Print todo items
                    console.ListToDo(itemRepo.ListInfo());
                    console.ResetMethod();
                    break;
            }
        }
    }
}