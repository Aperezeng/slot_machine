using System;

using static System.Convert;
System.Random random = new System.Random();

{
    const int LOWER_VALUE = 0;
    const int UPPER_VALUE = 2;
    const int ROWS = 3;
    const int COLUMNS = 3;
    const int WON_MIDDLE = 1;
    const int WON_HORIZONTALS = 5;
    //const int WON_VERTICALS = 10;
    const int WON_DIAGONALS = 20; 
    const string HORIZONTALS = "horizontals";
    const string VERTICALS = "verticals";
    const string DIAGONALS = "diagonals";
    const string MIDDLE_LINE = "middle";

    int[,] slotBoard = new int[ROWS, COLUMNS];

    Console.WriteLine("Hello there! Let's get started!");
    Console.WriteLine($"Here are your mode options:");
    Console.WriteLine($"single middle line: {MIDDLE_LINE}");
    Console.WriteLine($"all horizontal lines: {HORIZONTALS}");
    Console.WriteLine($"all vertical lines: {VERTICALS}");
    Console.WriteLine($"all diagonal lines: {DIAGONALS}");

    Console.WriteLine("What mode would you like?");
    string playersMode = Console.ReadLine().ToUpper().ToLower();

    Console.WriteLine("Enter your bid. Your bid:");
    int playersWager = ToInt32(Console.ReadLine());

    while (playersMode != "horizontals" && playersMode != "verticals" && playersMode != "diagonals" &&
           playersMode != "middle")
    {
        Console.WriteLine(
            $"you entered an invalid mode. Your mode must be {HORIZONTALS}, {VERTICALS}, {DIAGONALS}, or {MIDDLE_LINE}");
        Console.WriteLine("Enter your mode again");
        playersMode = Console.ReadLine();
    }

    if (playersMode == "horizontals" || playersMode == "verticals" || playersMode == "diagonals" ||
        playersMode == "middle")
    {
        Console.WriteLine("Let's get started. Best of luck to you");

        Console.WriteLine("Here we go! spinning....");

        //will populate the grid 
        for (int i = 1; i < ROWS; i++)
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
        if (playersMode == "middle")
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
                Console.WriteLine($"Congratulations! You won {WON_MIDDLE} dollar!");
            }
        }
        
        //all horizontal lines 
        if (playersMode == "horizontals")
        {
            bool eachWin = true;
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    
                    int firstSymbol = slotBoard[0, 0];
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
            if(win)
            {
                Console.WriteLine($"Congratulations! You won ${WON_HORIZONTALS} dollars!");
            }
        }
        
        //both diagonal lines 
        if (playersMode == "diagonals")
        {
            int firstSymbol = slotBoard[0, 0];
            for (int i = 0, j = 0; i < rowsCount && j < colsCount; i++, j++)
            {
                int currentSymbol = slotBoard[i, j];
                if (firstSymbol != currentSymbol)
                {
                    Console.WriteLine("loser");
                    win = false;
                    break;
                } 
            }

            int lastColIndex = colsCount - 1;
            for (int m = 0; m < rowsCount && lastColIndex >= 0; m++, lastColIndex--)
            {
                int revCurrentSymbol = slotBoard[m, lastColIndex];
                if (firstSymbol != revCurrentSymbol)
                {
                    Console.WriteLine("loser");
                    win = false; 
                    break;
                }
            }

            if (win)
            {
                Console.WriteLine($"Congratulations! You won {WON_DIAGONALS} dollars!");
            }
        }
    }
}



//check for winning line or winning combination 
//player's total money won 