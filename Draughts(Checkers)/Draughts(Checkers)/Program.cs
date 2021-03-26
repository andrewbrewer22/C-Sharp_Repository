using System;
using System.Collections.Generic;

//                (        )
namespace Draughts_Checkers_
{
    class Program
    {
        public static Master main = new Master();
        static void Main()
        {
            main.Control();
        }
    }

    public class Master
    {
        //Layout object
        PrintBoard print = new PrintBoard();
        //loop bool
        static bool playing = true;

        public Input inp = new Input();
        public Master()
        {

        }

        public void Control()
        {
            //User input element
            string userInput = "";
            //User split element
            string[] userXY = { "", "" };
            //Final split string element to int
            int X = 0;
            int Y = 0;

            //If input not valid toggle not valid input
            bool notValidInput = false;
            bool notValidPos = false;

            //Default player output
            Console.WriteLine("Input X and Y seperated by space");
            Console.WriteLine("Player W's turn");
            Console.WriteLine("________________________________");
            print.printBoard();

            do
            {
                //While Input is not valid, retry until valid
                do
                {
                    //get player input
                    userInput = Console.ReadLine();

                    //Test input for correct input
                    try
                    {
                        userXY = userInput.Split(" ");

                        X = Int32.Parse(userXY[0]);
                        Y = Int32.Parse(userXY[1]);
                        notValidInput = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input");
                        notValidInput = true;
                    }
                }
                while (notValidInput);

                //test input
                do
                {
                    notValidPos = inp.TestFirstPos(X, Y);
                }
                while (notValidPos);

                //test returns invalid, do not exectute input

                //exectute input

            }
            while (playing);
        }
    }

    public class Input
    {
        public Input()
        {

        }

        //Initial Position
        public bool TestFirstPos(int x, int y)
        {
            //return true if the input is invalid
            return false;
        }

        //Movement Position
        public bool TestSecondPos(int x, int y)
        {
            //return true if the input is invalid
            return false;
        }
    }

    public class PrintBoard
    {
        static string[][] board;
        string indexHolder = "";

        public void printBoard()
        {
            board = Board.BuildBoard();

            //loops through every index
            for (int i = 0; i < board.Length; i++)
            {
                //loops through the second dimension
                for (int j = 0; j < board[i].Length; j++)
                {
                    indexHolder += board[i][j];
                }
                Console.WriteLine(indexHolder);
                indexHolder = "";
            }
        }
    }

    public static class Board
    {
        public static string[][] layout;
        public static string[][] BuildBoard()
        {
            //9x9, with the first row and colum being the coordinates
            layout = new string[][]
            {                 /*0   1   2   3   4   5   6   7   8*/
            /*0*/new string[] {"0","1","2","3","4","5","6","7","8"},
            /*1*/new string[] {"1"," ","W"," ","W"," ","W"," ","W"},//W
            /*2*/new string[] {"2","W"," ","W"," ","W"," ","W"," "},//W
            /*3*/new string[] {"3"," ","W"," ","W"," ","W"," ","W"},//W
            /*4*/new string[] {"4"," "," "," "," "," "," "," "," "},//
            /*5*/new string[] {"5"," "," "," "," "," "," "," "," "},//
            /*6*/new string[] {"6","B"," ","B"," ","B"," ","B"," "},//B
            /*7*/new string[] {"7"," ","B"," ","B"," ","B"," ","B"},//B
            /*8*/new string[] {"8","B"," ","B"," ","B"," ","B"," "},//B
            //Only Index 1 1 or higher should be called. 1 1 = 0 0
            };

            return layout;
        }
    }
}
