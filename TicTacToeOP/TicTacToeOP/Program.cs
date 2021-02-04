using System;

namespace TicTacToeOP
{
    class Program
    {


        public static string playerOne = "X";
        public static string playerTwo = "O";
        public static string currentPlayer = "X";

        public static bool gameActive = true;

        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };

        public static void Main()
        {
            do
            {
                CheckForWin();
                DrawBoard();
                Console.WriteLine("______________________");

                GetInput();
            } 
            while (gameActive);

            if(gameActive == false)
            {
                DrawBoard();
                //CheckForWin();
            }
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + currentPlayer);
            Console.WriteLine("Enter Row:");

            int row = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());

            if(row < 3 && column < 3)
            {
                PlaceMark(row, column);
            }
            else
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Non-valid position");
                Console.WriteLine("______________________");
            }
            
        }

        public static void PlaceMark(int row, int column)
        {
            CheckForWin();
            //Console.WriteLine("You typed: " + row + " " + column);
            bool goodToGo = CheckForPosition(row, column);

            if (goodToGo)
            {
                board[row][column] = currentPlayer;
                //isPlayerTurn = false
                if(currentPlayer == playerOne)
                {
                    currentPlayer = playerTwo;
                }
                else
                {
                    currentPlayer = playerOne;
                }
            }
            else
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Non-valid position");
                Console.WriteLine("______________________");
            }
        }

        public static bool CheckForPosition(int row, int column)
        {
            //checks the position of player placement
            if(board[row][column] != "X" && board[row][column] != "O")
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        public static void CheckForWin()
        {
            bool horX = HorizontalWinX();
            bool horO = HorizontalWinO();

            bool verX = VerticalWinX();
            bool verO = VerticalWinO();

            bool diaX = DiagonalWinX();
            bool diaO = DiagonalWinO();

            bool tie = CheckForTie();

            if(horX || verX || diaX)
            {
                Console.WriteLine("______________________");
                Console.WriteLine("X Wins");
                Console.WriteLine("______________________");
                gameActive = false;
            }

            if(horO || verO || diaO)
            {
                Console.WriteLine("______________________");
                Console.WriteLine("O Wins");
                Console.WriteLine("______________________");
                gameActive = false;
            }

            if(tie == true)
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Tie");
                Console.WriteLine("______________________");
                gameActive = false;
            }
        }
        public static bool CheckForTie()
        {
            if (board[0][0] != " " ^ board[0][0] != " " &&
                board[0][1] != " " ^ board[0][1] != " " &&
                board[0][2] != " " ^ board[0][2] != " " &&
                board[1][0] != " " ^ board[1][0] != " " &&
                board[1][1] != " " ^ board[1][1] != " " &&
                board[1][2] != " " ^ board[1][2] != " " &&
                board[2][0] != " " ^ board[2][0] != " " &&
                board[2][1] != " " ^ board[2][1] != " " &&
                board[2][2] != " " ^ board[2][2] != " ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HorizontalWinX()
        {
            //Top win
            if (board[0][0] == "X" && board[0][1] == "X" && board[0][2] == "X")
            {
                return true;
            }
            //Middle win
            else if (board[1][0] == "X" && board[1][1] == "X" && board[1][2] == "X")
            {
                return true;
            }
            //Bottom win
            else if (board[2][0] == "X" && board[2][1] == "X" && board[2][2] == "X")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool HorizontalWinO()
        {
            //Top win
            if (board[0][0] == "O" && board[0][1] == "O" && board[0][2] == "O")
            {
                return true;
            }
            //Middle win
            else if (board[1][0] == "O" && board[1][1] == "O" && board[1][2] == "O")
            {
                return true;
            }
            //Bottom win
            else if (board[2][0] == "O" && board[2][1] == "O" && board[2][2] == "O")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerticalWinX()
        {
            //Left vertical win
            if (board[0][0] == "X" && board[1][0] == "X" && board[2][0] == "X")
            {
                return true;
            }
            //Middle vertical win
            else if (board[0][1] == "X" && board[1][1] == "X" && board[2][1] == "X")
            {
                return true;
            }
            //Right vertical win
            else if (board[0][2] == "X" && board[1][2] == "X" && board[2][2] == "X")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool VerticalWinO()
        {
            //Left vertical win
            if (board[0][0] == "O" && board[1][0] == "O" && board[2][0] == "O")
            {
                return true;
            }

            //Middle vertical win
            if (board[0][1] == "O" && board[1][1] == "O" && board[2][1] == "O")
            {
                return true;
            }

            //Right vertical win
            if (board[0][2] == "O" && board[1][2] == "O" && board[2][2] == "O")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DiagonalWinX()
        {
            //Left to right win
            if (board[0][0] == "X" && board[1][1] == "X" && board[2][2] == "X")
            {
                return true;
            }
            //Right to left win
            if (board[0][2] == "X" && board[1][1] == "X" && board[2][0] == "X")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DiagonalWinO()
        {
            //Left to right win
            if (board[0][0] == "O" && board[1][1] == "O" && board[2][2] == "O")
            {
                return true;
            }

            //Right to left win
            if (board[0][2] == "O" && board[1][1] == "O" && board[2][0] == "O")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}
