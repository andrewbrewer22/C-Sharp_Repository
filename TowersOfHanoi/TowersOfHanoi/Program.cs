using System;
using System.Collections.Generic;

/*Your program should print the state of the board to the user
Your program should ask the user which stack do they want to move the top piece from, and to which stack do they want to move it to.
Your program should update the board
Your program should repeat steps 1,2 and 3 until the game is won.
Your program should not allow a user to make an illegal move.*/

namespace TowersOfHanoi
{
    class Program
    {
        static public bool playing = true;
        static public int[] stickA = new int[] { 4, 3, 2, 1 };
        static public int[] stickB = new int[] { 0, 0, 0, 0 };
        static public int[] stickC = new int[] { 0, 0, 0, 0 };

        //Dictionary used to pair our sticks with int values for easier access
        static Dictionary<int, int[]> stickDictionary = new Dictionary<int, int[]>();


        static void Main()
        {
            string userInputPosition = "";
            int userPosition = 0;

            stickDictionary.Add(0, stickA);
            stickDictionary.Add(1, stickB);
            stickDictionary.Add(2, stickC);

            Console.WriteLine("Welcome to Towers of Hanoi");
            Console.WriteLine("Rules in ReadMe file");
            Console.WriteLine("__________________________");

            do
            {
                PrintBoard(stickA, stickB, stickC);
                Console.WriteLine("Choose a stick: (1) (2) (3)");
                userInputPosition = Console.ReadLine();
                userPosition = CheckPosition(userInputPosition, stickA, stickB, stickC);

                //If our stick we chose is empty, keep choosing a stick until a valid choice is picked
                do
                {
                    userInputPosition = Console.ReadLine();
                    userPosition = CheckPosition(userInputPosition, stickA, stickB, stickC);
                }
                while (userPosition == -1);



            }
            while (playing);
        }

        #region Print Board
        static void PrintBoard(int[] stickA, int[] stickB, int[] stickC)
        {
            Console.WriteLine("Stick 1: " + stickA[0] + " " + stickA[1] + " " + stickA[2] + " " + stickA[3]);
            Console.WriteLine("Stick 2: " + stickB[0] + " " + stickB[1] + " " + stickB[2] + " " + stickB[3]);
            Console.WriteLine("Stick 3: " + stickC[0] + " " + stickC[1] + " " + stickC[2] + " " + stickC[3]);
        }
        #endregion

        #region Postion Validation
        static int CheckPosition(string userInput, int[] stickA, int[] stickB, int[] stickC)
        {
            int userChance = 0;
            //If assigning userInput from string to int is feasible
            try
            {
                userChance = Convert.ToInt32(userInput);
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                userChance = 0;
            }
            //If user int is a possible choice reassign to index value
            switch (userChance)
            {
                case 1:
                    userChance = 0;
                    break;

                case 2:
                    userChance = 1;
                    break;

                case 3:
                    userChance = 2;
                    break;

                default:
                    userChance = 10;
                    Console.WriteLine("Invalid Input");
                    break;
            }

            //Check if our number is equal to our sticks

            //Check if stick is empty
            if(stickDictionary[userChance][0] == 0)
            {
                Console.WriteLine("Empty Stick");
                Console.WriteLine("Choose valid Stick");
                Console.WriteLine("___________________");
                return -1;
            }
            else
            {
                for(int i = 0; i < stickDictionary[userChance].Length -1; i++)
                {
                    if(stickDictionary[userChance][i] == 0)
                    {

                    }
                }
            }

            return 124;
        }
        #endregion
    }
}
