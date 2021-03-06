﻿using System;
using System.Collections.Generic;

namespace MasterMind
{
    class Program
    {
        public static bool playing = true;
        static void Main()
        {
            int guess1 = 0;
            int guess2 = 0;

            int positionOne = Convert.ToInt32(Randomizer());
            int positionTwo = Convert.ToInt32(Randomizer());

            Console.WriteLine("PosOne: " + positionOne + " PosTwo: " + positionTwo);

            Console.WriteLine("Welcome to Master Mind");
            Console.WriteLine("Possible Colors: Red, Green, Blue");
            Console.WriteLine("_________________________________");
            do
            {
                Console.WriteLine("Please guess your first color");
                guess1 = Converter(Console.ReadLine());
                if (guess1 == 10)
                {
                    Console.WriteLine("Invalid Input");

                }

                Console.WriteLine("Please guess your second color");
                guess2 = Converter(Console.ReadLine());
                if (guess2 == 10)
                {
                    Console.WriteLine("Invalid Input");
                }

                Console.WriteLine(CheckAnswer(positionOne, positionTwo, guess1, guess2));
                Console.WriteLine("________________________");
            }
            while (playing);
        }

        //Converts the user color input into an integer
        static int Converter(string userInput)
        {
            userInput = userInput.ToLower();
            switch (userInput)
            {
                case "red":
                    return 0;
                    break;

                case "green":
                    return 1;
                    break;

                case "blue":
                    return 2;
                    break;

                case "0":
                    return 0;
                    break;

                case "1":
                    return 1;
                    break;

                case "2":
                    return 2;
                    break;
            }
            return 10;
        }
        //Random Number generator for random color selection
        static string Randomizer()
        {
            Random random = new Random();
            int finalValue = random.Next(0, 3);

            return finalValue.ToString();
        }
        static string CheckAnswer(int positionOne, int positionTwo, int guess1, int guess2)
        {
            /*
            "0-0" if the user did not guess the correct colors at all
            "1-0" if they guessed one of the colors correctly but not at the correct position
            "0-1" if they guessed one of the colors correctly at the correct position
            "2-0" if they guessed both colors correctly but at the wrong positions*/

            if (positionOne == positionTwo)
            {
                if (guess1 == guess2)
                {
                    playing = false;
                    return "Correct!";
                }
                else
                {
                    return "2-0: guessed both colors correctly but at the wrong positions";
                }
            }

            if (guess1 == guess2)
            {
                if (positionOne == guess2 && positionTwo == guess1)
                {
                    return "2-0: guessed both colors correctly but at the wrong positions";
                }

                else if (positionOne == guess1 || positionTwo == guess1)
                {
                    return "0-1: guessed one of the colors correctly at the correct position";
                }

                else
                {
                    //playing = false;
                    return "0-0";
                }
            }

            if (positionOne == guess1)
            {
                if (positionTwo == guess2)
                {
                    playing = false;
                    return "Correct!";
                }
                return "0-1: guessed one of the colors correctly at the correct position";
            }

            if (positionOne == guess2 || positionTwo == guess1)
            {
                return "1-0: guessed one of the colors correctly but not at the correct position";
            }

            return "0-0: User did not guess the correct colors at all";
        }
    }
}
