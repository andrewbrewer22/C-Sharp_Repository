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
    public class Program
    {
        static App friend;

        //Say Hi to App Class and than hide in a corner
        static void Main()
        {
            friend = new App();
        }
    }
}