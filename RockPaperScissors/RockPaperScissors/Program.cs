using System;

namespace RockPaperScissors
{
    class Program
    {
        public const string Rock = "rock";
        public const string Scissors = "scissors";
        public const string Paper = "paper";

        public static void Main()
        {
            Console.WriteLine("Rock Paper or Scissors?");
            //read user input
            string userHand = Console.ReadLine();
            userHand = userHand.ToLower();
            //generate random hand
            string opposingHand = Random();
            //passing array argument
            string[] sendArgument = { "", "" };
            //add both arguments to array
            sendArgument[0] = userHand;
            sendArgument[1] = opposingHand;

            string finalJudgment = Judge(sendArgument);
            Console.WriteLine("Your Hand: " + userHand + " Opposing Hand: " + opposingHand);
            Console.WriteLine(finalJudgment);
        }

        public static string Random()
        {
            //answer to return to main
            string answer = "";
            //random int generator 1-3
            Random rand = new Random();
            int randNum = rand.Next(1, 4);

            //Checks the random number with matching case and assignes
            // answer: rock, paper, or scissors and than returns to main
            switch (randNum)
            {
                case 1:
                    answer = "rock";
                    break;

                case 2:
                    answer = "paper";
                    break;

                case 3:
                    answer = "scissors";
                    break;

                default:
                    Console.WriteLine("That is not an option");
                    break;
            }

            return answer;
        }

        public static string Judge(string[] arr)
        {


            string userHand = arr[0];
            string opposingHand = arr[1];
            string judgment = "";

            //Tie
            if(userHand == opposingHand)
            {
                judgment = "Tie";
            }
            //Rock beats Scissors
            if (userHand == Rock && opposingHand == Scissors)
            {
                judgment = "You Win";
            }
            else if(userHand == Scissors && opposingHand == Rock)
            {
                judgment = " You Lose";
            }
            //Paper Beats Rock
            if (userHand == Paper && opposingHand == Rock)
            {
                judgment = "You Win";
            }
            else if (userHand == Rock && opposingHand == Paper)
            {
                judgment = "You Lose";
            }
            //Scissors beats Paper
            if (userHand == Scissors && opposingHand == Paper)
            {
                judgment = "You Win";
            }
            else if(userHand == Paper && opposingHand == Scissors)
            {
                judgment = "You Lose";
            }

            return judgment;
        }
    }
}