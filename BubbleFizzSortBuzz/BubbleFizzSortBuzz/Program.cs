using System;

namespace BubbleFizzSortBuzz
{
    class Program
    {
        public static string fizz = "fizz";
        public static string buzz = "buzz";
        static void Main()
        {
            FizzBuzz();

            //Run the sort until all numbers are sorted
            BubbleSort();
            BubbleSort();
            BubbleSort();
            BubbleSort();
        }
        static void FizzBuzz()
        {
            for (int i = 0; i <= 100; i++)
            {
                if ((i % 3) == 0 && (i % 5) == 0)
                {
                    Console.WriteLine(i + ": " + fizz + buzz);
                }
                else if ((i % 3) == 0)
                {
                    Console.WriteLine(i + ": " + fizz);
                }
                else if ((i % 5) == 0)
                {
                    Console.WriteLine(i + ": " + buzz);
                }
            }
        }

        public static int[] numbers = new int[] { 4, 1, 5, 7, 3, 2 };
        public static int tempInt = 0;
        public static string newNumbers = "";

        static void BubbleSort()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                //    A       <        B
                if(i > 0 && numbers[i] < numbers[i - 1])
                {
               //      B           B
                    tempInt = numbers[i - 1];
               //        B             A
                    numbers[i - 1] = numbers[i];
               //        A          B
                    numbers[i] = tempInt;
                }
                //Print new numbers
                for(int j = 0; j < numbers.Length; j++)
                {
                    newNumbers += numbers[j] + " ";
                }
                Console.WriteLine(newNumbers);
                newNumbers = "";
            }
        }
    }
}
