using System;
using System.Collections.Generic;


/*1. Ask the user if they want to add an item, or if they are done.
2. If the user wants to add an item,ask for description, due date, and priority.
create a ToDoItem representing the user's input, add the new instance to a list of items
3. Repeat until the user is done entering items.
4. Loop through the items and print the details of each item to the console.*/


namespace ToDo
{
    class Program
    {
        public static bool gatherData = true;
        static void Main()
        {
            Console.WriteLine("Known bugs: ");
            Console.WriteLine("Typing Done will not end the current iteration," +
                " Must go through all iterations before ending");
           // Console.WriteLine("");
            Console.WriteLine("Prints done and whatever else was typed when trying" +
                " to exit the toDo creater");
            Console.WriteLine("");
            Console.WriteLine("The ToDo generator \"Works\" but needs some improvments" );
            Console.WriteLine("");

            ToDoItem item = new ToDoItem();

            do
            {
                Console.WriteLine("Type \"Done\" when finished inputing data");
                Console.WriteLine("Enter a Description");
                item.Description = Console.ReadLine();
                //gatherData = item.CreateToDoItem(item.Description, item.DueDate, item.Priority);

                Console.WriteLine("Enter a priority: High, Med, Low");
                item.Priority = Console.ReadLine();
                //gatherData = item.CreateToDoItem(item.Description, item.DueDate, item.Priority);

                Console.WriteLine("Enter a due date");
                item.DueDate = Console.ReadLine();

                //item.CreateToDoItem(item.Description, item.DueDate, item.Priority);
                gatherData = item.CreateToDoItem(item.Description, item.DueDate, item.Priority);
            }
            while (gatherData);

            
        }
    }

    class ToDoItem
    {
        public string Description { get; set; }
        public string DueDate { get; set; }
        public string Priority { get; set; }

        List<string> resultList = new List<string>();
        public bool CreateToDoItem(string description, string dueDate, string priority)
        {
            //set our values
            Description = description;
            DueDate = dueDate;
            Priority = priority;

            bool keepGathering = true;
            if(description == "Done" || dueDate == "Done" || priority == "Done")
            {
                keepGathering = false;
            }

            //Our List that we will use at the end to be printed
            
            resultList.Add(description + " " + dueDate + " " + priority);
            ConstructList(keepGathering, resultList);
            /*
            for (int i = 0; i <= resultList.Count - 1; i++)
            {
                Console.WriteLine(resultList[i]);
            }
            */

            return keepGathering;
        }

        public void ConstructList(bool gatherData, List<string> ourList)
        {

            if (gatherData == false)
            {
                //Loop through our entire list and print every index
                for (int i = 0; i <= ourList.Count -1; i++)
                {
                    Console.WriteLine(ourList[i]);
                }
            }
        }
    }
}
