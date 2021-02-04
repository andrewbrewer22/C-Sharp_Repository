using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string[]> studentGrades = new Dictionary<string, string[]>();

            string name = string.Empty;
            string[] grades = null;
            do
            {
                Console.WriteLine("Enter student or type 'quit' when done");
                name = Console.ReadLine();

                if (name != "quit")
                {
                    Console.WriteLine("Please enter students grades seperated by spaces");
                    grades = Console.ReadLine().Split(" ");
                }
                studentGrades.Add(name, grades);

            } while (name != "quit");

            double lowValue = 0.0;
            double highValue = 0.0;
            double average = 0.0;
            foreach (var item in studentGrades)
            {
                //int finKeyLength = item.Key.Length;
                if (item.Key != "quit")
                {
                    Console.WriteLine("Student: " + item.Key);
                    Console.WriteLine("Grades:");

                    //preset our low and high values to the first grades
                    lowValue = Convert.ToDouble(item.Value[0]);
                    highValue = Convert.ToDouble(item.Value[0]);
                    //cycle through all grades given
                    for (int i = 0; i < item.Value.Length; i++)
                    {
                        //Converts the grades from strings to doubles
                        if (Convert.ToDouble(item.Value[i]) < lowValue)
                        {
                            lowValue = Convert.ToDouble(item.Value[i]);
                        }
                        if (Convert.ToDouble(item.Value[i]) > highValue)
                        {
                            highValue = Convert.ToDouble(item.Value[i]);
                        }

                        average += Convert.ToDouble(item.Value[i]);
                    }
                    average = average / item.Value.Length;
                    Console.WriteLine("High grade: " + highValue);
                    Console.WriteLine("Low grade: " + lowValue);
                    Console.WriteLine("Average: " + average);
                }
            }
        }
    }
}
