using System;
using System.Collections.Generic;

/*Your program should print the state of the board to the user
Your program should ask the user which stack do they want to move the top piece from, and to which stack do they want to move it to.
Your program should update the board
Your program should repeat steps 1,2 and 3 until the game is won.
Your program should not allow a user to make an illegal move.*/


//Things to improve
//1. Create a user input method that regulates and tests all user input validity
//2.

namespace TowersOfHanoi
{
    class Program
    {
        static int numberOfMoves = 0;

        static public bool playing = true;
        static public int[] stickA = new int[] { 4, 3, 2, 1 };
        static public int[] stickB = new int[] { 0, 0, 0, 0 };
        static public int[] stickC = new int[] { 0, 0, 0, 0 };

        static public int[] defaultStick = new int[] { 0, 0, 0, 0 };

        //Dictionary used to pair our sticks with int values for easier access
        static Dictionary<int, int[]> stickDictionary = new Dictionary<int, int[]>();


        static void Main()
        {
            string userInputPosition = "";
            int userPosition = 0;

            stickDictionary.Add(0, stickA);
            stickDictionary.Add(1, stickB);
            stickDictionary.Add(2, stickC);
            stickDictionary.Add(10, defaultStick);

            Console.WriteLine("Welcome to Towers of Hanoi");
            Console.WriteLine("Rules in ReadMe file");
            Console.WriteLine("__________________________");

            do
            {
                PrintBoard(stickA, stickB, stickC);
                Console.WriteLine("Choose a stick: (1) (2) (3)");
                userInputPosition = Console.ReadLine();
                //This is the number we grabbed from the top of the stick
                userPosition = CheckPosition(userInputPosition, stickA, stickB, stickC).Item1;
                //While stick invalid, allow user to re-input until valid
                while (userPosition == -1)
                {
                    PrintBoard(stickA, stickB, stickC);

                    userInputPosition = Console.ReadLine();
                    //This is the number we grabbed from the top of the stick
                    userPosition = CheckPosition(userInputPosition, stickA, stickB, stickC).Item1;
                }

                //Checks for desired user stick to move value
                Console.WriteLine("Ok, choose the destination of your choice");
                Console.WriteLine("_________________________________________");
                int movingStick = 0;
                string inputMovingStick = "";
                inputMovingStick = Console.ReadLine();
                movingStick = MovePosition(inputMovingStick, userPosition);

                while (movingStick == -1)
                {
                    PrintBoard(stickA, stickB, stickC);
                    Console.WriteLine("Choose valid destination");
                    inputMovingStick = Console.ReadLine();
                    movingStick = MovePosition(inputMovingStick, userPosition);
                }
                if(stickDictionary[2][0] == 4 && stickDictionary[2][1] == 3 &&
                    stickDictionary[2][2] == 2 && stickDictionary[2][3] == 1)
                {
                    playing = false;
                }
                Console.WriteLine("Number of Moves: " + numberOfMoves);
            }
            while (playing);

            PrintBoard(stickA, stickB, stickC);
            Console.WriteLine("Number of Moves: " + numberOfMoves);
            Console.WriteLine("You Win!");
            
        }

        #region Print Board
        static void PrintBoard(int[] stickA, int[] stickB, int[] stickC)
        {
            Console.WriteLine("Stick 1: " + stickA[0] + " " + stickA[1] + " " + stickA[2] + " " + stickA[3]);
            Console.WriteLine("Stick 2: " + stickB[0] + " " + stickB[1] + " " + stickB[2] + " " + stickB[3]);
            Console.WriteLine("Stick 3: " + stickC[0] + " " + stickC[1] + " " + stickC[2] + " " + stickC[3]);
        }
        #endregion

