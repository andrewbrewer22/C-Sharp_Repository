using System;

namespace ManyMethods
{
    class Program
    {
         public static void Main()
        {
            Hello();
            Addition();
            CatDog();
            OddEvent();
            Inches();
            Echo();
            KillGrams();
            Date();
            Age();
            Guess();
        }

        static string Name = "";
        static void Hello()
        {
            Console.WriteLine("Welcome to Many Methods!");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine("Relax and input the following information");
            Console.WriteLine("Name?");
            Name = Console.ReadLine();
            Console.WriteLine($"Ah, so your name is {Name}");
        }

        static void Addition()
        {
            Console.WriteLine("Next we'll do some maths, adding two numbers should do");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine("First Number");
            double firstNum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Second Number");
            double secondNum = Convert.ToDouble(Console.ReadLine());

            double answer = firstNum + secondNum;
            double wrong = answer + 328038.783;
            Console.WriteLine($"And the answer {Name} got issss");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine($"{wrong} Yikes...");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine($"Whoops, forgot to carry the one, heres the right answer: {answer}");

            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void CatDog()
        {
            Console.WriteLine($"Which do you prefer {Name}? Cats or Dogs...");
            string result = Console.ReadLine();
            if (result.ToUpper() == "CATS")
            {
                Console.WriteLine($"I mean, I guess if you like ripped up carpet and cleaning up pee, sure {Name} sure");
            }
            else if (result.ToUpper() == "DOGS")
            {
                Console.WriteLine($"I mean yea, {Name}'s bestfriend or whatever, between you and me I'm pretty sure its the food");
            }
            else
            {
                Console.WriteLine("I like hypotheticals too");
            }

            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void OddEvent()
        {
            Console.WriteLine("Now how about an Odd or an Even Number");
            Console.WriteLine("ENTER");
            Console.ReadLine();
            Console.WriteLine("Number Please");
            double oddEven = Convert.ToDouble(Console.ReadLine());
            if(oddEven%2 == 0)
            {
                Console.WriteLine("Wow an Even!");
            }
            else
            {
                Console.WriteLine("Wow an Odd!");
            }

            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void Inches()
        {
            Console.WriteLine("Now for my next trick, Conversion!!");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine("Please give me the even number of feet that are in your height");
            int heightFeet = Convert.ToInt32(Console.ReadLine());
            int heightInches = 12 * heightFeet;

            Console.WriteLine($"It would apear you are: {heightInches} inches tall, tell your friends!");
            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void Echo()
        {
            Console.WriteLine($"Have you ever screamed into Mausoleum {Name}? Now's your chance!");
            Console.WriteLine("What would you like to say?");

            string userYell = Console.ReadLine();
            string capitalYell = userYell.ToUpper();
            Console.WriteLine($"{capitalYell}!");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine(userYell);

            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine(userYell);

            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void KillGrams()
        {
            Console.WriteLine("Just in from HQ, we're gonna do another conversion");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            Console.WriteLine("Give me a number in pounds");
            double userPounds = Convert.ToDouble(Console.ReadLine());
            double userKilograms = userPounds / 2.205;

            Console.WriteLine($"Wow {userKilograms} KiloGrams! I sure hope that's not your weight...");
            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void Date()
        {
            Console.WriteLine("Now lookie at the time!");
            Console.WriteLine("ENTER");
            Console.ReadLine();

            DateTime now = DateTime.Now;

            Console.WriteLine($"It is: {now}");
        }

        static void Age()
        {
            Console.WriteLine("ENTER");
            Console.ReadLine();
            Console.WriteLine("What year were you born?");

            Console.WriteLine("YEAR");

            int userYear = Convert.ToInt32(Console.ReadLine());
            int age = 2021 - userYear;

            Console.WriteLine($"So {Name}, your {age} years old? wow");

            Console.WriteLine("ENTER");
            Console.ReadLine();
        }

        static void Guess()
        {
            Console.WriteLine("Hehe, now for the final challenge, you must guess my word");
            Console.WriteLine("Word: ");
            Console.ReadLine();

            string userWord = Console.ReadLine();

            if (userWord.ToUpper() == "CSHARP")
            {
                Console.WriteLine("Wow you got it Right!");

            }
            else
            {
                Console.WriteLine("Well, that was wrong, but no worries, I won't");
                Console.WriteLine("make you do this all over again. Have a good Day!!");
            }
        }
    }
}
