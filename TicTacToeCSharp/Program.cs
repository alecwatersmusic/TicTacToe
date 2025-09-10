using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        static char[] arr = { };
        static int player = 1; // default player
        static int choice; // position user want to place
        static int flag = 0; // checks victory; 1 = win; -1 = draw
        static int size = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n------------------\n");

            // Choose game size
            Console.WriteLine("Would you like to play 3x3 or 4x4? (Enter 3 or 4): \n");
            string sizeChozen = Console.ReadLine();

            char[] threeByThree = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] fourByFour = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G'};

            if (sizeChozen == "3")
            {
                arr = threeByThree;
                size = 3;
            }
            else if (sizeChozen == "4")
            {
                arr = fourByFour;
                size = 4;
            }
            else
            {
                Console.WriteLine("Invalid input: defaulting to 3x3 game.");
                size = 3;
            }
            Console.WriteLine("Starting game...");
            Thread.Sleep(2000);
            RunGame(size);
        }

        private static void RunGame(int size)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Player 1: X | Player 2: O\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's Turn\n");
                }
                else
                {
                    Console.WriteLine("Player 1's Turn\n");
                }

                Board(size); // Creates board

                ValidateInput(); // Prompts and validates user input

                flag = CheckWin(size); // Check for win or draw
            }

            while (flag != 1 && flag != -1);
            Console.Clear();
            Board(size); // Updates board

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw!");
            }

            Console.WriteLine("Play again? (y/n): \n");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                player = 1;
                flag = 0;
                Main([]);
            }
            else
            {
                Console.WriteLine("Have a great day!");
                Thread.Sleep(2000);
            }
        }

        // Prints and updates board when called
        private static void Board(int size)
        {

            if (size == 4)
            {
                Console.WriteLine("     |     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  |  {3}", arr[1], arr[2], arr[3], arr[4]);
                Console.WriteLine("_____|_____|_____|_____ ");
                Console.WriteLine("     |     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  |  {3}", arr[5], arr[6], arr[7], arr[8]);
                Console.WriteLine("_____|_____|_____|_____ ");
                Console.WriteLine("     |     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  |  {3}", arr[9], arr[10], arr[11], arr[12]);
                Console.WriteLine("_____|_____|_____|_____ ");
                Console.WriteLine("     |     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  |  {3}", arr[13], arr[14], arr[15], arr[16]);
                Console.WriteLine("     |     |     |      ");
            }
            else
            {
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
                Console.WriteLine("     |     |      ");
            }

        }

        private static void ValidateInput()
        {
            Console.WriteLine("Choose your tile: \n");
            string choiceString = Console.ReadLine();

            // 4x4: Convert alphanumeric characters
            if (string.Equals(choiceString, "A", StringComparison.OrdinalIgnoreCase))
            {
                choice = 10;
            }
            else if (string.Equals(choiceString, "B", StringComparison.OrdinalIgnoreCase))
            {
                choice = 11;
            }
            else if (string.Equals(choiceString, "C", StringComparison.OrdinalIgnoreCase))
            {
                choice = 12;
            }
            else if (string.Equals(choiceString, "D", StringComparison.OrdinalIgnoreCase))
            {
                choice = 13;
            }
            else if (string.Equals(choiceString, "E", StringComparison.OrdinalIgnoreCase))
            {
                choice = 14;
            }
            else if (string.Equals(choiceString, "F", StringComparison.OrdinalIgnoreCase))
            {
                choice = 15;
            }
            else if (string.Equals(choiceString, "G", StringComparison.OrdinalIgnoreCase))
            {
                choice = 16;
            }
            else
            {
                try
                {
                    choice = int.Parse(choiceString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: please enter a number or letter corresponding to an unmarked tile.\n");
                    Thread.Sleep(2000);
                    return;
                }
            }
            try
            {
                if (choice < 1 || choice >= arr.Length)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid input: please choose a number between 1 and {0}\n", arr.Length - 1);
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("You chose: {0}\n", choice);
            Thread.Sleep(1000);

            //if (arr[choice] != 'X' && arr[choice] != 'O')
            if (Array.IndexOf(arr, arr[choice]) != 'X' && Array.IndexOf(arr, arr[choice]) != 'O')
            {
                if (player % 2 == 0)
                {
                    arr[choice] = 'O';
                    player++;
                }
                else
                {
                    arr[choice] = 'X';
                    player++;
                }
            }
            else
            {
                Console.WriteLine("Cannot place: row {0} already marked with {1}\n", choice, arr[choice]);
            }
        }

        // Updates flag, which checks for current game status
        private static int CheckWin(int size)
        {
            if (size == 4)
            {
                return CheckWinFourBoard();
            }
            else
            {
                // Horizontal victory
                // First row
                if (arr[1] == arr[2] && arr[2] == arr[3])
                {
                    return 1;
                }
                // Second row
                else if (arr[4] == arr[5] && arr[5] == arr[6])
                {
                    return 1;
                }
                //Winning Condition For Third Row
                else if (arr[6] == arr[7] && arr[7] == arr[8])
                {
                    return 1;
                }

                // Vertical victory
                // First column
                else if (arr[1] == arr[4] && arr[4] == arr[7])
                {
                    return 1;
                }
                // Second column
                else if (arr[2] == arr[5] && arr[5] == arr[8])
                {
                    return 1;
                }
                // Third column
                else if (arr[3] == arr[6] && arr[6] == arr[9])
                {
                    return 1;
                }

                // Diagonal victory
                else if (arr[1] == arr[5] && arr[5] == arr[9])
                {
                    return 1;
                }
                else if (arr[3] == arr[5] && arr[5] == arr[7])
                {
                    return 1;
                }

                // Draw
                else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' &&
                    arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
                {
                    return -1;
                }

                else
                {
                    return 0;
                }
            }

            
        }

        private static int CheckWinFourBoard()
        {
            // Horizontal victory
            // First row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[2] == arr[3] && arr[3] == arr[4])
            {
                return 1;
            }
            // Second row
            else if (arr[5] == arr[6] && arr[6] == arr[7])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            // Third row
            else if (arr[9] == arr[10] && arr[10] == arr[11])
            {
                return 1;
            }
            else if (arr[10] == arr[11] && arr[11] == arr[12])
            {
                return 1;
            }
            // Fourth row
            else if (arr[13] == arr[14] && arr[14] == arr[15])
            {
                return 1;
            }
            else if (arr[14] == arr[15] && arr[15] == arr[16])
            {
                return 1;
            }

            // Vertical victory
            // First column
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[5] == arr[9] && arr[9] == arr[13])
            {
                return 1;
            }
            // Second column
            else if (arr[2] == arr[6] && arr[6] == arr[10])
            {
                return 1;
            }
            else if (arr[6] == arr[10] && arr[10] == arr[14])
            {
                return 1;
            }
            // Third column
            else if (arr[3] == arr[7] && arr[7] == arr[11])
            {
                return 1;
            }
            else if (arr[7] == arr[11] && arr[11] == arr[15])
            {
                return 1;
            }
            // Fourth column
            else if (arr[4] == arr[8] && arr[8] == arr[12])
            {
                return 1;
            }
            else if (arr[8] == arr[12] && arr[12] == arr[16])
            {
                return 1;
            }

            // Diagonal victory
            // First row
            else if (arr[1] == arr[6] && arr[6] == arr[11])
            {
                return 1;
            }
            else if (arr[2] == arr[7] && arr[7] == arr[12])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            else if (arr[4] == arr[7] && arr[7] == arr[10])
            {
                return 1;
            }
            // Second row
            else if (arr[5] == arr[10] && arr[10] == arr[15])
            {
                return 1;
            }
            else if (arr[6] == arr[11] && arr[11] == arr[16])
            {
                return 1;
            }
            else if (arr[7] == arr[10] && arr[10] == arr[13])
            {
                return 1;
            }
            else if (arr[8] == arr[11] && arr[11] == arr[14])
            {
                return 1;
            }

            // Draw
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' &&
                arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' &&
                arr[9] != '9' && arr[10] != 'A' && arr[11] != 'B' && arr[12] != 'C' &&
                arr[13] != 'D' && arr[14] != 'E' && arr[15] != 'F' && arr[16] != 'G')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}