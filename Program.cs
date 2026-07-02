using System.ComponentModel.Design;
using static System.Convert;
System.Random random = new System.Random();

Console.WriteLine("Hello there! Let's get started!");
{
    const int LOWER_VALUE = 0;
    const int UPPER_VALUE = 2;
    const int ROWS = 3;
    const int COLUMNS = 3;
    const string HORIZONTALS = "horizontals";
    const string VERTICALS = "verticals";
    const string DIAGONALS = "diagonals";
    const string MIDDLE_LINE = "middle";
    const int WON_MIDDLE_LINE = 5; 
    const int WON_HORIZONTALS = 10;
    const int WON_VERTICALS = 15;
    const int WON_DIAGONALS = 20;

    bool playing = true;
    int losses = 0;
    int jackpot = 0;
    int totalBalance = 0; 

    while (playing)
    {
        int[,] slotBoard = new int[ROWS, COLUMNS];

        Console.WriteLine("Here are your mode options:");
        Console.WriteLine($"single middle line: {MIDDLE_LINE}");
        Console.WriteLine($"all horizontal lines: {HORIZONTALS}");
        Console.WriteLine($"all vertical lines: {VERTICALS}");
        Console.WriteLine($"all diagonal lines: {DIAGONALS}");

        Console.WriteLine("Enter your bid:");
        string validWager = Console.ReadLine();
        int playerWager;
        while (!int.TryParse(validWager, out playerWager) || playerWager < 0)
        {
            Console.WriteLine("You entered an invalid input. Must enter a positive number");
            Console.WriteLine("Enter your bid again");
            validWager = Console.ReadLine();
        }

        totalBalance += playerWager; 
        Console.WriteLine($"your current balance is {totalBalance}");

        Console.WriteLine("What mode would you like?");
        string playersMode = Console.ReadLine().ToLower();

        while (playersMode != HORIZONTALS && playersMode != VERTICALS && playersMode != DIAGONALS &&
               playersMode != MIDDLE_LINE)
        {
            Console.WriteLine($"you entered an invalid mode. Your mode must be {HORIZONTALS}, {VERTICALS}, {DIAGONALS}, or {MIDDLE_LINE}");
            Console.WriteLine("Enter your mode again");
            playersMode = Console.ReadLine().ToLower();
        }

        if (playersMode == HORIZONTALS || playersMode == VERTICALS || playersMode == DIAGONALS ||
            playersMode == MIDDLE_LINE)
        {
            Console.WriteLine("Let's get started. Best of luck to you");

            Console.WriteLine("Here we go! spinning....");

            //will populate the grid 
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    int spinningWheel = random.Next(LOWER_VALUE, UPPER_VALUE);
                    slotBoard[i, j] = spinningWheel;
                }
            }

            int rowsCount = slotBoard.GetLength(0);
            int colsCount = slotBoard.GetLength(1);

            //will go through each cell and show the index and its value
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write($"[{i},{j}]: {slotBoard[i, j]} \t");
                }
                Console.WriteLine();
            }

            bool win = true;
            
            //middle line only 
            if (playersMode == MIDDLE_LINE)
            {
                int middleLine = rowsCount / 2;
                for (int j = 0; j < colsCount; j++)
                {
                    int firstSymbol = slotBoard[middleLine, 0];
                    int currentSymbol = slotBoard[middleLine, j];
                    if (firstSymbol != currentSymbol)
                    {
                        win = false;
                        Console.WriteLine("Sorry, you lost! Better luck next time.");
                        break;
                    }
                }

                if (win)
                {
                    Console.WriteLine($"Congratulations! You won {WON_MIDDLE_LINE} points!");
                    jackpot = WON_MIDDLE_LINE;
                }
            }

            //all horizontal lines 
            if (playersMode == HORIZONTALS)
            {
                bool eachWin = true;
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        int firstSymbol = slotBoard[i, 0];
                        int currentSymbol = slotBoard[i, j];
                        if (firstSymbol != currentSymbol)
                        {
                            eachWin = false;
                            Console.WriteLine("Sorry, you lost! Better luck next time.");
                            break;
                        }
                    }

                    //will check for loses. If there are any lose then there won't be any overall win. 
                    if (!eachWin)
                    {
                        win = false;
                        break;
                    }
                }

                //all horizontal lines win
                if (win)
                {
                    Console.WriteLine($"Congratulations! You won {WON_HORIZONTALS} points!");
                    jackpot = WON_HORIZONTALS;
                }
            }

            //all vertical lines 
            if (playersMode == VERTICALS)
            {
                bool eachWin = true;
                for (int j = 0; j < colsCount; j++)
                {
                    for (int i = 0; i < rowsCount; i++)
                    {
                        int firstSymbol = slotBoard[0, j];
                        int currentSymbol = slotBoard[i, j];
                        if (firstSymbol != currentSymbol)
                        {
                            eachWin = false;
                            Console.WriteLine("Sorry, you lost! Better luck next time.");
                            break;
                        }
                    }

                    if (!eachWin)
                    {
                        win = false;
                        break;
                    }
                }

                if (win)
                {
                    Console.WriteLine($"Congratulations! You won {WON_VERTICALS} points!");
                    jackpot = WON_VERTICALS;
                }
            }

            //both diagonal lines 
            if (playersMode == DIAGONALS)
            {
                int firstSymbol = slotBoard[0, 0];
                for (int i = 0, j = 0; i < rowsCount && j < colsCount; i++, j++)
                {
                    int currentSymbol = slotBoard[i, j];
                    if (firstSymbol != currentSymbol)
                    {
                        win = false;
                        break;
                    }
                }
                
                int lastColIndex = colsCount - 1;
                int lastSymbol = slotBoard[0, lastColIndex];
                for (int m = 0; m < rowsCount && lastColIndex >= 0; m++, lastColIndex--)
                {
                    int revCurrentSymbol = slotBoard[m, lastColIndex];
                    if (lastSymbol != revCurrentSymbol)
                    {
                        win = false;
                        break;
                    }
                }

                //win on both diagonals
                if (win)
                {
                    jackpot = WON_DIAGONALS;
                }
            }
            
            if (!win)
            {
                totalBalance -= playerWager;
                Console.WriteLine($"You lost {playerWager} points");
            }
            else if (win)
            {
                totalBalance += jackpot;
                Console.WriteLine($"You won {jackpot} points");
            }
            
            Console.WriteLine($"Your current balance is {totalBalance}");
            
            Console.WriteLine("Would you like to continue playing? Enter yes or no");

            string Continue = Console.ReadLine().ToLower();

            if (Continue == "no")
            {
                Console.WriteLine("Thanks for playing! See you next time.");
                break;
            }

            if (Continue == "yes")
            {
                Console.WriteLine("Great! Here we go again :)");
            }
        }
    }
}




