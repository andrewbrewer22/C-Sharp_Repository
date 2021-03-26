using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ToDoSQL
{
    /*An App class that is the brains the manages all the rules
    and coordinates the user interactions and the database interactions.*/
    public class App
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
