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

    /*An ItemRepository class that acts as the interface between 
    your application and the database that store the TodoItems. 
    This class is responsible for managing the list of items and how 
    it is saved and fetched from the database.*/
    class ItemRepository
    {
        ItemContext contextItem;
        //Needed constructor, ensures the db is created
        public ItemRepository()
        {
            contextItem = new ItemContext();
            contextItem.Database.EnsureCreated();
        }
        public List<string> ListInfo()
        {
            //Return list
            List<string> toDoList = new List<string>();

            foreach (TodoItem i in contextItem.toDo)
            {
                toDoList.Add(i.ID + " Status: " + i.Status + " Title: " + i.Title + " Description: " + i.Description);
            }
            return toDoList;
        }

        //Editing
        public (bool, int) EditInfoCheck(int[] editCode)
        {
            int currentID = 0;
            bool notValid = true;

            foreach (TodoItem i in contextItem.toDo)
            {
                //Check each ID of context. If our user ID matches, than continue
                if (i.ID == editCode[0])
                {
                    currentID = editCode[0];
                    notValid = false;
                    break;
                }
                else
                {
                    notValid = true;
                }
            }

            //Return true or false to App so we know if the information is legit
            if (notValid)
            {
                //Return the failing ID code
                return (false, editCode[0]);

            }
            else
            {
                //ID was successful, return the section code
                return (true, editCode[1]);
            }
        }
        public void PushEdit(int[] editCode, string edit)
        {
            //Push the edit onto the desired ID
            foreach (TodoItem i in contextItem.toDo)
            {
                if (i.ID == editCode[0])
                {
                    //Translate editcode [1]
                    switch (editCode[1])
                    {
                        case 0:
                            i.Status = edit;
                            break;

                        case 1:
                            i.Description = edit;
                            break;

                        case 2:
                            i.Title = edit;
                            break;
                    }
                }
            }
            //Save changes
            contextItem.SaveChanges();
            Console.WriteLine("___________________Changes Saved__________________");
        }

        //Remove
        public void RemoveItem(int removeCode)
        {
            foreach (TodoItem i in contextItem.toDo)
            {
                if (i.ID == removeCode)
                {
                    contextItem.toDo.Remove(i);
                    contextItem.SaveChanges();
                    Console.WriteLine("Item Removed");
                }
            }
        }

        //Add Item
        public void AddItem(string[] newItem)
        {
            //Title, Description, status
            TodoItem newTodo = new TodoItem(newItem[0], newItem[1], newItem[2]);
            contextItem.toDo.Add(newTodo);
            contextItem.SaveChanges();
            Console.WriteLine("Item added");
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

        #region EDIT Var
        //used to dispatch our request for further evaluation
        //                                ID  Sec
        public int[] editCode = new int[] { 0, 0 };
        //current string to establish in edit
        public string editToPush = "";
        //Used to determine if we should use our base switch statement
        //Edit bools
        public bool editingItem = false;
        public bool continueEdit = false;
        public bool editComplete = false;
        #endregion

        #region Remove Var
        //Remove bools
        public bool removeItem = false;
        public int removeCode = 0;
        #endregion

        #region ADD Var
        public bool addNewItem = false;
        public string[] newToDoItem = { "", "", "" };
        #endregion

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
                    //EditItemPrompt();
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
            //used to split up the userinput for evaluation
            string[] userSplit = userInput.Split(" ");

            if (userSplit[0] == "additem" && userSplit[1] == "newitem")
            {
                Console.WriteLine("Type a Title");
                newToDoItem[0] = Console.ReadLine();

                Console.WriteLine("Type a Description");
                newToDoItem[1] = Console.ReadLine();

                Console.WriteLine("Type the \"Status\" of the ToDo Item");
                newToDoItem[2] = Console.ReadLine();

                addNewItem = true;
            }

            if (!addNewItem)
            {
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
                        Console.WriteLine("additem \'newitem\': Add new to do item");

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
        }

        public void RemoveItemPrompt()
        {
            Console.WriteLine("Remove Item");
            Console.WriteLine("________________________________");
            //Basic Commands
            string userInput = Console.ReadLine();
            //used to split up the userinput for evaluation
            string[] userSplit = userInput.Split(" ");

            int todoID = 0;

            if (userSplit[0] == "removeitem")
            {
                //Set remove item, if the evaluation is not true
                //set false
                removeItem = true;

                try
                {
                    //Index 1 is the todo ID
                    todoID = Convert.ToInt32(userSplit[1]);
                    //Assign our ID editcode ID
                    removeCode = todoID;
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a valid todo ID");
                    removeItem = false;
                    //throw;
                }
            }

            if (!removeItem)
            {
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
                        Console.WriteLine("removeitem \'itemID\' : deletes item");
                        //Console.WriteLine("Put removeitem help here");
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
        }

        //Check input for user editing
        public void EditItemPrompt(List<string> todo)
        {
            Console.WriteLine("Edit Item");
            Console.WriteLine("________________________________");
            string userInput = "";
            string[] userSplit = new string[10];
            //only grab the user input if were not editing
            if (!continueEdit)
            {
                //Basic Commands
                userInput = Console.ReadLine();
                //used to split up the userinput for evaluation
                userSplit = userInput.Split(" ");
            }

            //Used as temp variable to hold our split ID char
            int todoID = 0;

            //If the user input made it through first test
            //Continue to edit by grabbing desired user info
            if (continueEdit)
            {
                Console.WriteLine("Input edit:");
                editToPush = Console.ReadLine();

                editComplete = true;
                //continueEdit = false;
            }

            //Retrieves the first word of the user input if edit
            if (!continueEdit && userSplit[0] == "edit")
            {
                //If all tests pass, let APP continue the request
                editingItem = true;

                //identify the second index as the ID todo
                try
                {
                    //Index 1 is the todo ID
                    todoID = Convert.ToInt32(userSplit[1]);

                    //Assign our ID editcode ID
                    editCode[0] = todoID;
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a valid todo ID");
                    editingItem = false;
                    //throw;
                }
                //identify which category the user would like to edit

                switch (userSplit[2])
                {
                    case "status":
                        //Console.WriteLine("status");
                        editCode[1] = 0;
                        break;

                    case "description":
                        //Console.WriteLine("description");
                        editCode[1] = 1;
                        break;

                    case "title":
                        //Console.WriteLine("title");
                        editCode[1] = 2;
                        break;

                    default:
                        Console.WriteLine("Not a valid section to edit");
                        editCode[0] = 0;
                        editCode[1] = 0;
                        editingItem = false;
                        break;
                }
            }

            if (!editingItem && !continueEdit)
            {
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

                    case "return":
                        currentPrompt = 0;
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    case "list":
                        currentPrompt = 4;
                        break;

                    //Select todo item and edit
                    case "help edititem":
                        Console.WriteLine("edit \"itemID\" \"status, title, description\"");
                        break;

                    //case "edit"

                    default:
                        Console.WriteLine("Invalid Input. Type \'help\' for a list of commands");
                        break;
                }
            }
        }
        public void ResetMethod()
        {
            //Add Item
            newToDoItem[0] = "";
            newToDoItem[1] = "";
            newToDoItem[2] = "";
            addNewItem = false;

            //reset editing parameters
            editCode[0] = 0;
            editCode[1] = 0;
            editComplete = false;
            editingItem = false;
            continueEdit = false;

            //reset remove paremters
            removeCode = 0;
            removeItem = false;

            currentPrompt = 0;
        }
        public void ListToDo(List<string> todo)
        {
            for (int i = 0; i < todo.Count; i++)
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
            //our currentprompt = the console class current prompt
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
                    //Console.WriteLine("Edit trigger");
                    console.EditItemPrompt(itemRepo.ListInfo());

                    break;

                case 4:
                    //Print todo items
                    console.ListToDo(itemRepo.ListInfo());
                    Console.WriteLine("_____________________________________________");
                    console.ResetMethod();
                    break;
            }

            #region ADDING
            if (console.addNewItem)
            {
                itemRepo.AddItem(console.newToDoItem);
                console.ResetMethod();
            }
            #endregion

            #region REMOVING
            if (console.removeItem)
            {
                itemRepo.RemoveItem(console.removeCode);
                console.ResetMethod();
            }
            #endregion

            #region EDITING
            //If the user editing prompt did not pick up any problems
            //continue to pass the code to itemrepo editinfo meth
            if (console.editingItem)
            {
                //pass editcode to editinfo for further evaluation
                if (itemRepo.EditInfoCheck(console.editCode).Item1)
                {
                    //if the code was good continue to next edit station
                    Console.WriteLine("Good input");
                    console.editingItem = false;
                    console.continueEdit = true;
                }
                else
                {
                    //if input was bad, stop the code and report why
                    Console.WriteLine("Invalid ID: " + "(" + itemRepo.EditInfoCheck(console.editCode).Item2
                        + ")" + " please \'list\' to see available options");
                    console.editingItem = false;
                    console.ResetMethod();
                }
            }
            //if edit complete, push the edit to the itemRepo
            //for final step
            if (console.editComplete)
            {
                //                  ID and sec      edit to push to sec
                itemRepo.PushEdit(console.editCode, console.editToPush);

                console.ResetMethod();
            }
            #endregion
        }
    }
}