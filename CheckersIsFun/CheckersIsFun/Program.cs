using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    /*Extra Work: 
     *Handle checking for legal moves
      Handle making checkers into Kings
      Change the color of your checkers*/
    class Program
    {
        //active game
        public static bool playing = true;
        //which players turn. True is white, black is false
        public static bool PlayerTurn = true;
        //userInput holder var
        public static string userInput = "";
        //split var
        public static char whiteSpace;
        //Seperator array
        public static string[] sepUserInput = new string[] { "", "" };
        //invalid input bool
        public static bool reTest = false;

        public static bool AskForUserSend = false;

        //Pieces
        public int White = 12;
        public int Black = 12;

        //X Y coordinates
        public static int FirstX = 0;
        public static int FirstY = 0;
        public static int SecondX = 0;
        public static int SecondY = 0;
        static void Main()
        {
            PrintBoard print = new PrintBoard();
            whiteSpace = ' ';

            do
            {
                print.printBoard();
                //Which player turn
                if (PlayerTurn)
                {
                    //white
                    Console.WriteLine("Player W Turn!");
                }
                else
                {
                    //black
                    Console.WriteLine("Player B Turn!");
                }

                //Get user input
                Console.WriteLine("Input an X and Y integer seperated by a space: ");
                sepUserInput = Console.ReadLine().Split(whiteSpace);

                //Test Input
                FirstX = TestUserInput.TestInput(sepUserInput).Item1;
                FirstY = TestUserInput.TestInput(sepUserInput).Item2;
                //Keep re-inputing until input is valid
                while (reTest)
                {
                    Console.WriteLine("Input an X and Y integer seperated by a space: ");
                    sepUserInput = Console.ReadLine().Split(whiteSpace);
                    FirstX = TestUserInput.TestInput(sepUserInput).Item1;
                    FirstY = TestUserInput.TestInput(sepUserInput).Item2;

                    //Test position
                    TestBoardPosition.TestPosition(FirstX, FirstY);
                }

                //Test position
                TestBoardPosition.TestPosition(FirstX, FirstY);

                //Valid select
                if (TestBoardPosition.TestPosition(FirstX, FirstY) == 0)
                {
                    //Ask which coordinate to move to
                    do
                    {
                        sepUserInput = Console.ReadLine().Split(whiteSpace);
                        SecondX = TestUserInput.TestInput(sepUserInput).Item1;
                        SecondY = TestUserInput.TestInput(sepUserInput).Item2;

                        Console.WriteLine("Where to?: ");
                        TestBoardPosition.TestPosition(SecondX, SecondY);
                    }
                    while (reTest);

                    if(TestBoardPosition.TestPosition(SecondX, SecondY) == 0)
                    {
                        MoveToPosition.MoveTo(FirstX, FirstY, SecondX, SecondY);
                    }
                    else
                    {
                        reTest = true;
                    }
                }
                //invalid select
                else if(TestBoardPosition.TestPosition(FirstX, FirstY) == 1)
                {
                    reTest = true;
                }

                



                //Implement Input

            }
            while (playing);
        }
    }
    public class TestUserInput
    {
        //Program program = new Program();
        public static (int, int) TestInput(string[] userInput)
        {
            int x = 0;
            int y = 0;

            //test if input is a number
            try
            {
                x = Int32.Parse(userInput[0]);
                y = Int32.Parse(userInput[1]);
                Program.reTest = false;
            }
            catch
            {
                Console.WriteLine("None valid input");
                Program.reTest = true;
            }

            return (x, y);
        }
    }
    //Testing board pos
    public class TestBoardPosition
    {
        public static string currentPiece = "";
        public static int TestPosition(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                Console.WriteLine("Invalid Row/Column");
                //Program.reTest = true;
                return 1;
            }
            //if valid input continue
            else if (Program.reTest == false)
            {

                //Check for blank space first
                if (Board.layout[x][y] == " ")
                {
                    Console.WriteLine("Blank Position");
                    //Program.reTest = true;
                    return 1;
                }
                else
                {
                    currentPiece = Board.layout[x][y];
                    Board.layout[x][y] = " ";
                    return 0;
                }
            }
            return 1;
        }
    }

    //Move to position
    public class MoveToPosition
    {
        static string holder = "";
        public static void MoveTo(int fx, int fy, int sx, int sy)
        {
            //get and set the first coordinate to blank
            holder = Board.layout[fx][fy];
            Board.layout[fx][fy] = " ";

            //put our new piece in place of the new coordinate
            Board.layout[sx][sy] = holder;
            holder = "";
        }
    }

    //put Board together
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

    //print current board
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
}