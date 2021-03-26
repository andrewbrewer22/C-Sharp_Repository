using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ToDoSQL
{
    /*An ItemRepository class that acts as the interface between 
        your application and the database that store the TodoItems. 
        This class is responsible for managing the list of items and how 
        it is saved and fetched from the database.*/
    public class ItemRepository
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
}