        #region Postion Affairs
        static (int, int) CheckPosition(string userInput, int[] stickA, int[] stickB, int[] stickC)
        {
            int stickTopNumber = 0;
            int stick = 0;
            //If assigning userInput from string to int is feasible
            try
            {
                //if the following line of code can execute than no problem
                stick = Convert.ToInt32(userInput);
                //This is if the user inputs nothing and presses enter
                if (userInput == "")
                {
                    Console.WriteLine("Invalid Input");
                    return (-1, 0);
                    stick = 0;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                stick = 0;
            }
            //If user int is a possible choice reassign to index value
            switch (stick)
            {
                case 1:
                    stick = 0;
                    break;

                case 2:
                    stick = 1;
                    break;

                case 3:
                    stick = 2;
                    break;

                default:
                    stick = 10;
                    Console.WriteLine("Invalid Input");
                    break;
            }

            //Check if our number is equal to our sticks

            //Check if stick is empty
            if (stickDictionary[stick][0] == 0)
            {
                Console.WriteLine("Empty Stick");
                Console.WriteLine("Choose valid Stick");
                Console.WriteLine("___________________");
                return (-1, 0);
            }

            //Loops through stick(s) and determines if it is empty
            //if the stick is not empty grab the top valued index
            else
            {
                //***Loop through the selected stick and sto the top value
                for (int i = 3; i >= 0; i--)
                {
                    //Loops through current stick arr identifying it has something
                    if (stickDictionary[stick][i] != 0)
                    {
                        //Loop through again to get the top of the stick
                        for (int j = 0; j <= 3; j++)
                        {
                            //Console.WriteLine("DEBUG 1: " + "Top Number " + stickTopNumber);
                            //loops until local var finds an empty and take the prior value
                            if (stickDictionary[stick][j] == 0)
                            {
                                stickTopNumber = stickDictionary[stick][i];
                                stickDictionary[stick][i] = 0;
                                //Console.WriteLine("DEBUG 2: " + "Top Number " + stickTopNumber);
                                break;
                            }
                            //else just take the last index of the stick
                            else
                            {
                                stickTopNumber = stickDictionary[stick][i];
                               // Console.WriteLine("DEBUG 3: " + "Top Number " + stickTopNumber);
                                stickDictionary[stick][i] = 0;
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            //Console.WriteLine("DEBUG 4: " + "Top Number " + stickTopNumber);
            return (stickTopNumber, stick);
        }

        /*MovePosition() is in charge of checking the users
         desired stick change, in which it is [EMPTY, FULL, SAME STICK]
         We will than assign our picked stick index from the  prior method
        and assign accordingly*/

        //userInput is the desired location for the userPosition. The userPosition is the top stick number we just grabbed
        static int MovePosition(string userInput, int userPosition)
        {
            //Test our user input and return -1 if the input is invalid
            int currentRow = 0;
            //If we can get throught the try catch, that means the input is valid
            try
            {
                //if the following line of code can execute than no problem
                currentRow = Convert.ToInt32(userInput);
                //This is if the user inputs nothing and presses enter
                if (userInput == "")
                {
                    Console.WriteLine("Invalid Input");
                    currentRow = 0;
                    return -1;
                }
                else if (currentRow == 1 || currentRow == 2 || currentRow == 3)
                {
                    //Console.WriteLine("Valid Input");
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    currentRow = 0;
                    return -1;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                currentRow = 0;
                return -1;
            }

            //If user int is a possible choice reassign to index value
            switch (currentRow)
            {
                case 1:
                    currentRow = 0;
                    break;

                case 2:
                    currentRow = 1;
                    break;

                case 3:
                    currentRow = 2;
                    break;

                default:
                    currentRow = 10;
                    Console.WriteLine("Invalid Input");
                    break;
            }

            //Take our prior destination index out and replace with 0
            //Put our index in our new destination if the destination is clear

            //Check if the destination is clear by 
            //checking if the top/ top most index is 0
            for (int i = 0; i <= 3; i++)
            {
                //if our currently selected row has room, check if prior number is
                //bigger to allow to be stacked on, if all row is 0 than add to 0 index
                //stick empty
                if (stickDictionary[currentRow][0] == 0)
                {
                    stickDictionary[currentRow][0] = userPosition;
                    numberOfMoves += 1;
                    return 1;
                }
                //stick full
                else if(stickDictionary[currentRow][3] != 0)
                {
                    Console.WriteLine("Stick Full");
                    return -1;
                }

                else if(stickDictionary[currentRow][i] == 0)
                {
                    if(userPosition <= stickDictionary[currentRow][i -1])
                    {
                        stickDictionary[currentRow][i] = userPosition;
                        numberOfMoves += 1;
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Prior number in destination is smaller than current selection");
                        return -1;
                    }   
                }
            }
            return -1;
        }
        #endregion
    }
}
