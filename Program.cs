using System;

using static System.Convert;
System.Random random = new System.Random();

{
    const int LOWER_VALUE = 0;
    const int UPPER_VALUE = 2;
    const int ROWS = 3;
    const int COLUMNS = 3;
    const int WON_MIDDLE = 1;
    //const int WON_VERTICALS = 3;
    //const int WON_HORIZONTALS = 5;
    //const int WON_VERTICALS = 10;
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

    while (playersMode != "horizontals" && playersMode != "verticals" && playersMode != "diagonals" && playersMode != "middle")
    {
        Console.WriteLine($"you entered an invalid mode. Your mode must be {HORIZONTALS}, {VERTICALS}, {DIAGONALS}, or {MIDDLE_LINE}");
        Console.WriteLine("Enter your mode again");
        playersMode = Console.ReadLine();
    }

    if (playersMode == "horizontals" ||  playersMode == "verticals" || playersMode == "diagonals" || playersMode == "middle")
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
                        Console.WriteLine("you lost! not all symbols matched");
                        return;
                    }
                }
                Console.WriteLine($"you won! all symbols matched. you won ${WON_MIDDLE} dollar");
            }
            
            if(playersMode == "horizontals")
            {
                
            }
        }
    }


//check for winning line or winning combination 
//player's total money won 