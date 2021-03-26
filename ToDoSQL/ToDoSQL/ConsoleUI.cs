using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ToDoSQL
{
    /*A ConsoleUtils class to handle printing to the console, and reading 
        from the console. Yes, this could be done in the App class, but we 
        want to contain all code that handles user input and display to the ConsoleUtils class.*/
    public class ConsoleUI
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
}
